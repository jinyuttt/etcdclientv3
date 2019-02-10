
using System;

namespace etcdclientv3.lease
{
    /**
     * Signals that the lease client do not have this lease.
     */
    public class NoSuchLeaseException : Exception
    {

        public NoSuchLeaseException(long leaseId) : base("No such lease: " + leaseId)
        {

        }
    }
}
