using System;
using System.Collections.Generic;
using System.Text;

namespace etcdclientv3.data
{
 public   interface IResponse
    {
        IHeader GetHeader();
    }
}
