using etcdclientv3.Response;

namespace etcdclientv3.auth
{
    public class AuthRoleDeleteResponse :
    AbstractResponse<Etcdserverpb.AuthRoleDeleteResponse> {

  public AuthRoleDeleteResponse(Etcdserverpb.AuthRoleDeleteResponse response):base(response,response.Header) {

  }
}
}
