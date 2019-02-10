using etcdclientv3.IEtcdClient;
using etcdclientv3.maintenance;
using System;
using static Etcdserverpb.Maintenance;

namespace etcdclientv3.impl
{
    class MaintenanceImpl : IMaintenance
    {

        private ClientConnectionManager connectionManager;
        private ManagedChannel managedChannel;
        private MaintenanceClient maintenanceClient = null;

        MaintenanceImpl(ClientConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
            managedChannel = connectionManager.NewChannel();
            maintenanceClient = new MaintenanceClient(managedChannel.Channel);
        }

        /**
         * get all active keyspace alarm.
         *
         * @return alarm list
         */

        public AlarmResponse ListAlarms()
        {
            Etcdserverpb.AlarmRequest alarmRequest = new Etcdserverpb.AlarmRequest();
            alarmRequest.Alarm = Etcdserverpb.AlarmType.None;
            alarmRequest.Action = Etcdserverpb.AlarmRequest.Types.AlarmAction.Get;
            alarmRequest.MemberID = 0;
           var rsp=  maintenanceClient.Alarm(alarmRequest);
            AlarmResponse response = new AlarmResponse(rsp);
            return response;

            //return Util.ToCompletableFuture(
            //    this.stub.Alarm(alarmRequest),
            //     new FunctionResponse<Etcdserverpb.AlarmRequest, AlarmResponse>()
            //);
        }

        /**
         * disarms a given alarm.
         *
         * @param member the alarm
         * @return the response result
         */

        public AlarmResponse AlarmDisarm(AlarmMember member)
        {

            Etcdserverpb.AlarmRequest alarmRequest = new Etcdserverpb.AlarmRequest();
            alarmRequest.Alarm = Etcdserverpb.AlarmType.Nospace;
            alarmRequest.Action = Etcdserverpb.AlarmRequest.Types.AlarmAction.Deactivate;
            alarmRequest.MemberID = member.MemberId;
            var rsp = maintenanceClient.Alarm(alarmRequest);
            AlarmResponse response = new AlarmResponse(rsp);
            return response;
        //    return Util.ToCompletableFuture(
        //        this.stub.Alarm(alarmRequest),
        //        new FunctionResponse<Etcdserverpb.AlarmRequest, AlarmResponse>()
        //    );
        }

        /**
         * defragment one member of the cluster.
         *
         * <p>After compacting the keyspace, the backend database may exhibit internal
         * fragmentation. Any internal fragmentation is space that is free to use
         * by the backend but still consumes storage space. The process of
         * defragmentation releases this storage space back to the file system.
         * Defragmentation is issued on a per-member so that cluster-wide latency
         * spikes may be avoided.
         *
         * <p>Defragment is an expensive operation. User should avoid defragmenting
         * multiple members at the same time.
         * To defragment multiple members in the cluster, user need to call defragment
         * multiple times with different endpoints.
         */

        public DefragmentResponse DefragmentMember(Uri endpoint)
        {
            //需要一个全新的连接
          var request=  new Etcdserverpb.DefragmentRequest();
          var rsp=  maintenanceClient.Defragment(request);
            DefragmentResponse response = new DefragmentResponse(rsp);
            return response;
            //return Util.ToCompletableFuture(
            //       stub.Defragment(new Etcdserverpb.DefragmentRequest()),
            //      new FunctionResponse<Etcdserverpb.DefragmentRequest, DefragmentResponse>()
            //   );
        }

        /**
         * get the status of one member.
         */

        public StatusResponse StatusMember(Uri endpoint)
        {
            //一个全新连接
            var request = new Etcdserverpb.StatusRequest();
          var rsp=  maintenanceClient.Status(request);
            StatusResponse response = new StatusResponse(rsp);
            return response;
           // return Util.ToCompletableFuture(
           //           stub.Status(new Etcdserverpb.StatusRequest()),
           //           new FunctionResponse<Etcdserverpb.StatusRequest, StatusResponse>()
           //);
        }


        public MoveLeaderResponse MoveLeader(ulong transfereeID)
        {
            Etcdserverpb.MoveLeaderRequest request = new Etcdserverpb.MoveLeaderRequest();
            request.TargetID = transfereeID;
            var rsp = maintenanceClient.MoveLeader(request);
            MoveLeaderResponse response = new MoveLeaderResponse(rsp);
            return response;
            //return Util.ToCompletableFuture(
            //  this.stub.MoveLeader(request),
            // new FunctionResponse<Etcdserverpb.MoveLeaderRequest, MoveLeaderResponse>()
            //);
        }

        public HashKVResponse HashKV(Uri endpoint, long rev)
        {
            //新连接
            Etcdserverpb.HashKVRequest request = new Etcdserverpb.HashKVRequest();
            request.Revision = rev;
            var rsp = maintenanceClient.HashKV(request);
            HashKVResponse response = new HashKVResponse(rsp);
            return response;
            // return Util.ToCompletableFuture(
            //            stub.HashKV(request),
            //            new FunctionResponse<Etcdserverpb.HashKVRequest, HashKVResponse>()
            //);
        }


        public long Snapshot()
        {
            Etcdserverpb.SnapshotRequest request = new Etcdserverpb.SnapshotRequest();
            var rsp = maintenanceClient.Snapshot(request);
            return 0;
        }

        public void Close()
        {
          
        }
    }
}
