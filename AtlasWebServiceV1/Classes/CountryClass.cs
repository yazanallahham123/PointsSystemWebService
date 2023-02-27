using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class CountryClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string ArabicName { get; set; }
        [DataMember(Order = 3)]
        public string EnglishName { get; set; }
        [DataMember(Order = 4)]
        public string Code { get; set; }
        [DataMember(Order = 5)]
        public bool ShowInSignUp { get; set; }

        [DataMember(Order = 7)]
        public int Order { get; set; }
        [DataMember(Order = 8)]
        public int CountryCode { get; set; }

        [DataMember(Order = 3)]
        public string PolicyArabicTitle { get; set; }
        [DataMember(Order = 3)]
        public string PolicyEnglishTitle { get; set; }
        [DataMember(Order = 3)]
        public string PolicyArabicDescription { get; set; }
        [DataMember(Order = 3)]
        public string PolicyEnglishDescription { get; set; }
        [DataMember(Order = 8)]
        public int PhoneDigitsCount { get; set; }
        [DataMember(Order = 8)]
        public string PhoneSuffixes { get; set; }
        [DataMember(Order = 8)]
        public string SupportPhoneNumber { get; set; }
        public CountryClass PopulateCountry(string[] fieldNames, SqlDataReader reader)
        {
            var country = new CountryClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    country.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    country.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    country.EnglishName = reader["EnglishName"].ToString();

            if (fieldNames.Contains("Code"))
                if (!Convert.IsDBNull(reader["Code"]))
                    country.Code = reader["Code"].ToString();

            if (fieldNames.Contains("ShowInSignUp"))
                if (!Convert.IsDBNull(reader["ShowInSignUp"]))
                    country.ShowInSignUp = Convert.ToBoolean(reader["ShowInSignUp"]);

            if (fieldNames.Contains("CountryCode"))
                if (!Convert.IsDBNull(reader["CountryCode"]))
                    country.CountryCode = Convert.ToInt32(reader["CountryCode"]);

            if (fieldNames.Contains("PolicyArabicTitle"))
                if (!Convert.IsDBNull(reader["PolicyArabicTitle"]))
                    country.PolicyArabicTitle = reader["PolicyArabicTitle"].ToString();

            if (fieldNames.Contains("PolicyEnglishTitle"))
                if (!Convert.IsDBNull(reader["PolicyEnglishTitle"]))
                    country.PolicyEnglishTitle = reader["PolicyEnglishTitle"].ToString();

            if (fieldNames.Contains("PolicyArabicDescription"))
                if (!Convert.IsDBNull(reader["PolicyArabicDescription"]))
                    country.PolicyArabicDescription = reader["PolicyArabicDescription"].ToString();

            if (fieldNames.Contains("PolicyEnglishDescription"))
                if (!Convert.IsDBNull(reader["PolicyEnglishDescription"]))
                    country.PolicyEnglishDescription = reader["PolicyEnglishDescription"].ToString();

            if (fieldNames.Contains("PhoneDigitsCount"))
                if (!Convert.IsDBNull(reader["PhoneDigitsCount"]))
                    country.PhoneDigitsCount = Convert.ToInt32(reader["PhoneDigitsCount"]);

            if (fieldNames.Contains("PhoneSuffixes"))
                if (!Convert.IsDBNull(reader["PhoneSuffixes"]))
                    country.PhoneSuffixes = reader["PhoneSuffixes"].ToString();

            if (fieldNames.Contains("SupportPhoneNumber"))
                if (!Convert.IsDBNull(reader["SupportPhoneNumber"]))
                    country.SupportPhoneNumber = reader["SupportPhoneNumber"].ToString();
            return country;
        }

    }
}