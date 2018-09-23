using etcdclientv3.Response;
using System.Collections.Generic;

namespace etcdclientv3.cluster
{ 
public class MemberUpdateResponse: AbstractResponse<Etcdserverpb.MemberUpdateResponse>
    {

  private List<Member> members;
        private object lock_obj = new object();
  public MemberUpdateResponse(Etcdserverpb.MemberUpdateResponse response):base(response,response.Header) {
   
  }

  /**
   * returns a list of all members after updating the member.
   */
  public  List<Member> GetMembers() {
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
