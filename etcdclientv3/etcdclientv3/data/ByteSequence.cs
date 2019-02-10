using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace etcdclientv3.data
{
    public class ByteSequence
    {
       
        private  ByteString byteString;

        private ByteSequence(ByteString byteString)
        {
            this.byteString = byteString;
        }

        public ByteString GetByteString()
        {
            return this.byteString;
        }
        public byte[] GetBytes()
        {
            return byteString.ToByteArray();
        }
        public override string ToString()
        {
            return this.byteString.ToStringUtf8();
        }
        /**
         * Create new ByteSequence from a String.
         * @param source input String
         * @param charset the character set to use to transform the String into bytes
         * @return the ByteSequence
         */
        public static ByteSequence From(string source,Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(source);
            return new ByteSequence(ByteString.CopyFrom(source, encoding));
        }

        public static ByteSequence From(ByteString source)
        {
            return new ByteSequence(source);
        }

        public static ByteSequence From(byte[] source)
        {
            return new ByteSequence(ByteString.CopyFrom(source));
        }

        internal bool IsPresent
        {
            get { return false; }
        }

       
    }
}
