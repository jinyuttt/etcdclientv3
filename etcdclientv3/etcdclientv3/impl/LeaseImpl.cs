
using etcdclientv3.IEtcdClient;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using etcdclientv3.lease;
using System;
using etcdclientv3.options;
using static Etcdserverpb.Lease;

namespace etcdclientv3.impl
{
    public class LeaseImpl : ILease
    {

        //private static  Logger LOG = LoggerFactory.getLogger(LeaseImpl);

        /**
         * FIRST_KEEPALIVE_TIMEOUT_MS is the timeout for the first keepalive request
         * before the actual TTL is known to the lease client.
         */
        private static int FIRST_KEEPALIVE_TIMEOUT_MS = 5000;

        private ClientConnectionManager connectionManager;
        private ManagedChannel managedChannel;
        private LeaseClient leaseClient = null;
      

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
            Etcdserverpb.LeaseGrantRequest leaseGrantRequest = new Etcdserverpb.LeaseGrantRequest();
            leaseGrantRequest.TTL = ttl;
           var rsp= leaseClient.LeaseGrant(leaseGrantRequest);
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
          
            Grpc.Core.CallOptions callOptions = new Grpc.Core.CallOptions();
            //callOptions.
            var rsp = leaseClient.LeaseKeepAlive(callOptions);
            return null;
        }


        public void close()
        {
           
        }

     
        public  LeaseKeepAliveResponse KeepAliveOnce(long leaseId, LeaseOption option=null)
        {
            Grpc.Core.CallOptions callOptions = new Grpc.Core.CallOptions();
           
           var rsp= leaseClient.LeaseKeepAlive(callOptions);
          
            return null;
        }
        public LeaseKeepAliveResponse KeepAliveOnce(long leaseId)
        {

            return KeepAliveOnce(leaseId, null);
        }


        public LeaseTimeToLiveResponse TimeToLive(long leaseId, LeaseOption option)
        {

            Etcdserverpb.LeaseTimeToLiveRequest leaseTimeToLiveRequest = new Etcdserverpb.LeaseTimeToLiveRequest();
            leaseTimeToLiveRequest.ID = leaseId;
            leaseTimeToLiveRequest.Keys = option.IsAttachedKeys;
            var rsp = leaseClient.LeaseTimeToLive(leaseTimeToLiveRequest);
            LeaseTimeToLiveResponse response = new LeaseTimeToLiveResponse(rsp);
            return response;
            //return Util.ToCompletableFutureWithRetry(
            //     this.stub.LeaseTimeToLive(leaseTimeToLiveRequest),
            //      new FunctionResponse<Etcdserverpb.LeaseTimeToLiveRequest, LeaseTimeToLiveResponse>()
            //     );
        }

        public void Close()
        {
           
        }
    }
}
