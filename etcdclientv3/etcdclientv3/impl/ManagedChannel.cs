using Grpc.Core;

namespace etcdclientv3.impl
{
    internal class ManagedChannel
    {
        public Channel Channel
        {
            get;set;
        }
        public void Close()
        {
            Channel.ShutdownAsync();
        }
        public bool IsClose
        {
            get { return Channel.State == ChannelState.Shutdown; }
        }
    }
}