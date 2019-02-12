using etcdclientv3.data;
using etcdclientv3.IEtcdClient;
using etcdclientv3.options;
using etcdclientv3.watch;
using Google.Protobuf;
using System.Collections.Concurrent;
using System.Collections.Generic;
using static Etcdserverpb.Watch;

namespace etcdclientv3.impl
{
    partial class WatchImpl : IWatch
    {

        // watchers stores a mapping between leaseID -> WatchIml.
     //   private ConcurrentDictionary<long, WatcherImpl> watchers = new ConcurrentDictionary<long, WatcherImpl>();
        private ConcurrentQueue<WatcherImpl> pendingWatchers = new ConcurrentQueue<WatcherImpl>();
        private ISet<long> cancelSet = new HashSet<long>();
        private ClientConnectionManager connectionManager;
        private ManagedChannel managedChannel;
        private volatile bool closed = false;
        private WatchClient watchClient = null;

        WatchImpl(ClientConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
            managedChannel = connectionManager.NewChannel();
            watchClient = new WatchClient(managedChannel.Channel);
        }

       

        public IWatcher Watch(ByteSequence key)
        {
            return this.Watch(key, WatchOption.DEFAULT);
        }


        public IWatcher Watch(ByteSequence key, WatchOption watchOption)
        {
            if (closed)
            {
                throw new ClosedWatchClientException();
            }
            WatcherImpl watcher = null;
            lock (this)
            {
                watcher = new WatcherImpl(key, watchOption, this);
                watcher.Resume();
                pendingWatchers.Enqueue(watcher);
            }
            return watcher;
        }


        public void Close()
        {
            lock (this)
            {
                if (closed)
                {
                    return;
                }
                WatcherImpl watcherImpl = null;
                while (!pendingWatchers.IsEmpty)
                {

                    if(pendingWatchers.TryDequeue(out watcherImpl))
                    {
                        watcherImpl.Close();
                    }
                }
            }
            closed = true;
         
        }

    
    }
}

