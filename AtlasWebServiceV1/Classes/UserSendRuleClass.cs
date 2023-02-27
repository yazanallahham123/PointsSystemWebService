using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class UserSendRuleClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int UserId { get; set; }
        [DataMember(Order = 3)]
        public string Username { get; set; }
        [DataMember(Order = 4)]
        public string FullName { get; set; }
        [DataMember(Order = 5)]
        public int UserTypeId { get; set; }
        [DataMember(Order = 6)]
        public string UserTypeName { get; set; }
        [DataMember(Order = 7)]
        public int Order { get; set; }


        public UserSendRuleClass PopulateUserSendRule(string[] fieldNames, SqlDataReader reader)
        {
            var userSendRule = new UserSendRuleClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    userSendRule.Id = (int)reader["Id"];

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    userSendRule.UserId = Convert.ToInt32(reader["UserId"]);

            if (fieldNames.Contains("Username"))
                if (!Convert.IsDBNull(reader["Username"]))
                    userSendRule.Username = reader["Username"].ToString();

            if (fieldNames.Contains("FullName"))
                if (!Convert.IsDBNull(reader["FullName"]))
                    userSendRule.FullName = reader["FullName"].ToString();

            if (fieldNames.Contains("UserTypeId"))
                if (!Convert.IsDBNull(reader["UserTypeId"]))
                    userSendRule.UserTypeId = Convert.ToInt32(reader["UserTypeId"]);

            if (fieldNames.Contains("UserTypeName"))
                if (!Convert.IsDBNull(reader["UserTypeName"]))
                    userSendRule.UserTypeName = reader["UserTypeName"].ToString();

            return userSendRule;
        }

    }
}