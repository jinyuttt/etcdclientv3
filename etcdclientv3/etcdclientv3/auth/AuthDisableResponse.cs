using etcdclientv3.Response;

namespace etcdclientv3.auth
{
    public class AuthDisableResponse : AbstractResponse<Etcdserverpb.AuthDisableResponse>
    {

        public AuthDisableResponse(Etcdserverpb.AuthDisableResponse response) : base(response, response.Header)
        {

        }
    }
}
