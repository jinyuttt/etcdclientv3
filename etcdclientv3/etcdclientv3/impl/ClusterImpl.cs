using etcdclientv3.cluster;
using etcdclientv3.IEtcdClient;
using System;
using System.Collections.Generic;
using static Etcdserverpb.Cluster;

namespace etcdclientv3.impl
{ 
class ClusterImpl : ICluster {


  private  ClientConnectionManager connectionManager;
        private ClusterClient clusterClient = null;
        private ManagedChannel managedChannel = null;
  ClusterImpl(ClientConnectionManager connectionManager) {
    this.connectionManager = connectionManager;
            managedChannel = connectionManager.NewChannel();
            clusterClient = new ClusterClient(managedChannel.Channel);
  }

  /**
   * lists the current cluster membership.
   */
 
  public MemberListResponse ListMember() {
           var rsp= clusterClient.MemberList(new Etcdserverpb.MemberListRequest());
            MemberListResponse response = new MemberListResponse(rsp);
            return response;
   // return Util.ToCompletableFuture(
   //  new Etcdserverpb.MemberListRequest(), new FunctionResponse<Etcdserverpb.MemberListRequest, MemberListResponse>()
   // );
        }

  /**
   * add a new member into the cluster.
   *
   * @param peerAddrs the peer addresses of the new member
   */
  
  public  MemberAddResponse AddMember(List<Uri> peerAddrs) {
            Etcdserverpb.MemberAddRequest memberAddRequest = new Etcdserverpb.MemberAddRequest();
            foreach (Uri uri in peerAddrs)
            {
                memberAddRequest.PeerURLs.Add(uri.Host);
                    }
            var rsp = clusterClient.MemberAdd(memberAddRequest);
            MemberAddResponse response = new MemberAddResponse(rsp);
            return response;
            // return Util.ToCompletableFuture(
            //    memberAddRequest, new FunctionResponse<Etcdserverpb.MemberAddRequest, MemberAddResponse>()
            // );
        }

  /**
   * removes an existing member from the cluster.
   *
   * @param memberID the id of the member
   */
  
  public  MemberRemoveResponse RemoveMember(ulong memberID) {
            Etcdserverpb.MemberRemoveRequest memberRemoveRequest = new Etcdserverpb.MemberRemoveRequest();
            memberRemoveRequest.ID = memberID;
            var rsp = clusterClient.MemberRemove(memberRemoveRequest);
            MemberRemoveResponse response = new MemberRemoveResponse(rsp);
            return response;
            // return Util.ToCompletableFuture(
            //  memberRemoveRequest,
            //   new FunctionResponse<Etcdserverpb.MemberRemoveRequest, MemberRemoveResponse>()
            // );
        }

  /**
   * update peer addresses of the member.
   *
   * @param memberID the id of member to update
   * @param peerAddrs the new endpoints for the member
   */

  public MemberUpdateResponse UpdateMember(
      ulong memberID, List<Uri> peerAddrs) {
            Etcdserverpb.MemberUpdateRequest memberUpdateRequest = new Etcdserverpb.MemberUpdateRequest();
            memberUpdateRequest.ID = memberID;
            foreach(Uri uri in peerAddrs)
            {
                memberUpdateRequest.PeerURLs.Add(uri.Host);
            }
            var rsp = clusterClient.MemberUpdate(memberUpdateRequest);
            MemberUpdateResponse response = new MemberUpdateResponse(rsp);
            return response;
            //return Util.ToCompletableFuture(
            //    memberUpdateRequest,
            //    new FunctionResponse<Etcdserverpb.MemberUpdateRequest, MemberUpdateResponse>()
            //);
        }

        public void Close()
        {
           
        }
    }
}
