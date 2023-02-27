using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Net;
using System.Text;
using System.IO;

namespace ParameterValidatorLibrary
{

    public class UserClass
    {
        public static List<string[]> headerRow = new List<string[]>()
       {
          new string[] { "رقم السطر"}
       };


        public int Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string MobileNumber { get; set; }

        public string CreateDate { get; set; }

        public int UserType { get; set; }

        public int CompanyId { get; set; }

        public bool CanGrantPoints { get; set; }

        public bool CanTakeOffers { get; set; }

        public bool Disabled { get; set; }

        public int GovernorateId { get; set; }

        public int CityId { get; set; }

        public int LocationId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }


        public double TotalSent { get; set; }

        public double TotalReceived { get; set; }

        public double PointsBalance { get; set; }

        public double TotalSent_Waiting { get; set; }

        public double TotalReceived_Waiting { get; set; }

        public string QRCode { get; set; }


        public int PositionId { get; set; }

        public int JobId { get; set; }

        public int WorkDomainId { get; set; }

        public int EducationLevelId { get; set; }


        public string Birthdate { get; set; }

        public string NickName { get; set; }
   
        public int Gender { get; set; }
    
        public int YearsOfExperience { get; set; }
      
        public int StaffCount { get; set; }

        public bool HasVocationalCertificate { get; set; }

        public string Notes { get; set; }

        public string CommercialName { get; set; }


        public string AccessToken { get; set; }

        public bool IsActive { get; set; }

        public double OrdersPoints { get; set; }

        public bool PermissionFromTemplate { get; set; }

        public int CountryId { get; set; }

        //Missing LoggedUser prop


        public int CountryCurrencyId { get; set; }

        public bool LocationValidated { get; set; }

        public bool VisibleOnMap { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }


        public double GiftsPoints { get; set; }

        public double TotalReceivedGiftsPoints { get; set; }

        public double TotalSentFromGiftsPoints { get; set; }

        //Missing UsersPermissionsTbl Class prop


        public string UserTypeName { get; set; }


        public string CompanyArabicName { get; set; }

        public string CompanyEnglishName { get; set; }


        public string LocationArabicName { get; set; }

        public string LocationEnglishName { get; set; }

        public string CityArabicName { get; set; }

        public string CityEnglishName { get; set; }

        public string GovernorateArabicName { get; set; }

        public string GovernorateEnglishName { get; set; }


        public string CountryArabicName { get; set; }

        public string CountryEnglishName { get; set; }


        public string JobArabicName { get; set; }

        public string JobEnglishName { get; set; }


        public string PositionArabicName { get; set; }

        public string PositionEnglishName { get; set; }


        public string WorkDomainArabicName { get; set; }

        public string WorkDomainEnglishName { get; set; }


        public string EducationLevelArabicName { get; set; }

        public string EducationLevelEnglishName { get; set; }


        public int LunchCount { get; set; }


        public int CurrencyId { get; set; }

        public string CurrencyArabicName { get; set; }

        public string CurrencyEnglishName { get; set; }

        public string CurrencyArabicCode { get; set; }

        public string CurrencyEnglishCode { get; set; }



        public string MobileCountryCode { get; set; }


        public int Order { get; set; }

        public bool HasOpenCart { get; set; }

        public double OrdersPointsFromGifts { get; set; }

        public string Street { get; set; }

        public string Building { get; set; }

        public string Floor { get; set; }

        public string ApartmentNo { get; set; }

        public string AddressNote { get; set; }

        public string BlockNo { get; set; }


        public int CurrentBranchId { get; set; }

        public string CurrentBranchArabicName { get; set; }

        public string CurrentBranchEnglishName { get; set; }

        public UserClass PopulateUser(string[] fieldNames, SqlDataReader reader, string prefix = "")
        {

            var user = new UserClass();

            if (fieldNames.Contains(prefix + "Id"))
                if (!Convert.IsDBNull(reader[prefix + "Id"]))
                    user.Id = Convert.ToInt32(reader[prefix + "Id"]);

            if (fieldNames.Contains(prefix + "Username"))
                if (!Convert.IsDBNull(reader[prefix + "Username"]))
                    user.Username = reader[prefix + "Username"].ToString();

            if (fieldNames.Contains(prefix + "FullName"))
                if (!Convert.IsDBNull(reader[prefix + "FullName"]))
                    user.FullName = reader[prefix + "FullName"].ToString();

            if (fieldNames.Contains(prefix + "Email"))
                if (!Convert.IsDBNull(reader[prefix + "Email"]))
                    user.Email = reader[prefix + "Email"].ToString();

            if (fieldNames.Contains(prefix + "MobileNumber"))
                if (!Convert.IsDBNull(reader[prefix + "MobileNumber"]))
                    user.MobileNumber = reader[prefix + "MobileNumber"].ToString();

            if (fieldNames.Contains(prefix + "CreateDate"))
                if (!Convert.IsDBNull(reader[prefix + "CreateDate"]))
                    user.CreateDate = reader[prefix + "CreateDate"].ToString();

            if (fieldNames.Contains(prefix + "UserType"))
                if (!Convert.IsDBNull(reader[prefix + "UserType"]))
                    user.UserType = Convert.ToInt32(reader[prefix + "UserType"]);

            if (fieldNames.Contains(prefix + "CompanyId"))
                if (!Convert.IsDBNull(reader[prefix + "CompanyId"]))
                    user.CompanyId = Convert.ToInt32(reader[prefix + "CompanyId"]);

            if (fieldNames.Contains(prefix + "CanGrantPoints"))
                if (!Convert.IsDBNull(reader[prefix + "CanGrantPoints"]))
                    user.CanGrantPoints = Convert.ToBoolean(reader[prefix + "CanGrantPoints"]);

            if (fieldNames.Contains(prefix + "CanTakeOffers"))
                if (!Convert.IsDBNull(reader[prefix + "CanTakeOffers"]))
                    user.CanTakeOffers = Convert.ToBoolean(reader[prefix + "CanTakeOffers"]);

            if (fieldNames.Contains(prefix + "Disabled"))
                if (!Convert.IsDBNull(reader[prefix + "Disabled"]))
                    user.Disabled = Convert.ToBoolean(reader[prefix + "Disabled"]);

            if (fieldNames.Contains(prefix + "GovernorateId"))
                if (!Convert.IsDBNull(reader[prefix + "GovernorateId"]))
                    user.GovernorateId = Convert.ToInt32(reader[prefix + "GovernorateId"]);

            if (fieldNames.Contains(prefix + "CityId"))
                if (!Convert.IsDBNull(reader[prefix + "CityId"]))
                    user.CityId = Convert.ToInt32(reader[prefix + "CityId"]);

            if (fieldNames.Contains(prefix + "LocationId"))
                if (!Convert.IsDBNull(reader[prefix + "LocationId"]))
                    user.LocationId = Convert.ToInt32(reader[prefix + "LocationId"]);

            if (fieldNames.Contains(prefix + "Address1"))
                if (!Convert.IsDBNull(reader[prefix + "Address1"]))
                    user.Address1 = reader[prefix + "Address1"].ToString();

            if (fieldNames.Contains(prefix + "Address2"))
                if (!Convert.IsDBNull(reader[prefix + "Address2"]))
                    user.Address2 = reader[prefix + "Address2"].ToString();

            if (fieldNames.Contains(prefix + "TotalSent"))
                if (!Convert.IsDBNull(reader[prefix + "TotalSent"]))
                    user.TotalSent = Convert.ToDouble(reader[prefix + "TotalSent"]);

            if (fieldNames.Contains(prefix + "TotalReceived"))
                if (!Convert.IsDBNull(reader[prefix + "TotalReceived"]))
                    user.TotalReceived = Convert.ToDouble(reader[prefix + "TotalReceived"]);

            if (fieldNames.Contains(prefix + "PointsBalance"))
                if (!Convert.IsDBNull(reader[prefix + "PointsBalance"]))
                    user.PointsBalance = Convert.ToDouble(reader[prefix + "PointsBalance"]);

            if (fieldNames.Contains(prefix + "TotalSent_Waiting"))
                if (!Convert.IsDBNull(reader[prefix + "TotalSent_Waiting"]))
                    user.TotalSent_Waiting = Convert.ToDouble(reader[prefix + "TotalSent_Waiting"]);

            if (fieldNames.Contains(prefix + "TotalReceived_Waiting"))
                if (!Convert.IsDBNull(reader[prefix + "TotalReceived_Waiting"]))
                    user.TotalReceived_Waiting = Convert.ToDouble(reader[prefix + "TotalReceived_Waiting"]);

            if (fieldNames.Contains(prefix + "QRCode"))
                if (!Convert.IsDBNull(reader[prefix + "QRCode"]))
                    user.QRCode = reader[prefix + "QRCode"].ToString();

            if (fieldNames.Contains(prefix + "PositionId"))
                if (!Convert.IsDBNull(reader[prefix + "PositionId"]))
                    user.PositionId = (int)reader[prefix + "PositionId"];

            if (fieldNames.Contains(prefix + "JobId"))
                if (!Convert.IsDBNull(reader[prefix + "JobId"]))
                    user.JobId = (int)reader[prefix + "JobId"]; ;

            if (fieldNames.Contains(prefix + "WorkDomainId"))
                if (!Convert.IsDBNull(reader[prefix + "WorkDomainId"]))
                    user.WorkDomainId = (int)reader[prefix + "WorkDomainId"];

            if (fieldNames.Contains(prefix + "EducationLevelId"))
                if (!Convert.IsDBNull(reader[prefix + "EducationLevelId"]))
                    user.EducationLevelId = (int)reader[prefix + "EducationLevelId"];

            if (fieldNames.Contains(prefix + "Birthdate"))
                if (!Convert.IsDBNull(reader[prefix + "Birthdate"]))
                    user.Birthdate = Convert.ToDateTime(reader[prefix + "Birthdate"]).ToString("yyyy-MM-dd");

            if (fieldNames.Contains(prefix + "NickName"))
                if (!Convert.IsDBNull(reader[prefix + "NickName"]))
                    user.NickName = reader[prefix + "NickName"].ToString();

            if (fieldNames.Contains(prefix + "Gender"))
                if (!Convert.IsDBNull(reader[prefix + "Gender"]))
                    user.Gender = (int)reader[prefix + "Gender"];

            if (fieldNames.Contains(prefix + "YearsOfExperience"))
                if (!Convert.IsDBNull(reader[prefix + "YearsOfExperience"]))
                    user.YearsOfExperience = (int)reader[prefix + "YearsOfExperience"];

            if (fieldNames.Contains(prefix + "StaffCount"))
                if (!Convert.IsDBNull(reader[prefix + "StaffCount"]))
                    user.StaffCount = (int)reader[prefix + "StaffCount"];

            if (fieldNames.Contains(prefix + "HasVocationalCertificate"))
                if (!Convert.IsDBNull(reader[prefix + "HasVocationalCertificate"]))
                    user.HasVocationalCertificate = (bool)reader[prefix + "HasVocationalCertificate"];

            if (fieldNames.Contains(prefix + "Notes"))
                if (!Convert.IsDBNull(reader[prefix + "Notes"]))
                    user.Notes = reader[prefix + "Notes"].ToString();

            if (fieldNames.Contains(prefix + "CommercialName"))
                if (!Convert.IsDBNull(reader[prefix + "CommercialName"]))
                    user.CommercialName = reader[prefix + "CommercialName"].ToString();

            if (fieldNames.Contains(prefix + "IsActive"))
                if (!Convert.IsDBNull(reader[prefix + "IsActive"]))
                    user.IsActive = (bool)reader[prefix + "IsActive"];

            if (fieldNames.Contains(prefix + "OrdersPoints"))
                if (!Convert.IsDBNull(reader[prefix + "OrdersPoints"]))
                    user.OrdersPoints = Convert.ToDouble(reader[prefix + "OrdersPoints"]);

            if (fieldNames.Contains(prefix + "PermissionFromTemplate"))
                if (!Convert.IsDBNull(reader[prefix + "PermissionFromTemplate"]))
                    user.PermissionFromTemplate = (bool)reader[prefix + "PermissionFromTemplate"];

            if (fieldNames.Contains(prefix + "CountryId"))
                if (!Convert.IsDBNull(reader[prefix + "CountryId"]))
                    user.CountryId = Convert.ToInt32(reader[prefix + "CountryId"]);

            if (fieldNames.Contains(prefix + "CountryCurrencyId"))
                if (!Convert.IsDBNull(reader[prefix + "CountryCurrencyId"]))
                    user.CountryCurrencyId = Convert.ToInt32(reader[prefix + "CountryCurrencyId"]);

            if (fieldNames.Contains(prefix + "LocationValidated"))
                if (!Convert.IsDBNull(reader[prefix + "LocationValidated"]))
                    user.LocationValidated = Convert.ToBoolean(reader[prefix + "LocationValidated"]);

            if (fieldNames.Contains(prefix + "VisibleOnMap"))
                if (!Convert.IsDBNull(reader[prefix + "VisibleOnMap"]))
                    user.VisibleOnMap = Convert.ToBoolean(reader[prefix + "VisibleOnMap"]);

            if (fieldNames.Contains(prefix + "Latitude"))
                if (!Convert.IsDBNull(reader[prefix + "Latitude"]))
                    user.Latitude = Convert.ToDouble(reader[prefix + "Latitude"]);

            if (fieldNames.Contains(prefix + "Longitude"))
                if (!Convert.IsDBNull(reader[prefix + "Longitude"]))
                    user.Longitude = Convert.ToDouble(reader[prefix + "Longitude"]);

            if (fieldNames.Contains(prefix + "GiftsPoints"))
                if (!Convert.IsDBNull(reader[prefix + "GiftsPoints"]))
                    user.GiftsPoints = Convert.ToDouble(reader[prefix + "GiftsPoints"]);

            if (fieldNames.Contains(prefix + "TotalReceivedGiftsPoints"))
                if (!Convert.IsDBNull(reader[prefix + "TotalReceivedGiftsPoints"]))
                    user.TotalReceivedGiftsPoints = Convert.ToDouble(reader[prefix + "TotalReceivedGiftsPoints"]);

            if (fieldNames.Contains(prefix + "TotalSentFromGiftsPoints"))
                if (!Convert.IsDBNull(reader[prefix + "TotalSentFromGiftsPoints"]))
                    user.TotalSentFromGiftsPoints = Convert.ToDouble(reader[prefix + "TotalSentFromGiftsPoints"]);

            if (fieldNames.Contains(prefix + "UserTypeName"))
                if (!Convert.IsDBNull(reader[prefix + "UserTypeName"]))
                    user.UserTypeName = reader[prefix + "UserTypeName"].ToString();

            if (fieldNames.Contains(prefix + "CompanyArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "CompanyArabicName"]))
                    user.CompanyArabicName = reader[prefix + "CompanyArabicName"].ToString();

            if (fieldNames.Contains(prefix + "CompanyEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "CompanyEnglishName"]))
                    user.CompanyEnglishName = reader[prefix + "CompanyEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "LocationArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "LocationArabicName"]))
                    user.LocationArabicName = reader[prefix + "LocationArabicName"].ToString();

            if (fieldNames.Contains(prefix + "LocationEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "LocationEnglishName"]))
                    user.LocationEnglishName = reader[prefix + "LocationEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "CityArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "CityArabicName"]))
                    user.CityArabicName = reader[prefix + "CityArabicName"].ToString();

            if (fieldNames.Contains(prefix + "CityEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "CityEnglishName"]))
                    user.CityEnglishName = reader[prefix + "CityEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "GovernorateArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "GovernorateArabicName"]))
                    user.GovernorateArabicName = reader[prefix + "GovernorateArabicName"].ToString();

            if (fieldNames.Contains(prefix + "GovernorateEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "GovernorateEnglishName"]))
                    user.GovernorateEnglishName = reader[prefix + "GovernorateEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "CountryArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "CountryArabicName"]))
                    user.CountryArabicName = reader[prefix + "CountryArabicName"].ToString();

            if (fieldNames.Contains(prefix + "CountryEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "CountryEnglishName"]))
                    user.CountryEnglishName = reader[prefix + "CountryEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "JobArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "JobArabicName"]))
                    user.JobArabicName = reader[prefix + "JobArabicName"].ToString();

            if (fieldNames.Contains(prefix + "JobEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "JobEnglishName"]))
                    user.JobEnglishName = reader[prefix + "JobEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "PositionArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "PositionArabicName"]))
                    user.PositionArabicName = reader[prefix + "PositionArabicName"].ToString();

            if (fieldNames.Contains(prefix + "PositionEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "PositionEnglishName"]))
                    user.PositionEnglishName = reader[prefix + "PositionEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "WorkDomainArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "WorkDomainArabicName"]))
                    user.WorkDomainArabicName = reader[prefix + "WorkDomainArabicName"].ToString();

            if (fieldNames.Contains(prefix + "WorkDomainEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "WorkDomainEnglishName"]))
                    user.WorkDomainEnglishName = reader[prefix + "WorkDomainEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "EducationLevelArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "EducationLevelArabicName"]))
                    user.EducationLevelArabicName = reader[prefix + "EducationLevelArabicName"].ToString();

            if (fieldNames.Contains(prefix + "EducationLevelEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "EducationLevelEnglishName"]))
                    user.EducationLevelEnglishName = reader[prefix + "EducationLevelEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "LunchCount"))
                if (!Convert.IsDBNull(reader[prefix + "LunchCount"]))
                    user.LunchCount = Convert.ToInt32(reader[prefix + "LunchCount"]);


            if (fieldNames.Contains(prefix + "CurrencyId"))
                if (!Convert.IsDBNull(reader[prefix + "CurrencyId"]))
                    user.CurrencyId = Convert.ToInt32(reader[prefix + "CurrencyId"]);

            if (fieldNames.Contains(prefix + "CurrencyArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "CurrencyArabicName"]))
                    user.CurrencyArabicName = reader[prefix + "CurrencyArabicName"].ToString();

            if (fieldNames.Contains(prefix + "CurrencyEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "CurrencyEnglishName"]))
                    user.CurrencyEnglishName = reader[prefix + "CurrencyEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "MobileCountryCode"))
                if (!Convert.IsDBNull(reader[prefix + "MobileCountryCode"]))
                    user.MobileCountryCode = reader[prefix + "MobileCountryCode"].ToString();

            if (fieldNames.Contains(prefix + "HasOpenCart"))
                if (!Convert.IsDBNull(reader[prefix + "HasOpenCart"]))
                    user.HasOpenCart = (bool)reader[prefix + "HasOpenCart"];

            if (fieldNames.Contains(prefix + "OrdersPointsFromGifts"))
                if (!Convert.IsDBNull(reader[prefix + "OrdersPointsFromGifts"]))
                    user.OrdersPointsFromGifts = Convert.ToDouble(reader[prefix + "OrdersPointsFromGifts"]);

            if (fieldNames.Contains(prefix + "AccessToken"))
                if (!Convert.IsDBNull(reader[prefix + "AccessToken"]))
                    user.AccessToken = reader[prefix + "AccessToken"].ToString();

            if (fieldNames.Contains(prefix + "Street"))
                if (!Convert.IsDBNull(reader[prefix + "Street"]))
                    user.Street = reader[prefix + "Street"].ToString();

            if (fieldNames.Contains(prefix + "BlockNo"))
                if (!Convert.IsDBNull(reader[prefix + "BlockNo"]))
                    user.BlockNo = reader[prefix + "BlockNo"].ToString();

            if (fieldNames.Contains(prefix + "ApartmentNo"))
                if (!Convert.IsDBNull(reader[prefix + "ApartmentNo"]))
                    user.ApartmentNo = reader[prefix + "ApartmentNo"].ToString();

            if (fieldNames.Contains(prefix + "Floor"))
                if (!Convert.IsDBNull(reader[prefix + "Floor"]))
                    user.Floor = reader[prefix + "Floor"].ToString();

            if (fieldNames.Contains(prefix + "AddressNote"))
                if (!Convert.IsDBNull(reader[prefix + "AddressNote"]))
                    user.AddressNote = reader[prefix + "AddressNote"].ToString();

            if (fieldNames.Contains(prefix + "Building"))
                if (!Convert.IsDBNull(reader[prefix + "Building"]))
                    user.Building = reader[prefix + "Building"].ToString();

            if (fieldNames.Contains(prefix + "CurrentBranchId"))
                if (!Convert.IsDBNull(reader[prefix + "CurrentBranchId"]))
                    user.CurrentBranchId = (int)reader[prefix + "CurrentBranchId"];

            if (fieldNames.Contains(prefix + "CurrentBranchArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "CurrentBranchArabicName"]))
                    user.CurrentBranchArabicName = reader[prefix + "CurrentBranchArabicName"].ToString();

            if (fieldNames.Contains(prefix + "CurrentBranchEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "CurrentBranchEnglishName"]))
                    user.CurrentBranchEnglishName = reader[prefix + "CurrentBranchEnglishName"].ToString();
            return user;
        }
    }
}