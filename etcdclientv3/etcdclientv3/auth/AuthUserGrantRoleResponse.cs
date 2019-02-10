using etcdclientv3.Response;

namespace etcdclientv3.auth
{
    public class AuthUserGrantRoleResponse : AbstractResponse<Etcdserverpb.AuthUserGrantRoleResponse>
    {

        public AuthUserGrantRoleResponse(Etcdserverpb.AuthUserGrantRoleResponse response) : base(response, response.Header)
        {

        }
    }
}
