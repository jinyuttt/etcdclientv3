using etcdclientv3.Response;
namespace etcdclientv3.lease
{
    public class LeaseGrantResponse : AbstractResponse<Etcdserverpb.LeaseGrantResponse>
    {

        public LeaseGrantResponse(Etcdserverpb.LeaseGrantResponse response) : base(response, response.Header)
        {

        }

        /**
         * ID is the lease ID for the granted lease.
         */
        public long GetID()
        {
            return GetResponse().ID;
        }

        /**
         * TTL is the server chosen lease time-to-live in seconds.
         */
        public long GetTTL()
        {
            return GetResponse().TTL;
        }
    }
}
