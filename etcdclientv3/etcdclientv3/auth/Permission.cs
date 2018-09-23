using etcdclientv3.data;

namespace etcdclientv3.auth
{

    public class Permission {

        private  Type permType;
       private  ByteSequence key;
       private  ByteSequence rangeEnd;

  public enum Type {
            READ,
            WRITE,
            READWRITE,
            UNRECOGNIZED,
        }

        public Permission(Type permType, ByteSequence key, ByteSequence rangeEnd) {
            this.permType = permType;
            this.key = key;
            this.rangeEnd = rangeEnd;
        }

        /**
         * returns the type of Permission: READ, WRITE, READWRITE, or UNRECOGNIZED.
         */
        public Type getPermType() {
            return permType;
        }

        public ByteSequence getKey() {
            return key;
        }

        public ByteSequence getRangeEnd() {
            return rangeEnd;
        }
    }
}
