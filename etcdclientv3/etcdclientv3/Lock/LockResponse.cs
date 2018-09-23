using etcdclientv3.data;
using etcdclientv3.Response;

namespace etcdclientv3.Lock
{
public class LockResponse : AbstractResponse<V3Lockpb.LockResponse> {

  public LockResponse(V3Lockpb.LockResponse response):base(response,response.Header) {
   
  }

  /**
   * key is a key that will exist on etcd for the duration that the Lock caller
   * owns the lock. Users should not modify this key or the lock may exhibit
   * undefined behavior.
   */
  public ByteSequence GetKey() {
    return ByteSequence.from(GetResponse().Key);
  }

}
}
