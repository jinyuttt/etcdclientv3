
using etcdclientv3.data;
using etcdclientv3.Response;
using System.Collections.Generic;

namespace etcdclientv3.KV
{ 
public class GetResponse : AbstractResponse<Etcdserverpb.RangeResponse> {

  private List<KeyValue> kvs;
  private object lock_obj = new object();
  public GetResponse(Etcdserverpb.RangeResponse rangeResponse):base(rangeResponse,rangeResponse.Header) {

  }

  /**
   * return a list of key-value pairs matched by the range request.
   */
  public  List<KeyValue> GetKvs() {
            lock (lock_obj)
            {
                if (kvs == null) {
                    var kvsp= GetResponse().Kvs;
                    List<KeyValue> list = new List<KeyValue>(kvsp.Count);
                    foreach(var m in kvsp)
                    {
                        list.Add(new KeyValue(m));
                    }
                    kvs = list;
                }
            }
    return kvs;
  }

  /**
   * more indicates if there are more keys to return in the requested range.
   */
  public bool IsMore() {
            return GetResponse().More;
  }

  /**
   * return the number of keys within the range when requested.
   */
  public long GetCount() {
            return GetResponse().Count;
  }
}
}
