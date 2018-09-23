using System;
using System.Collections.Generic;
using System.Text;

namespace etcdclientv3.data
{
   public interface IHeader
    {

        ulong GetClusterId();

        ulong GetMemberId();

        long GetRevision();

        ulong GetRaftTerm();
    }
}
