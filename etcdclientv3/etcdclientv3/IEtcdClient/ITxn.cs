using etcdclientv3.KV;
using etcdclientv3.op;

namespace etcdclientv3.IEtcdClient
{
    public interface ITxn {

        /**
         * takes a list of comparison. If all comparisons passed in succeed,
         * the operations passed into Then() will be executed. Or the operations
         * passed into Else() will be executed.
         */
        //CHECKSTYLE:OFF
        ITxn If(params  Cmp<object>[] cmps);
        //CHECKSTYLE:ON

        /**
         * takes a list of operations. The Ops list will be executed, if the
         * comparisons passed in If() succeed.
         */
        //CHECKSTYLE:OFF
        ITxn Then(params  Op[] ops);
        //CHECKSTYLE:ON

        /**
         * takes a list of operations. The Ops list will be executed, if the
         * comparisons passed in If() fail.
         */
        //CHECKSTYLE:OFF
        ITxn Else(params  Op[] ops);
        //CHECKSTYLE:OFF

        /**
         * tries to commit the transaction.
         *
         * @return a TxnResponse wrapped in CompletableFuture
         */
       TxnResponse commit();
    }
}
