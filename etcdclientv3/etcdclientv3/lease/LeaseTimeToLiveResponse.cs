using etcdclientv3.data;
using etcdclientv3.Response;
using System.Collections.Generic;

namespace etcdclientv3.lease
{

    public class LeaseTimeToLiveResponse : AbstractResponse<Etcdserverpb.LeaseTimeToLiveResponse>
    {

        private List<ByteSequence> keys;
        private object lock_obj = new object();
        public LeaseTimeToLiveResponse(Etcdserverpb.LeaseTimeToLiveResponse response) : base(response, response.Header)
        {

        }

        /**
         * ID is the lease ID from the keep alive request.
         */
        public long getID()
        {
            return GetResponse().ID;
        }

        /**
         * TTL is the remaining TTL in seconds for the lease;
         * the lease will expire in under TTL+1 seconds.
         */
        public long GetTTl()
        {
            return GetResponse().TTL;
        }

        /**
         * GrantedTTL is the initial granted time in seconds upon lease creation/renewal.
         */
        public long GetGrantedTTL()
        {
            return GetResponse().GrantedTTL;
        }

        /**
         * Keys is the list of keys attached to this lease.
         */
        public List<ByteSequence> getKeys()
        {
            lock (lock_obj)
            {
                if (keys == null)
                {
                    var kkeys = GetResponse().Keys;
                    List<ByteSequence> list = new List<ByteSequence>(kkeys.Count);
                    foreach (var k in kkeys)
                    {
                        list.Add(ByteSequence.From(k));
                    }
                    keys = list;
                }

            }
            return keys;
        }
    }
}
