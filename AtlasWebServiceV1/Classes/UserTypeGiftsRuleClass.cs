using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class UserTypeGiftsRuleClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int UserTypeId { get; set; }
        [DataMember(Order = 3)]
        public int ToUserTypeId { get; set; }
        [DataMember(Order = 4)]
        public string UserTypeName { get; set; }
        [DataMember(Order = 5)]
        public string ToUserTypeName { get; set; }
        [DataMember(Order = 6)]
        public int Order { get; set; }


        public UserTypeGiftsRuleClass PopulateUserTypeGiftsRule(string[] fieldNames, SqlDataReader reader)
        {
            var userTypeGiftsRule = new UserTypeGiftsRuleClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    userTypeGiftsRule.Id = (int)reader["Id"];

            if (fieldNames.Contains("UserTypeId"))
                if (!Convert.IsDBNull(reader["UserTypeId"]))
                    userTypeGiftsRule.UserTypeId = Convert.ToInt32(reader["UserTypeId"]);

            if (fieldNames.Contains("ToUserTypeId"))
                if (!Convert.IsDBNull(reader["ToUserTypeId"]))
                    userTypeGiftsRule.ToUserTypeId = Convert.ToInt32(reader["ToUserTypeId"]);

            if (fieldNames.Contains("UserTypeName"))
                if (!Convert.IsDBNull(reader["UserTypeName"]))
                    userTypeGiftsRule.UserTypeName = reader["UserTypeName"].ToString();

            if (fieldNames.Contains("ToUserTypeName"))
                if (!Convert.IsDBNull(reader["ToUserTypeName"]))
                    userTypeGiftsRule.ToUserTypeName = reader["ToUserTypeName"].ToString();

            return userTypeGiftsRule;
        }

    }
}