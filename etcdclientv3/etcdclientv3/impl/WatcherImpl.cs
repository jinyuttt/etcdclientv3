using etcdclientv3.data;
using etcdclientv3.IEtcdClient;
using etcdclientv3.options;
using etcdclientv3.watch;
using System;
using System.Collections.Generic;
using static Etcdserverpb.Watch;

namespace etcdclientv3.impl
{
    partial class WatchImpl
    {
        /**
         * Watcher class holds watcher information.
         */
        public class WatcherImpl : IWatcher
        {
            private readonly WatchOption watchOption;
            private readonly ByteSequence key;
            private WatchClient watchClient = null;
            // watch events buffer.
           // private ConcurrentQueue<WatchResponseWithError> eventsQueue = new ConcurrentQueue<WatchResponseWithError>();
            private long watchID;
            // the revision to watch on.
            private long revision;
            private volatile bool closed = false;
            private Grpc.Core.AsyncDuplexStreamingCall<Etcdserverpb.WatchRequest, Etcdserverpb.WatchResponse> stream;
            private readonly WatchImpl owner;

            public WatcherImpl(ByteSequence key, WatchOption watchOption, WatchImpl owner)
            {
                this.key = key;
                this.watchOption = watchOption;
                this.revision = watchOption.Revision;
                this.owner = owner;
                this.watchClient = owner.watchClient;
            }

            public long Revision
            {
                get { return revision; }
                set { revision = value; }
            }

            public bool IsClosed
            {
                get { return closed; }
                set { closed = value; }
            }

            public long WatchID
            {
                get { return watchID; }
                set { watchID = value; }

            }

            public WatchOption GetWatchOption()
            {
                return watchOption;
            }

            public ByteSequence GetKey()
            {
                return key;
            }

            public void Resume()
            {
                if (closed)
                {
                    return;
                }

                if (stream == null)
                {
                    // id is not really useful today but it may be in etcd 3.4
                    watchID = -1;
                    Etcdserverpb.WatchCreateRequest createRequest = new Etcdserverpb.WatchCreateRequest
                    {
                        Key = key.GetByteString(),
                        PrevKv = watchOption.IsPrevKV,
                        ProgressNotify = watchOption.IsProgressNotify,
                        RangeEnd = watchOption.EndKey.GetByteString(),
                        StartRevision = watchOption.Revision
                    };
                    if (watchOption.EndKey.IsPresent)
                    {
                        createRequest.RangeEnd = watchOption.EndKey.GetByteString();
                    }
                    if (watchOption.IsNoDelete)
                    {
                        createRequest.Filters.Add(Etcdserverpb.WatchCreateRequest.Types.FilterType.Nodelete);

                    }
                    if (watchOption.IsNoPut)
                    {
                        createRequest.Filters.Add(Etcdserverpb.WatchCreateRequest.Types.FilterType.Noput);

                    }
                    Grpc.Core.CallOptions callOptions = new Grpc.Core.CallOptions();
                    Etcdserverpb.WatchRequest request = new Etcdserverpb.WatchRequest
                    {
                        CreateRequest = createRequest
                    };
                    var rsp = watchClient.Watch(callOptions);
                    rsp.RequestStream.WriteAsync(request);
                    stream = rsp;
                    this.watchID = rsp.ResponseStream.Current.WatchId;
                    
                }
            }

            public void Close()
            {
                if (closed)
                {
                    return;
                }
                stream.RequestStream.CompleteAsync();
                closed = true;
                watchID = -1;

            }

            public void OnNext(Etcdserverpb.WatchResponse response)
            {
                if (response.Created)
                {

                    //
                    // Created
                    //

                    if (response.WatchId == -1)
                    {
                        // listener.onError(newEtcdException(ErrorCode.INTERNAL, "etcd server failed to create watch id"));
                        return;
                    }

                    revision = response.Header.Revision;
                    watchID = response.WatchId;
                }
                else if (response.Canceled)
                {

                    //
                    // Cancelled
                    //

                    string reason = response.CancelReason;
                    // Throwable error;

                    if (response.CompactRevision != 0)
                    {
                        //error = new CompactedException(response.CompactRevision);
                    }
                    else if (string.IsNullOrEmpty(reason))
                    {
                        //error = newEtcdException(
                        //  ErrorCode.OUT_OF_RANGE,
                        //  "etcdserver: mvcc: required revision is a future revision"
                        //);
                    }
                    else
                    {
                        //error = newEtcdException(
                        //  ErrorCode.FAILED_PRECONDITION,
                        //  reason
                        //);
                    }

                    // listener.onError(error);
                }
                else if (response.Events.Count == 0 && watchOption.IsProgressNotify)
                {

                    //
                    // Event
                    //
                    // A response may not contain events, this is in case of "Progress_Notify":
                    //
                    //   the watch will periodically receive a  WatchResponse with no events, 
                    //   if there are no recent events. It is useful when clients wish to 
                    //   recover a disconnected watcher starting from a recent known revision.
                    //
                    //   The etcd server decides how often to send notifications based on current 
                    //   server load.
                    //
                    // For more info:
                    //   https://coreos.com/etcd/docs/latest/learning/api.html#watch-streams
                    //
                    // listener.onNext(new io.etcd.jetcd.watch.WatchResponse(response));
                    revision = response.Header.Revision;
                }
                else if (response.Events.Count > 0)
                {
                    // listener.onNext(new io.etcd.jetcd.watch.WatchResponse(response));
                    revision = response.Events[response.Events.Count - 1].Kv.ModRevision + 1;
                }
            }

            public WatchResponse Listen()
            {
                if (closed)
                {
                    throw new ClosedWatcherException();
                }
                try
                {
                    return this.CreateWatchResponseFuture();
                }
                catch (Exception e)
                {

                    if (closed)
                    {
                        throw new ClosedWatcherException();
                    }


                }
                return null;
            }

            private WatchResponse CreateWatchResponseFuture()
            {

                WatchResponse watchResponse = null;
                return watchResponse = new WatchResponse(stream.ResponseStream.Current);

            }

            public List<WatchEvent> ReadAll()
            {
                List<WatchEvent> list = new List<WatchEvent>();
                var watchResponse = new WatchResponse(stream.ResponseStream.Current);
                list.AddRange(watchResponse.GetEvents());
                this.OnNext(stream.ResponseStream.Current);
                while (true)
                {
                    var task = stream.ResponseStream.MoveNext();
                    if(task.Result)
                    {
                        watchResponse = new WatchResponse(stream.ResponseStream.Current);
                        list.AddRange(watchResponse.GetEvents());
                        this.OnNext(stream.ResponseStream.Current);
                    }
                    else
                    {
                        break;
                    }
                }
                return list;
            }

            public List<WatchEvent> GetLastEvent()
            {
                List<WatchEvent> list = new List<WatchEvent>();
                var watchResponse = new WatchResponse(stream.ResponseStream.Current);
                var cur = watchResponse.GetEvents();
                if (cur.Count > 0)
                {
                    list.Add(cur[cur.Count-1]);
                    this.OnNext(stream.ResponseStream.Current);
                }
                while (true)
                {
                    var task = stream.ResponseStream.MoveNext();
                    if (task.Result)
                    {
                        watchResponse = new WatchResponse(stream.ResponseStream.Current);
                        cur = watchResponse.GetEvents();
                        if (cur.Count > 0)
                        {
                            list.Add(cur[cur.Count - 1]);
                            this.OnNext(stream.ResponseStream.Current);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                return list;
            }
        }
    }
}

