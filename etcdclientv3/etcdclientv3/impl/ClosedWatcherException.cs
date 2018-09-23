using System;
using System.Runtime.Serialization;

namespace etcdclientv3.impl
{
    [Serializable]
    internal class ClosedWatcherException : Exception
    {
        public ClosedWatcherException()
        {
        }

        public ClosedWatcherException(string message) : base(message)
        {
        }

        public ClosedWatcherException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClosedWatcherException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}