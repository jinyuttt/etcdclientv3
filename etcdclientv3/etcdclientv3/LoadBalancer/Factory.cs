using System;

namespace etcdclientv3.LoadBalancer
{
    public interface IFactory
    {
        Uri GetUri();
    }
}