using etcdclientv3.data;
using etcdclientv3.IEtcdClient;
using etcdclientv3.options;
using etcdclientv3.watch;
using Google.Protobuf;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using static Etcdserverpb.Watch;

namespace etcdclientv3.impl
{
    class WatchImpl : IWatch {

        // watchers stores a mapping between leaseID -> WatchIml.
      private ConcurrentDictionary<long, WatcherImpl> watchers = new ConcurrentDictionary<long, WatcherImpl>();
      private ConcurrentQueue<WatcherImpl> pendingWatchers = new ConcurrentQueue<WatcherImpl>();
       private ISet<long> cancelSet = new HashSet<long>();
        private ClientConnectionManager connectionManager;
        private ManagedChannel managedChannel;

        // private volatile StreamObserver<WatchRequest> grpcWatchStreamObserver;
        private bool closed = false;
        private WatchClient watchClient = null;

        WatchImpl(ClientConnectionManager connectionManager) {
            this.connectionManager = connectionManager;
            managedChannel = connectionManager.NewChannel();
            watchClient = new WatchClient(managedChannel.channel);
        }

        private bool IsClosed() {
            return this.closed;
        }

        private void SetClosed() {
            this.closed = true;
        }


        public IWatcher Watch(ByteSequence key) {
            return this.Watch(key, WatchOption.DEFAULT);
        }


        public IWatcher Watch(ByteSequence key, WatchOption watchOption) {
            if (IsClosed()) {
                throw new ClosedWatchClientException();
            }
            WatcherImpl watcher = new WatcherImpl(key, watchOption, this);
           // this.pendingWatchers.Enqueue(watcher);

            Etcdserverpb.WatchRequest request = new Etcdserverpb.WatchRequest();
            Etcdserverpb.WatchCreateRequest  createRequest = new Etcdserverpb.WatchCreateRequest();
            createRequest.Key = key.GetByteString();
            createRequest.PrevKv = watchOption.isPrevKV();
            createRequest.ProgressNotify = watchOption.isProgressNotify();
            createRequest.RangeEnd = watchOption.getEndKey().GetByteString();
            createRequest.StartRevision = watchOption.getRevision();
            request.CreateRequest = createRequest;
            Grpc.Core.CallOptions callOptions = new Grpc.Core.CallOptions();
            watchClient.Watch(callOptions);
           // watchClient.Watch()
           // watchClient.Watch()

            //  if (this.pendingWatchers.Count == 1) {
            // head of the queue send watchCreate request.
            //  WatchRequest request = this.toWatchCreateRequest(watcher);
            // this.getGrpcWatchStreamObserver().onNext(request);
            // }

            return watcher;
        }


        public void close() {
            lock (this)
            {
                if (IsClosed())
                {
                    return;
                }
            }
            this.SetClosed();
            //  this.notifyWatchers(newClosedWatchClientException());
            // this.closeGrpcWatchStreamObserver();
            //  this.executor.shutdownNow();
            //  this.scheduledExecutorService.shutdownNow();
        }

        // notifies all watchers about a exception. it doesn't close watchers.
        // it is the responsibility of user to close watchers.
        private void notifyWatchers(EtcdException e) {
            WatchResponseWithError wre = new WatchResponseWithError(e);
            if (!this.pendingWatchers.IsEmpty)
            {
                while (!this.pendingWatchers.IsEmpty)
                {
                    // this.pendingWatchers.try
                }
            }
            //this.pendingWatchers.forEach(watcher -> {
            //  try {
            //    watcher.enqueue(wre);
            //  } catch (Exception we) {
            //    LOG.warn("failed to notify watcher", we);
            //  }
            //});
            //this.pendingWatchers.clear();
            //this.watchers.values().forEach(watcher -> {
            //  try {
            //    watcher.enqueue(wre);
            //  } catch (Exception we) {
            //    LOG.warn("failed to notify watcher", we);
            //  }
            //});
            this.watchers.Clear();
        }

        private void CancelWatcher(long id) {
            lock (this)
            {
                if (this.IsClosed())
                {
                    return;
                }

                if (this.cancelSet.Contains(id))
                {
                    return;
                }
                WatcherImpl W;
                this.watchers.TryRemove(id, out W);
                this.cancelSet.Add(id);

                Etcdserverpb.WatchCancelRequest watchCancelRequest = new Etcdserverpb.WatchCancelRequest();
                watchCancelRequest.WatchId = id;
                Etcdserverpb.WatchRequest request = new Etcdserverpb.WatchRequest();
                request.CancelRequest = watchCancelRequest;
                //this.getGrpcWatchStreamObserver().onNext(cancelRequest);

            }
        }

        //private  StreamObserver<WatchRequest> getGrpcWatchStreamObserver() {
        //          lock (this)
        //          {
        //              if (this.grpcWatchStreamObserver == null)
        //              {
        //                  this.grpcWatchStreamObserver = this.stub.Watch(this.createWatchStreamObserver());
        //              }
        //          }
        //  return this.grpcWatchStreamObserver;
        //}

        //private StreamObserver<WatchResponse>CreateWatchStreamObserver() {
        //        return  StreamObserver<WatchResponse>();
        //}

        private void processWatchResponse(WatchResponse watchResponse) {
            // prevents grpc on sending watchResponse to a closed watch client.
            //if (this.isClosed()) {
            //  return;
            //}

            //if (watchResponse.getCreated()) {
            //  processCreate(watchResponse);
            //} else if (watchResponse.getCanceled()) {
            //  processCanceled(watchResponse);
            //} else {
            //  processEvents(watchResponse);
            //}
      //  }
        // resume with a delay; avoiding immediate retry on a long connection downtime.
        //Util.addOnFailureLoggingCallback(scheduledExecutorService.schedule(this::resume, 500, TimeUnit.MILLISECONDS),
        //   LOG, "scheduled resume failed");
    }

  private  void Resume() {
        lock (this)
        {
            //this.closeGrpcWatchStreamObserver();
           // this.cancelSet.clear();
           // this.resumeWatchers();
        }
  }

  // closeGrpcWatchStreamObserver closes the underlying grpc watch stream.
  private void closeGrpcWatchStreamObserver() {
    //if (this.grpcWatchStreamObserver == null) {
    //  return;
    //}
    //this.grpcWatchStreamObserver.onCompleted();
    //this.grpcWatchStreamObserver = null;
  }

  private static bool IsNoLeaderError(Grpc.Core.Status status) {
    return status.StatusCode == Grpc.Core.StatusCode.Unavailable
        && "etcdserver: no leader".Equals(status.Detail);
  }

  private static bool isHaltError(Grpc.Core.Status status) {
    // Unavailable codes mean the system will be right back.
    // (e.g., can't connect, lost leader)
    // Treat Internal codes as if something failed, leaving the
    // system in an inconsistent state, but retrying could make progress.
    // (e.g., failed in middle of send, corrupted frame)
    return status.StatusCode != Grpc.Core.StatusCode.Unavailable && status.StatusCode != Grpc.Core.StatusCode.Internal;
  }

  private void ProcessCreate(WatchResponse response) {
            WatcherImpl watcher = null;
                this.pendingWatchers.TryDequeue(out watcher);

    this.SendNextWatchCreateRequest();

    if (watcher == null) {
      // shouldn't happen
      // may happen due to duplicate watch create responses.
     // LOG.warn("Watch client receives watch create response but find no corresponding watcher");
      return;
    }

    if (watcher.IsClosed()) {
      return;
    }

    if (response.GetWatchId() == -1) {
      watcher.Enqueue(new WatchResponseWithError(
          new EtcdException(ErrorCode.INTERNAL, "etcd server failed to create watch id")));
      return;
    }

    if (watcher.GetRevision() == 0) {
      watcher.SetRevision(response.GetHeader().GetRevision());
    }

    watcher.SetWatchID(response.GetWatchId());
            this.watchers[watcher.GetWatchID()] = watcher;
  }

  /**
   * chooses the next resuming watcher to register with the grpc stream.
   */
  private Etcdserverpb.WatchRequest NextResume() {
            //        WatcherImpl pendingWatcher = null;
            //        this.pendingWatchers.TryDequeue(out pendingWatcher);
            //if (pendingWatcher != null) {
            //  return options.of(this.toWatchCreateRequest(pendingWatcher));
            //}
            //return Optional.empty();
            return null;
  }

  private void SendNextWatchCreateRequest() {
    //this.NextResume().ifPresent(
       // nextWatchRequest -> this.getGrpcWatchStreamObserver().onNext(nextWatchRequest));
  }

  private void ProcessEvents(WatchResponse response) {
            WatcherImpl watcher = null;
            this.watchers.TryGetValue(response.GetWatchId(),out watcher);
    if (watcher == null) {
      // cancel server side watcher.
      this.CancelWatcher(response.GetWatchId());
      return;
    }

    if (response.GetCompactRevision() != 0) {
      watcher.Enqueue(new WatchResponseWithError(
         new EtcdException(response.GetCompactRevision())));
      return;
    }

    if (response.GetEventsCount() == 0) {
      watcher.SetRevision(response.GetHeader().GetRevision());
      return;
    }
    watcher.Enqueue(new WatchResponseWithError(response));
    //watcher.SetRevision(
    //    response.GetEvents(response.GetEventsCount() - 1)
    //        .GetKv().getModRevision() + 1);
  }

  private void ResumeWatchers() {
    //this.watchers.values().forEach(watcher -> {
    //  if (watcher.isClosed()) {
    //    return;
    //  }
    //  watcher.setWatchID(-1);
    //  this.pendingWatchers.add(watcher);
    //});

    //this.watchers.clear();

    //this.sendNextWatchCreateRequest();
  }

  private void ProcessCanceled(WatchResponse response) {
            WatcherImpl watcher = null;
      this.watchers.TryGetValue(response.GetWatchId(),out watcher);
    this.cancelSet.Remove(response.GetWatchId());
    if (watcher == null) {
      return;
    }
    string reason = response.GetCancelReason();
    if (string.IsNullOrEmpty(reason))
            {
      watcher.Enqueue(new WatchResponseWithError(new EtcdException(
          ErrorCode.OUT_OF_RANGE,
          "etcdserver: mvcc: required revision is a future revision"))
      );

    } else {
      watcher.Enqueue(
          new WatchResponseWithError(new EtcdException(ErrorCode.FAILED_PRECONDITION, reason)));
    }
  }

  private static Etcdserverpb.WatchRequest ToWatchCreateRequest(WatcherImpl watcher) {
            ByteString key = watcher.GetKey().GetByteString();
    WatchOption option = watcher.GetWatchOption();
            Etcdserverpb.WatchCreateRequest watchCreate = new Etcdserverpb.WatchCreateRequest();
            watchCreate.Key = key;
            watchCreate.PrevKv = option.isPrevKV();
            watchCreate.ProgressNotify=option.isProgressNotify();
            watchCreate.StartRevision = watcher.GetRevision();
            watchCreate.RangeEnd = option.getEndKey().GetByteString();
    if (option.isNoDelete()) {
  watchCreate.Filters.Add(Etcdserverpb.WatchCreateRequest.Types.FilterType.Nodelete);
    }

    if (option.isNoPut()) {

                watchCreate.Filters.Add(Etcdserverpb.WatchCreateRequest.Types.FilterType.Noput);
            }
            Etcdserverpb.WatchRequest request = new Etcdserverpb.WatchRequest();
            request.CreateRequest = watchCreate;
            return request;
  }

  /**
   * Watcher class holds watcher information.
   */
  public  class WatcherImpl   : IWatcher {

     
    private   WatchOption watchOption;
    private   ByteSequence key;
    private   Object closedLock = new Object();
    // watch events buffer.
    private   ConcurrentQueue<WatchResponseWithError> eventsQueue = new ConcurrentQueue<WatchResponseWithError>();
    private long watchID;
    // the revision to watch on.
    private long revision;
    private bool closed = false;
    private   WatchImpl owner;

    public WatcherImpl(ByteSequence key, WatchOption watchOption, WatchImpl owner) {
      this.key = key;
      this.watchOption = watchOption;
      this.revision = watchOption.getRevision();
      this.owner = owner;
    }

    public long GetRevision() {
      return this.revision;
    }

    public void SetRevision(long revision) {
      this.revision = revision;
    }

    public bool IsClosed() {
      lock (this.closedLock) {
        return closed;
      }
    }

            public void SetClosed() {
            lock (this.closedLock) {
        this.closed = true;
      }
    }

            public long GetWatchID() {
      return watchID;
    }

            public void SetWatchID(long watchID) {
      this.watchID = watchID;
    }

    public WatchOption GetWatchOption() {
      return watchOption;
    }

    public ByteSequence GetKey() {
      return key;
    }

    private void enqueue(WatchResponseWithError watchResponse) {
      try {
        this.eventsQueue.Enqueue(watchResponse);
      } catch (Exception e) {
                Thread.CurrentThread.Interrupt();
        //LOG.warn("Interrupted", e);
      }
    }

     
    public void Close() {
      lock (this.closedLock) {
        if (IsClosed()) {
          return;
        }
        this.SetClosed();
      }

      this.owner.CancelWatcher(this.watchID);
     
    }
            public WatchResponse Listen()
            {
                if (IsClosed())
                {
                    throw new ClosedWatcherException();
                }
                try
                {
                    return this.CreateWatchResponseFuture().Get();
                }
                catch (Exception e)
                {
                    lock (this.closedLock)
                    {
                        if (IsClosed())
                        {
                            throw new ClosedWatcherException();
                        }
                    }

                }
                return null;
            }

    private  WatchResponse CreateWatchResponseFuture() {

                WatchResponseWithError watchResponse = null;
                this.eventsQueue.TryDequeue(out watchResponse);
                if (watchResponse != null)
                {
                    return new WatchResponse(watchResponse.GetWatchResponse());
                }
                else
                {
                    return null;
                }
     
    }

            internal void Enqueue(WatchResponseWithError watchResponseWithError)
            {
                throw new NotImplementedException();
            }
        }

            internal void Enqueue(WatchResponseWithError watchResponseWithError)
            {
                throw new NotImplementedException();
            }

        public void Close()
        {
            
        }
    }
}

