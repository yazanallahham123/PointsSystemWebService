using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class UserSendExceptionClass
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


        public UserSendExceptionClass PopulateUserSendException(string[] fieldNames, SqlDataReader reader)
        {
            var userSendException = new UserSendExceptionClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    userSendException.Id = (int)reader["Id"];

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    userSendException.UserId = Convert.ToInt32(reader["UserId"]);

            if (fieldNames.Contains("Username"))
                if (!Convert.IsDBNull(reader["Username"]))
                    userSendException.Username = reader["Username"].ToString();

            if (fieldNames.Contains("FullName"))
                if (!Convert.IsDBNull(reader["FullName"]))
                    userSendException.FullName = reader["FullName"].ToString();

            if (fieldNames.Contains("ForbiddenUserId"))
                if (!Convert.IsDBNull(reader["ForbiddenUserId"]))
                    userSendException.ForbiddenUserId = Convert.ToInt32(reader["ForbiddenUserId"]);

            if (fieldNames.Contains("ForbiddenUsername"))
                if (!Convert.IsDBNull(reader["ForbiddenUsername"]))
                    userSendException.ForbiddenUsername = reader["ForbiddenUsername"].ToString();

            if (fieldNames.Contains("ForbiddenFullName"))
                if (!Convert.IsDBNull(reader["ForbiddenFullName"]))
                    userSendException.ForbiddenFullName = reader["ForbiddenFullName"].ToString();

            return userSendException;
        }

    }
}