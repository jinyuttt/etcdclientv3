using etcdclientv3.Response;
using System.Collections.Generic;

namespace etcdclientv3.KV
{
    public class TxnResponse : AbstractResponse<Etcdserverpb.TxnResponse> {

        // TODO add txnResponsesRef when nested txn is implemented.
        private List<PutResponse> putResponses;
        private List<GetResponse> getResponses;
        private List<DeleteResponse> deleteResponses;
        private List<TxnResponse> txnResponses;
        private object lock_obj = new object();

        public TxnResponse(Etcdserverpb.TxnResponse txnResponse):base(txnResponse, txnResponse.Header) {
           
        }

        /**
         * return true if the compare evaluated to true or false otherwise.
         */
        public bool isSucceeded() {
            return GetResponse().Succeeded;
        }

        /**
         * returns a list of DeleteResponse; empty list if none.
         */
        public  List<DeleteResponse> GetDeleteResponses() {
            lock (lock_obj)
            {
                if (deleteResponses == null) {
                    var delRes = GetResponse().Responses;
                    List<DeleteResponse> list = new List<DeleteResponse>(delRes.Count);
                    foreach (var responseOp in delRes)
                    {
                        if (responseOp.ResponseCase == Etcdserverpb.ResponseOp.ResponseOneofCase.ResponseDeleteRange)
                            list.Add(new DeleteResponse(responseOp.ResponseDeleteRange));
                    }
                    deleteResponses = list;
                }
            }
            return deleteResponses;
        }

        /**
         * returns a list of GetResponse; empty list if none.
         */
        public  List<GetResponse> getGetResponses() {
            lock (lock_obj)
            {
                if (getResponses == null)
                {
                    var resps = GetResponse().Responses;
                    List<GetResponse> list = new List<GetResponse>(resps.Count);
                    foreach (var responseOp in resps)
                    {
                        if (responseOp.ResponseCase == Etcdserverpb.ResponseOp.ResponseOneofCase.ResponseRange)
                            list.Add(new GetResponse(responseOp.ResponseRange));
                    }
                }
            }
            return getResponses;
        }

        /**
         * returns a list of PutResponse; empty list if none.
         */
        public  List<PutResponse> GetPutResponses() {
            lock (lock_obj)
            {
                if (putResponses == null) {
                    List<PutResponse> list = new List<PutResponse>();
                    foreach (var rsp in GetResponse().Responses)
                    {
                        PutResponse response = new PutResponse(rsp.ResponsePut);
                        list.Add(response);
                    }
                    putResponses = list;
                }
            }
            return putResponses;
        }

        public  List<TxnResponse> getTxnResponses() {
            lock (lock_obj)
            {
                if (txnResponses == null) {
                    List<TxnResponse> list = new List<TxnResponse>();
                    foreach(var rsp in GetResponse().Responses)
                    {
                        TxnResponse response = new TxnResponse(rsp.ResponseTxn);
                        list.Add(response);
                    }
                    txnResponses = list;
                       
                }
            }
            return txnResponses;
        }
    }
}
