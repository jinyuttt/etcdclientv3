
using System;
using System.Collections.Generic;

namespace etcdclientv3.IEtcdClient
{
    public class Util {

        public static List<Uri> ToURIs(List<string> uris) {
            List<Uri> list = new List<Uri>();
            foreach(string u in uris)
            {
                Uri uri = new Uri(u);
                list.Add(uri);
            }
            return list;
        }

    }
}
