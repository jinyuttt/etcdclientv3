
using etcdclientv3.IEtcdClient;
using System.Collections.Concurrent;
using etcdclientv3.lease;
using etcdclientv3.options;
using static Etcdserverpb.Lease;
using System;
using System.Timers;

namespace etcdclientv3.impl
{
    public partial class LeaseImpl : ILease
    {

        //private static  Logger LOG = LoggerFactory.getLogger(LeaseImpl);

        /**
         * FIRST_KEEPALIVE_TIMEOUT_MS is the timeout for the first keepalive request
         * before the actual TTL is known to the lease client.
         */
        private static int FIRST_KEEPALIVE_TIMEOUT_MS = 5000;

        private readonly ClientConnectionManager connectionManager;
        private ManagedChannel managedChannel;
        private LeaseClient leaseClient = null;
        private ConcurrentDictionary<long, KeepAlive<Etcdserverpb.LeaseKeepAliveRequest,Etcdserverpb.LeaseKeepAliveResponse>> keepAlives = null;
        private volatile bool closed=false;
         Timer timer= new Timer(500);
        Timer timerDeadLine = new Timer(1000);

        LeaseImpl(ClientConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
            managedChannel = connectionManager.NewChannel();
            leaseClient = new LeaseClient(managedChannel.Channel);
            // this.stub = connectionManager.NewStub<LeaseFutureStub>(null);
            // this.leaseStub = connectionManager.NewStub<LeaseStub>(null);
            // this.keepAlives = new ConcurrentDictionary<string, impl.KeepAlive>();
            //this.scheduledExecutorService = MoreExecutors.listeningDecorator(Executors.newScheduledThreadPool(2));
        }


        public LeaseGrantResponse Grant(long ttl)
        {
            Etcdserverpb.LeaseGrantRequest leaseGrantRequest = new Etcdserverpb.LeaseGrantRequest
            {
                TTL = ttl
            };
            var rsp = leaseClient.LeaseGrant(leaseGrantRequest);
            LeaseGrantResponse response = new LeaseGrantResponse(rsp);
            return response;
        }


        public LeaseRevokeResponse Revoke(long leaseId)
        {
            Etcdserverpb.LeaseRevokeRequest leaseRevokeRequest = new Etcdserverpb.LeaseRevokeRequest
            {
                ID = leaseId
            };
            var rsp = leaseClient.LeaseRevoke(leaseRevokeRequest);
            LeaseRevokeResponse response = new LeaseRevokeResponse(rsp);
            return response;
            //   return Util.ToCompletableFutureWithRetry(
            //       this.stub.LeaseRevoke(leaseRevokeRequest),
            //       new FunctionResponse<Etcdserverpb.LeaseRevokeRequest, LeaseRevokeResponse>()
            //  );
        }


        public ICloseableClient KeepAlive(long leaseId)
        {
            KeepAlive<Etcdserverpb.LeaseKeepAliveRequest, Etcdserverpb.LeaseKeepAliveResponse> item = null;
            if (!keepAlives.TryGetValue(leaseId,out item))
            {
                item = new KeepAlive<Etcdserverpb.LeaseKeepAliveRequest, Etcdserverpb.LeaseKeepAliveResponse>(leaseId);
            }
           
            Grpc.Core.CallOptions callOptions = new Grpc.Core.CallOptions();
            //callOptions.

            var rsp = leaseClient.LeaseKeepAlive(callOptions);
            item.AddObserver(rsp);

            return item ;
        }

        private void Start()
        {
            this.SendKeepAliveExecutor();
            this.DeadLineExecutor();
        }
        private void Reset()
        {
            //this.keepAliveFuture.cancel(true);
            //this.keepAliveRequestObserver.onCompleted();
            //this.keepAliveResponseObserver.onCompleted();
           foreach(var kv in keepAlives)
            {
                kv.Value.List.ForEach(item =>
                {
                    item.RequestStream.CompleteAsync();
                });
            }
            this.SendKeepAliveExecutor();
        }

        private void SendKeepAliveExecutor()
        {


            Grpc.Core.CallOptions callOptions = new Grpc.Core.CallOptions();
            //callOptions.
            var rsp = leaseClient.LeaseKeepAlive(callOptions);
            try
            {
                timer.Elapsed -= Timer_Elapsed;
            }
            catch
            {

            }
           
                timer.Elapsed += Timer_Elapsed;
            
           
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (var kv in keepAlives)
            {
                if (kv.Value.NextKeepAlive < DateTime.Now.Ticks)
                {
                    kv.Value.List.ForEach(item =>
                    {
                        item.RequestStream.WriteAsync(new Etcdserverpb.LeaseKeepAliveRequest()
                        {
                            ID = kv.Key
                        });
                    });
                }
            }
          
        }

        private void ProcessOnError()
        {
            if (this.closed)
            {
                return;
            }


        }

        private  void ProcessKeepAliveResponse(
           Etcdserverpb.LeaseKeepAliveResponse leaseKeepAliveResponse)
        {
            if (this.closed)
            {
                return;
            }

            long leaseID = leaseKeepAliveResponse.ID;
            long ttl = leaseKeepAliveResponse.TTL;
            KeepAlive<Etcdserverpb.LeaseKeepAliveRequest, Etcdserverpb.LeaseKeepAliveResponse> ka = null;
            if (keepAlives.TryGetValue(leaseID, out ka))
            {


                if (ttl > 0)
                {
                    long nextKeepAlive = DateTime.Now.Ticks + ttl * 1000 / 3;
                    ka.NextKeepAlive = nextKeepAlive;
                    ka.DeadLine = DateTime.Now.Ticks + ttl * 1000;
                    ka.List.ForEach(kv =>
                     {
                         kv.RequestStream.WriteAsync(new Etcdserverpb.LeaseKeepAliveRequest() { ID = leaseID });
                       
                     });
                }
                else
                {
                    this.RemoveKeepAlive(leaseID);
                    // lease expired; close all keep alive
                    //this.re(leaseID);
                    //ka.onError(
                    //    newEtcdException(
                    //      ErrorCode.NOT_FOUND,
                    //      "etcdserver: requested lease not found"
                    //    )
                    //);
                }
            }
        }

        private void DeadLineExecutor()
        {
            try
            {
                timerDeadLine.Elapsed -= TimerDeadLine_Elapsed;
            }
            catch
            {

            }
            timerDeadLine.Elapsed += TimerDeadLine_Elapsed;

        }

        private void TimerDeadLine_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           foreach(var ka in keepAlives)
            {
                if(ka.Value.DeadLine<DateTime.Now.Ticks)
                {
                    ka.Value.List.ForEach(item =>
                    {
                        item.RequestStream.CompleteAsync();
                    });
                }
            }
            
        }

        public void Close()
        {

        }

        public void RemoveKeepAlive(long leaseId)
        {
            KeepAlive<Etcdserverpb.LeaseKeepAliveRequest, Etcdserverpb.LeaseKeepAliveResponse> kv;
            this.keepAlives.TryRemove(leaseId, out kv);
        }

        public LeaseKeepAliveResponse KeepAliveOnce(long leaseId, LeaseOption option = null)
        {
            Grpc.Core.CallOptions callOptions = new Grpc.Core.CallOptions();

            var rsp = leaseClient.LeaseKeepAlive(callOptions);

            return null;
        }

        public LeaseKeepAliveResponse KeepAliveOnce(long leaseId)
        {

            return KeepAliveOnce(leaseId, null);
        }


        public LeaseTimeToLiveResponse TimeToLive(long leaseId, LeaseOption option)
        {

            Etcdserverpb.LeaseTimeToLiveRequest leaseTimeToLiveRequest = new Etcdserverpb.LeaseTimeToLiveRequest
            {
                ID = leaseId,
                Keys = option.IsAttachedKeys
            };
            var rsp = leaseClient.LeaseTimeToLive(leaseTimeToLiveRequest);
            LeaseTimeToLiveResponse response = new LeaseTimeToLiveResponse(rsp);
            return response;
         
        }
    }
}
