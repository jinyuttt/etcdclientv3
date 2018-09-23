using etcdclientv3.Response;

namespace etcdclientv3.auth
{
    public class AuthRoleGrantPermissionResponse :AbstractResponse<Etcdserverpb.AuthRoleGrantPermissionResponse> {

  public AuthRoleGrantPermissionResponse(
      Etcdserverpb.AuthRoleGrantPermissionResponse response):base(response,response.Header) {
  
  }
}
}
