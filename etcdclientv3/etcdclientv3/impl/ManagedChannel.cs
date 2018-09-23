using Grpc.Core;
using System;

namespace etcdclientv3.impl
{
    internal class ManagedChannel
    {
        public Channel channel
        {
            get;set;
        }
        public void Close()
        {
            channel.ShutdownAsync();
        }
        public bool IsClose
        {
            get { return channel.State == ChannelState.Shutdown; }
        }
    }
}