using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
	[DataContract]
	public class UserPermissionClass
	{
		[DataMember(Order = 1)]
		public int Id { get; set; }
		[DataMember(Order = 2)]
		public int UserId { get; set; }
		[DataMember(Order = 3)]
		public bool CanCreateUsers { get; set; }
		[DataMember(Order = 4)]
		public bool CanCreateTransfer { get; set; }
		[DataMember(Order = 5)]
		public bool CanCreateOffers { get; set; }
		[DataMember(Order = 6)]
		public bool CanCreateItems { get; set; }
		[DataMember(Order = 7)]
		public bool CanCreateCities { get; set; }
		[DataMember(Order = 8)]
		public bool CanCreateLocations { get; set; }
		[DataMember(Order = 9)]
		public bool CanCreateCompanies { get; set; }
		[DataMember(Order = 10)]
		public bool CanCreateGovernorates { get; set; }

		[DataMember(Order = 11)]
		public bool CanCreatePositions { get; set; }
		[DataMember(Order = 12)]
		public bool CanCreateJobs { get; set; }
		[DataMember(Order = 13)]
		public bool CanCreateWorkDomains { get; set; }
		[DataMember(Order = 14)]
		public bool CanCreateEducationLevels { get; set; }


		[DataMember(Order = 15)]
		public bool CanCreateBrands { get; set; }
		[DataMember(Order = 16)]
		public bool CanCreateCategories { get; set; }
		[DataMember(Order = 17)]
		public bool CanCreateColors { get; set; }
		[DataMember(Order = 18)]
		public bool CanCreateCountries { get; set; }
		[DataMember(Order = 19)]
		public bool CanCreateCurrencies { get; set; }
		[DataMember(Order = 20)]
		public bool CanCreateOrders { get; set; }


		[DataMember(Order = 21)]
		public bool CanUpdateUsers { get; set; }
		[DataMember(Order = 22)]
		public bool CanUpdateTransfer { get; set; }
		[DataMember(Order = 23)]
		public bool CanUpdateOffers { get; set; }
		[DataMember(Order = 24)]
		public bool CanUpdateItems { get; set; }
		[DataMember(Order = 25)]
		public bool CanUpdateCities { get; set; }
		[DataMember(Order = 26)]
		public bool CanUpdateLocations { get; set; }
		[DataMember(Order = 27)]
		public bool CanUpdateCompanies { get; set; }
		[DataMember(Order = 28)]
		public bool CanUpdateGovernorates { get; set; }

		[DataMember(Order = 29)]
		public bool CanUpdatePositions { get; set; }
		[DataMember(Order = 30)]
		public bool CanUpdateJobs { get; set; }
		[DataMember(Order = 31)]
		public bool CanUpdateWorkDomains { get; set; }
		[DataMember(Order = 32)]
		public bool CanUpdateEducationLevels { get; set; }


		[DataMember(Order = 33)]
		public bool CanUpdateBrands { get; set; }
		[DataMember(Order = 34)]
		public bool CanUpdateCategories { get; set; }
		[DataMember(Order = 35)]
		public bool CanUpdateColors { get; set; }
		[DataMember(Order = 36)]
		public bool CanUpdateCountries { get; set; }
		[DataMember(Order = 37)]
		public bool CanUpdateCurrencies { get; set; }
		[DataMember(Order = 38)]
		public bool CanUpdateOrders { get; set; }

		[DataMember(Order = 39)]
		public bool CanDeleteUsers { get; set; }
		[DataMember(Order = 40)]
		public bool CanDeleteTransfer { get; set; }
		[DataMember(Order = 41)]
		public bool CanDeleteOffers { get; set; }
		[DataMember(Order = 42)]
		public bool CanDeleteItems { get; set; }
		[DataMember(Order = 43)]
		public bool CanDeleteCities { get; set; }
		[DataMember(Order = 44)]
		public bool CanDeleteLocations { get; set; }
		[DataMember(Order = 45)]
		public bool CanDeleteCompanies { get; set; }
		[DataMember(Order = 46)]
		public bool CanDeleteGovernorates { get; set; }

		[DataMember(Order = 47)]
		public bool CanDeletePositions { get; set; }
		[DataMember(Order = 48)]
		public bool CanDeleteJobs { get; set; }
		[DataMember(Order = 49)]
		public bool CanDeleteWorkDomains { get; set; }
		[DataMember(Order = 50)]
		public bool CanDeleteEducationLevels { get; set; }


		[DataMember(Order = 51)]
		public bool CanDeleteBrands { get; set; }
		[DataMember(Order = 52)]
		public bool CanDeleteCategories { get; set; }
		[DataMember(Order = 53)]
		public bool CanDeleteColors { get; set; }
		[DataMember(Order = 54)]
		public bool CanDeleteCountries { get; set; }
		[DataMember(Order = 55)]
		public bool CanDeleteCurrencies { get; set; }
		[DataMember(Order = 56)]
		public bool CanDeleteOrders { get; set; }

		[DataMember(Order = 57)]
		public bool CanTransfer { get; set; }
		[DataMember(Order = 58)]
		public bool UnlimitedTransfer { get; set; }
		[DataMember(Order = 59)]
		public double MaxTransferAmount { get; set; }
		[DataMember(Order = 60)]
		public bool CanChangeUserPermissions { get; set; }

		[DataMember(Order = 61)]
		public bool CanUpdateColumns { get; set; }
		[DataMember(Order = 62)]
		public bool CanUpdateColumnsTemplete { get; set; }

		//Template
		[DataMember(Order = 63)]
		public int UserTypesId { get; set; }
		[DataMember(Order = 64)]
		public string UsersTypeName { get; set; }
		[DataMember(Order = 65)]
		public string ArabicName { get; set; }
		[DataMember(Order = 66)]
		public string EnglishName { get; set; }

		[DataMember(Order = 67)]
		public int Order { get; set; }

		[DataMember(Order = 68)]
		public bool CanCreateItemsGovernorates { get; set; }
		[DataMember(Order = 69)]
		public bool CanUpdateItemsGovernorates { get; set; }
		[DataMember(Order = 70)]
		public bool CanDeleteItemsGovernorates { get; set; }
		[DataMember(Order = 71)]
		public bool CanCreateItemsCompanies { get; set; }
		[DataMember(Order = 72)]
		public bool CanUpdateItemsCompanies { get; set; }
		[DataMember(Order = 73)]
		public bool CanDeleteItemsCompanies { get; set; }
		[DataMember(Order = 74)]
		public bool CanCreateItemsUsersTypes { get; set; }
		[DataMember(Order = 75)]
		public bool CanUpdateItemsUsersTypes { get; set; }
		[DataMember(Order = 76)]
		public bool CanDeleteItemsUsersTypes { get; set; }
		[DataMember(Order = 77)]
		public bool CanCreateOffersGovernorates { get; set; }
		[DataMember(Order = 78)]
		public bool CanUpdateOffersGovernorates { get; set; }
		[DataMember(Order = 79)]
		public bool CanDeleteOffersGovernorates { get; set; }
		[DataMember(Order = 80)]
		public bool CanCreateOffersCompanies { get; set; }
		[DataMember(Order = 81)]
		public bool CanUpdateOffersCompanies { get; set; }
		[DataMember(Order = 82)]
		public bool CanDeleteOffersCompanies { get; set; }
		[DataMember(Order = 83)]
		public bool CanCreateOffersUsersTypes { get; set; }
		[DataMember(Order = 84)]
		public bool CanUpdateOffersUsersTypes { get; set; }
		[DataMember(Order = 85)]
		public bool CanDeleteOffersUsersTypes { get; set; }
		[DataMember(Order = 86)]
		public bool CanCreateOffersDetails { get; set; }
		[DataMember(Order = 87)]
		public bool CanUpdateOffersDetails { get; set; }
		[DataMember(Order = 88)]
		public bool CanDeleteOffersDetails { get; set; }

		[DataMember(Order = 89)]
		public bool CanCreateOrderDetails { get; set; }
		[DataMember(Order = 90)]
		public bool CanUpdateOrderDetails { get; set; }
		[DataMember(Order = 91)]
		public bool CanDeleteOrderDetails { get; set; }

		[DataMember(Order = 92)]
		public int LoggedUser { get; set; }
		[DataMember(Order = 93)]
		public bool CanCreateSizesGroups { get; set; }
		[DataMember(Order = 94)]
		public bool CanUpdateSizesGroups { get; set; }
		[DataMember(Order = 95)]
		public bool CanDeleteSizesGroups { get; set; }
		[DataMember(Order = 96)]
		public bool CanCreateSizes { get; set; }
		[DataMember(Order = 97)]
		public bool CanUpdateSizes { get; set; }
		[DataMember(Order = 98)]
		public bool CanDeleteSizes { get; set; }
		[DataMember(Order = 99)]
		public bool CanCreateBanners { get; set; }
		[DataMember(Order = 100)]
		public bool CanUpdateBanners { get; set; }
		[DataMember(Order = 101)]
		public bool CanDeleteBanners { get; set; }
		[DataMember(Order = 102)]
		public bool CanCreateItemColors { get; set; }
		[DataMember(Order = 103)]
		public bool CanUpdateItemColors { get; set; }
		[DataMember(Order = 104)]
		public bool CanDeleteItemColors { get; set; }
		[DataMember(Order = 105)]
		public bool CanCreateItemSizes { get; set; }
		[DataMember(Order = 106)]
		public bool CanUpdateItemSizes { get; set; }
		[DataMember(Order = 107)]
		public bool CanDeleteItemSizes { get; set; }
		[DataMember(Order = 108)]
		public bool CanCreateItemImages { get; set; }
		[DataMember(Order = 109)]
		public bool CanUpdateItemImages { get; set; }
		[DataMember(Order = 110)]
		public bool CanCreateItemPrices { get; set; }
		[DataMember(Order = 111)]
		public bool CanUpdateItemPrices { get; set; }
		[DataMember(Order = 112)]
		public bool CanDeleteItemPrices { get; set; }
		[DataMember(Order = 113)]
		public bool CanCreatePriceTypes { get; set; }
		[DataMember(Order = 114)]
		public bool CanUpdatePriceTypes { get; set; }
		[DataMember(Order = 115)]
		public bool CanDeletePriceTypes { get; set; }
		[DataMember(Order = 116)]
		public bool CanCreateUserProfileColumns { get; set; }
		[DataMember(Order = 117)]
		public bool CanUpdateUserProfileColumns { get; set; }
		[DataMember(Order = 118)]
		public bool CanDeleteUserProfileColumns { get; set; }
		[DataMember(Order = 119)]
		public bool CanValidateUserLocation { get; set; }


	  [DataMember(Order = 120)]
		public bool CanCreateUserCompanies { get; set; }
		[DataMember(Order = 121)]
		public bool CanUpdateUserCompanies { get; set; }
		[DataMember(Order = 122)]
		public bool CanDeleteUserCompanies { get; set; }

		[DataMember(Order = 123)]
		public bool CanCreateUserTransferRules { get; set; }
		[DataMember(Order = 124)]
		public bool CanUpdateUserTransferRules { get; set; }
		[DataMember(Order = 125)]
		public bool CanDeleteUserTransferRules { get; set; }

		[DataMember(Order = 126)]
		public bool CanCreateUserTypeTransferRules { get; set; }
		[DataMember(Order = 127)]
		public bool CanUpdateUserTypeTransferRules { get; set; }
		[DataMember(Order = 128)]
		public bool CanDeleteUserTypeTransferRules { get; set; }

		[DataMember(Order = 129)]
		public bool CanCreateUserTransferException { get; set; }
		[DataMember(Order = 130)]
		public bool CanUpdateUserTransferException { get; set; }
		[DataMember(Order = 131)]
		public bool CanDeleteUserTransferException { get; set; }

		[DataMember(Order = 131)]
		public bool CanViewHome { get; set; }
		[DataMember(Order = 132)]
		public bool CanViewItems { get; set; }
		[DataMember(Order = 133)]
		public bool CanViewReports { get; set; }
		[DataMember(Order = 134)]
		public bool CanViewTransfers { get; set; }
		[DataMember(Order = 135)]
		public bool CanViewMainBalance { get; set; }
		[DataMember(Order = 136)]
		public bool CanViewIndexs { get; set; }
		[DataMember(Order = 137)]
		public bool CanViewOffers { get; set; }
		[DataMember(Order = 138)]
		public bool CanViewOrders { get; set; }
		[DataMember(Order = 139)]
		public bool CanViewComplains { get; set; }
		[DataMember(Order = 140)]
		public bool CanViewMaintenance { get; set; }
		[DataMember(Order = 140)]
		public bool CanViewUsers  { get; set; }
		public UserPermissionClass PopulateUserPermission(string[] fieldNames, SqlDataReader reader)
		{
			var userPermission = new UserPermissionClass();

			if (fieldNames.Contains("Id"))
				if (!Convert.IsDBNull(reader["Id"]))
					userPermission.Id = (int)reader["Id"];

			if (fieldNames.Contains("UserId"))
				if (!Convert.IsDBNull(reader["UserId"]))
					userPermission.UserId = (int)reader["UserId"];

			if (fieldNames.Contains("UnlimitedTransfer"))
				if (!Convert.IsDBNull(reader["UnlimitedTransfer"]))
					userPermission.UnlimitedTransfer = (bool)reader["UnlimitedTransfer"];

			if (fieldNames.Contains("MaxTransferAmount"))
				if (!Convert.IsDBNull(reader["MaxTransferAmount"]))
					userPermission.MaxTransferAmount = Convert.ToDouble(reader["MaxTransferAmount"]);

			if (fieldNames.Contains("CanChangeUserPermissions"))
				if (!Convert.IsDBNull(reader["CanChangeUserPermissions"]))
					userPermission.CanChangeUserPermissions = (bool)reader["CanChangeUserPermissions"];

			if (fieldNames.Contains("CanTransfer"))
				if (!Convert.IsDBNull(reader["CanTransfer"]))
					userPermission.CanTransfer = (bool)reader["CanTransfer"];

			//Users
			if (fieldNames.Contains("CanCreateUsers"))
				if (!Convert.IsDBNull(reader["CanCreateUsers"]))
					userPermission.CanCreateUsers = (bool)reader["CanCreateUsers"];

			if (fieldNames.Contains("CanUpdateUsers"))
				if (!Convert.IsDBNull(reader["CanUpdateUsers"]))
					userPermission.CanUpdateUsers = (bool)reader["CanUpdateUsers"];

			if (fieldNames.Contains("CanDeleteUsers"))
				if (!Convert.IsDBNull(reader["CanDeleteUsers"]))
					userPermission.CanDeleteUsers = (bool)reader["CanDeleteUsers"];


			//Transfers
			if (fieldNames.Contains("CanCreateTransfer"))
				if (!Convert.IsDBNull(reader["CanCreateTransfer"]))
					userPermission.CanCreateTransfer = (bool)reader["CanCreateTransfer"];

			if (fieldNames.Contains("CanUpdateTransfer"))
				if (!Convert.IsDBNull(reader["CanUpdateTransfer"]))
					userPermission.CanUpdateTransfer = (bool)reader["CanUpdateTransfer"];

			if (fieldNames.Contains("CanDeleteTransfer"))
				if (!Convert.IsDBNull(reader["CanDeleteTransfer"]))
					userPermission.CanDeleteTransfer = (bool)reader["CanDeleteTransfer"];



			//Offers
			if (fieldNames.Contains("CanCreateOffers"))
				if (!Convert.IsDBNull(reader["CanCreateOffers"]))
					userPermission.CanCreateOffers = (bool)reader["CanCreateOffers"];

			if (fieldNames.Contains("CanUpdateOffers"))
				if (!Convert.IsDBNull(reader["CanUpdateOffers"]))
					userPermission.CanUpdateOffers = (bool)reader["CanUpdateOffers"];

			if (fieldNames.Contains("CanDeleteOffers"))
				if (!Convert.IsDBNull(reader["CanDeleteOffers"]))
					userPermission.CanDeleteOffers = (bool)reader["CanDeleteOffers"];


			//Items
			if (fieldNames.Contains("CanCreateItems"))
				if (!Convert.IsDBNull(reader["CanCreateItems"]))
					userPermission.CanCreateItems = (bool)reader["CanCreateItems"];

			if (fieldNames.Contains("CanUpdateItems"))
				if (!Convert.IsDBNull(reader["CanUpdateItems"]))
					userPermission.CanUpdateItems = (bool)reader["CanUpdateItems"];

			if (fieldNames.Contains("CanDeleteItems"))
				if (!Convert.IsDBNull(reader["CanDeleteItems"]))
					userPermission.CanDeleteItems = (bool)reader["CanDeleteItems"];


			//Cities
			if (fieldNames.Contains("CanCreateCities"))
				if (!Convert.IsDBNull(reader["CanCreateCities"]))
					userPermission.CanCreateCities = (bool)reader["CanCreateCities"];

			if (fieldNames.Contains("CanUpdateCities"))
				if (!Convert.IsDBNull(reader["CanUpdateCities"]))
					userPermission.CanUpdateCities = (bool)reader["CanUpdateCities"];

			if (fieldNames.Contains("CanDeleteCities"))
				if (!Convert.IsDBNull(reader["CanDeleteCities"]))
					userPermission.CanDeleteCities = (bool)reader["CanDeleteCities"];

			//Locations
			if (fieldNames.Contains("CanCreateLocations"))
				if (!Convert.IsDBNull(reader["CanCreateLocations"]))
					userPermission.CanCreateLocations = (bool)reader["CanCreateLocations"];

			if (fieldNames.Contains("CanUpdateLocations"))
				if (!Convert.IsDBNull(reader["CanUpdateLocations"]))
					userPermission.CanUpdateLocations = (bool)reader["CanUpdateLocations"];

			if (fieldNames.Contains("CanDeleteLocations"))
				if (!Convert.IsDBNull(reader["CanDeleteLocations"]))
					userPermission.CanDeleteLocations = (bool)reader["CanDeleteLocations"];

			//Companies
			if (fieldNames.Contains("CanCreateCompanies"))
				if (!Convert.IsDBNull(reader["CanCreateCompanies"]))
					userPermission.CanCreateCompanies = (bool)reader["CanCreateCompanies"];

			if (fieldNames.Contains("CanUpdateCompanies"))
				if (!Convert.IsDBNull(reader["CanUpdateCompanies"]))
					userPermission.CanUpdateCompanies = (bool)reader["CanUpdateCompanies"];

			if (fieldNames.Contains("CanDeleteCompanies"))
				if (!Convert.IsDBNull(reader["CanDeleteCompanies"]))
					userPermission.CanDeleteCompanies = (bool)reader["CanDeleteCompanies"];

			//Governorates
			if (fieldNames.Contains("CanCreateGovernorates"))
				if (!Convert.IsDBNull(reader["CanCreateGovernorates"]))
					userPermission.CanCreateGovernorates = (bool)reader["CanCreateGovernorates"];

			if (fieldNames.Contains("CanUpdateGovernorates"))
				if (!Convert.IsDBNull(reader["CanUpdateGovernorates"]))
					userPermission.CanUpdateGovernorates = (bool)reader["CanUpdateGovernorates"];

			if (fieldNames.Contains("CanDeleteGovernorates"))
				if (!Convert.IsDBNull(reader["CanDeleteGovernorates"]))
					userPermission.CanDeleteGovernorates = (bool)reader["CanDeleteGovernorates"];


			//Cities
			if (fieldNames.Contains("CanCreatePositions"))
				if (!Convert.IsDBNull(reader["CanCreatePositions"]))
					userPermission.CanCreatePositions = (bool)reader["CanCreatePositions"];

			if (fieldNames.Contains("CanUpdatePositions"))
				if (!Convert.IsDBNull(reader["CanUpdatePositions"]))
					userPermission.CanUpdatePositions = (bool)reader["CanUpdatePositions"];

			if (fieldNames.Contains("CanDeletePositions"))
				if (!Convert.IsDBNull(reader["CanDeletePositions"]))
					userPermission.CanDeletePositions = (bool)reader["CanDeletePositions"];

			//Locations
			if (fieldNames.Contains("CanCreateJobs"))
				if (!Convert.IsDBNull(reader["CanCreateJobs"]))
					userPermission.CanCreateJobs = (bool)reader["CanCreateJobs"];

			if (fieldNames.Contains("CanUpdateJobs"))
				if (!Convert.IsDBNull(reader["CanUpdateJobs"]))
					userPermission.CanUpdateJobs = (bool)reader["CanUpdateJobs"];

			if (fieldNames.Contains("CanDeleteJobs"))
				if (!Convert.IsDBNull(reader["CanDeleteJobs"]))
					userPermission.CanDeleteJobs = (bool)reader["CanDeleteJobs"];

			//Companies
			if (fieldNames.Contains("CanCreateWorkDomains"))
				if (!Convert.IsDBNull(reader["CanCreateWorkDomains"]))
					userPermission.CanCreateWorkDomains = (bool)reader["CanCreateWorkDomains"];

			if (fieldNames.Contains("CanUpdateWorkDomains"))
				if (!Convert.IsDBNull(reader["CanUpdateWorkDomains"]))
					userPermission.CanUpdateWorkDomains = (bool)reader["CanUpdateWorkDomains"];

			if (fieldNames.Contains("CanDeleteWorkDomains"))
				if (!Convert.IsDBNull(reader["CanDeleteWorkDomains"]))
					userPermission.CanDeleteWorkDomains = (bool)reader["CanDeleteWorkDomains"];

			//Governorates
			if (fieldNames.Contains("CanCreateEducationLevels"))
				if (!Convert.IsDBNull(reader["CanCreateEducationLevels"]))
					userPermission.CanCreateEducationLevels = (bool)reader["CanCreateEducationLevels"];

			if (fieldNames.Contains("CanUpdateEducationLevels"))
				if (!Convert.IsDBNull(reader["CanUpdateEducationLevels"]))
					userPermission.CanUpdateEducationLevels = (bool)reader["CanUpdateEducationLevels"];

			if (fieldNames.Contains("CanDeleteEducationLevels"))
				if (!Convert.IsDBNull(reader["CanDeleteEducationLevels"]))
					userPermission.CanDeleteEducationLevels = (bool)reader["CanDeleteEducationLevels"];

			//Governorates
			if (fieldNames.Contains("CanCreateBrands"))
				if (!Convert.IsDBNull(reader["CanCreateBrands"]))
					userPermission.CanCreateBrands = (bool)reader["CanCreateBrands"];

			if (fieldNames.Contains("CanUpdateBrands"))
				if (!Convert.IsDBNull(reader["CanUpdateBrands"]))
					userPermission.CanUpdateBrands = (bool)reader["CanUpdateBrands"];

			if (fieldNames.Contains("CanDeleteBrands"))
				if (!Convert.IsDBNull(reader["CanDeleteBrands"]))
					userPermission.CanDeleteBrands = (bool)reader["CanDeleteBrands"];


			//Governorates
			if (fieldNames.Contains("CanCreateCategories"))
				if (!Convert.IsDBNull(reader["CanCreateCategories"]))
					userPermission.CanCreateCategories = (bool)reader["CanCreateCategories"];

			if (fieldNames.Contains("CanUpdateCategories"))
				if (!Convert.IsDBNull(reader["CanUpdateCategories"]))
					userPermission.CanUpdateCategories = (bool)reader["CanUpdateCategories"];

			if (fieldNames.Contains("CanDeleteCategories"))
				if (!Convert.IsDBNull(reader["CanDeleteCategories"]))
					userPermission.CanDeleteCategories = (bool)reader["CanDeleteCategories"];

			//Governorates
			if (fieldNames.Contains("CanCreateColors"))
				if (!Convert.IsDBNull(reader["CanCreateColors"]))
					userPermission.CanCreateColors = (bool)reader["CanCreateColors"];

			if (fieldNames.Contains("CanUpdateColors"))
				if (!Convert.IsDBNull(reader["CanUpdateColors"]))
					userPermission.CanUpdateColors = (bool)reader["CanUpdateColors"];

			if (fieldNames.Contains("CanDeleteColors"))
				if (!Convert.IsDBNull(reader["CanDeleteColors"]))
					userPermission.CanDeleteColors = (bool)reader["CanDeleteColors"];

			//Governorates
			if (fieldNames.Contains("CanCreateCountries"))
				if (!Convert.IsDBNull(reader["CanCreateCountries"]))
					userPermission.CanCreateCountries = (bool)reader["CanCreateCountries"];

			if (fieldNames.Contains("CanUpdateCountries"))
				if (!Convert.IsDBNull(reader["CanUpdateCountries"]))
					userPermission.CanUpdateCountries = (bool)reader["CanUpdateCountries"];

			if (fieldNames.Contains("CanDeleteCountries"))
				if (!Convert.IsDBNull(reader["CanDeleteCountries"]))
					userPermission.CanDeleteCountries = (bool)reader["CanDeleteCountries"];

			//Governorates
			if (fieldNames.Contains("CanCreateCurrencies"))
				if (!Convert.IsDBNull(reader["CanCreateCurrencies"]))
					userPermission.CanCreateCurrencies = (bool)reader["CanCreateCurrencies"];

			if (fieldNames.Contains("CanUpdateCurrencies"))
				if (!Convert.IsDBNull(reader["CanUpdateCurrencies"]))
					userPermission.CanUpdateCurrencies = (bool)reader["CanUpdateCurrencies"];

			if (fieldNames.Contains("CanDeleteCurrencies"))
				if (!Convert.IsDBNull(reader["CanDeleteCurrencies"]))
					userPermission.CanDeleteCurrencies = (bool)reader["CanDeleteCurrencies"];

			//Governorates
			if (fieldNames.Contains("CanCreateOrders"))
				if (!Convert.IsDBNull(reader["CanCreateOrders"]))
					userPermission.CanCreateOrders = (bool)reader["CanCreateOrders"];

			if (fieldNames.Contains("CanUpdateOrders"))
				if (!Convert.IsDBNull(reader["CanUpdateOrders"]))
					userPermission.CanUpdateOrders = (bool)reader["CanUpdateOrders"];

			if (fieldNames.Contains("CanDeleteOrders"))
				if (!Convert.IsDBNull(reader["CanDeleteOrders"]))
					userPermission.CanDeleteOrders = (bool)reader["CanDeleteOrders"];

			//Template
			if (fieldNames.Contains("UserTypesId"))
				if (!Convert.IsDBNull(reader["UserTypesId"]))
					userPermission.UserTypesId = (int)reader["UserTypesId"];

			if (fieldNames.Contains("UsersTypeName"))
				if (!Convert.IsDBNull(reader["UsersTypeName"]))
					userPermission.UsersTypeName = reader["UsersTypeName"].ToString();

			if (fieldNames.Contains("ArabicName"))
				if (!Convert.IsDBNull(reader["ArabicName"]))
					userPermission.ArabicName = reader["ArabicName"].ToString();

			if (fieldNames.Contains("EnglishName"))
				if (!Convert.IsDBNull(reader["EnglishName"]))
					userPermission.EnglishName = reader["EnglishName"].ToString();

			if (fieldNames.Contains("CanUpdateColumns"))
				if (!Convert.IsDBNull(reader["CanUpdateColumns"]))
					userPermission.CanUpdateColumns = (bool)reader["CanUpdateColumns"];

			if (fieldNames.Contains("CanUpdateColumnsTemplete"))
				if (!Convert.IsDBNull(reader["CanUpdateColumnsTemplete"]))
					userPermission.CanUpdateColumnsTemplete = (bool)reader["CanUpdateColumnsTemplete"];

			//New Added
			if (fieldNames.Contains("CanCreateItemsGovernorates"))
				if (!Convert.IsDBNull(reader["CanCreateItemsGovernorates"]))
					userPermission.CanCreateItemsGovernorates = (bool)reader["CanCreateItemsGovernorates"];

			if (fieldNames.Contains("CanUpdateItemsGovernorates"))
				if (!Convert.IsDBNull(reader["CanUpdateItemsGovernorates"]))
					userPermission.CanUpdateItemsGovernorates = (bool)reader["CanUpdateItemsGovernorates"];

			if (fieldNames.Contains("CanDeleteItemsGovernorates"))
				if (!Convert.IsDBNull(reader["CanDeleteItemsGovernorates"]))
					userPermission.CanDeleteItemsGovernorates = (bool)reader["CanDeleteItemsGovernorates"];

			if (fieldNames.Contains("CanCreateItemsCompanies"))
				if (!Convert.IsDBNull(reader["CanCreateItemsCompanies"]))
					userPermission.CanCreateItemsCompanies = (bool)reader["CanCreateItemsCompanies"];

			if (fieldNames.Contains("CanUpdateItemsCompanies"))
				if (!Convert.IsDBNull(reader["CanUpdateItemsCompanies"]))
					userPermission.CanUpdateItemsCompanies = (bool)reader["CanUpdateItemsCompanies"];

			if (fieldNames.Contains("CanDeleteItemsCompanies"))
				if (!Convert.IsDBNull(reader["CanDeleteItemsCompanies"]))
					userPermission.CanDeleteItemsCompanies = (bool)reader["CanDeleteItemsCompanies"];

			if (fieldNames.Contains("CanCreateItemsUsersTypes"))
				if (!Convert.IsDBNull(reader["CanCreateItemsUsersTypes"]))
					userPermission.CanCreateItemsUsersTypes = (bool)reader["CanCreateItemsUsersTypes"];

			if (fieldNames.Contains("CanUpdateItemsUsersTypes"))
				if (!Convert.IsDBNull(reader["CanUpdateItemsUsersTypes"]))
					userPermission.CanUpdateItemsUsersTypes = (bool)reader["CanUpdateItemsUsersTypes"];

			if (fieldNames.Contains("CanDeleteItemsUsersTypes"))
				if (!Convert.IsDBNull(reader["CanDeleteItemsUsersTypes"]))
					userPermission.CanDeleteItemsUsersTypes = (bool)reader["CanDeleteItemsUsersTypes"];

			if (fieldNames.Contains("CanCreateOffersGovernorates"))
				if (!Convert.IsDBNull(reader["CanCreateOffersGovernorates"]))
					userPermission.CanCreateOffersGovernorates = (bool)reader["CanCreateOffersGovernorates"];

			if (fieldNames.Contains("CanUpdateOffersGovernorates"))
				if (!Convert.IsDBNull(reader["CanUpdateOffersGovernorates"]))
					userPermission.CanUpdateOffersGovernorates = (bool)reader["CanUpdateOffersGovernorates"];

			if (fieldNames.Contains("CanDeleteOffersGovernorates"))
				if (!Convert.IsDBNull(reader["CanDeleteOffersGovernorates"]))
					userPermission.CanDeleteOffersGovernorates = (bool)reader["CanDeleteOffersGovernorates"];

			if (fieldNames.Contains("CanCreateOffersCompanies"))
				if (!Convert.IsDBNull(reader["CanCreateOffersCompanies"]))
					userPermission.CanCreateOffersCompanies = (bool)reader["CanCreateOffersCompanies"];

			if (fieldNames.Contains("CanUpdateOffersCompanies"))
				if (!Convert.IsDBNull(reader["CanUpdateOffersCompanies"]))
					userPermission.CanUpdateOffersCompanies = (bool)reader["CanUpdateOffersCompanies"];

			if (fieldNames.Contains("CanDeleteOffersCompanies"))
				if (!Convert.IsDBNull(reader["CanDeleteOffersCompanies"]))
					userPermission.CanDeleteOffersCompanies = (bool)reader["CanDeleteOffersCompanies"];

			if (fieldNames.Contains("CanCreateOffersUsersTypes"))
				if (!Convert.IsDBNull(reader["CanCreateOffersUsersTypes"]))
					userPermission.CanCreateOffersUsersTypes = (bool)reader["CanCreateOffersUsersTypes"];

			if (fieldNames.Contains("CanUpdateOffersUsersTypes"))
				if (!Convert.IsDBNull(reader["CanUpdateOffersUsersTypes"]))
					userPermission.CanUpdateOffersUsersTypes = (bool)reader["CanUpdateOffersUsersTypes"];

			if (fieldNames.Contains("CanDeleteOffersUsersTypes"))
				if (!Convert.IsDBNull(reader["CanDeleteOffersUsersTypes"]))
					userPermission.CanDeleteOffersUsersTypes = (bool)reader["CanDeleteOffersUsersTypes"];

			if (fieldNames.Contains("CanCreateOffersDetails"))
				if (!Convert.IsDBNull(reader["CanCreateOffersDetails"]))
					userPermission.CanCreateOffersDetails = (bool)reader["CanCreateOffersDetails"];

			if (fieldNames.Contains("CanUpdateOffersDetails"))
				if (!Convert.IsDBNull(reader["CanUpdateOffersDetails"]))
					userPermission.CanUpdateOffersDetails = (bool)reader["CanUpdateOffersDetails"];

			if (fieldNames.Contains("CanDeleteOffersDetails"))
				if (!Convert.IsDBNull(reader["CanDeleteOffersDetails"]))
					userPermission.CanDeleteOffersDetails = (bool)reader["CanDeleteOffersDetails"];

			if (fieldNames.Contains("CanCreateOrderDetails"))
				if (!Convert.IsDBNull(reader["CanCreateOrderDetails"]))
					userPermission.CanCreateOrderDetails = (bool)reader["CanCreateOrderDetails"];

			if (fieldNames.Contains("CanUpdateOrderDetails"))
				if (!Convert.IsDBNull(reader["CanUpdateOrderDetails"]))
					userPermission.CanUpdateOrderDetails = (bool)reader["CanUpdateOrderDetails"];

			if (fieldNames.Contains("CanDeleteOrderDetails"))
				if (!Convert.IsDBNull(reader["CanDeleteOrderDetails"]))
					userPermission.CanDeleteOrderDetails = (bool)reader["CanDeleteOrderDetails"];

			if (fieldNames.Contains("LoggedUser"))
				if (!Convert.IsDBNull(reader["LoggedUser"]))
					userPermission.LoggedUser = Convert.ToInt32(reader["LoggedUser"]);

			if (fieldNames.Contains("CanCreateSizesGroups"))
				if (!Convert.IsDBNull(reader["CanCreateSizesGroups"]))
					userPermission.CanCreateSizesGroups = (bool)reader["CanCreateSizesGroups"];

			if (fieldNames.Contains("CanUpdateSizesGroups"))
				if (!Convert.IsDBNull(reader["CanUpdateSizesGroups"]))
					userPermission.CanUpdateSizesGroups = (bool)reader["CanUpdateSizesGroups"];

			if (fieldNames.Contains("CanDeleteSizesGroups"))
				if (!Convert.IsDBNull(reader["CanDeleteSizesGroups"]))
					userPermission.CanDeleteSizesGroups = (bool)reader["CanDeleteSizesGroups"];

			if (fieldNames.Contains("CanCreateSizes"))
				if (!Convert.IsDBNull(reader["CanCreateSizes"]))
					userPermission.CanCreateSizes = (bool)reader["CanCreateSizes"];

			if (fieldNames.Contains("CanUpdateSizes"))
				if (!Convert.IsDBNull(reader["CanUpdateSizes"]))
					userPermission.CanUpdateSizes = (bool)reader["CanUpdateSizes"];

			if (fieldNames.Contains("CanDeleteSizes"))
				if (!Convert.IsDBNull(reader["CanDeleteSizes"]))
					userPermission.CanDeleteSizes = (bool)reader["CanDeleteSizes"];

			if (fieldNames.Contains("CanCreateBanners"))
				if (!Convert.IsDBNull(reader["CanCreateBanners"]))
					userPermission.CanCreateBanners = (bool)reader["CanCreateBanners"];

			if (fieldNames.Contains("CanUpdateBanners"))
				if (!Convert.IsDBNull(reader["CanUpdateBanners"]))
					userPermission.CanUpdateBanners = (bool)reader["CanUpdateBanners"];

			if (fieldNames.Contains("CanDeleteBanners"))
				if (!Convert.IsDBNull(reader["CanDeleteBanners"]))
					userPermission.CanDeleteBanners = (bool)reader["CanDeleteBanners"];

			if (fieldNames.Contains("CanCreateItemColors"))
				if (!Convert.IsDBNull(reader["CanCreateItemColors"]))
					userPermission.CanCreateItemColors = (bool)reader["CanCreateItemColors"];

			if (fieldNames.Contains("CanUpdateItemColors"))
				if (!Convert.IsDBNull(reader["CanUpdateItemColors"]))
					userPermission.CanUpdateItemColors = (bool)reader["CanUpdateItemColors"];

			if (fieldNames.Contains("CanDeleteItemColors"))
				if (!Convert.IsDBNull(reader["CanDeleteItemColors"]))
					userPermission.CanDeleteItemColors = (bool)reader["CanDeleteItemColors"];

			if (fieldNames.Contains("CanCreateItemSizes"))
				if (!Convert.IsDBNull(reader["CanCreateItemSizes"]))
					userPermission.CanCreateItemSizes = (bool)reader["CanCreateItemSizes"];

			if (fieldNames.Contains("CanUpdateItemSizes"))
				if (!Convert.IsDBNull(reader["CanUpdateItemSizes"]))
					userPermission.CanUpdateItemSizes = (bool)reader["CanUpdateItemSizes"];

			if (fieldNames.Contains("CanDeleteItemSizes"))
				if (!Convert.IsDBNull(reader["CanDeleteItemSizes"]))
					userPermission.CanDeleteItemSizes = (bool)reader["CanDeleteItemSizes"];

			if (fieldNames.Contains("CanCreateItemImages"))
				if (!Convert.IsDBNull(reader["CanCreateItemImages"]))
					userPermission.CanCreateItemImages = (bool)reader["CanCreateItemImages"];

			if (fieldNames.Contains("CanUpdateItemImages"))
				if (!Convert.IsDBNull(reader["CanUpdateItemImages"]))
					userPermission.CanUpdateItemImages = (bool)reader["CanUpdateItemImages"];


			if (fieldNames.Contains("CanCreateItemPrices"))
				if (!Convert.IsDBNull(reader["CanCreateItemPrices"]))
					userPermission.CanCreateItemPrices = (bool)reader["CanCreateItemPrices"];

			if (fieldNames.Contains("CanUpdateItemPrices"))
				if (!Convert.IsDBNull(reader["CanUpdateItemPrices"]))
					userPermission.CanUpdateItemPrices = (bool)reader["CanUpdateItemPrices"];

			if (fieldNames.Contains("CanDeleteItemPrices"))
				if (!Convert.IsDBNull(reader["CanDeleteItemPrices"]))
					userPermission.CanDeleteItemPrices = (bool)reader["CanDeleteItemPrices"];

			if (fieldNames.Contains("CanCreatePriceTypes"))
				if (!Convert.IsDBNull(reader["CanCreatePriceTypes"]))
					userPermission.CanCreatePriceTypes = (bool)reader["CanCreatePriceTypes"];

			if (fieldNames.Contains("CanUpdatePriceTypes"))
				if (!Convert.IsDBNull(reader["CanUpdatePriceTypes"]))
					userPermission.CanUpdatePriceTypes = (bool)reader["CanUpdatePriceTypes"];

			if (fieldNames.Contains("CanDeletePriceTypes"))
				if (!Convert.IsDBNull(reader["CanDeletePriceTypes"]))
					userPermission.CanDeletePriceTypes = (bool)reader["CanDeletePriceTypes"];

			if (fieldNames.Contains("CanCreateUserProfileColumns"))
				if (!Convert.IsDBNull(reader["CanCreateUserProfileColumns"]))
					userPermission.CanCreateUserProfileColumns = (bool)reader["CanCreateUserProfileColumns"];

			if (fieldNames.Contains("CanUpdateUserProfileColumns"))
				if (!Convert.IsDBNull(reader["CanUpdateUserProfileColumns"]))
					userPermission.CanUpdateUserProfileColumns = (bool)reader["CanUpdateUserProfileColumns"];

			if (fieldNames.Contains("CanDeleteUserProfileColumns"))
				if (!Convert.IsDBNull(reader["CanDeleteUserProfileColumns"]))
					userPermission.CanDeleteUserProfileColumns = (bool)reader["CanDeleteUserProfileColumns"];

			if (fieldNames.Contains("CanValidateUserLocation"))
				if (!Convert.IsDBNull(reader["CanValidateUserLocation"]))
					userPermission.CanValidateUserLocation = (bool)reader["CanValidateUserLocation"];

		if (fieldNames.Contains("CanCreateUserCompanies"))
				if (!Convert.IsDBNull(reader["CanCreateUserCompanies"]))
					userPermission.CanCreateUserCompanies = (bool)reader["CanCreateUserCompanies"];

			if (fieldNames.Contains("CanUpdateUserCompanies"))
				if (!Convert.IsDBNull(reader["CanUpdateUserCompanies"]))
					userPermission.CanUpdateUserCompanies = (bool)reader["CanUpdateUserCompanies"];

			if (fieldNames.Contains("CanDeleteUserCompanies"))
				if (!Convert.IsDBNull(reader["CanDeleteUserCompanies"]))
					userPermission.CanDeleteUserCompanies = (bool)reader["CanDeleteUserCompanies"];


			if (fieldNames.Contains("CanCreateUserTransferRules"))
				if (!Convert.IsDBNull(reader["CanCreateUserTransferRules"]))
					userPermission.CanCreateUserTransferRules = (bool)reader["CanCreateUserTransferRules"];

			if (fieldNames.Contains("CanUpdateUserTransferRules"))
				if (!Convert.IsDBNull(reader["CanUpdateUserTransferRules"]))
					userPermission.CanUpdateUserTransferRules = (bool)reader["CanUpdateUserTransferRules"];

			if (fieldNames.Contains("CanDeleteUserTransferRules"))
				if (!Convert.IsDBNull(reader["CanDeleteUserTransferRules"]))
					userPermission.CanDeleteUserTransferRules = (bool)reader["CanDeleteUserTransferRules"];


			if (fieldNames.Contains("CanCreateUserTypeTransferRules"))
				if (!Convert.IsDBNull(reader["CanCreateUserTypeTransferRules"]))
					userPermission.CanCreateUserTypeTransferRules = (bool)reader["CanCreateUserTypeTransferRules"];

			if (fieldNames.Contains("CanUpdateUserTypeTransferRules"))
				if (!Convert.IsDBNull(reader["CanUpdateUserTypeTransferRules"]))
					userPermission.CanUpdateUserTypeTransferRules = (bool)reader["CanUpdateUserTypeTransferRules"];

			if (fieldNames.Contains("CanDeleteUserTypeTransferRules"))
				if (!Convert.IsDBNull(reader["CanDeleteUserTypeTransferRules"]))
					userPermission.CanDeleteUserTypeTransferRules = (bool)reader["CanDeleteUserTypeTransferRules"];


			if (fieldNames.Contains("CanCreateUserTransferException"))
				if (!Convert.IsDBNull(reader["CanCreateUserTransferException"]))
					userPermission.CanCreateUserTransferException = (bool)reader["CanCreateUserTransferException"];

			if (fieldNames.Contains("CanUpdateUserTransferException"))
				if (!Convert.IsDBNull(reader["CanUpdateUserTransferException"]))
					userPermission.CanUpdateUserTransferException = (bool)reader["CanUpdateUserTransferException"];

			if (fieldNames.Contains("CanDeleteUserTransferException"))
				if (!Convert.IsDBNull(reader["CanDeleteUserTransferException"]))
					userPermission.CanDeleteUserTransferException = (bool)reader["CanDeleteUserTransferException"];


			if (fieldNames.Contains("CanViewHome"))
				if (!Convert.IsDBNull(reader["CanViewHome"]))
					userPermission.CanViewHome = (bool)reader["CanViewHome"];

			if (fieldNames.Contains("CanViewItems"))
				if (!Convert.IsDBNull(reader["CanViewItems"]))
					userPermission.CanViewItems = (bool)reader["CanViewItems"];

			if (fieldNames.Contains("CanViewReports"))
				if (!Convert.IsDBNull(reader["CanViewReports"]))
					userPermission.CanViewReports = (bool)reader["CanViewReports"];

			if (fieldNames.Contains("CanViewTransfers"))
				if (!Convert.IsDBNull(reader["CanViewTransfers"]))
					userPermission.CanViewTransfers = (bool)reader["CanViewTransfers"];

			if (fieldNames.Contains("CanViewMainBalance"))
				if (!Convert.IsDBNull(reader["CanViewMainBalance"]))
					userPermission.CanViewMainBalance = (bool)reader["CanViewMainBalance"];

			if (fieldNames.Contains("CanViewIndexs"))
				if (!Convert.IsDBNull(reader["CanViewIndexs"]))
					userPermission.CanViewIndexs = (bool)reader["CanViewIndexs"];

			if (fieldNames.Contains("CanViewOffers"))
				if (!Convert.IsDBNull(reader["CanViewOffers"]))
					userPermission.CanViewOffers = (bool)reader["CanViewOffers"];

			if (fieldNames.Contains("CanViewOrders"))
				if (!Convert.IsDBNull(reader["CanViewOrders"]))
					userPermission.CanViewOrders = (bool)reader["CanViewOrders"];

			if (fieldNames.Contains("CanViewComplains"))
				if (!Convert.IsDBNull(reader["CanViewComplains"]))
					userPermission.CanViewComplains = (bool)reader["CanViewComplains"];

			if (fieldNames.Contains("CanViewMaintenance"))
				if (!Convert.IsDBNull(reader["CanViewMaintenance"]))
					userPermission.CanViewMaintenance = (bool)reader["CanViewMaintenance"];

			if (fieldNames.Contains("CanViewUsers"))
				if (!Convert.IsDBNull(reader["CanViewUsers"]))
					userPermission.CanViewUsers = (bool)reader["CanViewUsers"];
			return userPermission;
		}




	}
}