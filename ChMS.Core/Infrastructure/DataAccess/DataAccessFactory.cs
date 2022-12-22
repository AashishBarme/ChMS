using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Infrastructure.DataAccess
{
    public class DataAccessFactory
    {
        private readonly ConnectionSettings _settings;

        public BaseRepository ReadRepository { get; private set; }
        public BaseRepository DefaultRepository { get; private set; }
        public DataAccessFactory(ConnectionSettings settings)
        {
            _settings = settings;
            SetDefaultConnection();
            SetReadConnection();
        }

        private void SetDefaultConnection()
        {
            var source = new DefaultConnectionString();
            source.SetConnectionString(_settings.DefaultConnection);
            DefaultRepository = new BaseRepository(source);
        }

        private void SetReadConnection()
        {
            var source = new DefaultConnectionString();
            source.SetConnectionString(_settings.ReadConnection);
            ReadRepository = new BaseRepository(source);
        }
    }
}
