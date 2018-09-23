using etcdclientv3.data;
using etcdclientv3.IEtcdClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace etcdclientv3.EtcdClient
{
   public class UitlEtcdClient
    {
        IEtcdClient.ClientBuilder clientBuilder = null;
        IClient client = null;
        public IClient SetAddress(params string[] address)
        {
            clientBuilder = new ClientBuilder();
            clientBuilder.EndPoints(address);
            LoadUrlLunXun loadUrlLunXun = new LoadUrlLunXun();
            clientBuilder.LoadBalancerFactory(loadUrlLunXun);
            loadUrlLunXun.EndPoint = clientBuilder.EndPoints();
            client = clientBuilder.Build();
            return client;
        }
        public void close()
        {
            client.Close();
        }
        public void Put(string key,string value)
        {
         
            ByteSequence bkey = ByteSequence.from(key, Encoding.UTF8);
            ByteSequence bvalue = ByteSequence.from(value, Encoding.UTF8);
            client.GetKVClient().Put(bkey, bvalue);
        }

        public void Delete(string key)
        {
         
            ByteSequence bkey = ByteSequence.from(key, Encoding.UTF8);
            client.GetKVClient().Delete(bkey);
        }

        public string Get(string key)
        {
           
            ByteSequence bkey = ByteSequence.from(key, Encoding.UTF8);
             List<KeyValue> keyValues=  client.GetKVClient().Get(bkey).GetKvs();
            if(keyValues.Count>0)
            {
                return keyValues[0].GetValue().ToString();
            }
            return null;
        }
    }
}
