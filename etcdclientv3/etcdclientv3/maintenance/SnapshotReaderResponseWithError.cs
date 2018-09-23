using System;

namespace etcdclientv3.maintenance
{

    public class SnapshotReaderResponseWithError
    {

        public SnapshotResponse snapshotResponse;
        public Exception error;

        public SnapshotReaderResponseWithError(SnapshotResponse snapshotResponse)
        {
            this.snapshotResponse = snapshotResponse;
        }

        public SnapshotReaderResponseWithError(Exception e)
        {
            this.error = e;
        }
    }
}
