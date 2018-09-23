
using etcdclientv3.Response;
using System.Collections.Generic;

namespace etcdclientv3.auth
{
    public class AuthUserListResponse :
    AbstractResponse<Etcdserverpb.AuthUserListResponse>
    {

        public AuthUserListResponse(Etcdserverpb.AuthUserListResponse response) : base(response, response.Header)
        {

        }

        /**
         * returns a list of users.
         */
        public List<string> GetUsers()
        {
            var usrs= GetResponse().Users;
            List<string> list = new List<string>(usrs.Count);
            foreach(var m in usrs)
            {
                list.Add(m);
            }
            return list;
        }
    }
}
