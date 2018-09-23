using etcdclientv3.Response;

namespace etcdclientv3.lease
{
    public class LeaseKeepAliveResponse :
        AbstractResponse<Etcdserverpb.LeaseKeepAliveResponse>
    {

        public LeaseKeepAliveResponse(Etcdserverpb.LeaseKeepAliveResponse response):base(response,response.Header)
        {
           
        }

        /**
         * ID is the lease ID from the keep alive request.
         */
        public long GetID()
        {
            return GetResponse().ID;
        }

        /**
         * TTL is the new time-to-live for the lease.
         */
        public long GetTTL()
        {
            return GetResponse().TTL;
        }
    }
}
