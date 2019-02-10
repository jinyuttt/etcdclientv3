
using etcdclientv3.cluster;
using System;
using System.Collections.Generic;
using System.Text;

namespace etcdclientv3.IEtcdClient
{
    public interface ICluster : ICloseableClient
    {

        /**
         * lists the current cluster membership.
         */
        MemberListResponse ListMember();

        /**
         * add a new member into the cluster.
         *
         * @param peerAddrs the peer addresses of the new member
         */
        MemberAddResponse AddMember(List<Uri> peerAddrs);

        /**
         * removes an existing member from the cluster.
         */
        MemberRemoveResponse RemoveMember(ulong memberID);

        /**
         * update peer addresses of the member.
         */
        MemberUpdateResponse UpdateMember(ulong memberID, List<Uri> peerAddrs);
    }
}
