using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Infrastructure.DataAccess
{
    public interface IConnectionString
    {
        string GetConnectionString();
        void SetConnectionString(string connectionString);
    }
}
