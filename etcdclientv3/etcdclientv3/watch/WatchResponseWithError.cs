using etcdclientv3.impl;
using System;

namespace etcdclientv3.watch
{
    public class WatchResponseWithError
    {

        private readonly Etcdserverpb.WatchResponse watchResponse;
        private readonly EtcdException exception;
        private readonly WatchResponse response;

        private WatchResponseWithError()
        {

        }

        public WatchResponseWithError(Etcdserverpb.WatchResponse watchResponse)
        {
            this.watchResponse = watchResponse;
        }

        public WatchResponseWithError(EtcdException e)
        {
            this.exception = e;
        }

        public WatchResponseWithError(WatchResponse response)
        {
            this.response = response;
        }

        public Etcdserverpb.WatchResponse GetWatchResponse()
        {
            return watchResponse;
        }

        public EtcdException GetException()
        {
            return exception;
        }
    }
}
