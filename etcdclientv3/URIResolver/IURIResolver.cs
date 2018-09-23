using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace URIResolver
{
    interface IURIResolver
    {
         int Priority();
         bool Supports(Uri uri);
         List<SocketAddress> Resolve(Uri uri);

    }
}
