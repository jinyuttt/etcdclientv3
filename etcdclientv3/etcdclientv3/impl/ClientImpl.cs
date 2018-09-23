using etcdclientv3.IEtcdClient;
using etcdclientv3.op;

namespace etcdclientv3.impl
{ 
public  class ClientImpl : IClient {
  private  IKV kvClient;
  private  IAuth authClient;
  private  IMaintenance maintenanceClient;
  private  ICluster clusterClient;
  private  ILease leaseClient;
  private  IWatch watchClient;
  private  ILock lockClient;
  private  ClientBuilder builder;
  private  ClientConnectionManager connectionManager;
  private object lock_obj = new object();
  public ClientImpl(ClientBuilder clientBuilder) {
    // Copy the builder so external modifications won't affect this client impl.
    this.builder = clientBuilder.Copy();
    this.kvClient = null;
    this.authClient = null;
    this.maintenanceClient = null;
    this.clusterClient = null;
    this.leaseClient = null;
    this.watchClient = null;
    this.lockClient = null;
    this.connectionManager = new ClientConnectionManager(this.builder);
  
    }
  

 
  public IAuth GetAuthClient() {
            return newClient<IAuth, AuthImpl>(authClient, new EtcdClientFactory<ClientConnectionManager, AuthImpl>());
  }

   
  public IKV GetKVClient() {
    return newClient<IKV, KVImpl>(kvClient,new EtcdClientFactory<ClientConnectionManager,KVImpl>());
  }

   
  public ICluster GetClusterClient() {
    return newClient<ICluster, ClusterImpl>(clusterClient, new EtcdClientFactory<ClientConnectionManager, ClusterImpl>());
  }

   
  public IMaintenance GetMaintenanceClient() {
    return newClient(maintenanceClient, new EtcdClientFactory<ClientConnectionManager, MaintenanceImpl>());
  }

   
  public ILease GetLeaseClient() {
        
          return newClient(leaseClient, new EtcdClientFactory<ClientConnectionManager,LeaseImpl>());
  }

   
  public IWatch GetWatchClient() {
    return newClient(watchClient, new EtcdClientFactory<ClientConnectionManager, WatchImpl>());
  }

   
  public ILock GetLockClient() {
    return newClient(lockClient, new EtcdClientFactory<ClientConnectionManager, LockImpl>());
  }

   
  public  void close() {
  
  }

  /**
   * Create a new client instance.
   *
   * @param reference the atomic reference holding the instance
   * @param factory the factory to create the client
   * @param <T> the type of client
   * @return the client
   */
  private  T newClient<T,V> (T reference, IFunction<ClientConnectionManager, V> factory)where V:T {
           T client = reference;
          if (client == null) {
             lock(lock_obj) {
                    client = reference;
                    if (client == null) {
                              client = factory.apply(this.connectionManager);
                              reference = client;
        }
      }
    }

    return client;
  }
  public void Close()
        {
            connectionManager.Close();
        }
    }
}
