using etcdclientv3.data;
using Etcdserverpb;


namespace etcdclientv3.Response
{
    public class AbstractResponse<T> : IResponse
    {
        private T response;
        private ResponseHeader responseHeader;
        private IHeader header;

        public AbstractResponse(T response, ResponseHeader responseHeader)
        {
            this.response = response;
            this.responseHeader = responseHeader;

            this.header = new HeaderImpl(this);
        }
        public IHeader GetHeader()
        {
            return header;
        }
        public override string ToString()
        {
            return response.ToString();
        }

        protected T GetResponse()
        {
            return this.response;
        }

        protected ResponseHeader GetResponseHeader()
        {
            return this.responseHeader;
        }

        private class HeaderImpl : IHeader
        {
            AbstractResponse<T> response = null;
            public HeaderImpl(AbstractResponse<T> response)
            {
                this.response = response;
            }
            public ulong GetClusterId()
            {
                return response.responseHeader.ClusterId;
            }


            public ulong GetMemberId()
            {
                return response.responseHeader.MemberId;
            }


            public long GetRevision()
            {
                return response.responseHeader.Revision;
            }

            public ulong GetRaftTerm()
            {
                return response.responseHeader.RaftTerm;
            }
        }
    }
}
