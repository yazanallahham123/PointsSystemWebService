using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class CouponClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int CouponTypeId { get; set; }
        [DataMember(Order = 3)]
        public string CouponSerial { get; set; }
        [DataMember(Order = 4)]
        public double CouponValue { get; set; }
        [DataMember(Order = 5)]
        public string StartDate { get; set; }
        [DataMember(Order = 6)]
        public bool HasEndDate { get; set; }
        [DataMember(Order = 7)]
        public string EndDate { get; set; }


        // * 1 for number 
        // * 2 from Percentage
        [DataMember(Order = 8)]
        public int CouponValueType { get; set; }


        [DataMember(Order = 9)]
        public string CouponTypeArabicName { get; set; }
        [DataMember(Order = 10)]
        public string CouponTypeEnglishName { get; set; }
        [DataMember(Order = 11)]
        public int Order { get; set; }

        public CouponClass PopulateCoupon(string[] fieldNames, SqlDataReader reader)
        {
            var coupon = new CouponClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    coupon.Id = (int)reader["Id"];

            if (fieldNames.Contains("CouponTypeId"))
                if (!Convert.IsDBNull(reader["CouponTypeId"]))
                    coupon.CouponTypeId = (int)reader["CouponTypeId"];

            if (fieldNames.Contains("CouponSerial"))
                if (!Convert.IsDBNull(reader["CouponSerial"]))
                    coupon.CouponSerial = reader["CouponSerial"].ToString();

            if (fieldNames.Contains("CouponValue"))
                if (!Convert.IsDBNull(reader["CouponValue"]))
                    coupon.CouponValue = Convert.ToDouble(reader["CouponValue"]);

            if (fieldNames.Contains("StartDate"))
                if (!Convert.IsDBNull(reader["StartDate"]))
                    coupon.StartDate = reader["StartDate"].ToString();

            if (fieldNames.Contains("HasEndDate"))
                if (!Convert.IsDBNull(reader["HasEndDate"]))
                    coupon.HasEndDate = (bool)reader["HasEndDate"];

            if (fieldNames.Contains("EndDate"))
                if (!Convert.IsDBNull(reader["EndDate"]))
                    coupon.EndDate = reader["EndDate"].ToString();


            if (fieldNames.Contains("CouponValueType"))
                if (!Convert.IsDBNull(reader["CouponValueType"]))
                    coupon.CouponValueType = (int)reader["CouponValueType"];


            if (fieldNames.Contains("CouponTypeArabicName"))
                if (!Convert.IsDBNull(reader["CouponTypeArabicName"]))
                    coupon.CouponTypeArabicName = reader["CouponTypeArabicName"].ToString();

            if (fieldNames.Contains("CouponTypeEnglishName"))
                if (!Convert.IsDBNull(reader["CouponTypeEnglishName"]))
                    coupon.CouponTypeEnglishName = reader["CouponTypeEnglishName"].ToString();

            return coupon;
        }
    }
}