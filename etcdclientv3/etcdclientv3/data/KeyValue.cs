using System;
using System.Collections.Generic;
using System.Text;

namespace etcdclientv3.data
{
  public  class KeyValue
    {
        private Mvccpb.KeyValue kv;

        public KeyValue(Mvccpb.KeyValue kv)
        {
            this.kv = kv;
        }

        public ByteSequence GetKey()
        {
            return ByteSequence.from(kv.Key);
        }

        public ByteSequence GetValue()
        {
            return ByteSequence.from(kv.Value);
        }

        public long GetCreateRevision()
        {
            return kv.Version;
        }

        public long GetModRevision()
        {
            return kv.ModRevision;
        }

        public long GetVersion()
        {
            return kv.Version;
        }

        public long GetLease()
        {
            return kv.Lease;
        }
    }
}
