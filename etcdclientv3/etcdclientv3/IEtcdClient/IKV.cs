using etcdclientv3.data;
using etcdclientv3.KV;
using etcdclientv3.options;
using System;
using System.Collections.Generic;
using System.Text;

namespace etcdclientv3.IEtcdClient
{
  public  interface IKV
    {
        /**
 * put a key-value pair into etcd.
 *
 * @param key key in ByteSequence
 * @param value value in ByteSequence
 * @return PutResponse
 */
        PutResponse Put(ByteSequence key, ByteSequence value);

        /**
         * put a key-value pair into etcd with option.
         *
         * @param key key in ByteSequence
         * @param value value in ByteSequence
         * @param option PutOption
         * @return PutResponse
         */
       PutResponse Put(ByteSequence key, ByteSequence value,
            PutOption option);

        /**
         * retrieve value for the given key.
         *
         * @param key key in ByteSequence
         * @return GetResponse
         */
       GetResponse Get(ByteSequence key);

        /**
         * retrieve keys with GetOption.
         *
         * @param key key in ByteSequence
         * @param option GetOption
         * @return GetResponse
         */
        GetResponse Get(ByteSequence key, GetOption option);

        /**
         * delete a key.
         *
         * @param key key in ByteSequence
         * @return DeleteResponse
         */
        DeleteResponse Delete(ByteSequence key);

        /**
         * delete a key or range with option.
         *
         * @param key key in ByteSequence
         * @param option DeleteOption
         * @return DeleteResponse
         */
        DeleteResponse Delete(ByteSequence key, DeleteOption option);

        /**
         * compact etcd KV history before the given rev.
         *
         * <p>All superseded keys with a revision less than the compaction revision will be removed.
         *
         * @param rev the revision to compact.
         * @return CompactResponse
         */
        CompactResponse Compact(long rev);

        /**
         * compact etcd KV history before the given rev with option.
         *
         * <p>All superseded keys with a revision less than the compaction revision will be removed.
         *
         * @param rev etcd revision
         * @param option CompactOption
         * @return CompactResponse
         */
       CompactResponse Compact(long rev, CompactOption option);


        /**
         * creates a transaction.
         *
         * @return a Txn
         */
        ITxn Txn();
    }
}
