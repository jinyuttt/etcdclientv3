using etcdclientv3.LoadBalancer;
using System;
using System.Collections.Generic;
using System.Text;

namespace etcdclientv3.EtcdClient
{
  public  class LoadUrlLunXun : IFactory
    {
        List<Uri> uris = null;
        int index = 0;
        public List<Uri> EndPoint
        {
            get { return uris; }
            set
            {
                uris = value;
            }
        }

        public Uri GetUri()
        {
            if(uris!=null&& uris.Count>0)
            {
                return  uris[index++ % uris.Count];
            }
            return null;
        }
    }
}
