using etcdclientv3.data;
using etcdclientv3.IEtcdClient;
using etcdclientv3.Lock;
using static V3Lockpb.Lock;

namespace etcdclientv3.impl
{ 

class LockImpl : ILock {

  private  ClientConnectionManager connectionManager;
        private ManagedChannel managedChannel;
        private LockClient lockClient = null;

  LockImpl(ClientConnectionManager connectionManager) {
    this.connectionManager = connectionManager;
            managedChannel = connectionManager.NewChannel();
            lockClient = new LockClient(managedChannel.channel);
  }

        public void Close()
        {
           
        }

        public LockResponse Lock(ByteSequence name, long leaseId) {

            V3Lockpb.LockRequest request = new V3Lockpb.LockRequest();
            request.Name = name.GetByteString();
            request.Lease = leaseId;
          var rsp=  lockClient.Lock(request);
            LockResponse response = new LockResponse(rsp);
            return response;
    //   return Util.ToCompletableFutureWithRetry(
    //    stub.Lock(request),
    //    new FunctionResponse<V3Lockpb.LockRequest, LockResponse>(),
    //    Util.IsRetriable

            //);
        }

   
  public   UnlockResponse UnLock(ByteSequence lockKey) {

            V3Lockpb.UnlockRequest request = new V3Lockpb.UnlockRequest();
            request.Key = lockKey.GetByteString();
          var rsp=  lockClient.Unlock(request);
            UnlockResponse response = new UnlockResponse(rsp);
            return response;
            //return Util.ToCompletableFutureWithRetry(
            //       stub.Unlock(request),
            //       new FunctionResponse<V3Lockpb.UnlockRequest, UnlockResponse>(),
            //       Util.IsRetriable
            //);
        }
}
}
