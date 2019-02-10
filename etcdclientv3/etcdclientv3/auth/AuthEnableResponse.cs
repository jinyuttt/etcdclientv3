using etcdclientv3.Response;

namespace etcdclientv3.auth
{
    public class AuthEnableResponse : AbstractResponse<Etcdserverpb.AuthEnableResponse>
    {
        public AuthEnableResponse(Etcdserverpb.AuthEnableResponse response):base(response,response.Header)
        {
           
        }
    }
}
