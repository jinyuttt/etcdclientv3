using etcdclientv3.Response;

namespace etcdclientv3.maintenance
{ 
public class StatusResponse : AbstractResponse<Etcdserverpb.StatusResponse> {

  public StatusResponse(Etcdserverpb.StatusResponse response):base(response,response.Header) {
    
  }

  /**
   * returns the cluster protocol version used by the responding member.
   */
  public string GetVersion() {
            return GetResponse().Version;
  }

  /**
   * return the size of the backend database, in bytes, of the responding member.
   */
  public long GetDbSize() {
            return GetResponse().DbSize;
  }

  /**
   * return the the member ID which the responding member believes is the current leader.
   */
  public ulong GetLeader() {
            return GetResponse().Leader;
  }

  /**
   * the current raft index of the responding member.
   */
  public ulong GetRaftIndex() {
            return GetResponse().RaftIndex;
  }

  /**
   * the current raft term of the responding member.
   */
  public ulong getRaftTerm() {
            return GetResponse().RaftTerm;
  }
}
}
