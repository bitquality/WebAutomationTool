using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.DAL
{
    public class ConnectionStringProvider
    {
        public static string ConnectToSqlServer(string hostServer=".", string catalogDbName= "BetaTestAutomationDB", string user="", string pass="", bool winAuth=true)
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = hostServer,
                InitialCatalog = catalogDbName,
                PersistSecurityInfo = true,
                IntegratedSecurity = winAuth,
                MultipleActiveResultSets = true,

                UserID = user,
                Password = pass,
            };

            // assumes a connectionString name in .config of MyDbEntities
            var entityConnectionStringBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sqlBuilder.ConnectionString,
                Metadata = "res://*/",
                //Metadata = "res://*/DbModel.csdl|res://*/DbModel.ssdl|res://*/DbModel.msl",
            };

            //  //works though
            using (EntityConnection conn =
                    new EntityConnection(entityConnectionStringBuilder.ToString()))
            {
                conn.Open();
                Console.WriteLine("Just testing the connection.");
                conn.Close();
            }

            return entityConnectionStringBuilder.ConnectionString;
        }
        public static string CreateSQlConnectionString()
        {
            string providerName = "System.Data.SqlClient";
            string serverName = ".";
            string databaseName = "BetaTestAutomationDB";

            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;//means windows auhtentiation

            // Build the SqlConnection connection string.
            string sqlConnString = sqlBuilder.ToString();

            #region EntityConnectionStringBuilder code:

            //// Initialize the EntityConnectionStringBuilder.
            //EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

            ////Set the provider name.
            //entityBuilder.Provider = providerName;

            //// Set the provider-specific connection string.
            //entityBuilder.ProviderConnectionString = sqlConnString;

            //// Set the Metadata location.
            //entityBuilder.Metadata = @"res://*/AdventureWorksModel.csdl|
            //            res://*/AdventureWorksModel.ssdl|
            //            res://*/AdventureWorksModel.msl";
            //Console.WriteLine(entityBuilder.ToString());

            ////  //works though
            //using (EntityConnection conn =
            //        new EntityConnection(entityBuilder.ToString()))
            //{
            //    conn.Open();
            //    Console.WriteLine("Just testing the connection.");
            //    conn.Close();
            //}
            #endregion

            return sqlConnString;
        }
        public static string CreateSQlConnectionString(string dbPath = @"|DataDirectory|\NerdDinners.sdf")
        {
            string providerName = "System.Data.SqlClient";
            string serverName = ".";
            string databaseName = "BetaTestAutomationDB";

            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;//means windows auhtentiation

            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/AdventureWorksModel.csdl|
                        res://*/AdventureWorksModel.ssdl|
                        res://*/AdventureWorksModel.msl";
            Console.WriteLine(entityBuilder.ToString());

            //works though
            //using (EntityConnection conn =
            //        new EntityConnection(entityBuilder.ToString()))
            //        {
            //            conn.Open();
            //            Console.WriteLine("Just testing the connection.");
            //            conn.Close();
            //        }

            return entityBuilder.ToString();
        }
    }
}
