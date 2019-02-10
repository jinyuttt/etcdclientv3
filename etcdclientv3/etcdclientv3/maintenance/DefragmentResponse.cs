using etcdclientv3.Response;

namespace etcdclientv3.maintenance
{
    public class DefragmentResponse : AbstractResponse<Etcdserverpb.DefragmentResponse>
    {

        public DefragmentResponse(Etcdserverpb.DefragmentResponse response) : base(response, response.Header)
        {
        }
    }
}
