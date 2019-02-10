using System;
using System.Collections.Generic;
using System.Text;

namespace etcdclientv3.IEtcdClient
{
    public interface ICloseableClient
    {
        void Close();
    }
}
