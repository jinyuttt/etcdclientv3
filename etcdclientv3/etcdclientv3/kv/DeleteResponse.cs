using etcdclientv3.data;
using etcdclientv3.Response;
using System.Collections.Generic;

namespace etcdclientv3.KV
{ 
public class DeleteResponse : AbstractResponse<Etcdserverpb.DeleteRangeResponse> {

  private List<KeyValue> prevKvs;
        private object lock_obj = new object();
  public DeleteResponse(Etcdserverpb.DeleteRangeResponse deleteRangeResponse):base(deleteRangeResponse, deleteRangeResponse.Header) {
  
  }

  /**
   * return the number of keys deleted by the delete range request.
   */
  public long GetDeleted() {
            return GetResponse().Deleted;
  }

  /**
   * return previous key-value pairs.
   */
  public  List<KeyValue> getPrevKvs() {
            lock (lock_obj)
            {
                if (prevKvs == null) {
                    var kvs= GetResponse().PrevKvs;
                    List<KeyValue> list = new List<KeyValue>(kvs.Count);
                    foreach(var kv in kvs)
                    {
                        list.Add(new KeyValue(kv));
                    }
                    prevKvs = list;
                }

            }
    return prevKvs;
  }
}
}
