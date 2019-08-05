using NPoco;
using System.Configuration;
using System.Data.SqlClient;

namespace Intercorp.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected IDatabase GetDbFactory()
        {
            var connectionString = ConfigurationManager.AppSettings["IntercorpDb"];
            return new Database(connectionString, DatabaseType.SqlServer2012, SqlClientFactory.Instance);
        }
    }
}
