using etcdclientv3.Response;

namespace etcdclientv3.auth
{
    public class AuthUserRevokeRoleResponse :
    AbstractResponse<Etcdserverpb.AuthUserRevokeRoleResponse>
    {

        public AuthUserRevokeRoleResponse(Etcdserverpb.AuthUserRevokeRoleResponse response):base(response,response.Header)
        {
           
        }
    }
}
