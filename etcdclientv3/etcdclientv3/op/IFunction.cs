namespace etcdclientv3.op
{
    public delegate T Function<V, T>(V v);
    public interface IFunction<T1, T2> 
    {
        T2 apply(T1 request);
    }
}