using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class UserAddressClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int UserId { get; set; }
        [DataMember(Order = 3)]
        public string AddressName { get; set; }
        [DataMember(Order = 4)]
        public string AddressDescription { get; set; }
        [DataMember(Order = 5)]
        public double Latitude { get; set; }
        [DataMember(Order = 6)]
        public double Longitude { get; set; }
        [DataMember(Order = 7)]
        public int CountryId { get; set; }
        [DataMember(Order = 7)]
        public int GovernorateId { get; set; }
        [DataMember(Order = 8)]
        public int CityId { get; set; }
        [DataMember(Order = 8)]
        public int LocationId { get; set; }
        [DataMember(Order = 9)]
        public string BlockNo { get; set; }
        [DataMember(Order = 10)]
        public string Street { get; set; }
        [DataMember(Order = 11)]
        public string Building { get; set; }
        [DataMember(Order = 12)]
        public string Floor { get; set; }
        [DataMember(Order = 13)]
        public string ApartmentNo { get; set; }
        [DataMember(Order = 15)]
        public string AddressNote { get; set; }
        [DataMember(Order = 16)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 14)]
        public string CountryEnglishName { get; set; }
        [DataMember(Order = 14)]
        public string GovernorateArabicName { get; set; }
        [DataMember(Order = 14)]
        public string GovernorateEnglishName { get; set; }
        [DataMember(Order = 14)]
        public string CityArabicName { get; set; }
        [DataMember(Order = 14)]
        public string CityEnglishName { get; set; }
        [DataMember(Order = 14)]
        public string LocationArabicName { get; set; }
        [DataMember(Order = 14)]
        public string LocationEnglishName { get; set; }
        [DataMember(Order = 15)]
        public double Order { get; set; }

        [DataMember(Order = 17)]
        public double DeliveryCost { get; set; }
        [DataMember(Order = 18)]
        public bool HasImmediateDelivdery { get; set; }
        [DataMember(Order = 19)]
        public double ImmediateDeliveryCost { get; set; }


        public UserAddressClass PopulateUserAddress(string[] fieldNames, SqlDataReader reader)
        {
            var userAddress = new UserAddressClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    userAddress.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    userAddress.UserId = Convert.ToInt32(reader["UserId"]);

            if (fieldNames.Contains("AddressName"))
                if (!Convert.IsDBNull(reader["AddressName"]))
                    userAddress.AddressName = reader["AddressName"].ToString();

            if (fieldNames.Contains("AddressDescription"))
                if (!Convert.IsDBNull(reader["AddressDescription"]))
                    userAddress.AddressDescription = reader["AddressDescription"].ToString();

            if (fieldNames.Contains("Latitude"))
                if (!Convert.IsDBNull(reader["Latitude"]))
                    userAddress.Latitude = (double)reader["Latitude"];

            if (fieldNames.Contains("Longitude"))
                if (!Convert.IsDBNull(reader["Longitude"]))
                    userAddress.Longitude = (double)reader["Longitude"];

            if (fieldNames.Contains("CountryId"))
                if (!Convert.IsDBNull(reader["CountryId"]))
                    userAddress.CountryId = Convert.ToInt32(reader["CountryId"]);

            if (fieldNames.Contains("GovernorateId"))
                if (!Convert.IsDBNull(reader["GovernorateId"]))
                    userAddress.GovernorateId = Convert.ToInt32(reader["GovernorateId"]);

            if (fieldNames.Contains("CityId"))
                if (!Convert.IsDBNull(reader["CityId"]))
                    userAddress.CityId = Convert.ToInt32(reader["CityId"]);

            if (fieldNames.Contains("LocationId"))
                if (!Convert.IsDBNull(reader["LocationId"]))
                    userAddress.LocationId = Convert.ToInt32(reader["LocationId"]);

            if (fieldNames.Contains("BlockNo"))
                if (!Convert.IsDBNull(reader["BlockNo"]))
                    userAddress.BlockNo = reader["BlockNo"].ToString();

            if (fieldNames.Contains("Street"))
                if (!Convert.IsDBNull(reader["Street"]))
                    userAddress.Street = reader["Street"].ToString();

            if (fieldNames.Contains("Building"))
                if (!Convert.IsDBNull(reader["Building"]))
                    userAddress.Building = reader["Building"].ToString();

            if (fieldNames.Contains("Floor"))
                if (!Convert.IsDBNull(reader["Floor"]))
                    userAddress.Floor = reader["Floor"].ToString();

            if (fieldNames.Contains("ApartmentNo"))
                if (!Convert.IsDBNull(reader["ApartmentNo"]))
                    userAddress.ApartmentNo = reader["ApartmentNo"].ToString();

            if (fieldNames.Contains("AddressNote"))
                if (!Convert.IsDBNull(reader["AddressNote"]))
                    userAddress.AddressNote = reader["AddressNote"].ToString();

            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    userAddress.CountryArabicName = reader["CountryArabicName"].ToString();

            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    userAddress.CountryEnglishName = reader["CountryEnglishName"].ToString();

            if (fieldNames.Contains("GovernorateArabicName"))
                if (!Convert.IsDBNull(reader["GovernorateArabicName"]))
                    userAddress.GovernorateArabicName = reader["GovernorateArabicName"].ToString();

            if (fieldNames.Contains("GovernorateEnglishName"))
                if (!Convert.IsDBNull(reader["GovernorateEnglishName"]))
                    userAddress.GovernorateEnglishName = reader["GovernorateEnglishName"].ToString();

            if (fieldNames.Contains("CityArabicName"))
                if (!Convert.IsDBNull(reader["CityArabicName"]))
                    userAddress.CityArabicName = reader["CityArabicName"].ToString();

            if (fieldNames.Contains("CityEnglishName"))
                if (!Convert.IsDBNull(reader["CityEnglishName"]))
                    userAddress.CityEnglishName = reader["CityEnglishName"].ToString();

            if (fieldNames.Contains("LocationArabicName"))
                if (!Convert.IsDBNull(reader["LocationArabicName"]))
                    userAddress.LocationArabicName = reader["LocationArabicName"].ToString();

            if (fieldNames.Contains("LocationEnglishName"))
                if (!Convert.IsDBNull(reader["LocationEnglishName"]))
                    userAddress.LocationEnglishName = reader["LocationEnglishName"].ToString();

            if (fieldNames.Contains("DeliveryCost"))
                if (!Convert.IsDBNull(reader["DeliveryCost"]))
                    userAddress.DeliveryCost = (double)reader["DeliveryCost"];

            if (fieldNames.Contains("HasImmediateDelivdery"))
                if (!Convert.IsDBNull(reader["HasImmediateDelivdery"]))
                    userAddress.HasImmediateDelivdery = (bool)reader["HasImmediateDelivdery"];

            if (fieldNames.Contains("ImmediateDeliveryCost"))
                if (!Convert.IsDBNull(reader["ImmediateDeliveryCost"]))
                    userAddress.ImmediateDeliveryCost = (double)reader["ImmediateDeliveryCost"];


            return userAddress;
        }
    }
}