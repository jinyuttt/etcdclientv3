using System;
using System.Runtime.Serialization;

namespace etcdclientv3.impl
{
    [Serializable]
    internal class ClosedWatchClientException : Exception
    {
        public ClosedWatchClientException()
        {
        }

        public ClosedWatchClientException(string message) : base(message)
        {
        }

        public ClosedWatchClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClosedWatchClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}