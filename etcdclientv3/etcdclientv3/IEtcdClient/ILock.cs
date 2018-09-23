using etcdclientv3.data;
using etcdclientv3.Lock;

namespace etcdclientv3.IEtcdClient
{
  public   interface ILock: ICloseableClient
    {

        /**
         * Acquire a lock with the given name.
         *
         * @param name
         *          the identifier for the distributed shared lock to be acquired.
         * @param leaseId
         *          the ID of the lease that will be attached to ownership of the
         *          lock. If the lease expires or is revoked and currently holds the
         *          lock, the lock is automatically released. Calls to Lock with the
         *          same lease will be treated as a single acquistion; locking twice
         *          with the same lease is a no-op.
         */
        LockResponse Lock(ByteSequence name, long leaseId);

        /**
         * Release the lock identified by the given key.
         *
         * @param lockKey
         *          key is the lock ownership key granted by Lock.
         */
        UnlockResponse UnLock(ByteSequence lockKey);

    }
}
