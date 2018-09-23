using etcdclientv3.lease;
using etcdclientv3.options;
namespace etcdclientv3.IEtcdClient
{
   public interface ILease: ICloseableClient
    {
        /**
        * New a lease with ttl value.
        *
        * @param ttl ttl value, unit seconds
        */
        LeaseGrantResponse Grant(long ttl);

        /**
         * revoke one lease and the key bind to this lease will be removed.
         *
         * @param leaseId id of the lease to revoke
         */
        LeaseRevokeResponse Revoke(long leaseId);

        /**
         * keep alive one lease only once.
         *
         * @param leaseId id of lease to keep alive once
         * @return The keep alive response
         */
        LeaseKeepAliveResponse KeepAliveOnce(long leaseId);

        /**
         * retrieves the lease information of the given lease ID.
         *
         * @param leaseId id of lease
         * @param leaseOption LeaseOption
         * @return LeaseTimeToLiveResponse wrapped in  
         */
        LeaseTimeToLiveResponse TimeToLive(long leaseId,
           LeaseOption leaseOption);

        /**
         * keep the given lease alive forever.
         *
         * @param leaseId lease to be keep alive forever.
         * @param observer the observer
         * @return a KeepAliveListener that listens for KeepAlive responses.
         */
        ICloseableClient KeepAlive(long leaseId);
    }
}
