using etcdclientv3.data;

namespace etcdclientv3.options
{
    public class WatchOption
    {

        public static WatchOption DEFAULT = NewBuilder().Build();

        /**
         * Create a builder to construct option for watch operation.
         *
         * @return builder
         */
        public static Builder NewBuilder()
        {
            return new Builder();
        }

        public class Builder
        {

            private long revision = 0L;
            private ByteSequence endKey = null;
            private bool prevKV = false;
            private bool progressNotify = false;
            private bool noPut = false;
            private bool noDelete = false;

            public Builder()
            {
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
             * When prevKV is set, created watcher gets the previous KV before the event happens,
             * if the previous KV is not compacted.
             *
             * @return builder
             */
            public Builder WithPrevKV(bool prevKV)
            {
                this.prevKV = prevKV;
                return this;
            }

            /**
             * When progressNotify is set, the watch server send periodic progress updates.
             * Progress updates have zero events in WatchResponse.
             *
             * @return builder
             */
            public Builder WithProgressNotify(bool progressNotify)
            {
                this.progressNotify = progressNotify;
                return this;
            }

            /**
             * filter out put event in server side.
             */
            public Builder WithNoPut(bool noPut)
            {
                this.noPut = noPut;
                return this;
            }

            /**
             * filter out delete event in server side.
             */
            public Builder withNoDelete(bool noDelete)
            {
                this.noDelete = noDelete;
                return this;
            }

            /**
             * Enables watch all the keys with matching prefix.
             *
             * @param prefix the common prefix of all the keys that you want to watch
             * @return builder
             */
            public Builder WithPrefix(ByteSequence prefix)
            {
                ByteSequence prefixEnd = OptionsUtil.PrefixEndOf(prefix);
                this.WithRange(prefixEnd);
                return this;
            }

            public WatchOption Build()
            {
                return new WatchOption(
                    endKey,
                    revision,
                    prevKV,
                    progressNotify,
                    noPut,
                    noDelete);
            }

        }

        private ByteSequence endKey;
        private long revision;
        private bool prevKV;
        private bool progressNotify;
        private bool noPut;
        private bool noDelete;

        private WatchOption(ByteSequence endKey,
            long revision,
            bool prevKV,
            bool progressNotify,
            bool noPut,
            bool noDelete)
        {
            this.endKey = endKey;
            this.revision = revision;
            this.prevKV = prevKV;
            this.progressNotify = progressNotify;
            this.noPut = noPut;
            this.noDelete = noDelete;
        }

        public ByteSequence EndKey
        {
            get { return endKey; }
        }

        public long Revision
        {
            get { return revision; }
        }

        /**
         * Whether created watcher gets the previous KV before the event happens.
         */
        public bool IsPrevKV
        {
            get { return prevKV; }
        }

        /**
         * Whether watcher server send  periodic progress updates.
         *
         * @return if true, watcher server should send periodic progress updates.
         */
        public bool IsProgressNotify
        {
            get { return progressNotify; }
        }

        /**
         * Whether filter put event in server side.
         *
         * @return if true, filter put event in server side
         */
        public bool IsNoPut
        {
            get { return noPut; }
        }

        /**
         * Whether filter delete event in server side.
         *
         * @return if true, filter delete event in server side
         */
        public bool IsNoDelete
        {
            get { return noDelete; }
        }
    }
}
