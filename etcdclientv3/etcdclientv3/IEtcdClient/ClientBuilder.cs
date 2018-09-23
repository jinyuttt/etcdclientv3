using etcdclientv3.data;
using etcdclientv3.EtcdClient;
using etcdclientv3.impl;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace etcdclientv3.IEtcdClient
{
   public class ClientBuilder
    {
        private  ISet<Uri> endpoints = new HashSet<Uri>();
        private  string user;
        private string password;
        private LoadBalancer.IFactory loadBalancerFactory;
        private SslStream sslContext;
        private bool lazyInitialization = false;
        private String authority;
        private URIResolverLoader uriResolverLoader;
        private int maxInboundMessageSize;
        private Dictionary<Metadata, Object> headers;
       public ClientBuilder()
        {
         }
        public List<Uri> EndPoints()
        {
            return new List<Uri>(this.endpoints);
        }
        public ClientBuilder EndPoints(List<Uri> endpoints)
        {

            foreach (Uri endpoint in endpoints)
            {
              
                this.endpoints.Add(endpoint);
            }

            return this;
        }
        public ClientBuilder EndPoints(params string[] endpoints)
        {
            return EndPoints(Util.ToURIs(new List<string>(endpoints)));
        }
        public ClientBuilder EndPoints(params  Uri[] endpoints)
        {

            return EndPoints(new List<Uri>(endpoints));
        }
        public ByteSequence User
        {
           get { return ByteSequence.from(user, Encoding.Default); }
        }

        /**
   * config etcd auth user.
   *
   * @param user etcd auth user
   * @return this builder
   * @throws NullPointerException if user is <code>null</code>
   */
        public ClientBuilder SetUser(ByteSequence user)
        {
          
            this.user = user.ToString();
            return this;
        }

        public ByteSequence Password
        {
            get { return ByteSequence.from(password, Encoding.Default); }
        }

        /**
         * config etcd auth password.
         *
         * @param password etcd auth password
         * @return this builder
         * @throws NullPointerException if password is <code>null</code>
         */
        public ClientBuilder SetPassword(ByteSequence password)
        {
          
            this.password = password.ToString();
            return this;
        }
        /**
 * config LoadBalancer factory.
 *
 * @param loadBalancerFactory etcd LoadBalancer.Factory
 * @return this builder
 * @throws NullPointerException if loadBalancerFactory is <code>null</code>
 */
        public ClientBuilder LoadBalancerFactory(LoadBalancer.IFactory loadBalancerFactory)
        {
            this.loadBalancerFactory = loadBalancerFactory;
            return this;
        }

        /**
         * get LoadBalancer.Factory for etcd client.
         *
         * @return loadBalancerFactory
         */
        public LoadBalancer.IFactory LoadBalancerFactory()
        {
            if(loadBalancerFactory==null)
            {
                LoadUrlLunXun loadUrl = new LoadUrlLunXun();
                loadUrl.EndPoint = this.EndPoints();
                loadBalancerFactory = loadUrl;
            }
            return loadBalancerFactory;
        }

        public bool LazyInitialization()
        {
            return lazyInitialization;
        }

        /**
         * Define if the client has to initialize connectivity and authentication on client constructor
         * or delay it to the first call to a client. Default is false.
         *
         * @param lazyInitialization true if the client has to lazily perform
         *        connectivity/authentication.
         * @return this builder
         */
        public ClientBuilder LazyInitialization(bool lazyInitialization)
        {
            this.lazyInitialization = lazyInitialization;
            return this;
        }

        public SslStream GetSslContext()
        {
            return sslContext;
        }

        /**
         * SSL/TLS context to use instead of the system default. It must have been configured with {@link
         * GrpcSslContexts}, but options could have been overridden.
         *
         * @param sslContext the ssl context
         * @return this builder
         */
        public ClientBuilder SslContext(SslStream sslContext)
        {
            this.sslContext = sslContext;
            return this;
        }

        public string Authority()
        {
            return authority;
        }

        /**
         * The authority used to authenticate connections to servers.
         */
        public ClientBuilder Authority(string authority)
        {
            this.authority = authority;
            return this;
        }

        public URIResolverLoader GetUriResolverLoader()
        {
            return uriResolverLoader;
        }

        public ClientBuilder UriResolverLoader(URIResolverLoader loader)
        {
            this.uriResolverLoader = loader;
            return this;
        }

        public int MaxInboundMessageSize()
        {
            return maxInboundMessageSize;
        }

        /**
         * Sets the maximum message size allowed for a single gRPC frame.
         */
        public ClientBuilder MaxInboundMessageSize(int maxInboundMessageSize)
        {
            this.maxInboundMessageSize = maxInboundMessageSize;
            return this;
        }

        public Dictionary<Metadata, Object> Headers()
        {
            return headers;
        }

        /**
         * Sets headers to be added to http request headers.
         */
        public ClientBuilder Headers(Dictionary<Metadata, Object> headers)
        {
            this.headers = new Dictionary<Metadata, object>(headers);
            return this;
        }

        public IClient Build()
        {
            return new ClientImpl(this);
        }
        public ClientBuilder Copy()
        {
            ClientBuilder clientBuilder = new ClientBuilder();
            clientBuilder.endpoints = this.endpoints;
            return clientBuilder;
        }
      
    }

   
}
