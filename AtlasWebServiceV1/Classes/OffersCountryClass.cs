using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class OffersCountryClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int CountryId { get; set; }
        [DataMember(Order = 3)]
        public int OfferId { get; set; }
        [DataMember(Order = 4)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 5)]
        public string CountryEnglishName { get; set; }
        [DataMember(Order = 6)]
        public string OfferArabicName { get; set; }
        [DataMember(Order = 7)]
        public string OfferEnglishName { get; set; }
        [DataMember(Order = 8)]
        public int Order { get; set; }

        public OffersCountryClass PopulateOfferCountry(string[] fieldNames, SqlDataReader reader)
        {
            var offerCountry = new OffersCountryClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    offerCountry.Id = (int)reader["Id"];

            if (fieldNames.Contains("CountryId"))
                if (!Convert.IsDBNull(reader["CountryId"]))
                    offerCountry.CountryId = (int)reader["CountryId"];

            if (fieldNames.Contains("OfferId"))
                if (!Convert.IsDBNull(reader["OfferId"]))
                    offerCountry.OfferId = (int)reader["OfferId"];

            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    offerCountry.CountryArabicName = reader["CountryArabicName"].ToString();

            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    offerCountry.CountryEnglishName = reader["CountryEnglishName"].ToString();

            if (fieldNames.Contains("OfferArabicName"))
                if (!Convert.IsDBNull(reader["OfferArabicName"]))
                    offerCountry.OfferArabicName = reader["OfferArabicName"].ToString();

            if (fieldNames.Contains("OfferEnglishName"))
                if (!Convert.IsDBNull(reader["OfferEnglishName"]))
                    offerCountry.OfferEnglishName = reader["OfferEnglishName"].ToString();


            return offerCountry;
        }
    }
}