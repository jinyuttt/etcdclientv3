using System;
using System.Collections.Generic;
using etcdclientv3.data;
using etcdclientv3.IEtcdClient;
using Etcdserverpb;
using Grpc.Core;

namespace etcdclientv3.impl
{
    class ClientConnectionManager
    {


        private ClientBuilder builder;
        private string token;
        private List<ManagedChannel> lstChannels = null;
        public ClientConnectionManager(
            ClientBuilder builder)
        {
            this.builder = builder;
            this.token = null;
            this.lstChannels = new List<ManagedChannel>();
        }

        private string GetToken(Channel channel)
        {
            string tk = token;
            if (tk == null)
            {
                tk = token;
                if (tk == null)
                {
                    tk = GenerateToken(channel);
                }
            }
            return tk;
        }

        private string GenerateToken(Channel channel)
        {
            if (builder.User != null && builder.Password != null)
            {

                return Authenticate(channel, builder.User, builder.Password).Token;
            }
            return "";
        }

        private void RefreshToken(Channel channel)
        {

            string tk = GenerateToken(channel);
            token = tk;
        }

        public ManagedChannel NewChannel()
        {
            ManagedChannel managedChannel = null;
            lock (lstChannels)
            {
                Uri uri = this.builder.LoadBalancerFactory().GetUri();
                Channel channel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
                channel.ConnectAsync();
                managedChannel = new ManagedChannel() { Channel = channel };
                //   channel.ShutdownAsync();
                lstChannels.Add(managedChannel);
            }
            return managedChannel;
        }


        public void Close()
        {
            lock (lstChannels)
            {
                foreach (ManagedChannel channel in lstChannels)
                {
                    channel.Close();
                }
            }
        }

        /**
         * get token from etcd with name and password.
         *
         * @param channel channel to etcd
         * @param username auth name
         * @param password auth password
         * @return authResp
         */
        private static AuthenticateResponse Authenticate(Channel channel, ByteSequence username, ByteSequence password)
        {
            AuthenticateRequest requet = new AuthenticateRequest
            {
                Name = username.ToString(),
                Password = password.ToString()
            };
            Auth.AuthClient authClient = new Auth.AuthClient(channel);
            var rsp = authClient.Authenticate(requet);
            AuthenticateResponse response = new AuthenticateResponse(rsp);
            return response;
        }
    }
}


 
  
