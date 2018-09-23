
using etcdclientv3.Response;

namespace etcdclientv3.auth
{
    public class AuthUserChangePasswordResponse :
    AbstractResponse<Etcdserverpb.AuthUserChangePasswordResponse>
    {

        public AuthUserChangePasswordResponse(
            Etcdserverpb.AuthUserChangePasswordResponse response):base(response,response.Header)
        {
           
        }
    }
}
