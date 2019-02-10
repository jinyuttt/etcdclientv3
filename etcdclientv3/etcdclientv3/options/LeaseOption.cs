namespace etcdclientv3.options
{
    public class LeaseOption {

        public static  LeaseOption DEFAULT = NewBuilder().Build();

        public static Builder NewBuilder() {
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
            public Builder WithAttachedKeys() {
                this.attachedKeys = true;
                return this;
            }

            public LeaseOption Build() {
                return new LeaseOption(this.attachedKeys);
            }
        }

        private bool attachedKeys;

  private LeaseOption(bool attachedKeys) {
            this.attachedKeys = attachedKeys;
        }

        public bool IsAttachedKeys {
            get { return attachedKeys; }
        }

    }
}
