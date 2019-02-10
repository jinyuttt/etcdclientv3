
using etcdclientv3.data;

namespace etcdclientv3.options
{
    public class GetOption
    {

        public static GetOption DEFAULT = NewBuilder().build();

        /**
         * Create a builder to construct option for get operation.
         *
         * @return builder
         */
        public static Builder NewBuilder()
        {
            return new Builder();
        }

        public class Builder
        {

            private long limit = 0L;
            private long revision = 0L;
            private SortOrder sortOrder = SortOrder.NONE;
            private SortTarget sortTarget = SortTarget.KEY;
            private bool serializable = false;
            private bool keysOnly = false;
            private bool countOnly = false;
            private ByteSequence endKey = null;

            public Builder()
            {
            }

            /**
             * Limit the number of keys to return for a get request. By default is 0 - no limitation.
             *
             * @param limit the maximum number of keys to return for a get request.
             * @return builder
             */
            public Builder WithLimit(long limit)
            {
                this.limit = limit;
                return this;
            }

            /**
             * Provide the revision to use for the get request.
             *
             * <p>If the revision is less or equal to zero, the get is over the newest key-value store.
             *
             * <p>If the revision has been compacted, ErrCompacted is returned as a response.
             *
             * @param revision the revision to get.
             * @return builder
             */
            public Builder WithRevision(long revision)
            {
                this.revision = revision;
                return this;
            }

            /**
             * Sort the return key value pairs in the provided <i>order</i>.
             *
             * @param order order to sort the returned key value pairs.
             * @return builder
             */
            public Builder WithSortOrder(SortOrder order)
            {
                this.sortOrder = order;
                return this;
            }

            /**
             * Sort the return key value pairs in the provided <i>field</i>.
             *
             * @param field field to sort the key value pairs by the provided
             * @return builder
             */
            public Builder WithSortField(SortTarget field)
            {
                this.sortTarget = field;
                return this;
            }

            /**
             * Set the get request to be a serializable get request.
             *
             * <p>Get requests are linearizable by
             * default. For better performance, a serializable get request is served locally without needing
             * to reach consensus with other nodes in the cluster.
             *
             * @param serializable is the get request a serializable get request.
             * @return builder
             */
            public Builder WithSerializable(bool serializable)
            {
                this.serializable = serializable;
                return this;
            }

            /**
             * Set the get request to only return keys.
             *
             * @param keysOnly flag to only return keys
             * @return builder
             */
            public Builder WithKeysOnly(bool keysOnly)
            {
                this.keysOnly = keysOnly;
                return this;
            }

            /**
             * Set the get request to only return count of the keys.
             *
             * @param countOnly flag to only return count of the keys
             * @return builder
             */
            public Builder WithCountOnly(bool countOnly)
            {
                this.countOnly = countOnly;
                return this;
            }

            /**
             * Set the end key of the get request. If it is set, the get request will return the keys from
             * <i>key</i> to <i>endKey</i> (exclusive).
             *
             * <p>If end key is '\0', the range is all keys >= key.
             *
             * <p>If the end key is one bit larger than the given key, then it gets all keys with the prefix
             * (the given key).
             *
             * <p>If both key and end key are '\0', it returns all keys.
             *
             * @param endKey end key
             * @return builder
             */
            public Builder WithRange(ByteSequence endKey)
            {
                this.endKey = endKey;
                return this;
            }

            /**
             * Enables 'Get' requests to obtain all the keys with matching prefix.
             *
             * <p>You should pass the key that is passed into
             * {@link KV#get(ByteSequence) KV.get} method
             * into this method as the given key.
             *
             * @param prefix the common prefix of all the keys that you want to get
             * @return builder
             */
            public Builder WithPrefix(ByteSequence prefix)
            {

                ByteSequence prefixEnd = OptionsUtil.PrefixEndOf(prefix);
                this.WithRange(prefixEnd);
                return this;
            }

            public GetOption build()
            {
                return new GetOption(endKey, limit, revision, sortOrder, sortTarget, serializable, keysOnly,
                    countOnly);
            }

        }

        private readonly ByteSequence endKey;
        private readonly long limit;
        private readonly long revision;
        private readonly SortOrder sortOrder;
        private readonly SortTarget sortTarget;
        private readonly bool serializable;
        private readonly bool keysOnly;
        private readonly bool countOnly;

        private GetOption(ByteSequence endKey, long limit, long revision,
            SortOrder sortOrder, SortTarget sortTarget, bool serializable, bool keysOnly,
            bool countOnly)
        {
            this.endKey = endKey;
            this.limit = limit;
            this.revision = revision;
            this.sortOrder = sortOrder;
            this.sortTarget = sortTarget;
            this.serializable = serializable;
            this.keysOnly = keysOnly;
            this.countOnly = countOnly;
        }

        /**
         * Get the maximum number of keys to return for a get request.
         *
         * @return the maximum number of keys to return.
         */
        public long GetLimit()
        {
            return this.limit;
        }

        public ByteSequence GetEndKey()
        {
            return this.endKey;
        }

        public long GetRevision()
        {
            return revision;
        }

        public SortOrder GetSortOrder()
        {
            return sortOrder;
        }

        public SortTarget GetSortField()
        {
            return sortTarget;
        }

        public bool isSerializable()
        {
            return serializable;
        }

        public bool IsKeysOnly()
        {
            return keysOnly;
        }

        public bool IsCountOnly()
        {
            return countOnly;
        }

        public enum SortOrder
        {
            NONE,
            ASCEND,
            DESCEND,
        }

        public enum SortTarget
        {
            KEY,
            VERSION,
            CREATE,
            MOD,
            VALUE,
        }
    }
}
