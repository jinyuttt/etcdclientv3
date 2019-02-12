using etcdclientv3.maintenance;
using System;
using System.IO;
using System.Net.Sockets;
namespace etcdclientv3.IEtcdClient
{
   public  interface IMaintenance : ICloseableClient
    {

        /**
         * get all active keyspace alarm.
         */
         AlarmResponse ListAlarms();

        /**
         * disarms a given alarm.
         *
         * @param member the alarm
         * @return the response result
         */
         AlarmResponse AlarmDisarm(AlarmMember member);

        /**
         * defragment one member of the cluster by its endpoint.
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
         DefragmentResponse DefragmentMember(Uri endpoint);

        /**
         * get the status of a member by its endpoint.
         */
         StatusResponse StatusMember(Uri endpoint);


        /**
         * returns a hash of the KV state at the time of the RPC.
         * If revision is zero, the hash is computed on all keys. If the revision
         * is non-zero, the hash is computed on all keys at or below the given revision.
         */
         HashKVResponse HashKV(Uri endpoint, long rev);

        /**
         * retrieves backend snapshot.
         *
         * @param output the output stream to write the snapshot content.
         *
         * @return a Snapshot for retrieving backend snapshot.
         */
         long Snapshot(Stream output);

        /**
         * retrieves backend snapshot as as stream of chunks.
         *
         * @param  observer a stream of data chunks
         */
      

        /**
         * moveLeader requests current leader to transfer its leadership to the transferee.
         * Request must be made to the leader.
         */
         MoveLeaderResponse MoveLeader(ulong transfereeID);
    }
}
