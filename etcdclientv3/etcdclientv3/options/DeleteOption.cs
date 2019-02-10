
using etcdclientv3.data;

namespace etcdclientv3.options
{

    public  class DeleteOption {

        public static  DeleteOption DEFAULT = NewBuilder().Build();

        public static Builder NewBuilder() {
            return new Builder();
        }

        public  class Builder {

            private ByteSequence endKey = null;
            private bool prevKV = false;

            public Builder() {
            }

            /**
             * Set the end key of the delete request. If it is set, the delete request will delete the keys
             * from <i>key</i> to <i>endKey</i> (exclusive).
             *
             * <p>If end key is '\0', the range is all keys >=
             * key.
             *
             * <p>If the end key is one bit larger than the given key, then it deletes all keys with
             * the prefix (the given key).
             *
             * <p>If both key and end key are '\0', it deletes all keys.
             *
             * @param endKey end key
             * @return builder
             */
            public Builder WithRange(ByteSequence endKey) {
                this.endKey = endKey;
                return this;
            }

            /**
             * Enables 'Delete' requests to delete all the keys with matching prefix.
             *
             * <p>You should pass the key that is passed into
             * {@link KV#delete(ByteSequence) KV.delete} method
             * into this method as the given key.
             *
             * @param prefix the common prefix of all the keys that you want to delete
             * @return builder
             */
            public Builder WithPrefix(ByteSequence prefix) {
               
                ByteSequence prefixEnd = OptionsUtil.PrefixEndOf(prefix);
                this.WithRange(prefixEnd);
                return this;
            }

            /**
             * Get the previous key/value pairs before deleting them.
             *
             * @param prevKV flag to get previous key/value pairs before deleting them.
             * @return builder
             */
            public Builder WithPrevKV(bool prevKV) {
                this.prevKV = prevKV;
                return this;
            }

            public DeleteOption Build() {
                return new DeleteOption(endKey, prevKV);
            }

        }

        private   ByteSequence endKey;
        private bool prevKV;

        private DeleteOption( ByteSequence endKey, bool prevKV) {
            this.endKey = endKey;
            this.prevKV = prevKV;
        }

        public  ByteSequence EndKey {
            get { return endKey; }
        }

        /**
         * Whether to get the previous key/value pairs before deleting them.
         *
         * @return true if get the previous key/value pairs before deleting them, otherwise false.
         */
        public bool IsPrevKV {
            get { return prevKV; }
        }
    }
}