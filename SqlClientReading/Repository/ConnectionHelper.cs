using Microsoft.Data.SqlClient;

namespace SqlClientReading.Repository
{
    public class ConnectionHelper
    {
        /// <summary>
        /// Makes a connection string for the local db server and the Chinook DB
        /// </summary>
        /// <returns>ConnectionString</returns>
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder connectStringBuilder = new SqlConnectionStringBuilder();
            connectStringBuilder.DataSource = "n-no-01-03-5598\\SQLEXPRESS";
            connectStringBuilder.InitialCatalog = "Chinook";
            connectStringBuilder.IntegratedSecurity = true;
            connectStringBuilder.TrustServerCertificate = true;
            return connectStringBuilder.ConnectionString;
        }
    }
}