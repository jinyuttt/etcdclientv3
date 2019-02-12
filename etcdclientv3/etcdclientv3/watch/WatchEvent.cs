using System;
using etcdclientv3.data;

namespace etcdclientv3.watch
{
    public class WatchEvent
    {

        private readonly KeyValue keyValue;
        private readonly KeyValue prevKV;
        private readonly EventType eventType;

        public WatchEvent(KeyValue keyValue, KeyValue prevKV, EventType eventType)
        {
            this.keyValue = keyValue;
            this.prevKV = prevKV;
            this.eventType = eventType;
        }

        public KeyValue GetKeyValue()
        {
            return keyValue;
        }

        public KeyValue GetPrevKV()
        {
            return prevKV;
        }

        public EventType GetEventType()
        {
            return eventType;
        }

        public enum EventType
        {
            PUT,
            DELETE,
            UNRECOGNIZED,
        }

        internal KeyValue GetKv()
        {
            return prevKV;
        }
    }
}
