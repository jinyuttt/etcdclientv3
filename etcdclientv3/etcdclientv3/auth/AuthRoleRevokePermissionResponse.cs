using etcdclientv3.Response;

namespace etcdclientv3.auth
{

    public class AuthRoleRevokePermissionResponse :
    AbstractResponse<Etcdserverpb.AuthRoleRevokePermissionResponse> {

  public AuthRoleRevokePermissionResponse(
      Etcdserverpb.AuthRoleRevokePermissionResponse response):base(response,response.Header) {
   
  }
}
}
