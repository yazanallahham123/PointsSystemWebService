using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Web;
using System.Web.Security;
using PointsSystemWebService.Classes;
using System.Collections.Generic;

namespace PointsSystemUnitTest
{
    [TestClass]
    public class PointsServiceAPIUnitTest
    {
        PointsSystemWebService.PointsServiceAPI Service = new PointsSystemWebService.PointsServiceAPI();

        public PointsServiceAPIUnitTest()
        {
            PointsSystemWebService.PointsServiceAPI.APITestingMode = true;
        }


        [TestMethod]
        public void TestCreateBook()
        {
            var result = Service.CreateBook("hi");

            Assert.AreEqual(result, "hi");
        }

        [TestMethod]
        public void TestGetConfig()
        {
            var result = Service.GetConfig();

            Assert.AreEqual(result.Code, 0);
        }

        [TestMethod]
        public void TestSearchItems_MultiForPublic()
        {
            var result = Service.SearchItems_MultiForPublic(new ItemSearchClass(), PageId: 1, RecordsCount: 200);

            Assert.AreEqual(result.Code, 0);
        }

        [TestMethod]
        public void TestGetItemsForPublic()
        {
            var result = Service.GetItemsForPublic(CategoryId: 1160, PageId: 1, RecordsCount: 200);

            Assert.AreEqual(result.Code, 0);
        }

        [TestMethod]
        public void TestGetUserBadges()
        {
            var result = Service.GetUserBadges(LoggedUser: 7);

            Assert.AreEqual(result.Code, 0);
        }

        [TestMethod]
        public void TestGetItems_ShortForPublic()
        {
            var result = Service.GetItems_ShortForPublic(CategoryId: 1160, PageId: 1, RecordsCount: 200);

            Assert.AreEqual(result.Code, 0);
        }


        [TestMethod]
        public void TestGetItemFilters()
        {
            var result = Service.GetItemFilters(LoggedUser: 7, CategoryId: 0, FilterByDisabled: false, ShowDisabled: false);

            Assert.AreEqual(result.Code, 0);
        }

        [TestMethod]
        public void TestNewSearchUsers()
        {
            var result = Service.NewSearchUsers(LoggedUser: 7,
               FilterByUsername: false, Username: "", FilterByFullName: false, FullName: "",
              FilterByEmail: false, Email: "", FilterByMobileNumber: false, MobileNumber: "", MobileCountryCode: "",
              FilterByText: true, Text: "945104510", FilterByDisabled: false, Disabled: false,
              FilterByHasVocationalCertificate: false, HasVocationalCertificate: false,
              FilterByIsActive: false, IsActive: false, FilterByAddress1: false, Address1: "",
              FilterByAddress2: false, Address2: "", FilterByNickname: false, Nickname: "",
              FilterByYearsOfExperience: false, FromFilterByYearsOfExperience: 0, ToFilterByYearsOfExperience: 0,
              FilterByStaffCount: false, FromStaffCount: 0, ToStaffCount: 0,
              FilterByNotes: false, Notes: "", FilterByCommercialName: false, CommercialName: "",
              FilterByUserTypeIds: false, UserTypeIds: new List<int>(),
              FilterByCompanyIds: false, CompanyIds: new List<int>(),
              FilterByGovernorateIds: false, GovernorateIds: new List<int>(),
              FilterByCityIds: false, CityIds: new List<int>(),
              FilterByLocationIds: false, LocationIds: new List<int>(),
              FilterByPositionIds: false, PositionIds: new List<int>(),
              FilterByJobIds: false, JobIds: new List<int>(),
              FilterByWorkDomainIds: false, WorkDomainIds: new List<int>(),
              FilterByGender: false, Gender: 0,
              FilterByEducationLevelIds: false, EducationLevelIds: new List<int>(),
              FilterByCreateDate: false, FromCreateDate: "", ToCreateDate: "",
              FilterByBirthdate: false, FromBirthdate: "", ToBirthdate: "",
              FilterByLunchCount: false, FromLunchCount: 0, ToLunchCount: 0,
              SearchForSenders: false, SearchForReceivers: false,
              FilterByCountryIds: false, CountryIds: new List<int>(),
              PageId: 1, RecordsCount: 100, ForReports: false,
              NotForAdmins: true,
              ForTransfers: true, TransferStatusId: 6,
              FilterByVisibleOnMap: false, VisibleOnMap: false,
              FilterByLocationValidated: false, LocationValidated: false);

            Assert.AreEqual(result.Code, 0);
        }



        [TestMethod]
        public void TestCreateMultipleTransfer()
        {
            var Receivers_UserId = new List<int>();
            Receivers_UserId.Add(7157);

            var result = Service.CreateMultipleTransfer(LoggedUser: 7157, Date: "", Amount: 10, Sender_UserId: 7157, Notes: "", TransferStatusId: 6, Receivers_UserId: Receivers_UserId);

            Assert.AreEqual(result.Code, 0);
        }

        [TestMethod]
        public void TestCreateMultipleWithdrawTransfer()
        {
            var result = Service.CreateMultipleWithdrawTransfer(LoggedUser: 7, Date: "", Amount: 10, Senders_UserIds: new List<int>(7132), Notes: "", TransferStatusId: 6, Receiver_UserId: 7);

            Assert.AreEqual(result.Code, 0);
        }


        [TestMethod]
        public void TestRoundCurrencies()
        {
            var result = Service.RoundCurrencies(LoggedUser: 7, Factor: 1, Items: new List<int>());

            Assert.AreEqual(result.Code, 0);
        }

        [TestMethod]
        public void TestGetOfferTypes()
        {
            var result = Service.GetOfferTypes();

            Assert.AreEqual(result.Code, 0);
        }

        [TestMethod]
        public void TestGetFeatureCategories()
        {

            var result = Service.GetFeatureCategories(CategoryId: null, CountryName: "", PageId: 1, RecordsCount: 100);

            Assert.AreEqual(result.Code, 0);
        }


        //Offer
        [TestMethod]
        public void TestOffer()
        {
            int OfferId = TestCreateOfferData();

            if (OfferId > 0)
            {
                TestUpdateOfferData(OfferId);

                TestDeleteOffer(OfferId);
            }

            Assert.AreNotEqual(OfferId, 0);
        }

        [TestMethod]
        public int TestCreateOfferData()
        {
            var offer = new OfferClass
            {
                ArabicName = "ArabicName",
                EnglishName = "EnglishName",
                Code = "code",
                OfferTypeId = 2,
                //MinPrice = 9,
                //MaxPrice = 99,

                ArabicDescription = "ArabicDescription",
                EnglishDescription = "EnglishDescription",
                Disabled = false,
                Notes = "Notes",
                CreatedBy = 7,
                StartDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"), //MM/DD/YYYY HH:MM:SS
            };


            var result = Service.CreateOfferData(LoggedUser: 7, Offer: offer,
               Governorates: new List<int>(), Companies: new List<int>(),
               UserTypes: new List<int>(), Countries: new List<int>());


            Assert.AreEqual(result.Code, 0);


            if ((result.Code == 0) && (result?.Result?.OfferClass?.Id > 0))
                return result.Result.OfferClass.Id;

            return 0;
        }

        [TestMethod]
        public void TestUpdateOfferData(int Id)
        {
            var offer = new OfferClass
            {
                Id = Id,
                ArabicName = "ArabicName",
                EnglishName = "EnglishName",
                Code = "code",
                OfferTypeId = 2,
                //MinPrice = 9,
                //MaxPrice = 99,

                ArabicDescription = "ArabicDescription",
                EnglishDescription = "EnglishDescription",
                Disabled = false,
                Notes = "Notes",
                CreatedBy = 7,
                StartDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"), //MM/DD/YYYY HH:MM:SS
            };


            var result = Service.UpdateOfferData(LoggedUser: 7, Offer: offer,
               Governorates: new List<int>(), Companies: new List<int>(),
               UserTypes: new List<int>(), Countries: new List<int>());

            Assert.AreEqual(result.Code, 0);
        }

        [TestMethod]
        public void TestDeleteOffer(int Id)
        {
            var result = Service.DeleteOffer(LoggedUser: 7, Id: Id);

            Assert.AreEqual(result.Code, 0);
        }


        //MainBalance
        [TestMethod]
        public void TestMainBalance()
        {
            int mainBalanceId = TestCreateMainBalance();

            if (mainBalanceId > 0)
            {
                TestUpdateMainBalance(mainBalanceId);

                TestDeleteMainBalance(mainBalanceId);
            }

            Assert.AreNotEqual(mainBalanceId, 0);
        }

        [TestMethod]
        public int TestCreateMainBalance()
        {
            var mainBalance = new MainBalanceClass()
            {
                UserId = 7,
                Date = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"),
                Amount = 10,
                Notes = ""
            };

            var result = Service.CreateMainBalance(MainBalance: mainBalance);

            Assert.AreEqual(result.Code, 0);

            if ((result.Code == 0) && (result.Result.Id > 0))
                return result.Result.Id;

            return 0;
        }

        [TestMethod]
        public void TestUpdateMainBalance(int Id)
        {
            var mainBalance = new MainBalanceClass()
            {
                Id = Id,
                UserId = 7,
                Date = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"),
                Amount = 10,
                Notes = "updated"
            };

            var result = Service.UpdateMainBalance(MainBalance: mainBalance);

            Assert.AreEqual(result.Code, 0);
        }

        [TestMethod]
        public void TestDeleteMainBalance(int Id)
        {
            var result = Service.DeleteMainBalance(LoggedUser: 7, MainBalanceId: Id);

            Assert.AreEqual(result.Code, 0);
        }


        //User
        [TestMethod]
        public void TestUser_WithCreateUser()
        {
            int userId = TestCreateUser();

            if (userId > 0)
            {
                TestUpdateUser(userId);

                TestDeleteUser(userId);
            }

            Assert.AreNotEqual(userId, 0);
        }

        [TestMethod]
        public void TestUser_WithSignUp()
        {
            int userId = TestSignUp_ForMatjar();

            if (userId > 0)
            {
                TestUpdateUser(userId);

                TestDeleteUser(userId);
            }

            Assert.AreNotEqual(userId, 0);
        }

        [TestMethod]
        public int TestCreateUser()
        {
            var user = new UserClass()
            {

                Id = 0,
                Username = "0966325472",
                FullName = "Omar alsabek Test from API",
                Email = "",
                Password = "123456789",
                MobileNumber = "0966325472",
                CreateDate = "",
                UserType = 4,
                CompanyId = -1,
                CanGrantPoints = true,
                CanTakeOffers = false,
                Disabled = false,
                LocationId = 76,
                CityId = 1,
                Address1 = "",
                Address2 = "",
                TotalSent = 0,
                TotalReceived = 0,
                PointsBalance = 0,
                CompanyArabicName = "",
                CompanyEnglishName = "",
                LocationArabicName = "غير محدد",
                LocationEnglishName = "غير محدد",
                CityArabicName = "",
                CityEnglishName = "",
                UserTypeName = "",
                Order = 0,
                GovernorateId = 1,
                GovernorateArabicName = "",
                GovernorateEnglishName = "",
                TotalSent_Waiting = 0,
                TotalReceived_Waiting = 0,
                QRCode = "",
                PositionId = 2,
                JobId = 4,
                WorkDomainId = 3,
                EducationLevelId = 2,
                JobArabicName = "",
                JobEnglishName = "",
                PositionArabicName = "",
                PositionEnglishName = "",
                WorkDomainArabicName = "",
                WorkDomainEnglishName = "",
                EducationLevelArabicName = "",
                EducationLevelEnglishName = "",
                Birthdate = "1973-06-26",
                NickName = "Omar alsabek",
                Gender = 2,
                YearsOfExperience = 2,
                StaffCount = 2,
                HasVocationalCertificate = false,
                Notes = "",
                CommercialName = "nhgyedsg",
                AccessToken = "",
                PermissionFromTemplate = false,
                IsActive = true,
                CountryId = 1,
                OrdersPoints = 0,
                LunchCount = 0,
                VisibleOnMap = true,
                Latitude = 0,
                Longitude = 0,
                LocationValidated = false,
                CountryArabicName = "",
                CountryEnglishName = "",
                CurrencyId = 1

            };

            var result = Service.CreateUser(LoggedUser: 7, User: user);

            Assert.AreEqual(result.Code, 0);

            if ((result.Code == 0) && (result?.Result?.Id > 0))
                return result.Result.Id;

            return 0;
        }

        [TestMethod]
        public void TestUpdateUser(int Id)
        {
            var user = new UserClass()
            {
                Id = Id,
                Username = "0966325472",
                FullName = "Omar alsabek",
                Email = "",
                Password = "123456789",
                MobileNumber = "0966325472",
                CreateDate = "",
                UserType = 4,
                CompanyId = -1,
                CanGrantPoints = true,
                CanTakeOffers = false,
                Disabled = false,
                LocationId = 76,
                CityId = 1,
                Address1 = "",
                Address2 = "",
                TotalSent = 0,
                TotalReceived = 0,
                PointsBalance = 0,
                CompanyArabicName = "",
                CompanyEnglishName = "",
                LocationArabicName = "غير محدد",
                LocationEnglishName = "غير محدد",
                CityArabicName = "",
                CityEnglishName = "",
                UserTypeName = "",
                Order = 0,
                GovernorateId = 1,
                GovernorateArabicName = "",
                GovernorateEnglishName = "",
                TotalSent_Waiting = 0,
                TotalReceived_Waiting = 0,
                QRCode = "",
                PositionId = 2,
                JobId = 4,
                WorkDomainId = 3,
                EducationLevelId = 2,
                JobArabicName = "",
                JobEnglishName = "",
                PositionArabicName = "",
                PositionEnglishName = "",
                WorkDomainArabicName = "",
                WorkDomainEnglishName = "",
                EducationLevelArabicName = "",
                EducationLevelEnglishName = "",
                Birthdate = "1973-06-26",
                NickName = "Omar alsabek",
                Gender = 2,
                YearsOfExperience = 2,
                StaffCount = 2,
                HasVocationalCertificate = false,
                Notes = "",
                CommercialName = "nhgyedsg",
                AccessToken = "",
                PermissionFromTemplate = false,
                IsActive = true,
                CountryId = 1,
                OrdersPoints = 0,
                LunchCount = 0,
                VisibleOnMap = true,
                Latitude = 0,
                Longitude = 0,
                LocationValidated = false,
                CountryArabicName = "",
                CountryEnglishName = "",
                CurrencyId = 1

            };

            var result = Service.UpdateUser(LoggedUser: 7, User: user);

            Assert.AreEqual(result.Code, 0);
        }

        [TestMethod]
        public void TestDeleteUser(int Id)
        {
            var result = Service.DeleteUser(LoggedUser: 7, User: Id);

            Assert.AreEqual(result.Code, 0);
        }

        [TestMethod]
        public int TestSignUp_ForMatjar()
        {
            var user = new UserClass()
            {
                Username = "xoxxoxox",
                FullName = "Test From API",
                Password = "123456789",
                Gender = 1,
                MobileNumber = "0991234754",
                Birthdate = DateTime.Now.AddYears(-20).ToString("MM/dd/yyyy hh:mm:ss"),
                CountryId = 1,
                CurrencyId = 1
            };

            var result = Service.SignUp_ForMatjar(User: user);

            Assert.AreEqual(result.Code, 0);

            if ((result.Code == 0) && (result?.Result?.Id > 0))
                return result.Result.Id;

            return 0;
        }


        //ItemData
        [TestMethod]
        public void TestItemData()
        {
            int itemId = TestCreateItemData();

            if (itemId > 0)
            {
                TestUpdateItemData(itemId);

                TestDeleteItem(itemId);
            }

            Assert.AreNotEqual(itemId, 0);
        }

        [TestMethod]
        public int TestCreateItemData()
        {
            var itemClass = new ItemClass()
            {
                Id = -1,
                ArabicName = "Omar itemzz",
                EnglishName = "Omar itemzz",
                Code = "Ozz",
                ArabicDescription = "",
                EnglishDescription = "",
                BrandId = 1,
                CountryId = 2,
                Price = "0",
                RequiredPoints = 10,
                Disabled = false,
                Notes = "",
                ImageURL = null,
                CreatedBy = 7143,
                UpdatedBy = -1,
                CreateDate = "",
                UpdateDate = "",
                CategoryId = 21,
                BrandArabicName = "",
                BrandEnglishName = "",
                CountryArabicName = "",
                CountryEnglishName = "",
                CreatedByUsername = "",
                CreatedByFullName = "",
                UpdatedByUsername = "",
                UpdatedByFullName = "",
                CategoryArabicName = "",
                CategoryEnglishName = "",
                Order = -1,
                Param1 = "",
                Param2 = "",
                DefaultPriceTypeId = 1
            };

            var countries = new List<int>() { };
            var Governorates = new List<int>() { };
            var Companies = new List<int>() { };
            var UserTypes = new List<int>() { };
            var Images = new List<string>() { };
            var BookingDay = new List<ItemBookingDayClass>();
            var Series = new List<ItemSeriesClass>();

            var Colors = new List<ItemColorClass>()
            {
                new ItemColorClass(){
                    Id = 0,
                    Order = 1,
                    ColorId = 2,
                    ColorArabicName = "أخضر",
                    ColorEnglishName = "أخضر",
                    ArabicDescription = "",
                    HexValue = "#ffffff",
                    ColorImageURL = ""
                }
            };
            var Sizes = new List<ItemSizeClass>()
            {
                new ItemSizeClass(){
                    Id = 0,
                    SizeId = 14,
                    ArabicDescription = "test",
                    EnglishDescription = "test"
                }
            };

            var Prices = new List<ItemPriceClass>()
            {
                    new ItemPriceClass(){
                      Price= "3",
                      TypeId= 1,
                      CountryCurrencyId= 78,
                      CountryId= 9,
                      Order= 1000,
                      Id= 1000
                    },

                    new ItemPriceClass(){
                      Price= "2",
                      TypeId= 1,
                      CountryCurrencyId= 93,
                      CountryId= 9,
                      Order= 1000,
                      Id= 1000
                    }
            };


            var result = Service.CreateItemData(LoggedUser: 7, Item: itemClass,
                Governorates: Governorates,
                Colors: Colors, Companies: Companies,
                Countries: countries,
                Images: Images,
                Prices: Prices,
                Sizes: Sizes,
                UserTypes: UserTypes,
                BookingDays: BookingDay,
                Series: Series);

            Assert.AreEqual(result.Code, 0);

            if ((result.Code == 0) && (result?.Result?.ItemClass.Id > 0))
                return result.Result.ItemClass.Id;

            return 0;
        }

        [TestMethod]
        public void TestUpdateItemData(int Id)
        {
            var itemClass = new ItemClass()
            {
                Id = Id,
                ArabicName = "Omar itemzz",
                EnglishName = "Omar itemzz",
                Code = "Ozz",
                ArabicDescription = "",
                EnglishDescription = "",
                BrandId = 1,
                CountryId = 2,
                Price = "0",
                RequiredPoints = 10,
                Disabled = false,
                Notes = "",
                ImageURL = null,
                CreatedBy = 7143,
                UpdatedBy = 7,
                CreateDate = "",
                UpdateDate = "",
                CategoryId = 21,
                BrandArabicName = "",
                BrandEnglishName = "",
                CountryArabicName = "",
                CountryEnglishName = "",
                CreatedByUsername = "",
                CreatedByFullName = "",
                UpdatedByUsername = "",
                UpdatedByFullName = "",
                CategoryArabicName = "",
                CategoryEnglishName = "",
                Order = -1,
                Param1 = "",
                Param2 = "",
                DefaultPriceTypeId = 1
            };

            var countries = new List<int>() { };
            var Governorates = new List<int>() { };
            var Companies = new List<int>() { };
            var UserTypes = new List<int>() { };
            var Images = new List<string>() { };
            var BookingDays = new List<ItemBookingDayClass>();
            var Series = new List<ItemSeriesClass>();


            var Colors = new List<ItemColorClass>()
            {
                new ItemColorClass(){
                    Id = 0,
                    Order = 1,
                    ColorId = 2,
                    ColorArabicName = "أخضر",
                    ColorEnglishName = "أخضر",
                    ArabicDescription = "",
                    HexValue = "#ffffff",
                    ColorImageURL = ""
                }
            };
            var Sizes = new List<ItemSizeClass>()
            {
                new ItemSizeClass(){
                    Id = 0,
                    SizeId = 14,
                    ArabicDescription = "test",
                    EnglishDescription = "test"
                }
            };

            var Prices = new List<ItemPriceClass>()
            {
                    new ItemPriceClass(){
                      Price= "3",
                      TypeId= 1,
                      CountryCurrencyId= 78,
                      CountryId= 9,
                      Order= 1000,
                      Id= 1000
                    },

                    new ItemPriceClass(){
                      Price= "2",
                      TypeId= 1,
                      CountryCurrencyId= 93,
                      CountryId= 9,
                      Order= 1000,
                      Id= 1000
                    }
            };


            var result = Service.UpdateItemData(LoggedUser: 7, Item: itemClass,
                Governorates: Governorates,
                Colors: Colors, Companies: Companies,
                Countries: countries,
                Images: Images,
                Prices: Prices,
                Sizes: Sizes,
                UserTypes: UserTypes,
                BookingDays: BookingDays,
                Series: Series);

            Assert.AreEqual(result.Code, 0);

        }


        [TestMethod]
        public void TestDeleteItem(int Id)
        {
            var result = Service.DeleteItem(LoggedUser: 7, Id: Id);

            Assert.AreEqual(result.Code, 0);
        }


        [TestMethod]
        public void TestGetSignupCountries()
        {
            var result = Service.GetSignupCountries();

            Assert.AreNotEqual(result.Result.Count, 0);
        }
    }
}
