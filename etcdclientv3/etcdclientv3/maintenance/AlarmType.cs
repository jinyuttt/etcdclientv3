namespace etcdclientv3.maintenance
{
    public enum AlarmType
    {
        NONE, // default, used to query if any alarm is active
        NOSPACE, // space quota is exhausted
        UNRECOGNIZED,
    }
}
