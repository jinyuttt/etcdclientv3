using etcdclientv3.EtcdClient;
using etcdclientv3.watch;
using System;
using System.Collections.Generic;
using System.Text;

namespace etcdclientv3.IEtcdClient
{
    /**
         * Interface of Watcher.
         */
    public interface IWatcher : ICloseableClient
    {
        /**
         * Retrieves next watch key, waiting if there are none.
         *
         * @throws ClosedWatcherException if watcher has been closed.
         * @throws ClosedClientException if watch client has been closed.
         * @throws CompactedException when watch a key at a revision that has
         *        been compacted.
         * @throws EtcdException when listen encounters connection error,
         *        etcd server error, or any internal client error.
         * @throws InterruptedException when listen thread is interrupted.
         */
        WatchResponse Listen();
    }
}
