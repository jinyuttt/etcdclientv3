using etcdclientv3.auth;
using etcdclientv3.data;
using etcdclientv3.IEtcdClient;
using static Etcdserverpb.Auth;

namespace etcdclientv3.impl
{
    public class AuthImpl : IAuth
    {


        private ClientConnectionManager connectionManager;
        private AuthClient authClient = null;
        private ManagedChannel managedChannel = null;
        AuthImpl(ClientConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
            managedChannel = connectionManager.NewChannel();
            authClient = new AuthClient(managedChannel.Channel);

        }

        public AuthEnableResponse AuthEnable()
        {
            Etcdserverpb.AuthEnableRequest enableRequest = new Etcdserverpb.AuthEnableRequest();
            var rsp = authClient.AuthEnable(enableRequest);
            AuthEnableResponse response = new AuthEnableResponse(rsp);
            return response;

            //return Util.ToCompletableFuture(
            //    this.stub.authEnable(enableRequest),
            //   new FunctionResponse<Etcdserverpb.AuthEnableRequest, AuthEnableResponse>());
        }


        public AuthDisableResponse AuthDisable()
        {
            Etcdserverpb.AuthDisableRequest disableRequest = new Etcdserverpb.AuthDisableRequest();
            var rsp = authClient.AuthDisable(disableRequest);
            AuthDisableResponse response = new AuthDisableResponse(rsp);
            return response;
            //return Util.ToCompletableFuture(
            //    this.stub.authDisable(disableRequest),
            //   new FunctionResponse<Etcdserverpb.AuthDisableRequest, AuthDisableResponse>());
        }


        public AuthUserAddResponse UserAdd(ByteSequence user, ByteSequence password)
        {
            Etcdserverpb.AuthUserAddRequest addRequest = new Etcdserverpb.AuthUserAddRequest();
            addRequest.Name = user.ToString();
            addRequest.Password = password.ToString();
            var rsp = authClient.UserAdd(addRequest);
            AuthUserAddResponse response = new AuthUserAddResponse(rsp);
            return response;
            //return Util.ToCompletableFuture(
            //    this.stub.userAdd(addRequest),
            //   new FunctionResponse<Etcdserverpb.AuthUserAddRequest, AuthUserAddResponse>());
        }

        public AuthUserDeleteResponse UserDelete(ByteSequence user)
        {
            Etcdserverpb.AuthUserDeleteRequest deleteRequest = new Etcdserverpb.AuthUserDeleteRequest();
            deleteRequest.Name = user.ToString();
            var rsp = authClient.UserDelete(deleteRequest);
            AuthUserDeleteResponse response = new AuthUserDeleteResponse(rsp);
            return response;
            //        return Util.ToCompletableFuture(
            // this.stub.userDelete(deleteRequest),
            //new FunctionResponse<Etcdserverpb.AuthUserDeleteRequest, AuthUserDeleteResponse>());
        }


        public AuthUserChangePasswordResponse UserChangePassword(ByteSequence user,
            ByteSequence password)
        {
            Etcdserverpb.AuthUserChangePasswordRequest changePasswordRequest = new Etcdserverpb.AuthUserChangePasswordRequest();
            changePasswordRequest.Name = user.ToString();
            changePasswordRequest.Password = password.ToString();
            var rsp = authClient.UserChangePassword(changePasswordRequest);
            AuthUserChangePasswordResponse response = new AuthUserChangePasswordResponse(rsp);
            return response;
            //return Util.ToCompletableFuture(
            //    this.stub.userChangePassword(changePasswordRequest),
            //    new FunctionResponse<Etcdserverpb.AuthUserChangePasswordRequest, AuthUserChangePasswordResponse>());
        }


        public AuthUserGetResponse UserGet(ByteSequence user)
        {
            Etcdserverpb.AuthUserGetRequest userGetRequest = new Etcdserverpb.AuthUserGetRequest();
            userGetRequest.Name = user.ToString();
            var rsp = authClient.UserGet(userGetRequest);
            AuthUserGetResponse response = new AuthUserGetResponse(rsp);
            return response;
            //return Util.ToCompletableFuture(
            //    this.stub.userGet(userGetRequest),
            //    new FunctionResponse<Etcdserverpb.AuthUserGetRequest, AuthUserGetResponse>());
        }


        public AuthUserListResponse UserList()
        {
            Etcdserverpb.AuthUserListRequest userListRequest = new Etcdserverpb.AuthUserListRequest();
            var rsp = authClient.UserList(userListRequest);
            AuthUserListResponse response = new AuthUserListResponse(rsp);
            return response;

            //return Util.ToCompletableFuture(
            //    this.stub.userList(userListRequest),
            //   new FunctionResponse<Etcdserverpb.AuthUserListRequest, AuthUserListResponse>());
        }


        public AuthUserGrantRoleResponse UserGrantRole(ByteSequence user,
            ByteSequence role)
        {

            Etcdserverpb.AuthUserGrantRoleRequest userGrantRoleRequest = new Etcdserverpb.AuthUserGrantRoleRequest();
            userGrantRoleRequest.User = user.ToString();
            userGrantRoleRequest.Role = role.ToString();
            var rsp = authClient.UserGrantRole(userGrantRoleRequest);
            AuthUserGrantRoleResponse response = new AuthUserGrantRoleResponse(rsp);
            return response;
            // return Util.ToCompletableFuture(
            //    new FunctionResponse<Etcdserverpb.AuthUserGrantRoleRequest, AuthUserGrantRoleResponse>());
        }

        public AuthUserRevokeRoleResponse UserRevokeRole(ByteSequence user, ByteSequence role)
        {
            Etcdserverpb.AuthUserRevokeRoleRequest userRevokeRoleRequest = new Etcdserverpb.AuthUserRevokeRoleRequest();
            userRevokeRoleRequest.Name = user.ToString();
            userRevokeRoleRequest.Role = role.ToString();
            var rsp = authClient.UserRevokeRole(userRevokeRoleRequest);
            AuthUserRevokeRoleResponse response = new AuthUserRevokeRoleResponse(rsp);
            return response;
            //return Util.ToCompletableFuture(
            //authClient.UserRevokeRole(userRevokeRoleRequest),
            //new FunctionResponse<Etcdserverpb.AuthUserRevokeRoleResponse, AuthUserRevokeRoleResponse>());
        }


        public AuthRoleAddResponse RoleAdd(ByteSequence user)
        {
            Etcdserverpb.AuthRoleAddRequest roleAddRequest = new Etcdserverpb.AuthRoleAddRequest();
            roleAddRequest.Name = user.ToString();
            var rsp = authClient.RoleAdd(roleAddRequest);
            AuthRoleAddResponse response = new AuthRoleAddResponse(rsp);
            return response;
            //    return Util.ToCompletableFuture(
            //this.stub.roleAdd(roleAddRequest), 
            //new FunctionResponse<Etcdserverpb.AuthRoleAddRequest, AuthRoleAddResponse>());
        }


        public AuthRoleGrantPermissionResponse RoleGrantPermission(ByteSequence role,
            ByteSequence key, ByteSequence rangeEnd, auth.Permission.Type permType)
        {
            Authpb.Permission.Types.Type type;
            switch (permType)
            {
                case Permission.Type.WRITE:
                    type = Authpb.Permission.Types.Type.Write;
                    break;
                case Permission.Type.READWRITE:
                    type = Authpb.Permission.Types.Type.Readwrite;
                    break;
                case Permission.Type.READ:
                    type = Authpb.Permission.Types.Type.Read;
                    break;
                default:
                    type = Authpb.Permission.Types.Type.Readwrite;
                    break;
            }
            Authpb.Permission perm = new Authpb.Permission();
            perm.Key = key.GetByteString();
            perm.RangeEnd = rangeEnd.GetByteString();
            perm.PermType = type;
            Etcdserverpb.AuthRoleGrantPermissionRequest roleGrantPermissionRequest = new Etcdserverpb.AuthRoleGrantPermissionRequest();
            roleGrantPermissionRequest.Name = role.ToString();
            roleGrantPermissionRequest.Perm = perm;
            var rsp = authClient.RoleGrantPermission(roleGrantPermissionRequest);
            AuthRoleGrantPermissionResponse response = new AuthRoleGrantPermissionResponse(rsp);
            return response;
            // return Util.ToCompletableFuture(
            // this.stub.roleGrantPermission(roleGrantPermissionRequest),
            //  new FunctionResponse<Etcdserverpb.AuthRoleGrantPermissionRequest, AuthRoleGrantPermissionResponse>());
        }

        public AuthRoleGetResponse RoleGet(ByteSequence role)
        {

            Etcdserverpb.AuthRoleGetRequest roleGetRequest = new Etcdserverpb.AuthRoleGetRequest();
            roleGetRequest.Role = role.ToString();
            var rsp = authClient.RoleGet(roleGetRequest);
            AuthRoleGetResponse response = new AuthRoleGetResponse(rsp);
            return response;
            //return Util.ToCompletableFuture(
            //    this.stub.roleGet(roleGetRequest),
            //    new FunctionResponse<Etcdserverpb.AuthRoleGetRequest, AuthRoleGetResponse>());
        }


        public AuthRoleListResponse RoleList()
        {
            Etcdserverpb.AuthRoleListRequest roleListRequest = new Etcdserverpb.AuthRoleListRequest();
            var rsp = authClient.RoleList(roleListRequest);
            AuthRoleListResponse response = new AuthRoleListResponse(rsp);
            return response;
            // return Util.ToCompletableFuture(
            //  this.stub.roleList(roleListRequest),
            //  new FunctionResponse<Etcdserverpb.AuthRoleListRequest, AuthRoleListResponse>());
        }


        public AuthRoleRevokePermissionResponse RoleRevokePermission(ByteSequence role,
            ByteSequence key, ByteSequence rangeEnd)
        {
            Etcdserverpb.AuthRoleRevokePermissionRequest roleRevokePermissionRequest = new Etcdserverpb.AuthRoleRevokePermissionRequest();
            roleRevokePermissionRequest.Role = role.ToString();
            roleRevokePermissionRequest.Key = role.ToString();
            roleRevokePermissionRequest.RangeEnd = rangeEnd.ToString();
            var rsp = authClient.RoleRevokePermission(roleRevokePermissionRequest);
            AuthRoleRevokePermissionResponse response = new AuthRoleRevokePermissionResponse(rsp);
            return response;
            //  return Util.ToCompletableFuture(
            //        this.stub.roleRevokePermission(roleRevokePermissionRequest),
            //     new FunctionResponse<Etcdserverpb.AuthRoleRevokePermissionRequest, AuthRoleRevokePermissionResponse>());
        }


        public AuthRoleDeleteResponse RoleDelete(ByteSequence role)
        {
            Etcdserverpb.AuthRoleDeleteRequest roleDeleteRequest = new Etcdserverpb.AuthRoleDeleteRequest();
            roleDeleteRequest.Role = role.ToString();
            var rsp = authClient.RoleDelete(roleDeleteRequest);
            AuthRoleDeleteResponse response = new AuthRoleDeleteResponse(rsp);
            return response;
            //  return Util.ToCompletableFuture(
            //   this.stub.roleDelete(roleDeleteRequest),
            //   new FunctionResponse<Etcdserverpb.AuthRoleDeleteRequest, AuthRoleDeleteResponse>());
        }
    }
}
