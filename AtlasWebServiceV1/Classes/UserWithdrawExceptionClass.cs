using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class UserWithdrawExceptionClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int UserId { get; set; }
        [DataMember(Order = 3)]
        public int ForbiddenUserId { get; set; }
        [DataMember(Order = 4)]
        public string Username { get; set; }
        [DataMember(Order = 5)]
        public string FullName { get; set; }
        [DataMember(Order = 6)]
        public string ForbiddenUsername { get; set; }
        [DataMember(Order = 7)]
        public string ForbiddenFullName { get; set; }
        [DataMember(Order = 8)]
        public int Order { get; set; }


        public UserWithdrawExceptionClass PopulateUserWithdrawException(string[] fieldNames, SqlDataReader reader)
        {
            var userWithdrawException = new UserWithdrawExceptionClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    userWithdrawException.Id = (int)reader["Id"];

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    userWithdrawException.UserId = Convert.ToInt32(reader["UserId"]);

            if (fieldNames.Contains("Username"))
                if (!Convert.IsDBNull(reader["Username"]))
                    userWithdrawException.Username = reader["Username"].ToString();

            if (fieldNames.Contains("FullName"))
                if (!Convert.IsDBNull(reader["FullName"]))
                    userWithdrawException.FullName = reader["FullName"].ToString();

            if (fieldNames.Contains("ForbiddenUserId"))
                if (!Convert.IsDBNull(reader["ForbiddenUserId"]))
                    userWithdrawException.ForbiddenUserId = Convert.ToInt32(reader["ForbiddenUserId"]);

            if (fieldNames.Contains("ForbiddenUsername"))
                if (!Convert.IsDBNull(reader["ForbiddenUsername"]))
                    userWithdrawException.ForbiddenUsername = reader["ForbiddenUsername"].ToString();

            if (fieldNames.Contains("ForbiddenFullName"))
                if (!Convert.IsDBNull(reader["ForbiddenFullName"]))
                    userWithdrawException.ForbiddenFullName = reader["ForbiddenFullName"].ToString();

            return userWithdrawException;
        }

    }
}