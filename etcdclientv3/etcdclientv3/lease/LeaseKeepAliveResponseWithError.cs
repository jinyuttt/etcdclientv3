
using System;

namespace etcdclientv3.lease
{
    public class LeaseKeepAliveResponseWithError
    {

        public LeaseKeepAliveResponse leaseKeepAliveResponse;
        public Exception error;

        public LeaseKeepAliveResponseWithError(LeaseKeepAliveResponse leaseKeepAliveResponse)
        {
            this.leaseKeepAliveResponse = leaseKeepAliveResponse;
        }

        public LeaseKeepAliveResponseWithError(Exception e)
        {
            this.error = e;
        }
    }
}
