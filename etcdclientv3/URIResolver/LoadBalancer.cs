using System;
using System.Collections.Generic;
using System.Text;

namespace URIResolver
{
   public abstract class LoadBalancer
    {
        public  static LoadBalancer Factory()
        {
         return LoadBalancer.NewLoadBalancer();
        }

        private static LoadBalancer NewLoadBalancer()
        {
            return null;
        }
    }
}
