using etcdclientv3.Response;
using Google.Protobuf;

namespace etcdclientv3.maintenance
{
    public class SnapshotResponse : AbstractResponse<Etcdserverpb.SnapshotResponse>
    {

        public SnapshotResponse(Etcdserverpb.SnapshotResponse response) : base(response, response.Header)
        {

        }

        public ulong GetRemainingBytes()
        {
            return GetResponse().RemainingBytes;
        }

        public ByteString GetBlob()
        {
            return GetResponse().Blob;
        }
    }
}
