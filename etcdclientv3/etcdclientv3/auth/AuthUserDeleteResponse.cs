using etcdclientv3.Response;

namespace etcdclientv3.auth
{
    public class AuthUserDeleteResponse :
    AbstractResponse<Etcdserverpb.AuthUserDeleteResponse>
    {

        public AuthUserDeleteResponse(Etcdserverpb.AuthUserDeleteResponse response) : base(response, response.Header)
        {

        }
    }
}
