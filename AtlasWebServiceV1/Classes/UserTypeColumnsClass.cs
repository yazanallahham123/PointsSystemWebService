using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class UserTypeColumnsClass
    {
        public int UserTypeId { get; set; }

        public int UserId { get; set; }

        public string UserTypeArabicName { get; set; }

        public string UserTypeEnglishName { get; set; }

        public List<TableColumnsClass> Tables { get; set; }

        public int Order { get; set; }

        public UserTypeColumnsClass PopulateUserTypeColumns(string[] fieldNames, SqlDataReader reader)
        {
            var userTypeColumns = new UserTypeColumnsClass();
            userTypeColumns.Tables = new List<TableColumnsClass>();

            if (fieldNames.Contains("UserTypeID"))
                if (!Convert.IsDBNull(reader["UserTypeID"]))
                    userTypeColumns.UserTypeId = (int)reader["UserTypeID"];

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    userTypeColumns.UserId = (int)reader["UserId"];

            if (fieldNames.Contains("Name"))
                if (!Convert.IsDBNull(reader["Name"]))
                {
                    userTypeColumns.UserTypeArabicName = reader["Name"].ToString();
                    userTypeColumns.UserTypeEnglishName = reader["Name"].ToString();
                }

            return userTypeColumns;
        }
    }
}