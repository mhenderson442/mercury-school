using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MercurySchool.Functions
{
    public static class DataUtilities
    {
        public static string GetSqlConnectionString(IConfiguration configuration)
        {

            if (configuration is null)
            {
                throw new System.ArgumentNullException(nameof(configuration));
            }

            var dataSource = configuration.GetValue<string>("DataSource");
            var initialCatalog = configuration.GetValue<string>("InitialCatalog");
            var userId = configuration.GetValue<string>("UserID");
            var password = configuration.GetValue<string>("Password");

            var sqlConnectionString = new SqlConnectionStringBuilder
            {
                DataSource = dataSource,
                InitialCatalog = initialCatalog,
                Encrypt = true,
                UserID = userId,
                Password = password

            }.ConnectionString;

            return sqlConnectionString;
        }
    }
}