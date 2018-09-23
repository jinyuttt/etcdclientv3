namespace etcdclientv3.options
{
    public class LeaseOption {

        public static  LeaseOption DEFAULT = newBuilder().build();

        public static Builder newBuilder() {
            return new Builder();
        }

        public  class Builder {

            private bool attachedKeys;

            public Builder() {
            }

            /**
             * requests lease timeToLive API to return attached keys of given lease ID.
             *
             * @return builder.
             */
            public Builder withAttachedKeys() {
                this.attachedKeys = true;
                return this;
            }

            public LeaseOption build() {
                return new LeaseOption(this.attachedKeys);
            }
        }

        private bool attachedKeys;

  private LeaseOption(bool attachedKeys) {
            this.attachedKeys = attachedKeys;
        }

        public bool isAttachedKeys() {
            return attachedKeys;
        }

    }
}
