using etcdclientv3.Response;
using System.Collections.Generic;

namespace etcdclientv3.cluster
{
    public class MemberListResponse : AbstractResponse<Etcdserverpb.MemberListResponse>
    {

        private List<Member> members;
        private readonly object lock_obj = new object();
        public MemberListResponse(Etcdserverpb.MemberListResponse response) : base(response, response.Header)
        {

        }

        /**
         * returns a list of members. empty list if none.
         */
        public List<Member> GetMembers()
        {
            if (members == null)
            {
                lock (lock_obj)
                {
                    if (members == null)
                    {
                        members = Util.ToMembers(GetResponse().Members);
                    }
                }
            }
            return members;
        }
    }
}
