using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class ConfigClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public int TransferConfirmationPeriod { get; set; }

        [DataMember(Order = 3)]
        public int OrderItemQuantityHoldPeriod { get; set; }

        [DataMember(Order = 4)]
        public int OrderTimeoutPeriod { get; set; }

        [DataMember(Order = 5)]
        public int OrderTimeoutRenewalCount { get; set; }

        [DataMember(Order = 6)]
        public double MainAgentOffersDefaultPercentage { get; set; }

        [DataMember(Order = 7)]
        public double SubAgentOffersDefaultPercentage { get; set; }

        [DataMember(Order = 8)]
        public int CurrencyId { get; set; }

        [DataMember(Order = 9)]
        public string CurrencyArabicName { get; set; }
        [DataMember(Order = 10)]
        public string CurrencyEnglishName { get; set; }
        [DataMember(Order = 11)]
        public int CountryId { get; set; }

        [DataMember(Order = 12)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 13)]
        public string CountryEnglishName { get; set; }

        [DataMember(Order = 14)]
        public int TransferTimeoutPeriod { get; set; }

        [DataMember(Order = 15)]
        public int PriceTypeId { get; set; }
        [DataMember(Order = 16)]
        public string PriceTypeArabicName { get; set; }
        [DataMember(Order = 17)]
        public string PriceTypeEnglishName { get; set; }
        [DataMember(Order = 18)]
        public double SearchRange { get; set; }
        [DataMember(Order = 19)]
        public bool AllowSearchByWorkDomain { get; set; }
        [DataMember(Order = 20)]
        public bool AutomaticallyShowUserOnMap { get; set; }
        [DataMember(Order = 21)]
        public bool AutomaticallyActivateUsers { get; set; }
        [DataMember(Order = 22)]
        public bool RequiredSmsVerification { get; set; }
        [DataMember(Order = 23)]
        public bool AbortAllTransferOnFail { get; set; }
        [DataMember(Order = 24)]
        public bool EnablePickUp { get; set; }
        [DataMember(Order = 25)]
        public bool EnableDelivery { get; set; }
        [DataMember(Order = 26)]
        public int CalculationCurrencyId { get; set; }
        [DataMember(Order = 27)]
        public string CalculationCurrencyArabicName { get; set; }
        [DataMember(Order = 28)]
        public string CalculationCurrencyEnglishName { get; set; }
        [DataMember(Order = 29)]
        public int PreviewCurrencyId { get; set; }
        [DataMember(Order = 30)]
        public string PreviewCurrencyArabicName { get; set; }
        [DataMember(Order = 31)]
        public string PreviewCurrencyEnglishName { get; set; }

        [DataMember(Order = 32)]
        public bool LinkCurrencies { get; set; }

        [DataMember(Order = 33)]
        public string ItemParam1Name { get; set; }
        [DataMember(Order = 34)]
        public string ItemParam2Name { get; set; }
        [DataMember(Order = 35)]
        public bool EnableItemParam1 { get; set; }
        [DataMember(Order = 36)]
        public bool EnableItemParam2 { get; set; }
        [DataMember(Order = 37)]
        public bool EnableOrderOffer { get; set; }
        [DataMember(Order = 38)]
        public int GrantPointTypeId { get; set; }
        [DataMember(Order = 39)]
        public string GrantPointTypeArabicName { get; set; }
        [DataMember(Order = 40)]
        public string GrantPointTypeEnglishName { get; set; }

        [DataMember(Order = 41)]
        public int PreviewCountryCurrencyId { get; set; }
        [DataMember(Order = 42)]
        public int CalculationCountryCurrencyId { get; set; }
        [DataMember(Order = 43)]
        public int CountryCurrencyId { get; set; }

        [DataMember(Order = 44)]
        public bool EnableItemSizeChartImage { get; set; }
        [DataMember(Order = 45)]
        public string PolicyArabicTitle { get; set; }
        [DataMember(Order = 46)]
        public string PolicyEnglishTitle { get; set; }
        [DataMember(Order = 47)]
        public string PolicyArabicDescription { get; set; }
        [DataMember(Order = 48)]
        public string PolicyEnglishDescription { get; set; }

        [DataMember(Order = 49)]
        public string CurrencyArabicCode { get; set; }
        [DataMember(Order = 50)]
        public string CurrencyEnglishCode { get; set; }
        [DataMember(Order = 51)]
        public string OwnerLogoURL { get; set; }
        [DataMember(Order = 52)]
        public string OwnerArabicTitle { get; set; }
        [DataMember(Order = 53)]
        public string OwnerEnglishTitle { get; set; }
        [DataMember(Order = 54)]
        public string OwnerArabicDescription { get; set; }
        [DataMember(Order = 55)]
        public string OwnerEnglishDescription { get; set; }
        [DataMember(Order = 56)]
        public string OwnerWebsiteURL { get; set; }
        [DataMember(Order = 57)]
        public string OwnerPhoneNumber { get; set; }
        [DataMember(Order = 58)]
        public string OwnerArabicAddress { get; set; }
        [DataMember(Order = 59)]
        public string OwnerEnglishAddress { get; set; }
        [DataMember(Order = 60)]
        public string OwnerEmail { get; set; }

        [DataMember(Order = 61)]
        public int ItemVisitPeriod { get; set; }
        [DataMember(Order = 62)]
        public int ItemBookingEndDate { get; set; }
        [DataMember(Order = 63)]
        public char ImageIndexSplitter { get; set; }
        [DataMember(Order = 64)]
        public int PriceDigitsNumberAfterComma { get; set; }


        [DataMember(Order = 32)]
        public bool SupportCountry { get; set; }
        [DataMember(Order = 32)]
        public bool SupportGovernorate { get; set; }
        [DataMember(Order = 32)]
        public bool SupportCity { get; set; }
        [DataMember(Order = 32)]
        public bool SupportLocation { get; set; }
        [DataMember(Order = 32)]
        public bool SupportBlockNo { get; set; }
        [DataMember(Order = 32)]
        public bool SupportStreet { get; set; }
        [DataMember(Order = 32)]
        public bool SupportBuilding { get; set; }
        [DataMember(Order = 32)]
        public bool SupportFloor { get; set; }
        [DataMember(Order = 32)]
        public bool SupportApartmentNo { get; set; }
        [DataMember(Order = 32)]
        public bool SupportAddressesNote { get; set; }

        [DataMember(Order = 32)]
        public bool CountryIsRequired { get; set; }
        [DataMember(Order = 32)]
        public bool GovernorateIsRequired { get; set; }
        [DataMember(Order = 32)]
        public bool CityIsRequired { get; set; }
        [DataMember(Order = 32)]
        public bool LocationIsRequired { get; set; }
        [DataMember(Order = 32)]
        public bool BlockNoIsRequired { get; set; }
        [DataMember(Order = 32)]
        public bool StreetIsRequired { get; set; }
        [DataMember(Order = 32)]
        public bool BuildingIsRequired { get; set; }
        [DataMember(Order = 32)]
        public bool FloorIsRequired { get; set; }
        [DataMember(Order = 32)]
        public bool ApartmentNoIsRequired { get; set; }
        [DataMember(Order = 32)]
        public bool AddressNoteIsRequired { get; set; }
        [DataMember(Order = 32)]
        public bool HasPoints { get; set; }


        [DataMember(Order = 32)]
        public bool ShowItemCodeInItemsList { get; set; }
        [DataMember(Order = 32)]
        public bool ShowBrandNameInItemPage { get; set; }
        [DataMember(Order = 32)]
        public bool HasMultipleCountries { get; set; }
        [DataMember(Order = 32)]
        public bool HasGuestMode { get; set; }
        [DataMember(Order = 32)]
        public bool HasBranches { get; set; }
        [DataMember(Order = 32)]
        public bool HasDelivery { get; set; }
        [DataMember(Order = 32)]
        public bool HasPickFromBranches { get; set; }
        [DataMember(Order = 32)]
        public bool ShowItemCodeInItemPage { get; set; }

        [DataMember(Order = 32)]
        public bool ShowBrandNameInItemsList { get; set; }

        [DataMember(Order = 32)]
        public bool AllowGiftingPointsBetweenUsers { get; set; }
        [DataMember(Order = 32)]
        public bool HasSeriesFeatures { get; set; }
        [DataMember(Order = 32)]
        public bool ShowStockLevel { get; set; }
        [DataMember(Order = 32)]
        public bool HasEPayment { get; set; }

        [DataMember(Order = 32)]
        public bool ShowCountryInSignUp { get; set; }
        [DataMember(Order = 32)]
        public bool ShowGovernorateInSignUp { get; set; }
        [DataMember(Order = 32)]
        public bool ShowCityInSignUp { get; set; }
        [DataMember(Order = 32)]
        public bool ShowEmailInSignUp { get; set; }
        [DataMember(Order = 32)]
        public bool ShowGenderInSignUp { get; set; 
        }
        public ConfigClass PopulateConfig(string[] fieldNames, SqlDataReader reader)
        {
            var config = new ConfigClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    config.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("TransferConfirmationPeriod"))
                if (!Convert.IsDBNull(reader["TransferConfirmationPeriod"]))
                    config.TransferConfirmationPeriod = Convert.ToInt32(reader["TransferConfirmationPeriod"]);

            if (fieldNames.Contains("OrderItemQuantityHoldPeriod"))
                if (!Convert.IsDBNull(reader["OrderItemQuantityHoldPeriod"]))
                    config.OrderItemQuantityHoldPeriod = Convert.ToInt32(reader["OrderItemQuantityHoldPeriod"]);

            if (fieldNames.Contains("OrderTimeoutPeriod"))
                if (!Convert.IsDBNull(reader["OrderTimeoutPeriod"]))
                    config.OrderTimeoutPeriod = Convert.ToInt32(reader["OrderTimeoutPeriod"]);

            if (fieldNames.Contains("OrderTimeoutRenewalCount"))
                if (!Convert.IsDBNull(reader["OrderTimeoutRenewalCount"]))
                    config.OrderTimeoutRenewalCount = Convert.ToInt32(reader["OrderTimeoutRenewalCount"]);

            if (fieldNames.Contains("MainAgentOffersDefaultPercentage"))
                if (!Convert.IsDBNull(reader["MainAgentOffersDefaultPercentage"]))
                    config.MainAgentOffersDefaultPercentage = Convert.ToDouble(reader["MainAgentOffersDefaultPercentage"]);

            if (fieldNames.Contains("SubAgentOffersDefaultPercentage"))
                if (!Convert.IsDBNull(reader["SubAgentOffersDefaultPercentage"]))
                    config.SubAgentOffersDefaultPercentage = Convert.ToDouble(reader["SubAgentOffersDefaultPercentage"]);


            if (fieldNames.Contains("CurrencyId"))
                if (!Convert.IsDBNull(reader["CurrencyId"]))
                    config.CurrencyId = Convert.ToInt32(reader["CurrencyId"]);

            if (fieldNames.Contains("CurrencyArabicName"))
                if (!Convert.IsDBNull(reader["CurrencyArabicName"]))
                    config.CurrencyArabicName = reader["CurrencyArabicName"].ToString();

            if (fieldNames.Contains("CurrencyEnglishName"))
                if (!Convert.IsDBNull(reader["CurrencyEnglishName"]))
                    config.CurrencyEnglishName = reader["CurrencyEnglishName"].ToString();


            if (fieldNames.Contains("CountryId"))
                if (!Convert.IsDBNull(reader["CountryId"]))
                    config.CountryId = Convert.ToInt32(reader["CountryId"]);

            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    config.CountryArabicName = reader["CountryArabicName"].ToString();

            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    config.CountryEnglishName = reader["CountryEnglishName"].ToString();


            if (fieldNames.Contains("TransferTimeoutPeriod"))
                if (!Convert.IsDBNull(reader["TransferTimeoutPeriod"]))
                    config.TransferTimeoutPeriod = Convert.ToInt32(reader["TransferTimeoutPeriod"]);


            if (fieldNames.Contains("PriceTypeId"))
                if (!Convert.IsDBNull(reader["PriceTypeId"]))
                    config.PriceTypeId = Convert.ToInt32(reader["PriceTypeId"]);

            if (fieldNames.Contains("PriceTypeArabicName"))
                if (!Convert.IsDBNull(reader["PriceTypeArabicName"]))
                    config.PriceTypeArabicName = reader["PriceTypeArabicName"].ToString();

            if (fieldNames.Contains("PriceTypeEnglishName"))
                if (!Convert.IsDBNull(reader["PriceTypeEnglishName"]))
                    config.PriceTypeEnglishName = reader["PriceTypeEnglishName"].ToString();


            if (fieldNames.Contains("SearchRange"))
                if (!Convert.IsDBNull(reader["SearchRange"]))
                    config.SearchRange = Convert.ToDouble(reader["SearchRange"]);

            if (fieldNames.Contains("AllowSearchByWorkDomain"))
                if (!Convert.IsDBNull(reader["AllowSearchByWorkDomain"]))
                    config.AllowSearchByWorkDomain = Convert.ToBoolean(reader["AllowSearchByWorkDomain"]);

            if (fieldNames.Contains("AutomaticallyShowUserOnMap"))
                if (!Convert.IsDBNull(reader["AutomaticallyShowUserOnMap"]))
                    config.AutomaticallyShowUserOnMap = Convert.ToBoolean(reader["AutomaticallyShowUserOnMap"]);

            if (fieldNames.Contains("AutomaticallyActivateUsers"))
                if (!Convert.IsDBNull(reader["AutomaticallyActivateUsers"]))
                    config.AutomaticallyActivateUsers = Convert.ToBoolean(reader["AutomaticallyActivateUsers"]);

            if (fieldNames.Contains("RequiredSmsVerification"))
                if (!Convert.IsDBNull(reader["RequiredSmsVerification"]))
                    config.RequiredSmsVerification = Convert.ToBoolean(reader["RequiredSmsVerification"]);

            if (fieldNames.Contains("AbortAllTransferOnFail"))
                if (!Convert.IsDBNull(reader["AbortAllTransferOnFail"]))
                    config.AbortAllTransferOnFail = Convert.ToBoolean(reader["AbortAllTransferOnFail"]);

            if (fieldNames.Contains("EnablePickUp"))
                if (!Convert.IsDBNull(reader["EnablePickUp"]))
                    config.EnablePickUp = Convert.ToBoolean(reader["EnablePickUp"]);

            if (fieldNames.Contains("EnableDelivery"))
                if (!Convert.IsDBNull(reader["EnableDelivery"]))
                    config.EnableDelivery = Convert.ToBoolean(reader["EnableDelivery"]);


            if (fieldNames.Contains("CalculationCurrencyId"))
                if (!Convert.IsDBNull(reader["CalculationCurrencyId"]))
                    config.CalculationCurrencyId = Convert.ToInt32(reader["CalculationCurrencyId"]);

            if (fieldNames.Contains("CalculationCurrencyArabicName"))
                if (!Convert.IsDBNull(reader["CalculationCurrencyArabicName"]))
                    config.CalculationCurrencyArabicName = reader["CalculationCurrencyArabicName"].ToString();

            if (fieldNames.Contains("CalculationCurrencyEnglishName"))
                if (!Convert.IsDBNull(reader["CalculationCurrencyEnglishName"]))
                    config.CalculationCurrencyEnglishName = reader["CalculationCurrencyEnglishName"].ToString();


            if (fieldNames.Contains("PreviewCurrencyId"))
                if (!Convert.IsDBNull(reader["PreviewCurrencyId"]))
                    config.PreviewCurrencyId = Convert.ToInt32(reader["PreviewCurrencyId"]);

            if (fieldNames.Contains("PreviewCurrencyArabicName"))
                if (!Convert.IsDBNull(reader["PreviewCurrencyArabicName"]))
                    config.PreviewCurrencyArabicName = reader["PreviewCurrencyArabicName"].ToString();

            if (fieldNames.Contains("PreviewCurrencyEnglishName"))
                if (!Convert.IsDBNull(reader["PreviewCurrencyEnglishName"]))
                    config.PreviewCurrencyEnglishName = reader["PreviewCurrencyEnglishName"].ToString();


            if (fieldNames.Contains("LinkCurrencies"))
                if (!Convert.IsDBNull(reader["LinkCurrencies"]))
                    config.LinkCurrencies = Convert.ToBoolean(reader["LinkCurrencies"]);


            if (fieldNames.Contains("ItemParam1Name"))
                if (!Convert.IsDBNull(reader["ItemParam1Name"]))
                    config.ItemParam1Name = reader["ItemParam1Name"].ToString();

            if (fieldNames.Contains("ItemParam2Name"))
                if (!Convert.IsDBNull(reader["ItemParam2Name"]))
                    config.ItemParam2Name = reader["ItemParam2Name"].ToString();

            if (fieldNames.Contains("EnableItemParam1"))
                if (!Convert.IsDBNull(reader["EnableItemParam1"]))
                    config.EnableItemParam1 = Convert.ToBoolean(reader["EnableItemParam1"]);

            if (fieldNames.Contains("EnableItemParam2"))
                if (!Convert.IsDBNull(reader["EnableItemParam2"]))
                    config.EnableItemParam2 = Convert.ToBoolean(reader["EnableItemParam2"]);

            if (fieldNames.Contains("EnableOrderOffer"))
                if (!Convert.IsDBNull(reader["EnableOrderOffer"]))
                    config.EnableOrderOffer = Convert.ToBoolean(reader["EnableOrderOffer"]);

            if (fieldNames.Contains("GrantPointTypeId"))
                if (!Convert.IsDBNull(reader["GrantPointTypeId"]))
                    config.GrantPointTypeId = Convert.ToInt32(reader["GrantPointTypeId"]);

            if (fieldNames.Contains("GrantPointTypeArabicName"))
                if (!Convert.IsDBNull(reader["GrantPointTypeArabicName"]))
                    config.GrantPointTypeArabicName = reader["GrantPointTypeArabicName"].ToString();

            if (fieldNames.Contains("GrantPointTypeEnglishName"))
                if (!Convert.IsDBNull(reader["GrantPointTypeEnglishName"]))
                    config.GrantPointTypeEnglishName = reader["GrantPointTypeEnglishName"].ToString();


            if (fieldNames.Contains("PreviewCountryCurrencyId"))
                if (!Convert.IsDBNull(reader["PreviewCountryCurrencyId"]))
                    config.PreviewCountryCurrencyId = Convert.ToInt32(reader["PreviewCountryCurrencyId"]);

            if (fieldNames.Contains("CalculationCountryCurrencyId"))
                if (!Convert.IsDBNull(reader["CalculationCountryCurrencyId"]))
                    config.CalculationCountryCurrencyId = Convert.ToInt32(reader["CalculationCountryCurrencyId"]);

            if (fieldNames.Contains("CountryCurrencyId"))
                if (!Convert.IsDBNull(reader["CountryCurrencyId"]))
                    config.CountryCurrencyId = Convert.ToInt32(reader["CountryCurrencyId"]);


            if (fieldNames.Contains("EnableItemSizeChartImage"))
                if (!Convert.IsDBNull(reader["EnableItemSizeChartImage"]))
                    config.EnableItemSizeChartImage = Convert.ToBoolean(reader["EnableItemSizeChartImage"]);

            if (fieldNames.Contains("PolicyArabicTitle"))
                if (!Convert.IsDBNull(reader["PolicyArabicTitle"]))
                    config.PolicyArabicTitle = reader["PolicyArabicTitle"].ToString();

            if (fieldNames.Contains("PolicyEnglishTitle"))
                if (!Convert.IsDBNull(reader["PolicyEnglishTitle"]))
                    config.PolicyEnglishTitle = reader["PolicyEnglishTitle"].ToString();

            if (fieldNames.Contains("PolicyArabicDescription"))
                if (!Convert.IsDBNull(reader["PolicyArabicDescription"]))
                    config.PolicyArabicDescription = reader["PolicyArabicDescription"].ToString();

            if (fieldNames.Contains("PolicyEnglishDescription"))
                if (!Convert.IsDBNull(reader["PolicyEnglishDescription"]))
                    config.PolicyEnglishDescription = reader["PolicyEnglishDescription"].ToString();

            if (fieldNames.Contains("CurrencyArabicCode"))
                if (!Convert.IsDBNull(reader["CurrencyArabicCode"]))
                    config.CurrencyArabicCode = reader["CurrencyArabicCode"].ToString();

            if (fieldNames.Contains("CurrencyEnglishCode"))
                if (!Convert.IsDBNull(reader["CurrencyEnglishCode"]))
                    config.CurrencyEnglishCode = reader["CurrencyEnglishCode"].ToString();








            if (fieldNames.Contains("OwnerLogoURL"))
                if (!Convert.IsDBNull(reader["OwnerLogoURL"]))
                    config.OwnerLogoURL = reader["OwnerLogoURL"].ToString();

            if (fieldNames.Contains("OwnerArabicTitle"))
                if (!Convert.IsDBNull(reader["OwnerArabicTitle"]))
                    config.OwnerArabicTitle = reader["OwnerArabicTitle"].ToString();

            if (fieldNames.Contains("OwnerEnglishTitle"))
                if (!Convert.IsDBNull(reader["OwnerEnglishTitle"]))
                    config.OwnerEnglishTitle = reader["OwnerEnglishTitle"].ToString();

            if (fieldNames.Contains("OwnerArabicDescription"))
                if (!Convert.IsDBNull(reader["OwnerArabicDescription"]))
                    config.OwnerArabicDescription = reader["OwnerArabicDescription"].ToString();

            if (fieldNames.Contains("OwnerEnglishDescription"))
                if (!Convert.IsDBNull(reader["OwnerEnglishDescription"]))
                    config.OwnerEnglishDescription = reader["OwnerEnglishDescription"].ToString();

            if (fieldNames.Contains("OwnerWebsiteURL"))
                if (!Convert.IsDBNull(reader["OwnerWebsiteURL"]))
                    config.OwnerWebsiteURL = reader["OwnerWebsiteURL"].ToString();

            if (fieldNames.Contains("OwnerPhoneNumber"))
                if (!Convert.IsDBNull(reader["OwnerPhoneNumber"]))
                    config.OwnerPhoneNumber = reader["OwnerPhoneNumber"].ToString();

            if (fieldNames.Contains("OwnerEnglishAddress"))
                if (!Convert.IsDBNull(reader["OwnerEnglishAddress"]))
                    config.OwnerEnglishAddress = reader["OwnerEnglishAddress"].ToString();
            if (fieldNames.Contains("OwnerArabicAddress"))
                if (!Convert.IsDBNull(reader["OwnerArabicAddress"]))
                    config.OwnerArabicAddress = reader["OwnerArabicAddress"].ToString();

            if (fieldNames.Contains("OwnerEmail"))
                if (!Convert.IsDBNull(reader["OwnerEmail"]))
                    config.OwnerEmail = reader["OwnerEmail"].ToString();

            if (fieldNames.Contains("ItemVisitPeriod"))
                if (!Convert.IsDBNull(reader["ItemVisitPeriod"]))
                    config.ItemVisitPeriod = Convert.ToInt32(reader["ItemVisitPeriod"]);
            if (fieldNames.Contains("ItemBookingEndDate"))
                if (!Convert.IsDBNull(reader["ItemBookingEndDate"]))
                    config.ItemBookingEndDate = Convert.ToInt32( reader["ItemBookingEndDate"]);

            if (fieldNames.Contains("ImageIndexSplitter"))
                if (!Convert.IsDBNull(reader["ImageIndexSplitter"]))
                    config.ImageIndexSplitter = Convert.ToChar(reader["ImageIndexSplitter"]);

            if (fieldNames.Contains("PriceDigitsNumberAfterComma"))
                if (!Convert.IsDBNull(reader["PriceDigitsNumberAfterComma"]))
                    config.PriceDigitsNumberAfterComma = Convert.ToInt32(reader["PriceDigitsNumberAfterComma"]);



            if (fieldNames.Contains("SupportCountry"))
                if (!Convert.IsDBNull(reader["SupportCountry"]))
                    config.SupportCountry = Convert.ToBoolean(reader["SupportCountry"]);

            if (fieldNames.Contains("SupportGovernorate"))
                if (!Convert.IsDBNull(reader["SupportGovernorate"]))
                    config.SupportGovernorate = Convert.ToBoolean(reader["SupportGovernorate"]);

            if (fieldNames.Contains("SupportCity"))
                if (!Convert.IsDBNull(reader["SupportCity"]))
                    config.SupportCity = Convert.ToBoolean(reader["SupportCity"]);

            if (fieldNames.Contains("SupportLocation"))
                if (!Convert.IsDBNull(reader["SupportLocation"]))
                    config.SupportLocation = Convert.ToBoolean(reader["SupportLocation"]);

            if (fieldNames.Contains("SupportBlockNo"))
                if (!Convert.IsDBNull(reader["SupportBlockNo"]))
                    config.SupportBlockNo = Convert.ToBoolean(reader["SupportBlockNo"]);

            if (fieldNames.Contains("SupportStreet"))
                if (!Convert.IsDBNull(reader["SupportStreet"]))
                    config.SupportStreet = Convert.ToBoolean(reader["SupportStreet"]);

            if (fieldNames.Contains("SupportBuilding"))
                if (!Convert.IsDBNull(reader["SupportBuilding"]))
                    config.SupportBuilding = Convert.ToBoolean(reader["SupportBuilding"]);

            if (fieldNames.Contains("SupportFloor"))
                if (!Convert.IsDBNull(reader["SupportFloor"]))
                    config.SupportFloor = Convert.ToBoolean(reader["SupportFloor"]);

            if (fieldNames.Contains("SupportApartmentNo"))
                if (!Convert.IsDBNull(reader["SupportApartmentNo"]))
                    config.SupportApartmentNo = Convert.ToBoolean(reader["SupportApartmentNo"]);

            if (fieldNames.Contains("SupportAddressesNote"))
                if (!Convert.IsDBNull(reader["SupportAddressesNote"]))
                    config.SupportAddressesNote = Convert.ToBoolean(reader["SupportAddressesNote"]);



            if (fieldNames.Contains("CountryIsRequired"))
                if (!Convert.IsDBNull(reader["CountryIsRequired"]))
                    config.CountryIsRequired = Convert.ToBoolean(reader["CountryIsRequired"]);

            if (fieldNames.Contains("GovernorateIsRequired"))
                if (!Convert.IsDBNull(reader["GovernorateIsRequired"]))
                    config.GovernorateIsRequired = Convert.ToBoolean(reader["GovernorateIsRequired"]);

            if (fieldNames.Contains("CityIsRequired"))
                if (!Convert.IsDBNull(reader["CityIsRequired"]))
                    config.CityIsRequired = Convert.ToBoolean(reader["CityIsRequired"]);

            if (fieldNames.Contains("LocationIsRequired"))
                if (!Convert.IsDBNull(reader["LocationIsRequired"]))
                    config.LocationIsRequired = Convert.ToBoolean(reader["LocationIsRequired"]);

            if (fieldNames.Contains("BlockNoIsRequired"))
                if (!Convert.IsDBNull(reader["BlockNoIsRequired"]))
                    config.BlockNoIsRequired = Convert.ToBoolean(reader["BlockNoIsRequired"]);

            if (fieldNames.Contains("StreetIsRequired"))
                if (!Convert.IsDBNull(reader["StreetIsRequired"]))
                    config.StreetIsRequired = Convert.ToBoolean(reader["StreetIsRequired"]);

            if (fieldNames.Contains("BuildingIsRequired"))
                if (!Convert.IsDBNull(reader["BuildingIsRequired"]))
                    config.BuildingIsRequired = Convert.ToBoolean(reader["BuildingIsRequired"]);

            if (fieldNames.Contains("FloorIsRequired"))
                if (!Convert.IsDBNull(reader["FloorIsRequired"]))
                    config.FloorIsRequired = Convert.ToBoolean(reader["FloorIsRequired"]);

            if (fieldNames.Contains("ApartmentNoIsRequired"))
                if (!Convert.IsDBNull(reader["ApartmentNoIsRequired"]))
                    config.ApartmentNoIsRequired = Convert.ToBoolean(reader["ApartmentNoIsRequired"]);

            if (fieldNames.Contains("AddressNoteIsRequired"))
                if (!Convert.IsDBNull(reader["AddressNoteIsRequired"]))
                    config.AddressNoteIsRequired = Convert.ToBoolean(reader["AddressNoteIsRequired"]);

            if (fieldNames.Contains("HasPoints"))
                if (!Convert.IsDBNull(reader["HasPoints"]))
                    config.HasPoints = Convert.ToBoolean(reader["HasPoints"]);


            if (fieldNames.Contains("ShowItemCodeInItemsList"))
                if (!Convert.IsDBNull(reader["ShowItemCodeInItemsList"]))
                    config.ShowItemCodeInItemsList = Convert.ToBoolean(reader["ShowItemCodeInItemsList"]);

            if (fieldNames.Contains("ShowBrandNameInItemPage"))
                if (!Convert.IsDBNull(reader["ShowBrandNameInItemPage"]))
                    config.ShowBrandNameInItemPage = Convert.ToBoolean(reader["ShowBrandNameInItemPage"]);

            if (fieldNames.Contains("HasMultipleCountries"))
                if (!Convert.IsDBNull(reader["HasMultipleCountries"]))
                    config.HasMultipleCountries = Convert.ToBoolean(reader["HasMultipleCountries"]);

            if (fieldNames.Contains("HasGuestMode"))
                if (!Convert.IsDBNull(reader["HasGuestMode"]))
                    config.HasGuestMode = Convert.ToBoolean(reader["HasGuestMode"]);

            if (fieldNames.Contains("HasBranches"))
                if (!Convert.IsDBNull(reader["HasBranches"]))
                    config.HasBranches = Convert.ToBoolean(reader["HasBranches"]);

            if (fieldNames.Contains("HasDelivery"))
                if (!Convert.IsDBNull(reader["HasDelivery"]))
                    config.HasDelivery = Convert.ToBoolean(reader["HasDelivery"]);

            if (fieldNames.Contains("HasPickFromBranches"))
                if (!Convert.IsDBNull(reader["HasPickFromBranches"]))
                    config.HasPickFromBranches = Convert.ToBoolean(reader["HasPickFromBranches"]);

            if (fieldNames.Contains("ShowItemCodeInItemPage"))
                if (!Convert.IsDBNull(reader["ShowItemCodeInItemPage"]))
                    config.ShowItemCodeInItemPage = Convert.ToBoolean(reader["ShowItemCodeInItemPage"]);

            if (fieldNames.Contains("ShowBrandNameInItemsList"))
                if (!Convert.IsDBNull(reader["ShowBrandNameInItemsList"]))
                    config.ShowBrandNameInItemsList = Convert.ToBoolean(reader["ShowBrandNameInItemsList"]);

            if (fieldNames.Contains("AllowGiftingPointsBetweenUsers"))
                if (!Convert.IsDBNull(reader["AllowGiftingPointsBetweenUsers"]))
                    config.AllowGiftingPointsBetweenUsers = Convert.ToBoolean(reader["AllowGiftingPointsBetweenUsers"]);

            if (fieldNames.Contains("HasSeriesFeatures"))
                if (!Convert.IsDBNull(reader["HasSeriesFeatures"]))
                    config.HasSeriesFeatures = Convert.ToBoolean(reader["HasSeriesFeatures"]);

            if (fieldNames.Contains("ShowStockLevel"))
                if (!Convert.IsDBNull(reader["ShowStockLevel"]))
                    config.ShowStockLevel = Convert.ToBoolean(reader["ShowStockLevel"]);

            if (fieldNames.Contains("HasEPayment"))
                if (!Convert.IsDBNull(reader["HasEPayment"]))
                    config.HasEPayment = Convert.ToBoolean(reader["HasEPayment"]);

            if (fieldNames.Contains("ShowCountryInSignUp"))
                if (!Convert.IsDBNull(reader["ShowCountryInSignUp"]))
                    config.ShowCountryInSignUp = Convert.ToBoolean(reader["ShowCountryInSignUp"]);

            if (fieldNames.Contains("ShowGovernorateInSignUp"))
                if (!Convert.IsDBNull(reader["ShowGovernorateInSignUp"]))
                    config.ShowGovernorateInSignUp = Convert.ToBoolean(reader["ShowGovernorateInSignUp"]);

            if (fieldNames.Contains("ShowCityInSignUp"))
                if (!Convert.IsDBNull(reader["ShowCityInSignUp"]))
                    config.ShowCityInSignUp = Convert.ToBoolean(reader["ShowCityInSignUp"]);

            if (fieldNames.Contains("ShowEmailInSignUp"))
                if (!Convert.IsDBNull(reader["ShowEmailInSignUp"]))
                    config.ShowEmailInSignUp = Convert.ToBoolean(reader["ShowEmailInSignUp"]);

            if (fieldNames.Contains("ShowGenderInSignUp"))
                if (!Convert.IsDBNull(reader["ShowGenderInSignUp"]))
                    config.ShowGenderInSignUp = Convert.ToBoolean(reader["ShowGenderInSignUp"]);


            return config;
        }

    }
}