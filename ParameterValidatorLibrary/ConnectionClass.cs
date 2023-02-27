using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ParameterValidatorLibrary
{
    public class ConnectionClass
    {
        public static SqlConnection Con_instance = null;
        //TODO: Handle change for connection string from ConnectionString
        public static string DatabaseName = string.Empty;

        // Lock synchronization object
        private static object syncLock = new object();
        public static SqlConnection GetDataConnection()
        {



            if (Con_instance == null)
            {
                lock (syncLock)
                {
                    if (Con_instance == null)
                    {
                        return new SqlConnection(WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString);

                        #region TestingRegion
                        //Get database name
                        //IDbConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
                        //var dbName = connection.Database;
                        //if (dbName.ToLower() != "null")
                        //{
                        //   return new SqlConnection(WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
                        //} 
                        #endregion

                        //New Added
                        //DatabaseName = "PointsSystemTest";
                        //int index = WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString.IndexOf("Catalog=") + 1;
                        //string piece = WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString.Substring(index);
                        //int indexOfComma = piece.IndexOf(";") + 1;
                        //string CatalogName = piece.Substring(0, indexOfComma);

                        //if (CatalogName == null)
                        //   CatalogName = DatabaseName;

                        //Save to config file 
                        //var configuration = WebConfigurationManager.OpenWebConfiguration("~");
                        //var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
                        //section.ConnectionStrings["Connection"].ConnectionString = "Data Source=...";
                        //configuration.Save();



                        //return new SqlConnection(Con_String_p1 + CatalogName + Con_String_p2);

                        //return new SqlConnection(WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString);

                    }

                }
            }

            return Con_instance;
        }

        public static void CloseConnection(SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch
            {

            }
        }

        public static SqlDataReader ExecuteStoredProcedure(string ProcedureName, bool isAPITestingMode, List<SqlParameter> Params, out SqlConnection connection)
        {
            SqlDataReader reader;
            connection = ConnectionClass.GetDataConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = ProcedureName
            };

            cmd.Parameters.Add(new SqlParameter("LoggedUser", "7"));
            cmd.Parameters.AddRange(Params.ToArray());

            reader = cmd.ExecuteReader();


            return reader;
        }
    }
}
