using Etcdserverpb;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;

namespace etcdclientv3.cluster
{
    public static class Util {

        /**
         * Converts a list of API member to a List of client side member.
         */
        static List<Member> ToMembers(
            List<Member> members) {

            return members;
        }

       public  static List<Uri> ToURIs(RepeatedField<string> uris)
        {
            List<Uri> list = new List<Uri>(uris.Count);
            foreach(var m in uris)
            {
                Uri uri = new Uri(m);
                list.Add(uri);
            }
            return list;
        }

        internal static List<Member> ToMembers(RepeatedField<Etcdserverpb.Member> members)
        {
            List<Member> list = new List<Member>(members.Count);
            foreach (var m in members)
            {
                
                list.Add(new Member(m));
            }
            return list;
        }
    }
}
