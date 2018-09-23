using etcdclientv3.data;
using etcdclientv3.IEtcdClient;
using etcdclientv3.options;
using etcdclientv3.watch;

namespace etcdclientv3.IEtcdClient
{ 
public interface IWatch : ICloseableClient {

  /**
   * watch on a key with option.
   *
   * @param key key to be watched on.
   * @param watchOption see {@link io.etcd.jetcd.options.WatchOption}.
   * @throws ClosedClientException if watch client has been closed.
   */
  IWatcher Watch(ByteSequence key, WatchOption watchOption);


  /**
   * watch on a key.
   *
   * @param key key to be watched on.
   * @throws ClosedClientException if watch client has been closed.
   **/
  IWatcher Watch(ByteSequence key);

       
}
}
