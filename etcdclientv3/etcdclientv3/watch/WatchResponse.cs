using etcdclientv3.Response;
using Mvccpb;
using System;
using System.Collections.Generic;

namespace etcdclientv3.watch
{
    public class WatchResponse : AbstractResponse<Etcdserverpb.WatchResponse>
    {

        private List<WatchEvent> events;
        private object lock_obj = new object();
        public WatchResponse(Etcdserverpb.WatchResponse response):base(response,response.Header)
        {
           
        }
        
        /**
         * convert API watch event to client event.
         */
        private static WatchEvent ToEvent(Event ev)
        {
            WatchEvent.EventType eventType;
            switch (ev.Type) {
              case Event.Types.EventType.Delete:
                     eventType = WatchEvent.EventType.DELETE;
            break;
              case Event.Types.EventType.Put:
                eventType = WatchEvent.EventType.PUT;
            break;
            default:
                eventType = WatchEvent.EventType.UNRECOGNIZED;
                    break;
        }
     return new WatchEvent(new data.KeyValue(ev.Kv),new data.KeyValue(ev.PrevKv), eventType);
           
        }
        public List<WatchEvent> GetEvents()
        {
            lock (lock_obj)
            {
                if (events == null)
                {
                    var evets = GetResponse().Events;
                    List<WatchEvent> list = new List<WatchEvent>(evets.Count);
                    foreach(var m in evets)
                    {
                        list.Add(ToEvent(m));
                    }

                }
            }

            return events;
        }

        internal int GetWatchId()
        {
            throw new NotImplementedException();
        }

        internal int GetCompactRevision()
        {
            throw new NotImplementedException();
        }

        internal int GetEventsCount()
        {
           return this.events.Count;
        }

        internal WatchEvent GetEvents(int v)
        {
           return this.events[v];
        }

        internal string GetCancelReason()
        {
            throw new NotImplementedException();
        }

        internal WatchResponse Get()
        {
            throw new NotImplementedException();
        }
    }
}

