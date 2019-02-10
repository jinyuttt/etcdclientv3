using etcdclientv3.Response;

namespace etcdclientv3.lease
{
    public class LeaseRevokeResponse : AbstractResponse<Etcdserverpb.LeaseRevokeResponse>
    {

        public LeaseRevokeResponse(Etcdserverpb.LeaseRevokeResponse revokeResponse) : base(revokeResponse, revokeResponse.Header)
        {

        }
    }
}
