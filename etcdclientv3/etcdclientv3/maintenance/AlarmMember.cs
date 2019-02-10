namespace etcdclientv3.maintenance
{

    public class AlarmMember
    {

        private readonly ulong memberId;
        private readonly AlarmType alarmType;

        public AlarmMember(ulong memberId, AlarmType alarmType)
        {
            this.memberId = memberId;
            this.alarmType = alarmType;
        }

        /**
         * returns the ID of the member associated with the raised alarm.
         */
        public ulong MemberId
        {
            get { return memberId; }
        }

        /**
         * returns the type of alarm which has been raised.
         */
        public AlarmType AlarmType
        {
            get { return alarmType; }
        }
    }
}
