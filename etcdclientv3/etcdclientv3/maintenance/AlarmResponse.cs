using etcdclientv3.Response;
using System.Collections.Generic;

namespace etcdclientv3.maintenance
{
    public class AlarmResponse : AbstractResponse<Etcdserverpb.AlarmResponse>
    {

        private List<AlarmMember> alarms;
        private readonly object lock_obj = new object();

        public AlarmResponse(Etcdserverpb.AlarmResponse response) : base(response, response.Header)
        {
        }

        private static AlarmMember ToAlarmMember(Etcdserverpb.AlarmMember alarmMember)
        {
            AlarmType type;
            switch (alarmMember.Alarm)
            {
                case Etcdserverpb.AlarmType.None:
                    type = AlarmType.NONE;
                    break;
                case Etcdserverpb.AlarmType.Nospace:
                    type = AlarmType.NOSPACE;
                    break;
                default:
                    type = AlarmType.UNRECOGNIZED;
                    break;
            }
            return new AlarmMember(alarmMember.MemberID, type);
        }

        /**
         * returns a list of alarms associated with the alarm request.
         */
        public List<AlarmMember> GetAlarms()
        {
            if (alarms == null)
            {
                lock (lock_obj)
                {
                    if (alarms == null)
                    {
                        var pbalarms = GetResponse().Alarms;
                        alarms = new List<AlarmMember>(pbalarms.Count);
                        foreach (var m in pbalarms)
                        {
                            alarms.Add(ToAlarmMember(m));
                        }
                    }
                }
            }
            return alarms;
        }
    }
}
