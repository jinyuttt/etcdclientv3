using System;
using etcdclientv3.data;
using etcdclientv3.options;
using Etcdserverpb;
using Google.Protobuf;

namespace etcdclientv3.op
{ 
public abstract class Op {

    /**
     * Operation type.
     */
    public enum Type {
        PUT, RANGE, DELETE_RANGE, TXN
    }

    protected Type type;
    protected ByteString key;

    protected Op(Type type, ByteString key) {
        this.type = type;
        this.key = key;
    }

        public abstract RequestOp ToRequestOp();

    public static PutOp Put(ByteSequence key, ByteSequence value, PutOption option) {
        return new PutOp(ByteString.CopyFrom(key.getBytes()), ByteString.CopyFrom(value.getBytes()),
            option);
    }

    public static GetOp get(ByteSequence key, GetOption option) {
        return new GetOp(ByteString.CopyFrom(key.getBytes()), option);
    }

    public static DeleteOp delete(ByteSequence key, DeleteOption option) {
        return new DeleteOp(ByteString.CopyFrom(key.getBytes()), option);
    }

    public static TxnOp txn(Cmp<object>[] cmps, Op[] thenOps, Op[] elseOps) {
        return new TxnOp(cmps, thenOps, elseOps);
    }

    public  class PutOp : Op {

        private ByteString value;
        private PutOption option;

        public PutOp(ByteString key, ByteString value, PutOption option):base(Type.PUT,key) {
          
            this.value = value;
            this.option = option;
        }

            public override RequestOp ToRequestOp()
            {
                throw new System.NotImplementedException();
            }

            RequestOp toRequestOp() {
                PutRequest put = new PutRequest();
                put.Key = this.key;
                put.Value = this.value;
                put.Lease = this.option.getLeaseId();
                put.PrevKv = this.option.getPrevKV();

                RequestOp op=new RequestOp();
                op.RequestPut = put;
                return op;
        }
    }

    public  class GetOp : Op {

        private GetOption option;

        public GetOp(ByteString key, GetOption option):base(Type.RANGE,key) {
          
            this.option = option;
        }

            public override RequestOp ToRequestOp()
            {
                throw new System.NotImplementedException();
            }

            RequestOp toRequestOp() {
                RangeRequest range = new RangeRequest() {
                    Key = this.key, CountOnly = this.option.IsCountOnly(),
                    Limit = this.option.GetLimit(), Revision = this.option.GetRevision(),
                    KeysOnly = this.option.IsKeysOnly(), Serializable = this.option.isSerializable(),
                    SortOrder = OptionsUtil.ToRangeRequestSortOrder(this.option.GetSortOrder()),
                    SortTarget = OptionsUtil.ToRangeRequestSortTarget(this.option.GetSortField())
                };
                range.RangeEnd= ByteString.CopyFrom(this.option.GetEndKey().getBytes());
                RequestOp op = new RequestOp();
                op.RequestRange = range;

                return op;
        }

            private object ToRangeRequestSortOrder(GetOption.SortOrder sortOrder)
            {
                throw new NotImplementedException();
            }
        }

    public  class DeleteOp : Op {

        private DeleteOption option;

        public DeleteOp(ByteString key, DeleteOption option) : base(Type.DELETE_RANGE, key) { 
            this.option = option;
        }

            public override RequestOp ToRequestOp()
            {
                throw new System.NotImplementedException();
            }

            RequestOp toRequestOp() {
                DeleteRangeRequest delete = new DeleteRangeRequest();
                  delete.Key = this.key;
                delete.PrevKv = this.option.isPrevKV();
    

            if (this.option.getEndKey().isPresent()) {
                    delete.RangeEnd = ByteString.CopyFrom(this.option.getEndKey().getBytes());
      
            }

              RequestOp op = new RequestOp();
                op.RequestDeleteRange = delete;
                return op;
        }
    }

    public  class TxnOp : Op {

        private Cmp<object>[] cmps;

        private Op[] thenOps;

        private Op[] elseOps;

        public TxnOp(Cmp<object>[] cmps, Op[] thenOps, Op[] elseOps):base(Type.TXN,null) {
           
            this.cmps = cmps;
            this.thenOps = thenOps;
            this.elseOps = elseOps;
        }

           

            public override RequestOp ToRequestOp() {
                TxnRequest txn = new TxnRequest();

            if (cmps != null) {
                foreach (Cmp<object> cmp in cmps) {
                    txn.Compare.Add(cmp.ToCompare());
                }
            }

            if (thenOps != null) {
                foreach (Op thenOp in thenOps) {
                    txn.Success.Add(thenOp.ToRequestOp());
                }
            }

            if (elseOps != null) {
                foreach (Op elseOp in elseOps) {
                    txn.Failure.Add(elseOp.ToRequestOp());
                }
            }

                RequestOp op = new RequestOp();
                op.RequestTxn = txn;
                return op;
                
        }

        }
}
}
