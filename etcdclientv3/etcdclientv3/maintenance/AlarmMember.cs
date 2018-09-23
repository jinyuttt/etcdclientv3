namespace etcdclientv3.maintenance
{

    public class AlarmMember
    {

        private ulong memberId;
        private AlarmType alarmType;

        public AlarmMember(ulong memberId, AlarmType alarmType)
        {
            this.memberId = memberId;
            this.alarmType = alarmType;
        }

        /**
         * returns the ID of the member associated with the raised alarm.
         */
        public ulong getMemberId()
        {
            return memberId;
        }

        /**
         * returns the type of alarm which has been raised.
         */
        public AlarmType getAlarmType()
        {
            return alarmType;
        }
    }
}
