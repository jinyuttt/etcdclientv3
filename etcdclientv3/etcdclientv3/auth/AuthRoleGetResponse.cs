using etcdclientv3.data;
using etcdclientv3.Response;
using System;
using System.Collections.Generic;

namespace etcdclientv3.auth
{
    public class AuthRoleGetResponse :AbstractResponse<Etcdserverpb.AuthRoleGetResponse> {

  private List<Permission> permissions;
        private object lock_obj = new object();
  public AuthRoleGetResponse(Etcdserverpb.AuthRoleGetResponse response):base(response,response.Header) {
   
  }

  private static Permission ToPermission(Authpb.Permission perm) {
    ByteSequence key = ByteSequence.from(perm.Key);
    ByteSequence rangeEnd = ByteSequence.from(perm.RangeEnd);
    Permission.Type type;
    switch (perm.PermType) {
      case Authpb.Permission.Types.Type.Read:
        type = Permission.Type.READ;
        break;
      case Authpb.Permission.Types.Type.Write:
        type = Permission.Type.WRITE;
        break;
      case Authpb.Permission.Types.Type.Readwrite:
        type = Permission.Type.READWRITE;
        break;
      default:
        type = Permission.Type.UNRECOGNIZED;
                    break;
    }

    return new Permission(type, key, rangeEnd);
  }

  public  List<Permission> GetPermissions() {
            lock (lock_obj)
            {
                if (permissions == null)
                {
                    var perms = GetResponse().Perm;
                    permissions = new List<Permission>(perms.Count);
                   foreach (var m in perms)
                    {
                        permissions.Add(ToPermission(m));
                    }
                }
            }
    return permissions;
  }
}
}
