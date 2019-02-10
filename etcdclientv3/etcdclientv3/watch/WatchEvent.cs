using System;
using etcdclientv3.data;

namespace etcdclientv3.watch
{
    public class WatchEvent
    {

        private KeyValue keyValue;
        private KeyValue prevKV;
        private EventType eventType;

        public WatchEvent(KeyValue keyValue, KeyValue prevKV, EventType eventType)
        {
            this.keyValue = keyValue;
            this.prevKV = prevKV;
            this.eventType = eventType;
        }

        public KeyValue getKeyValue()
        {
            return keyValue;
        }

        public KeyValue getPrevKV()
        {
            return prevKV;
        }

        public EventType getEventType()
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
