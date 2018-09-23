using etcdclientv3.Response;
using System.Collections.Generic;

namespace etcdclientv3.cluster
{ 
public class MemberRemoveResponse: AbstractResponse<Etcdserverpb.MemberRemoveResponse>
    {

  private List<Member> members;
        private object lock_obj = new object();
  public MemberRemoveResponse(Etcdserverpb.MemberRemoveResponse response):base(response,response.Header) {
   
  }


        /**
         * returns a list of all members after removing the member.
         */
        public List<Member> GetMembers()
        {
            lock (lock_obj)
            {
                if (members == null)
                {
                    members = Util.ToMembers(GetResponse().Members);
                }

            }
                return members;
           
        }
}
}
