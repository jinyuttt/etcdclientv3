using etcdclientv3.Response;

namespace etcdclientv3.KV
{
    public class CompactResponse : AbstractResponse<Etcdserverpb.CompactionResponse>
    {

        public CompactResponse(Etcdserverpb.CompactionResponse response) : base(response, response.Header)
        {

        }
    }
}
