using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class UserTypeWithdrawRuleClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int UserTypeId { get; set; }
        [DataMember(Order = 3)]
        public int FromUserTypeId { get; set; }
        [DataMember(Order = 4)]
        public string UserTypeName { get; set; }
        [DataMember(Order = 5)]
        public string FromUserTypeName { get; set; }
        [DataMember(Order = 6)]
        public int Order { get; set; }


        public UserTypeWithdrawRuleClass PopulateUserTypeWithdrawRule(string[] fieldNames, SqlDataReader reader)
        {
            var userTypeWithdrawRule = new UserTypeWithdrawRuleClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    userTypeWithdrawRule.Id = (int)reader["Id"];

            if (fieldNames.Contains("UserTypeId"))
                if (!Convert.IsDBNull(reader["UserTypeId"]))
                    userTypeWithdrawRule.UserTypeId = Convert.ToInt32(reader["UserTypeId"]);

            if (fieldNames.Contains("FromUserTypeId"))
                if (!Convert.IsDBNull(reader["FromUserTypeId"]))
                    userTypeWithdrawRule.FromUserTypeId = Convert.ToInt32(reader["FromUserTypeId"]);

            if (fieldNames.Contains("UserTypeName"))
                if (!Convert.IsDBNull(reader["UserTypeName"]))
                    userTypeWithdrawRule.UserTypeName = reader["UserTypeName"].ToString();

            if (fieldNames.Contains("FromUserTypeName"))
                if (!Convert.IsDBNull(reader["FromUserTypeName"]))
                    userTypeWithdrawRule.FromUserTypeName = reader["FromUserTypeName"].ToString();

            return userTypeWithdrawRule;
        }
    }
}