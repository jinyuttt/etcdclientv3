
using etcdclientv3.data;
using etcdclientv3.Response;

namespace etcdclientv3.KV
{ 
  public class PutResponse : AbstractResponse<Etcdserverpb.PutResponse> {

  public PutResponse(Etcdserverpb.PutResponse putResponse):base(putResponse,putResponse.Header) {
   
  }

  /**
   * return previous key-value pair.
   */
  public KeyValue getPrevKv() {
    return new KeyValue(GetResponse().PrevKv);
  }

  public bool hasPrevKv() {
            return GetResponse().PrevKv.Key.IsEmpty;
  }
}
}
