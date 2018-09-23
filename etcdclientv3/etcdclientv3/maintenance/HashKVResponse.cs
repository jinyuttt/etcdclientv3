using etcdclientv3.Response;

namespace etcdclientv3.maintenance
{ 
public class HashKVResponse : AbstractResponse<Etcdserverpb.HashKVResponse> {

  public HashKVResponse(Etcdserverpb.HashKVResponse response):base(response,response.Header) {
  }

  /**
   * return the hash value computed from the responding member's MVCC keys up to a given revision.
   */
  public uint GetHash() {
            return GetResponse().Hash;
  }

  /**
   * return compact_revision is the compacted revision of key-value store when hash begins.
   */
  public long getCompacted() {
            return GetResponse().CompactRevision;
  }
}
}
