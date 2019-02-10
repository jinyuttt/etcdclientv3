
using etcdclientv3.data;
using Etcdserverpb;
using System;
using static etcdclientv3.options.GetOption;

namespace etcdclientv3.options
{
    public class OptionsUtil {

        private static  byte[] NO_PREFIX_END = { 0 };

        private OptionsUtil() {
        }

        /**
         * Gets the range end of the given prefix.
         *
         * <p>The range end is the key plus one (e.g., "aa"+1 == "ab", "a\xff"+1 == "b").
         *
         * @param prefix the given prefix
         * @return the range end of the given prefix
         */
      public  static  ByteSequence PrefixEndOf(ByteSequence prefix) {
            byte[] endKey =(byte[]) prefix.GetBytes().Clone();
            for (int i = endKey.Length - 1; i >= 0; i--) {
                if (endKey[i] < 0xff) {
                    endKey[i] = (byte)(endKey[i] + 1);
                    byte[] dest= new byte[endKey.Length - i-1];
                    Array.Copy(endKey, i + 1, dest,0,dest.Length);
                    return ByteSequence.From(dest);
                }
            }

            return ByteSequence.From(NO_PREFIX_END);
        }

        /**
         * convert client SortOrder to apu SortOrder.
         */
        public static RangeRequest.Types.SortOrder ToRangeRequestSortOrder(SortOrder order) {
            switch (order) {
                case SortOrder.NONE:
                    return RangeRequest.Types.SortOrder.None;
                case SortOrder.ASCEND:
                    return RangeRequest.Types.SortOrder.Ascend;
                case SortOrder.DESCEND:
                    return RangeRequest.Types.SortOrder.Descend;
                default:
                    return RangeRequest.Types.SortOrder.None;
            }
        }

        /**
         * convert client SortTarget to apu SortTarget.
         */
        public static RangeRequest.Types.SortTarget ToRangeRequestSortTarget(SortTarget target) {
            switch (target) {
                case SortTarget.KEY:
                    return RangeRequest.Types.SortTarget.Key;
                case SortTarget.CREATE:
                    return RangeRequest.Types.SortTarget.Create;
                case SortTarget.MOD:
                    return RangeRequest.Types.SortTarget.Mod;
                case SortTarget.VALUE:
                    return RangeRequest.Types.SortTarget.Value;
                case SortTarget.VERSION:
                    return RangeRequest.Types.SortTarget.Version;
                default:
                    return RangeRequest.Types.SortTarget.Create;
            }
        }
    }
}
