namespace etcdclientv3.options
{
    public sealed class PutOption {

        public static  PutOption DEFAULT = newBuilder().build();
        public static Builder newBuilder() {
            return new Builder();
        }

        /**
         * Builder to construct a put option.
         */
        public  class Builder {

            private long leaseId = 0L;
            private bool prevKV = false;

            public Builder() {
            }

            /**
             * Assign a <i>leaseId</i> for a put operation. Zero means no lease.
             *
             * @param leaseId lease id to apply to a put operation
             * @return builder
             * @throws IllegalArgumentException if lease is less than zero.
             */
            public Builder withLeaseId(long leaseId) {
               // checkArgument(leaseId >= 0, "leaseId should greater than or equal to zero: leaseId=%s",
               //     leaseId);
                this.leaseId = leaseId;
                return this;
            }

            /**
             * When withPrevKV is set, put response contains previous key-value pair.
             *
             * @return builder
             */
            public Builder withPrevKV() {
                this.prevKV = true;
                return this;
            }

            /**
             * build the put option.
             *
             * @return the put option
             */
            public PutOption build() {
                return new PutOption(this.leaseId, this.prevKV);
            }

        }

        private  long leaseId;
        private  bool prevKV;

  private PutOption(long leaseId, bool prevKV) {
            this.leaseId = leaseId;
            this.prevKV = prevKV;
        }

        /**
         * Get the lease id.
         *
         * @return the lease id
         */
        public long getLeaseId() {
            return this.leaseId;
        }

        /**
         * Get the previous KV.
         *
         * @return the prevKV
         */
        public bool getPrevKV() {
            return this.prevKV;
        }
    }
}
