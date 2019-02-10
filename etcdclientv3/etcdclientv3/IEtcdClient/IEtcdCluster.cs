using System;
using System.Collections.Generic;
using System.Text;

namespace etcdclientv3.IEtcdClient
{
    public interface IEtcdCluster
    {
        void Start();

        void Restart();


        void Close();


        List<Uri> GetClientEndpoints();


        List<Uri> GetPeerEndpoints();
    }
}
