using etcdclientv3.Response;
using System.Collections.Generic;

namespace etcdclientv3.auth
{
    public class AuthUserGetResponse :
    AbstractResponse<Etcdserverpb.AuthUserGetResponse> {

  public AuthUserGetResponse(Etcdserverpb.AuthUserGetResponse response):base(response,response.Header) {

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
