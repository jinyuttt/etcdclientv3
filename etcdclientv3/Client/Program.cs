using etcdclientv3.EtcdClient;
using etcdclientv3.IEtcdClient;
using System;
using System.Threading;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            UitlEtcdClient etcdclient = new UitlEtcdClient();
            IClient client= etcdclient.SetAddress("http://127.0.0.1:2379");
            //client.GetKVClient().Put("dd", "ddd");
            while (true)
            {
                etcdclient.Put("ssd", DateTime.Now.ToString());
                string v = etcdclient.Get("ssd");
                if (v != null)
                {
                    Console.WriteLine(v);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
