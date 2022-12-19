using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Infrastructure.Identity
{
    public class JwtConfig
    {
         public JwtConfig(string key, string issuer)
        {
            Key = key;
            Issuer = issuer;
        }
        public string Key { get; init; }
        public string Issuer { get; init; }
    }
}
