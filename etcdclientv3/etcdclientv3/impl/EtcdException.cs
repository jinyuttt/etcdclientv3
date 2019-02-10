namespace etcdclientv3.impl
{
    public class EtcdException 
    {
        private object iNTERNAL;
        private string v;
        private int v1;

        public EtcdException(int v1)
        {
            this.v1 = v1;
        }

        public EtcdException(object iNTERNAL, string v)
        {
            this.iNTERNAL = iNTERNAL;
            this.v = v;
        }
    }
}