using etcdclientv3.op;
using System;
using System.Collections.Generic;
using System.Text;

namespace etcdclientv3.impl
{
    public class EtcdClientFactory<ClientConnectionManager, V> : IFunction<ClientConnectionManager, V>
    {
        public V apply(ClientConnectionManager request)
        {
            return (V)Activator.CreateInstance(typeof(V), request);
        
        }

     
    }
}
