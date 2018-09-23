
using System;
using System.Collections.Generic;

namespace etcdclientv3.cluster
{
    public class Member {

        private Etcdserverpb.Member member;

        public Member(Etcdserverpb.Member member) {
            this.member = member;
        }
        public Member()
        {

        }
        /**
         * returns the member ID for this member.
         */
        public ulong GetId() {
            return member.ID;
        }

        /**
         * returns the human-readable name of the member.
         *
         * <p>If the member is not started, the name will be an empty string.
         */
        public string GetName() {
            return member.Name;
        }

        /**
         * returns the list of URLs the member exposes to the cluster for communication.
         */
        public List<Uri> GetPeerURIs() {
            return Util.ToURIs(member.PeerURLs);
        }

        /**
         * returns list of URLs the member exposes to clients for communication.
         *
         * <p>f the member is not started, clientURLs will be empty.
         */
        public List<Uri> GetClientURIs() {
            return Util.ToURIs(member.ClientURLs);
        }
    }
}
