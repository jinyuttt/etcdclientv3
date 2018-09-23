
using etcdclientv3.Response;

namespace etcdclientv3.Lock
{ 
public class UnlockResponse : AbstractResponse<V3Lockpb.UnlockResponse> {

  public UnlockResponse(V3Lockpb.UnlockResponse response):base(response,response.Header) {
    
  }

}
}
