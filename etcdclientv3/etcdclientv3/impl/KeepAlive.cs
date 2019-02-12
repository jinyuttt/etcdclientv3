
using etcdclientv3.IEtcdClient;
using System.Collections.Generic;
using etcdclientv3.lease;
using System;
namespace etcdclientv3.impl
{

    /**
* The KeepAlive hold the keepAlive information for lease.
*/
    public class KeepAlive<TRequest,TResponce> : ICloseableClient
    {
        /**
       * FIRST_KEEPALIVE_TIMEOUT_MS is the timeout for the first keepalive request
       * before the actual TTL is known to the lease client.
       */
        private static int FIRST_KEEPALIVE_TIMEOUT_MS = 5000;
        private List<Grpc.Core.AsyncDuplexStreamingCall<TRequest, TResponce>> observers;
        private readonly long leaseId;

        private long deadLine;
        private long nextKeepAlive;
        private LeaseImpl leaseImpl = null;
        public KeepAlive(long leaseId)
        {
            this.nextKeepAlive = DateTime.Now.Ticks;
            this.deadLine = nextKeepAlive + FIRST_KEEPALIVE_TIMEOUT_MS;

            this.observers = new List<Grpc.Core.AsyncDuplexStreamingCall<TRequest, TResponce>>();
            this.leaseId = leaseId;
        }
        public long DeadLine
        {
            get { return deadLine; }
            set { deadLine = value; }
        }
       

        public void AddObserver(Grpc.Core.AsyncDuplexStreamingCall<TRequest, TResponce> observer)
        {
            lock (observers)
            {
                this.observers.Add(observer);
            }
        }

        //removeObserver only would be called synchronously by close in KeepAliveListener, no need to get lock here
        public void RemoveObserver(Grpc.Core.AsyncDuplexStreamingCall<TRequest, TResponce> listener)
        {
            lock (observers)
            {
                this.observers.Remove(listener);
                if (this.observers.Count == 0)
                {
                    leaseImpl.RemoveKeepAlive(leaseId);
                }
            }
        }

        public long NextKeepAlive
        {
            get { return nextKeepAlive; }
            set { nextKeepAlive = value; }
        }


      
        


        //public void onError(Throwable throwable)
        //    {
        //        for (StreamObserver<LeaseKeepAliveResponse> observer : observers)
        //        {
        //            observer.onError(toEtcdException(throwable));
        //        }
        //    }


        //public void onCompleted()
        //    {
        //        this.observers.forEach(StreamObserver::onCompleted);
        //        this.observers.clear();
        //    }

        public void Close()
        {
            leaseImpl.RemoveKeepAlive(this.leaseId);
        }

        public List<Grpc.Core.AsyncDuplexStreamingCall<TRequest, TResponce>> List
        {
            get { return observers; }
        }
    }
    
}
