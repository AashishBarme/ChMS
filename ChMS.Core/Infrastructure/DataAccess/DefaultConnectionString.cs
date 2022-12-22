using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Infrastructure.DataAccess
{
    public class DefaultConnectionString : IConnectionString
    {

        private string _connectionString;
        public DefaultConnectionString()
        {

            //_connectionString ="server=localhost;userid=admin;password=admin; database=project_management_system;";

        }
        public string GetConnectionString()
        {
            return _connectionString;
        }

        public void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
