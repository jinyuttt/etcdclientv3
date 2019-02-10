
using etcdclientv3.auth;
using etcdclientv3.data;

namespace etcdclientv3.IEtcdClient
{
    public interface IAuth
    {

        AuthEnableResponse AuthEnable();

        /**
         * disables auth of an etcd cluster.
         */
        AuthDisableResponse AuthDisable();

        /**
         * adds a new user to an etcd cluster.
         */
        AuthUserAddResponse UserAdd(ByteSequence user, ByteSequence password);

        /**
         * deletes a user from an etcd cluster.
         */
        AuthUserDeleteResponse UserDelete(ByteSequence user);

        /**
         * changes a password of a user.
         */
        AuthUserChangePasswordResponse UserChangePassword(ByteSequence user,
            ByteSequence password);

        /**
         * gets a detailed information of a user.
         */
        AuthUserGetResponse UserGet(ByteSequence user);

        /**
         * gets a list of all users.
         */
        AuthUserListResponse UserList();

        /**
         * grants a role to a user.
         */
        AuthUserGrantRoleResponse UserGrantRole(ByteSequence user, ByteSequence role);

        /**
         * revokes a role of a user.
         */
        AuthUserRevokeRoleResponse UserRevokeRole(ByteSequence user,
             ByteSequence role);

        /**
         * adds a new role to an etcd cluster.
         */
        AuthRoleAddResponse RoleAdd(ByteSequence user);

        /**
         * grants a permission to a role.
         */
        AuthRoleGrantPermissionResponse RoleGrantPermission(ByteSequence role,
               ByteSequence key,
               ByteSequence rangeEnd, Permission.Type permType);

        /**
         * gets a detailed information of a role.
         */
        AuthRoleGetResponse RoleGet(ByteSequence role);

        /**
         * gets a list of all roles.
         */
        AuthRoleListResponse RoleList();

        /**
         * revokes a permission from a role.
         */
        AuthRoleRevokePermissionResponse RoleRevokePermission(ByteSequence role,
            ByteSequence key,
            ByteSequence rangeEnd);

        /**
         * RoleDelete deletes a role.
         */
        AuthRoleDeleteResponse RoleDelete(ByteSequence role);
    }
}
