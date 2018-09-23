using System;
using etcdclientv3.data;
using etcdclientv3.IEtcdClient;
using etcdclientv3.KV;
using etcdclientv3.options;
using static Etcdserverpb.KV;

namespace etcdclientv3.impl
{ 
class KVImpl : IKV {

  private  ClientConnectionManager connectionManager;
      
        private KVClient kVClient = null;
        private ManagedChannel managedChannel = null;
    public    KVImpl(ClientConnectionManager connectionManager) {
              this.connectionManager = connectionManager;
              managedChannel = connectionManager.NewChannel();
               kVClient = new KVClient(managedChannel.channel);
           
  }


  public PutResponse Put(ByteSequence key, ByteSequence value) {
    return this.Put(key, value, PutOption.DEFAULT);
  }


  public PutResponse Put(ByteSequence key, ByteSequence value,
      PutOption option) {
 
            Etcdserverpb.PutRequest request = new Etcdserverpb.PutRequest();
            request.Key = key.GetByteString();
            request.Value = value.GetByteString();
            request.Lease = option.getLeaseId();
            request.PrevKv = option.getPrevKV();
            var rsp=kVClient.Put(request);
            PutResponse response = new PutResponse(rsp);
            return response;
    //return Util.ToCompletableFutureWithRetry(
    //     stub.Put(request),
    //     new FunctionResponse<Etcdserverpb.PutRequest, PutResponse>(),
    //     Util.IsRetriable
    //);
        }

        public GetResponse Get(ByteSequence key) {
         return this.Get(key, GetOption.DEFAULT);
  }


  public GetResponse Get(ByteSequence key, GetOption option) {
            Etcdserverpb.RangeRequest request = new Etcdserverpb.RangeRequest();
            request.Key = key.GetByteString();
            request.KeysOnly = option.IsCountOnly();
            request.Limit = option.GetLimit();
            request.Revision = option.GetRevision();
            request.KeysOnly = option.IsKeysOnly();
            request.Serializable = option.isSerializable();
            request.SortOrder = OptionsUtil.ToRangeRequestSortOrder(option.GetSortOrder());
            request.SortTarget = OptionsUtil.ToRangeRequestSortTarget(option.GetSortField());
            if (option.GetEndKey() != null)
            {
                request.RangeEnd = option.GetEndKey().GetByteString();
            }
           var rsp= kVClient.Range(request);
            GetResponse response = new GetResponse(rsp);
            return response;
    //return Util.ToCompletableFutureWithRetry(
    //    stub.Range(request),
    //     new FunctionResponse<Etcdserverpb.RangeRequest, GetResponse>(),
    //    Util.IsRetriable
    //);
        }

        
        public   DeleteResponse Delete(ByteSequence key) {
          return this.Delete(key, DeleteOption.DEFAULT);
  }


  public  DeleteResponse Delete(ByteSequence key, DeleteOption option) {
            Etcdserverpb.DeleteRangeRequest request = new Etcdserverpb.DeleteRangeRequest();
            request.Key = key.GetByteString();
            request.PrevKv = option.isPrevKV();
            request.RangeEnd = option.getEndKey().GetByteString();
          var rsp=  kVClient.DeleteRange(request);
            DeleteResponse response = new DeleteResponse(rsp);
            return response;
    //return Util.ToCompletableFutureWithRetry(
    //    stub.DeleteRange(request),
    //   new FunctionResponse<Etcdserverpb.DeleteRangeRequest, DeleteResponse>()
    //);
        }


  public CompactResponse Compact(long rev) {
    return this.Compact(rev, CompactOption.DEFAULT);
  }


  public CompactResponse  Compact(long rev, CompactOption option) {
            Etcdserverpb.CompactionRequest request = new Etcdserverpb.CompactionRequest();
            request.Revision = rev;
            request.Physical = option.isPhysical();
           var rsp= kVClient.Compact(request);
            CompactResponse response = new CompactResponse(rsp);
            return response;
    //return Util.ToCompletableFutureWithRetry(
    //   stub.Compact(request),
    //  new FunctionResponse<Etcdserverpb.CompactionRequest, CompactResponse>()
    //);
        }

  public ITxn Txn() {
            //return op.TxnImpl.NewTxn((request) ->
            //    Util.toCompletableFutureWithRetry(
            //         stub.Txn(request),
            //         new FunctionResponse<Type, TxnResponse>()
            //    )
            //);
            return null;
  }
}
}
