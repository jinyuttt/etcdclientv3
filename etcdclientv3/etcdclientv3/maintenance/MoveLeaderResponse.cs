
using etcdclientv3.Response;

namespace etcdclientv3.maintenance
{
    public class MoveLeaderResponse : AbstractResponse<Etcdserverpb.MoveLeaderResponse>
    {

        public MoveLeaderResponse(Etcdserverpb.MoveLeaderResponse response):base(response,response.Header)
        {
           
        }
    }
}
