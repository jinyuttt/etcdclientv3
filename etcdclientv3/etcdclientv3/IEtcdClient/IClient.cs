

namespace etcdclientv3.IEtcdClient
{
 public   interface IClient
    {
        IAuth GetAuthClient();

        IKV GetKVClient();

        ICluster GetClusterClient();

        IMaintenance GetMaintenanceClient();

        ILease GetLeaseClient();

        IWatch GetWatchClient();

        ILock GetLockClient();
        void Close();
     
     
    }
}
