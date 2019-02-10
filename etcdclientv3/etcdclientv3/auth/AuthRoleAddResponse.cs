using etcdclientv3.Response;

namespace etcdclientv3.auth
{
    public class AuthRoleAddResponse : AbstractResponse<Etcdserverpb.AuthRoleAddResponse>
    {
        public AuthRoleAddResponse(Etcdserverpb.AuthRoleAddResponse response) : base(response, response.Header)
        {

        }
    }
}
