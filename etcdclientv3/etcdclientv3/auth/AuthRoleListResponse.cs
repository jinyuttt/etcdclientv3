using etcdclientv3.Response;
using System.Collections.Generic;

namespace etcdclientv3.auth
{
    public class AuthRoleListResponse :
    AbstractResponse<Etcdserverpb.AuthRoleListResponse> {

  public AuthRoleListResponse(Etcdserverpb.AuthRoleListResponse response):base(response,response.Header) {

  }

  /**
   * returns a list of roles.
   */
  public List<string> GetRoles() {
            
            var roles = GetResponse().Roles;
            List<string> list = new List<string>(roles.Count);
            foreach(var m in roles)
            {
                list.Add(m);
            }
            return list;
  }
}
}
