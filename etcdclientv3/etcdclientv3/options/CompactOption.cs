
namespace etcdclientv3.options
{
    public class CompactOption {

        public static  CompactOption DEFAULT = newBuilder().build();

        public static Builder newBuilder() {
            return new Builder();
        }

        public  class Builder {

            private bool physical = false;

            public Builder() {
            }

            /**
             * make compact RPC call wait until
             * the compaction is physically applied to the local database
             * such that compacted entries are totally removed from the
             * backend database.
             *
             * @param physical whether the compact should wait until physically applied
             * @return builder
             */
            public Builder withCompactPhysical(bool physical) {
                this.physical = physical;
                return this;
            }

            public CompactOption build() {
                return new CompactOption(this.physical);
            }
        }

        private  bool physical;

  private CompactOption(bool physical) {
            this.physical = physical;
        }

        public bool isPhysical() {
            return physical;
        }
    }
}
