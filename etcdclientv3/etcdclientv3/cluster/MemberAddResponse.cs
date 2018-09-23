using etcdclientv3.Response;
using System.Collections.Generic;
namespace etcdclientv3.cluster
{ 
public class MemberAddResponse: AbstractResponse<Etcdserverpb.MemberAddResponse>
    {

  private  Member member;
  private List<Member> members;
        private object lock_obj = new object();
  public MemberAddResponse(Etcdserverpb.MemberAddResponse response):base(response,response.Header) {
    member = new Member(response.Member);
  }

  /**
   * returns the member information for the added member.
   */
  public Member getMember() {
    return member;
  }

  /**
   * returns a list of all members after adding the new member.
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