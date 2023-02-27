using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class UserWithdrawRuleClass
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


        public UserWithdrawRuleClass PopulateUserWithdrawRule(string[] fieldNames, SqlDataReader reader)
        {
            var userWithdrawRule = new UserWithdrawRuleClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    userWithdrawRule.Id = (int)reader["Id"];

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    userWithdrawRule.UserId = Convert.ToInt32(reader["UserId"]);

            if (fieldNames.Contains("Username"))
                if (!Convert.IsDBNull(reader["Username"]))
                    userWithdrawRule.Username = reader["Username"].ToString();

            if (fieldNames.Contains("FullName"))
                if (!Convert.IsDBNull(reader["FullName"]))
                    userWithdrawRule.FullName = reader["FullName"].ToString();

            if (fieldNames.Contains("UserTypeId"))
                if (!Convert.IsDBNull(reader["UserTypeId"]))
                    userWithdrawRule.UserTypeId = Convert.ToInt32(reader["UserTypeId"]);

            if (fieldNames.Contains("UserTypeName"))
                if (!Convert.IsDBNull(reader["UserTypeName"]))
                    userWithdrawRule.UserTypeName = reader["UserTypeName"].ToString();

            return userWithdrawRule;
        }

    }
}