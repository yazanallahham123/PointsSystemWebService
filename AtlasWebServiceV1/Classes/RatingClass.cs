using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class RatingClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int UserId { get; set; }
        [DataMember(Order = 3)]
        public int ReferenceId { get; set; }
        [DataMember(Order = 4)]
        public double RatingValue { get; set; }
        [DataMember(Order = 5)]
        public int RatingTypeId { get; set; }
        [DataMember(Order = 6)]
        public string RatingArabicName { get; set; }
        [DataMember(Order = 7)]
        public string RatingEnglishName { get; set; }
        [DataMember(Order = 8)]
        public string DeliveryUserFullName { get; set; }
        [DataMember(Order = 9)]
        public string DeliveryUserEmployeeCode { get; set; }
        [DataMember(Order = 10)]
        public string DeliveryUserMobileNumber { get; set; }
        [DataMember(Order = 11)]
        public int Order { get; set; }
        public RatingClass PopulateRating(string[] fieldNames, SqlDataReader reader)
        {
            var rating = new RatingClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    rating.Id = (int)reader["Id"];

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    rating.UserId = (int)reader["UserId"];

            if (fieldNames.Contains("ReferenceId"))
                if (!Convert.IsDBNull(reader["ReferenceId"]))
                    rating.ReferenceId = (int)reader["ReferenceId"];

            if (fieldNames.Contains("RatingValue"))
                if (!Convert.IsDBNull(reader["RatingValue"]))
                    rating.RatingValue = (double)reader["RatingValue"];

            if (fieldNames.Contains("RatingArabicName"))
                if (!Convert.IsDBNull(reader["RatingArabicName"]))
                    rating.RatingArabicName = reader["RatingArabicName"].ToString();

            if (fieldNames.Contains("RatingEnglishName"))
                if (!Convert.IsDBNull(reader["RatingEnglishName"]))
                    rating.RatingEnglishName = reader["RatingEnglishName"].ToString();

            if (fieldNames.Contains("DeliveryUserFullName"))
                if (!Convert.IsDBNull(reader["DeliveryUserFullName"]))
                    rating.DeliveryUserFullName = reader["DeliveryUserFullName"].ToString();

            if (fieldNames.Contains("DeliveryUserEmployeeCode"))
                if (!Convert.IsDBNull(reader["DeliveryUserEmployeeCode"]))
                    rating.DeliveryUserEmployeeCode = reader["DeliveryUserEmployeeCode"].ToString();

            if (fieldNames.Contains("DeliveryUserMobileNumber"))
                if (!Convert.IsDBNull(reader["DeliveryUserMobileNumber"]))
                    rating.DeliveryUserMobileNumber = reader["DeliveryUserMobileNumber"].ToString();

            return rating;
        }
    }
}