using etcdclientv3.data;
using Etcdserverpb;
using Google.Protobuf;
using System;

namespace etcdclientv3.op
{
    public class Cmp<T> {

        public enum Op {
            EQUAL, GREATER, LESS
        }
        private  ByteString key;
        private  Op op;
        private  CmpTarget<T> target;

        public Cmp(ByteSequence key, Op compareOp, CmpTarget<T> target) {
            this.key = ByteString.CopyFrom(key.getBytes());
            this.op = compareOp;
            this.target = target;
        }

       public Compare ToCompare() {
            Compare compare = new Compare();
            compare.Key = this.key;
            switch (this.op) {
                case Op.EQUAL:
                    compare.Result = Compare.Types.CompareResult.Equal;
                    break;
                case Op.GREATER:
                    compare.Result = Compare.Types.CompareResult.Greater;
                    break;
                case Op.LESS:
                    compare.Result = Compare.Types.CompareResult.Less;
                    break;
                default:
                    throw new Exception("Unexpected compare type (" + this.op + ")");
            }

            Compare.Types.CompareTarget target = this.target.getTarget();
            Object value = this.target.getTargetValue();

            compare.Target = target;
            switch (target) {
                case Compare.Types.CompareTarget.Version:
                    compare.Version = (long)value;
                    break;
                case Compare.Types.CompareTarget.Value:
                    compare.Value = (ByteString)value;
                    break;
                case Compare.Types.CompareTarget.Mod:
                   
                    compare.ModRevision = (long)value;
                    break;
                case Compare.Types.CompareTarget.Create:
                    compare.CreateRevision = (long)value;
                    break;
                default:
                    throw new  Exception("Unexpected target type (" + target + ")");
            }

            return compare;
        }
    }
}
