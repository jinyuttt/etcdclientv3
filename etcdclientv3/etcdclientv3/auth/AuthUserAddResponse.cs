using etcdclientv3.Response;

namespace etcdclientv3.auth
{
    public class AuthUserAddResponse :
    AbstractResponse<Etcdserverpb.AuthUserAddResponse>
    {

        public AuthUserAddResponse(Etcdserverpb.AuthUserAddResponse response) : base(response, response.Header)
        {

        }
    }
}
