using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ParameterValidatorLibrary
{
    static class Infrastructure
    {

        /// <summary>
        /// Helper Method
        /// </summary>
        /// <param name="className"></param>
        /// <param name="projectNamespace"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetClassProperties(string className, string projectNamespace = "")
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            if (String.IsNullOrWhiteSpace(projectNamespace))
                projectNamespace = Assembly.GetExecutingAssembly().GetName().Name;

            //Type CAType = Type.GetType(projectNamespace + "." + className);
            Type CAType = Type.GetType(projectNamespace + ".Classes." + className + ", " + projectNamespace + ", Version = 1.0.3.0, Culture = neutral, PublicKeyToken = null");
            //var myObj = Activator.CreateInstance(CAType);
            if (CAType == null)
                return null;


            foreach (PropertyInfo prop in CAType.GetProperties())
            {
                string propType = prop.PropertyType.ToString();
                int indexOfDot = 0;
                indexOfDot = propType.LastIndexOf('.');

                if (indexOfDot > 0)
                    propType = propType.Substring(indexOfDot + 1);


                properties.Add(prop.Name, propType);
            }

            return properties;
        }


        public static void LogHack(string operationName, string Param)
        {
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Developers_LogHack";
                    List<SqlParameter> Params = new List<SqlParameter>()
                    {
                        new SqlParameter("operationName", operationName),
                        new SqlParameter("Params", Param)
                    };

                    cmd.Parameters.AddRange(Params.ToArray());
                    cmd.ExecuteReader();
                }
            }
            catch (Exception) { }
        }

    }
}
