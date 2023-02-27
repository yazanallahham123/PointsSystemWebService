using ParameterValidatorLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParameterValidatorLibrary
{
    /// <summary>
    /// Please Don't Edit this class !!!
    /// without making a unique commit and Cherry-pick this commit among all branches
    /// </summary>
    public static class Errors
    {
        public const int FillData = 1;
        public const int NoPermissions = 2;
        public const int UsernameNotAvailable = 3;
        public const int MobileNumberIsNotAvailable = 4;
        public const int UsernameLengthMustBeSixOrOverCharacters = 5;
        public const int SenderCannotBeReceiverAtTheSameTime = 6;
        public const int NoSearchResult = 7;
        public const int QRCodeIsNotAvailable = 8;
        public const int CannotTransferToAdminUsers = 9;
        public const int NoBalance = 10;
        public const int CannotTransferPointsToThisTypeOfUsers = 11;
        public const int DataValidationError = 12;
        public const int IncorrectUsernameOrPassword = 13;
        public const int NegativeNumber = 14;
        public const int DuplicatedData = 15;
        public const int CantRenewItemHold = 16;
        public const int QuantityMustBeBiggerThanZero = 17;
        public const int HoldPeriodMustBeBiggerThanOne = 18;
        public const int OrderHoldPeriodMustBeBiggerThanItemHoldPeriod = 19;
        public const int CannotChangeUserFollowPermissionFromTemplate = 20;
        public const int CannotCancelOrder = 21;
        public const int OfferItemShouldHaveInitQuantity = 22;  //don't have messages
        public const int CannotSubmitEmptyOrder = 23;
        public const int CannotUpdateOfferItem = 24;
        public const int CannotTransferToDisabledUser = 25;
        public const int CannotCancelOrderInThisStatus = 26;
        public const int CannotAddItemToOrderInThisStatus = 27;
        public const int AdminOrSystemUserCannotBeClient = 28;
        public const int CannotDeleteOfferItem = 29;
        public const int CannotDeleteOffer = 30;
        public const int CannotAddThisItemToThisUser = 31;
        public const int NoColumnSelected = 32;
        public const int CannotDeleteOfferBecauseItIsItemsUsed = 33;
        public const int CannotInsertDuplicatedPriceOfferForSameItemInOneOffer = 34;
        public const int CannotInsertConcurrentTransfer = 35;
        public const int CannotAddItemToOrderWhenCatgDisabled = 36;
        public const int CannotDisabledUsedCurrency = 37;
        public const int CannotDeleteAllColumns = 38;
        public const int AdminCannotLoginFromMobileApplication = 39;
        public const int CannotEnablePickUpWithoutBranches = 40;

        // Error from Nuqaty
        public const int ReceiverIsInException = 50; //36
        public const int YouAreNotAllowedToSendPointsToThisUser = 51; //37
        public const int WithdrawSenderIsInException = 52; //38
        public const int YouAreNotAllowedToWithdrawPointsFromThisUser = 53; //39
        public const int WithdrawSenderHasNoBalance = 54; //40
        public const int WrongPinCode = 55; //41

        public const int ColorNotFound = 56;
        public const int SizeNotFound = 57;
        public const int PriceNotFound = 58;
        public const int CountryNotFound = 59;

        //New Error
        public const int CannotChangeCurrencyOrPriceTypeWithoutHavingPrices = 60;
        public const int CannotUpdateCountryOrCurrencyUserHaveOpenCart = 61;

        public const int EmptyBarcodes = 62;
        public const int SomeUsersMayHaveThisCoupon = 63;
        public const int CannotInsertUsersToPublicCoupon = 64;
        public const int CannotInsertMoreThanUserWithPersonalCoupon = 65;
        public const int OrderNotFound = 66;
        public const int CompanyNotFound = 67;
        public const int GovernorateNotFound = 68;
        public const int UserTypeNotFound = 69;


        //Orders Specific Errors
        public const int CannotUnPostOrderWhenUserCurrencyIsNotSameOfOrderCurrency = 70;

        //New errors for Offers
        public const int CannotCreateOfferPriceMoreThenItemPrice = 80;
        public const int CannotCreateOfferPointsMoreThenItemPoints = 81;
        public const int CannotCreateOrderWithoutPsychologicalBookImage = 82;
        public const int CannotUpdateOrderWhileShipping = 83;
        public const int DeliveryBusyCannotSetOrderInShipping = 84;
        public const int CannotSubmitOrderWithPsychotherapyMedicineWithoutCoupon = 85;

        //New errors for Items
        public const int ItemSerialNotFoundOrAlreadyScanned = 86;

        //General Error
        public const int UnknownError = -1;
        public const int Success = 0;
        public const int NotValidAccessToken = 100;
        public const int SessionTimeout = 101;
        public const int IncorrectPassword = 103;
        public const int UniqueData = 104;
        public const int UserIsDisabled = 200;
        public const int UserIsNotActive = 300;
        public const int MissingHeader = 404;

        //Nexmo Error Code (We use negative error code becasue those number follow nexmo error code)
        public const int ConcurrentVerifications = -10;
        public const int WrongDestinationNumber = -15;
        public const int CodeDoesntMatch = -16;
        public const int WrongCodeTooManyTimes = -17;

        //License Error Code
        public const int LicenseUnknownError = 911;

        public const int InvalidLicenseFile = 901;
        public const int InvalidLicenseFileData = 902;
        public const int InvalidItemsCount = 903;
        public const int InvalidUsersCount = 904;
        public const int InvalidInternetConnection = 905;
        public const int LicenseUserLimitExceeded = 906;
        public const int LicenseItemLimitExceeded = 907;
        public const int LicenseHasExpired = 908;
        public const int LicenseIsNotActive = 909;
        public const int LicenseExceeded = 910;

        /// <summary>
        /// Arabic Error
        /// </summary>
        private const string LicenseGeneralErrorArabicMessage = "خطأ في اتفاقية الترخيص.. رقم الخطأ: ";
        private static readonly string LicenseUnknownErrorArabicMessage = LicenseGeneralErrorArabicMessage + LicenseUnknownError;
        private static readonly string InvalidLicenseFileArabicMessage = LicenseGeneralErrorArabicMessage + InvalidLicenseFile;
        private static readonly string InvalidLicenseFileDataArabicMessage = LicenseGeneralErrorArabicMessage + InvalidLicenseFileData;
        private static readonly string InvalidItemsCountArabicMessage = LicenseGeneralErrorArabicMessage + InvalidItemsCount;
        private static readonly string InvalidUsersCountArabicMessage = LicenseGeneralErrorArabicMessage + InvalidUsersCount;
        private static readonly string InvalidInternetConnectionArabicMessage = LicenseGeneralErrorArabicMessage + InvalidInternetConnection;
        private static readonly string LicenseUserLimitExceededArabicMessage = LicenseGeneralErrorArabicMessage + LicenseUserLimitExceeded;
        private static readonly string LicenseItemLimitExceededArabicMessage = LicenseGeneralErrorArabicMessage + LicenseItemLimitExceeded;
        private static readonly string LicenseHasExpiredArabicMessage = LicenseGeneralErrorArabicMessage + LicenseHasExpired;
        private static readonly string LicenseIsNotActiveArabicMessage = LicenseGeneralErrorArabicMessage + LicenseIsNotActive;
        private static readonly string LicenseExceededArabicMessage = LicenseGeneralErrorArabicMessage + LicenseExceeded;

        /*Nexmo*/
        private const string ConcurrentVerificationsArabicMessage = "لا يسمح بالتحققات المتزامنة لنفس الرقم.  يرجى الإنتظار لمدة 10 دقائق و إعادة المحاولة";
        private const string WrongDestinationNumberArabicMessage = "الرقم المدخل غير صحيح.  يرجى إعادة المحاولة ";
        private const string CodeDoesntMatchArabicMessage = "الرمز المدخل غير صحيح.  يرجى إعادة المحاولة بعد 5 دقائق";
        private const string WrongCodeTooManyTimesArabicMessage = "تم إدخال الرمز بشكل خاطئ ثلاث مرات يرجى  الإنتظار لمدة 10 دقائق و إعادة المحاولة";

        /*New Error Nuqaty*/
        private const string ReceiverIsInExceptionArabicMessage = "لا يمكنك إرسال نقاط لهذا المستخدم لأنه ضمن قائمة الإستثناءات";
        private const string YouAreNotAllowedToSendPointsToThisUserArabicMessage = "لا تملك صلاحيات لإرسال نقاط لهذا المستخدم";
        private const string WithdrawSenderIsInExceptionArabicMessage = "لا يمكنك سحب نقاط من هذا المستخدم لأنه ضمن قائمة الإستثناءات";
        private const string YouAreNotAllowedToWithdrawPointsFromThisUserArabicMessage = "لا تملك صلاحيات لسحب نقاط من هذا المستخدم";
        private const string WithdrawSenderHasNoBalanceArabicMessage = "هذا العميل لا يملك رصيد كافي لسحبه";
        private const string WrongPinCodeArabicMessage = "الرمز المدخل غير صحيح";
        private const string IncorrectPasswordArabicMessage = "كلمة السر غير صحيحة";
        private const string UniqueDataArabicMessage = "لا يمكن إدخال بيانات مكررة";

        /*All Error*/
        private const string FillDataArabicMessage = "يرجى ملئ البيانات";
        private const string NoPermissionsCodeArabicMessage = "لا يوجد صلاحيات لإتمام هذه العملية";
        private const string UsernameNotAvailableArabicMessage = "اسم المستخدم غير متاح";
        private const string MobileNumberIsNotAvailableArabicMessage = "رقم الهاتف مستخدم من قبل";
        private const string UsernameLengthMustBeEightOrOverCharactersArabicMessage = "اسم المستخدم يجب أن يكون 6 أحرف أو اكثر";
        private const string SenderCannotBeReceiverAtTheSameTimeArabicMessage = "لا يمكن أن يكون المرسل هو نفسه المستقبل";
        private const string NoBalanceErrorArabicMessage = "لا يوجد رصيد كافي لإتمام العملية";
        private const string CannotTransferToAdminUsersArabicMessage = "لا يمكن تحويل رصيد إلى مستخدمين نظام أو مدراء نظام";
        private const string CannotTransferPointsToThisTypeOfUsersArabicMessage = "لا يمكن تحويل نقاط لهذا النوع من المستخدمين";
        private const string DataValidationErrorArabicMessage = "خطأ في البيانات المدخلة";
        private const string IncorrectUsernameOrPasswordArabicMessage = "تم تغيير اسم المستخدم او كلمة السر";
        private const string NegativeNumberArabicMessage = "خطأ قيمة مدخلة اصغر من الصفر";
        private const string DuplicatedDataArabicMessage = "خطأ لا يمكن ادخال معلومات موجودة مسبقا";
        private const string UnValidTokenArabicMessage = "خطأ في ترميز الوصول";
        private const string UnknownErrorArabicMessage = " خطأ غير معروف قد يكون سببه عملية حذف لسجلات مرتبطة مع فقرات أخرى أو خطأ في الإتصال يرجى المحاولة مرة أخرى";
        private const string CantRenewItemHoldArabicMessage = "لا يمكن تجديد فترة حجز المادة";
        private const string QuantityMustBeBiggerThanZeroArabicMessage = "يرجى إدخال كمية أكبر من الصفر";
        private const string HoldPeriodMustBeBiggerThanOneArabicMessage = "يرجى إدخال مدة الحجز أكبر من الواحد";
        private const string OrderHoldPeriodMustBeBiggerThanItemHoldPeriodArabicMessage = "يجب ان تكون مدة حجز الطلبية اكبر من مدة حجز المادة";
        private const string CannotChangeUserFollowPermissionFromTemplateArabicMessage = "لا يمكن تغيير صلاحيات مستخدم مسنده له قالب صلاحيات";
        private const string CannotCancelOrderArabicMessage = "لا يمكن الغاء ترحيل طلبية عند وجود سلة مفتوحة";
        private const string OfferItemShouldHaveInitQuantityArabicMessage = "يجب تحديد كمية المادة بالعرض";
        private const string CannotSubmitEmptyOrderArabicMessage = "لا يمكن ترحيل طلبية ليس لها مواد ";
        private const string CannotUpdateOfferItemArabicMessage = "لا يمكن تعديل مادة عرض عليها حركة ";
        private const string CannotDeleteOfferItemArabicMessage = "لا يمكن حذف مادة عرض عليها حركة ";
        private const string CannotDeleteOfferArabicMessage = "لا يمكن حذف مادة عرض عليها حركة ";
        private const string CannotTransferToDisabledUserArabicMessage = "لا يمكن تحويل الى مستخدم غير مفعل  ";
        private const string CannotCancelOrderInThisStatusArabicMessage = "لا يمكن تغيير حالة الطلبية المرحلة  ";
        private const string NoSearchResultArabicMessage = "لا يوجد نتائج بحث  ";
        private const string CannotAddItemToOrderInThisStatusArabicMessage = "لا يمكن الاضافة على السلة في هذه الحالة  ";
        private const string NoColumnSelectedArabicMessage = "لا يمكن تصدير تقرير بدون تخصيص اعمدة";
        private const string QRCodeIsNotAvailableArabicMessage = "رمز التعريف مستخدم من قبل";
        private const string NotValidAccessTokenArabicMessage = "خطأ في ترميز الوصول";
        private const string SessionTimeoutArabicMessage = "تم انتهاء زمن الجلسة الحالية";
        private const string UserIsDisabledArabicMessage = "تم ايقاف المستخدم الخاص بكم يرجى مراجعة ادارة";
        private const string UserIsNotActiveArabicMessage = "تم ايقاف تفعيل المستخدم الخاص بكم يرجى مراجعة ادارة";
        private const string AdminOrSystemUserCannotBeClientArabicMessage = "مدير النظام أو مستخدم النظام لا يمكن أن يصبح وكيل أو وكيل فرعي أو عميل";
        private const string CannotAddThisItemToThisUserArabicMessage = "لا يمكن إضافة هذه المادة إلى سلة هذا المستخدم";
        private const string CannotDeleteOfferBecauseItIsItemsUsedArabicMessage = "لا يمكن حذف هذا العرض لأن المواد الموجودة به مستخدمة";
        private const string CannotInsertDuplicatedPriceOfferForSameItemInOneOfferArabicMessage = "لا يمكن تكرار عرض على نوع سعر لنفس المادة موجود ضمن عرض واحد";
        private const string CannotInsertConcurrentTransferArabicMessage = "لا يمكن القيام بعملية تحويل اخرى حتى انتهاء فترة انتظار 30 ثانية";
        private const string CannotAddItemToOrderWhenCatgDisabledArabicMessage = "لا يمكن اضافة هذه المادة الى السلة ";
        private const string CannotDisabledUsedCurrencyArabicMessage = "لا يمكن تعطيل عملة مستخدمة";
        private const string CannotDeleteAllColumnsArabicMessage = "لا يمكن حذف جميع الحقول";
        private const string AdminCannotLoginFromMobileApplicationArabicMessage = "لا يمكن تسجيل الدخول للتطبيق من حساب مدير";
        private const string CannotEnablePickUpWithoutBranchesArabicMessage = "لا يمكن تفعيل الاستلام بدون تعريف فروع";
        private const string CannotChangeCurrencyOrPriceTypeWithoutHavingPricesArabicMessage = "لا يمكن تغيير عملة الاحتساب او نوع السعر بدون وجود اسعار لجميع المواد بالعملة الجديدة ونوع سعر جديد";
        private const string CannotUpdateCountryOrCurrencyUserHaveOpenCartArabicMessage = "لا يمكن تعديل معلومات العملة أو الدولة بسبب وجود سلة مفتوحة";
        private const string CannotUnPostOrderWhenUserCurrencyIsNotSameOfOrderCurrencyArabicMessage = "لا يمكن الغاء ترحيل الطلبية عندما تكون عملة المستخدم مختلفة عن عملة الطلبية";

        private const string EmptyBarcodesArabicMessage = "لا يمكن إدخال باركود فارغ";
        private const string SomeUsersMayHaveThisCouponArabicMessage = "من الممكن أن بعض المستخدمين يملكن هذه الكوبون";
        private const string CannotInsertUsersToPublicCouponArabicMessage = "لا يمكن ادخال مستخدمين لكوبون عام";
        private const string CannotInsertMoreThanUserWithPersonalCouponArabicMessage = "لا يمكن ادخال أكثر من مستخدم لكوبون شخصي";
        private const string OrderNotFoundArabicMessage = "الطلبية غير موجودة";
        private const string CannotCreateOfferPriceMoreThenItemPriceArabicMessage = "لا يمكن إنشاء سعر عرض أكبر من سعر المادة";
        private const string CannotCreateOfferPointsMoreThenItemPointsArabicMessage = "لا يمكن إنشاء عرض نقاط اكبر من نقاط المادة";
        private const string CannotCreateOrderWithoutPsychologicalBookImageArabicMessage = "لا يمكن إنشاء طلبية من دون تصوير دفتر نفسي";
        private const string CannotUpdateOrderWhileShippingArabicMessage = "لا يمكن تعديل على طلبية قيد التوصيل";
        private const string DeliveryBusyCannotSetOrderInShippingArabicMessage = " لا يمكن تعديل حالة الطلبية الى قيد التوصيل لان عامل التوصيل مشغول";
        private const string CannotSubmitOrderWithPsychotherapyMedicineWithoutCouponArabicMessage = "لا يمكن ترحيل طلبية تحوي عل دواء نفسي بدون ادخال صورة الكوبون الخاص بالدواء";
          
        private const string ColorNotFoundArabicMessage = "اللون المدخل غير موجود";
        private const string SizeNotFoundArabicMessage = "القياس المدخل غير موجود";
        private const string PriceNotFoundArabicMessage = "السعر المدخل غير موجود";
        private const string CountryNotFoundArabicMessage = "البلد المدخل غير موجود";
        private const string CompanyNotFoundArabicMessage = "الشركة المدخل غير موجود";
        private const string GovernorateNotFoundArabicMessage = "المحافظة المدخل غير موجود";
        private const string UserTypeNotFoundArabicMessage = "نوع المستخدم المدخل غير موجود";

        private const string ItemSerialNotFoundOrAlreadyScannedArabicMessage = "السيريال غير معرفة او قد تم تفعيلها مسبقاً";


        /// <summary>
        /// English Error
        /// </summary>
        /*License Error*/
        private const string LicenseGeneralErrorEnglishMessage = "Error in System License.. Error Code: ";
        private static readonly string LicenseUnknownErrorEnglishMessage = LicenseGeneralErrorEnglishMessage + LicenseUnknownError;
        private static readonly string InvalidLicenseFileEnglishMessage = LicenseGeneralErrorEnglishMessage + InvalidLicenseFile;
        private static readonly string InvalidLicenseFileDataEnglishMessage = LicenseGeneralErrorEnglishMessage + InvalidLicenseFileData;
        private static readonly string InvalidItemsCountEnglishMessage = LicenseGeneralErrorEnglishMessage + InvalidItemsCount;
        private static readonly string InvalidUsersCountEnglishMessage = LicenseGeneralErrorEnglishMessage + InvalidUsersCount;
        private static readonly string InvalidInternetConnectionEnglishMessage = LicenseGeneralErrorEnglishMessage + InvalidInternetConnection;
        private static readonly string LicenseUserLimitExceededEnglishMessage = LicenseGeneralErrorEnglishMessage + LicenseUserLimitExceeded;
        private static readonly string LicenseItemLimitExceededEnglishMessage = LicenseGeneralErrorEnglishMessage + LicenseItemLimitExceeded;
        private static readonly string LicenseHasExpiredEnglishMessage = LicenseGeneralErrorEnglishMessage + LicenseHasExpired;
        private static readonly string LicenseIsNotActiveEnglishMessage = LicenseGeneralErrorEnglishMessage + LicenseIsNotActive;
        private static readonly string LicenseExceededEnglishMessage = LicenseGeneralErrorEnglishMessage + LicenseExceeded;

        /*Nexmo*/
        private const string ConcurrentVerificationsEnglishMessage = "Concurrent verifications to the same number are not allowed ";
        private const string WrongDestinationNumberEnglishMessage = "The destination number is not in a supported network";
        private const string CodeDoesntMatchEnglishMessage = "The code inserted does not match the expected value";
        private const string WrongCodeTooManyTimesEnglishMessage = "The wrong code was provided too many times";

        /*New Error Nuqaty*/
        private const string ReceiverIsInExceptionEnglishMessage = "Cannot send to this user because it is listed in the exceptions list";
        private const string YouAreNotAllowedToSendPointsToThisUserEnglishMessage = "You don't have permissions to send points to this user type";
        private const string WithdrawSenderIsInExceptionEnglishMessage = "Cannot withdraw from this user because it is listed in the exceptions list";
        private const string YouAreNotAllowedToWithdrawPointsFromThisUserEnglishMessage = "You don't have permissions to withdraw points from this user type";
        private const string WithdrawSenderHasNoBalanceEnglishMessage = "This user has no engough balance to withdraw it";
        private const string WrongPinCodeEnglishMessage = "Wrong PinCode";
        private const string IncorrectPasswordEnglishMessage = "Incorrect Password";
        private const string UniqueDataEnglishMessage = "Cannot insert duplicate data";

        /*All Error*/
        private const string FillDataEnglishMessage = "Please fill missing data";
        private const string NoPermissionsCodeEnglishMessage = "You don't have permission to complete this operation";
        private const string UsernameNotAvailableEnglishMessage = "Username is not available";
        private const string MobileNumberIsNotAvailableEnglishMessage = "Mobile number is not available";
        private const string UsernameLengthMustBeEightOrOverCharactersEnglishMessage = "Username length must be 6 characters or more";
        private const string SenderCannotBeReceiverAtTheSameTimeEnglishMessage = "You cannot transfer to your self";
        private const string NoBalanceErrorEnglishMessage = "No Balance";
        private const string CannotTransferToAdminUsersEnglishMessage = "Cannot transfer to admin users";
        private const string NotValidAccessTokenEnglishMessage = "Not valid access token";
        private const string DataValidationErrorEnglishMessage = "Data validation error";
        private const string NegativeNumberEnglishMessage = "Please enter positive value";
        private const string DuplicatedDataEnglishMessage = "Cannot Insert Duplicated Data";
        private const string CantRenewItemHoldEnglishMessage = "Cannot Renew Item Hold ";
        private const string UnValidTokenEnglishMessage = "Token validation error";
        private const string UnknownErrorEnglishMessage = "Unknown Error";
        private const string QuantityMustBeBiggerThanZeroEnglishMessage = "Quantity must be bigger than zero";
        private const string HoldPeriodMustBeBiggerThanOneEnglishMessage = "Hold Period must be bigger than one";
        private const string OrderHoldPeriodMustBeBiggerThanItemHoldPeriodEnglishMessage = "Order Hold Period Must Be Bigger Than Item Hold Period";
        private const string CannotChangeUserFollowPermissionFromTemplateEnglishMessage = "Can't Change User Follow Permission From Template";
        private const string CannotCancelOrderEnglishMessage = "Can't Cancel Order When there is Open Order";
        private const string OfferItemShouldHaveInitQuantityEnglishMessage = "Offer Item Should Have Init Quantity";
        private const string CannotSubmitEmptyOrderEnglishMessage = "Cannot Submit Empty Order";
        private const string AdminOrSystemUserCannotBeClientEnglishMessage = "Administrator or System User cannot be any type of clients";
        private const string QRCodeIsNotAvailableEnglishMessage = "QR Code Is Not Available";
        private const string CannotTransferPointsToThisTypeOfUsersEnglishMessage = "Cannot Transfer Points To This Type Of Users";
        private const string CannotUpdateOfferItemEnglishMessage = "Cannot Update Offer Item";
        private const string CannotTransferToDisabledUserEnglishMessage = "Cannot Transfer To Disabled User";
        private const string UserIsDisabledEnglishMessage = "User Is Disabled";
        private const string CannotCancelOrderInThisStatusEnglishMessage = "Cannot Cancel Order In This Status";
        private const string NoSearchResultEnglishMessage = "No Search Result";
        private const string CannotAddItemToOrderInThisStatusEnglishMessage = "Cannot Add Item To Order In This Status";
        private const string UserIsNotActiveEnglishMessage = "User Is Not Active";
        private const string CannotDeleteOfferEnglishMessage = "Cannot Delete Offer";
        private const string CannotDeleteOfferItemEnglishMessage = "Cannot Delete Offer Item";
        private const string SessionTimeoutEnglishMessage = "Session Timeout";
        private const string IncorrectUsernameOrPasswordEnglishMessage = "Incorrect Username Or Password";
        private const string NoColumnSelectedEnglishMessage = "No Column Selected";
        private const string CannotAddThisItemToThisUserEnglishMessage = "Cannot Add This Item To This User";
        private const string CannotDeleteOfferBecauseItIsItemsUsedEnglishMessage = "Cannot Delete Offer that have items used in orders";
        private const string CannotInsertDuplicatedPriceOfferForSameItemInOneOfferEnglishMessage = "Cannot insert duplicated price offer for same item in one offer";
        private const string CannotInsertConcurrentTransferEnglishMessage = "Cannot Insert Concurrent Transfer";
        private const string CannotAddItemToOrderWhenCatgDisabledEnglishMessage = "Cannot Add Item To Order When Catgory Disabled";
        private const string CannotDisabledUsedCurrencyEnglishMessage = "Cannot Disabled Used Currency";
        private const string CannotDeleteAllColumnsEnglishMessage = "Cannot Delete All Columns";
        private const string AdminCannotLoginFromMobileApplicationEnglishMessage = "As Admin you can’t login from client app";
        private const string CannotEnablePickUpWithoutBranchesEnglishMessage = "Cannot Enable PickUp Without Branches";
        private const string CannotChangeCurrencyOrPriceTypeWithoutHavingPricesEnglishMessage = "Cannot Change Currency Or PriceType Without Having Prices For All Items";
        private const string CannotUpdateCountryOrCurrencyUserHaveOpenCartEnglishMessage = "Cannot update currancy or country user with an open cart";
        private const string CannotUnPostOrderWhenUserCurrencyIsNotSameOfOrderCurrencyEnglishMessage = "Cannot unpost order when user currency is different from order currency";

        private const string EmptyBarcodesEnglishMessage = "Cannot insert empty barcode";
        private const string SomeUsersMayHaveThisCouponEnglishMessage = "Some users may have this coupon";
        private const string CannotInsertUsersToPublicCouponEnglishMessage = "Cannot insert users to public coupon";
        private const string CannotInsertMoreThanUserWithPersonalCouponEnglishMessage = "Cannot insert more than user with personal coupon";
        private const string OrderNotFoundEnglishMessage = "Order not found";

        private const string CannotCreateOfferPriceMoreThenItemPriceEnglishMessage = "Cannot create offer price more then item price";
        private const string CannotCreateOfferPointsMoreThenItemPointsEnglishMessage = "Cannot create offer points more then item points";
        private const string CannotCreateOrderWithoutPsychologicalBookImageEnglishMessage = "Cannot Create Order Without Psychological Book Image";

        private const string CannotUpdateOrderWhileShippingEnglishMessage = "Cannot Update Order While Shipping";
        private const string DeliveryBusyCannotSetOrderInShippingEnglishMessage = "Delivery Busy Cannot Set Order InShipping";
        private const string CannotSubmitOrderWithPsychotherapyMedicineWithoutCouponEnglishMessage = "Cannot Submit Order With Psychotherapy Medicine Without Coupon";

        private const string ColorNotFoundEnglishMessage = "Color Not Found";
        private const string SizeNotFoundEnglishMessage = "Size Not Found";
        private const string PriceNotFoundEnglishMessage = "Price Not Found";
        private const string CountryNotFoundEnglishMessage = "Country Not Found";
        private const string CompanyNotFoundEnglishMessage = "Company Not Found";
        private const string GovernorateNotFoundEnglishMessage = "Governorate Not Found";
        private const string UserTypeNotFoundEnglishMessage = "User Type Not Found";

        private const string ItemSerialNotFoundOrAlreadyScannedEnglishMessage = "Serial is not found or already scanned";


        public static void LogError(int LoggedUser, string ErrorMessage, string Stack, string Version, string SourcePlatform, string SourceFunction, string Param, string Param2)
        {
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Developers_LogError"
                    };
                    List<SqlParameter> Params = new List<SqlParameter>()
                    {
                        new SqlParameter("LoggedUser", LoggedUser),
                        new SqlParameter("ErrorMessage", ErrorMessage),
                        new SqlParameter("Stack", Stack),
                        new SqlParameter("Version", Version),
                        new SqlParameter("SourcePlatform", SourcePlatform),
                        new SqlParameter("SourceFunction", SourceFunction),
                        new SqlParameter("Param", Param),
                        new SqlParameter("Param2", Param2),
                    };

                    cmd.Parameters.AddRange(Params.ToArray());
                    cmd.ExecuteReader();
                }
            }
            catch (Exception) { }
        }

        public static string GetErrorMessage(int Code)
        {
            var language = HttpContext.Current?.Request?.Headers["language"];
            if (language == "en")
            {
                switch (Code)
                {
                    case FillData: return FillDataEnglishMessage;
                    case NoPermissions: return NoPermissionsCodeEnglishMessage;
                    case UsernameNotAvailable: return UsernameNotAvailableEnglishMessage;
                    case MobileNumberIsNotAvailable: return MobileNumberIsNotAvailableEnglishMessage;
                    case UsernameLengthMustBeSixOrOverCharacters: return UsernameLengthMustBeEightOrOverCharactersEnglishMessage;
                    case SenderCannotBeReceiverAtTheSameTime: return SenderCannotBeReceiverAtTheSameTimeEnglishMessage;
                    case UnknownError: return UnknownErrorEnglishMessage;
                    case NoBalance: return NoBalanceErrorEnglishMessage;
                    case QRCodeIsNotAvailable: return QRCodeIsNotAvailableEnglishMessage;
                    case CannotTransferToAdminUsers: return CannotTransferToAdminUsersEnglishMessage;
                    case CannotTransferPointsToThisTypeOfUsers: return CannotTransferPointsToThisTypeOfUsersEnglishMessage;
                    case DataValidationError: return DataValidationErrorEnglishMessage;
                    case NegativeNumber: return NegativeNumberEnglishMessage;
                    case CantRenewItemHold: return CantRenewItemHoldEnglishMessage;
                    case QuantityMustBeBiggerThanZero: return QuantityMustBeBiggerThanZeroEnglishMessage;
                    case HoldPeriodMustBeBiggerThanOne: return HoldPeriodMustBeBiggerThanOneEnglishMessage;
                    case OrderHoldPeriodMustBeBiggerThanItemHoldPeriod: return OrderHoldPeriodMustBeBiggerThanItemHoldPeriodEnglishMessage;
                    case CannotChangeUserFollowPermissionFromTemplate: return CannotChangeUserFollowPermissionFromTemplateEnglishMessage;
                    case CannotCancelOrder: return CannotCancelOrderEnglishMessage;
                    case CannotSubmitEmptyOrder: return CannotSubmitEmptyOrderEnglishMessage;
                    case CannotUpdateOfferItem: return CannotUpdateOfferItemEnglishMessage;
                    case CannotTransferToDisabledUser: return CannotTransferToDisabledUserEnglishMessage;
                    case UserIsDisabled: return UserIsDisabledEnglishMessage;
                    case CannotCancelOrderInThisStatus: return CannotCancelOrderInThisStatusEnglishMessage;
                    case NoSearchResult: return NoSearchResultEnglishMessage;
                    case CannotAddItemToOrderInThisStatus: return CannotAddItemToOrderInThisStatusEnglishMessage;
                    case UserIsNotActive: return UserIsNotActiveEnglishMessage;
                    case CannotDeleteOffer: return CannotDeleteOfferEnglishMessage;
                    case CannotDeleteOfferItem: return CannotDeleteOfferItemEnglishMessage;
                    case SessionTimeout: return SessionTimeoutEnglishMessage;
                    case IncorrectUsernameOrPassword: return IncorrectUsernameOrPasswordEnglishMessage;
                    case CannotAddThisItemToThisUser: return CannotAddThisItemToThisUserEnglishMessage;
                    case CannotInsertConcurrentTransfer: return CannotInsertConcurrentTransferEnglishMessage;
                    case CannotAddItemToOrderWhenCatgDisabled: return CannotAddItemToOrderWhenCatgDisabledEnglishMessage;
                    case CannotDisabledUsedCurrency: return CannotDisabledUsedCurrencyEnglishMessage;
                    case CannotDeleteAllColumns: return CannotDeleteAllColumnsEnglishMessage;
                    case AdminCannotLoginFromMobileApplication: return AdminCannotLoginFromMobileApplicationEnglishMessage;
                    case CannotUpdateCountryOrCurrencyUserHaveOpenCart: return CannotUpdateCountryOrCurrencyUserHaveOpenCartEnglishMessage;
                    case EmptyBarcodes: return EmptyBarcodesEnglishMessage;
                    case CannotCreateOfferPriceMoreThenItemPrice: return CannotCreateOfferPriceMoreThenItemPriceEnglishMessage;
                    case CannotCreateOfferPointsMoreThenItemPoints: return CannotCreateOfferPointsMoreThenItemPointsEnglishMessage;
                    case SomeUsersMayHaveThisCoupon: return SomeUsersMayHaveThisCouponEnglishMessage;
                    case CannotInsertUsersToPublicCoupon: return CannotInsertUsersToPublicCouponEnglishMessage;
                    case CannotInsertMoreThanUserWithPersonalCoupon: return CannotInsertMoreThanUserWithPersonalCouponEnglishMessage;
                    case OrderNotFound: return OrderNotFoundEnglishMessage;
                    case CannotSubmitOrderWithPsychotherapyMedicineWithoutCoupon: return CannotSubmitOrderWithPsychotherapyMedicineWithoutCouponEnglishMessage;


                    /*Nexmo*/
                    case ConcurrentVerifications: return ConcurrentVerificationsEnglishMessage;
                    case WrongDestinationNumber: return WrongDestinationNumberEnglishMessage;
                    case CodeDoesntMatch: return CodeDoesntMatchEnglishMessage;
                    case WrongCodeTooManyTimes: return WrongCodeTooManyTimesEnglishMessage;
                    case CannotEnablePickUpWithoutBranches: return CannotEnablePickUpWithoutBranchesEnglishMessage;

                    /*Nuqaty*/
                    case ReceiverIsInException: return ReceiverIsInExceptionEnglishMessage;
                    case YouAreNotAllowedToSendPointsToThisUser: return YouAreNotAllowedToSendPointsToThisUserEnglishMessage;
                    case WithdrawSenderIsInException: return WithdrawSenderIsInExceptionEnglishMessage;
                    case YouAreNotAllowedToWithdrawPointsFromThisUser: return YouAreNotAllowedToWithdrawPointsFromThisUserEnglishMessage;
                    case WithdrawSenderHasNoBalance: return WithdrawSenderHasNoBalanceEnglishMessage;
                    case IncorrectPassword: return IncorrectPasswordEnglishMessage;
                    case UniqueData: return UniqueDataEnglishMessage;
                    case CannotChangeCurrencyOrPriceTypeWithoutHavingPrices: return CannotChangeCurrencyOrPriceTypeWithoutHavingPricesEnglishMessage;

                    /*General*/
                    case NoColumnSelected: return NoColumnSelectedEnglishMessage;
                    case CannotDeleteOfferBecauseItIsItemsUsed: return CannotDeleteOfferBecauseItIsItemsUsedEnglishMessage;
                    case DuplicatedData: return DuplicatedDataEnglishMessage;
                    case NotValidAccessToken: return NotValidAccessTokenEnglishMessage;
                    case AdminOrSystemUserCannotBeClient: return AdminOrSystemUserCannotBeClientEnglishMessage;
                    case CannotInsertDuplicatedPriceOfferForSameItemInOneOffer: return CannotInsertDuplicatedPriceOfferForSameItemInOneOfferEnglishMessage;
                    case WrongPinCode: return WrongPinCodeEnglishMessage;

                    case CannotUpdateOrderWhileShipping: return CannotUpdateOrderWhileShippingEnglishMessage;
                    case DeliveryBusyCannotSetOrderInShipping: return DeliveryBusyCannotSetOrderInShippingEnglishMessage;
                    case ColorNotFound: return ColorNotFoundEnglishMessage;
                    case SizeNotFound: return SizeNotFoundEnglishMessage;
                    case PriceNotFound: return PriceNotFoundEnglishMessage;
                    case CountryNotFound: return CountryNotFoundEnglishMessage;
                    case CompanyNotFound: return CompanyNotFoundEnglishMessage;
                    case GovernorateNotFound: return GovernorateNotFoundEnglishMessage;
                    case UserTypeNotFound: return UserTypeNotFoundEnglishMessage;


                    /*License*/
                    case LicenseUnknownError: return LicenseUnknownErrorEnglishMessage;
                    case InvalidLicenseFile: return InvalidLicenseFileEnglishMessage;
                    case InvalidLicenseFileData: return InvalidLicenseFileEnglishMessage;
                    case InvalidItemsCount: return InvalidLicenseFileEnglishMessage;
                    case InvalidUsersCount: return InvalidLicenseFileEnglishMessage;
                    case InvalidInternetConnection: return InvalidLicenseFileEnglishMessage;
                    case LicenseUserLimitExceeded: return InvalidLicenseFileEnglishMessage;
                    case LicenseItemLimitExceeded: return LicenseItemLimitExceededEnglishMessage;
                    case LicenseHasExpired: return LicenseHasExpiredEnglishMessage;
                    case LicenseIsNotActive: return LicenseIsNotActiveEnglishMessage;
                    case LicenseExceeded: return LicenseExceededEnglishMessage;

                    case CannotUnPostOrderWhenUserCurrencyIsNotSameOfOrderCurrency: return CannotUnPostOrderWhenUserCurrencyIsNotSameOfOrderCurrencyEnglishMessage;
                    case CannotCreateOrderWithoutPsychologicalBookImage: return CannotCreateOrderWithoutPsychologicalBookImageEnglishMessage;
                    case ItemSerialNotFoundOrAlreadyScanned: return ItemSerialNotFoundOrAlreadyScannedEnglishMessage;

                    default: return UnknownErrorEnglishMessage;
                }
            }
            else
            {
                switch (Code)
                {
                    case FillData: return FillDataArabicMessage;
                    case NoPermissions: return NoPermissionsCodeArabicMessage;
                    case UsernameNotAvailable: return UsernameNotAvailableArabicMessage;
                    case MobileNumberIsNotAvailable: return MobileNumberIsNotAvailableArabicMessage;
                    case UsernameLengthMustBeSixOrOverCharacters: return UsernameLengthMustBeEightOrOverCharactersArabicMessage;
                    case SenderCannotBeReceiverAtTheSameTime: return SenderCannotBeReceiverAtTheSameTimeArabicMessage;
                    case UnknownError: return UnknownErrorArabicMessage;
                    case NoBalance: return NoBalanceErrorArabicMessage;
                    case QRCodeIsNotAvailable: return QRCodeIsNotAvailableArabicMessage;
                    case CannotTransferToAdminUsers: return CannotTransferToAdminUsersArabicMessage;
                    case CannotTransferPointsToThisTypeOfUsers: return CannotTransferPointsToThisTypeOfUsersArabicMessage;
                    case DataValidationError: return DataValidationErrorArabicMessage;
                    case NegativeNumber: return NegativeNumberArabicMessage;
                    case CantRenewItemHold: return CantRenewItemHoldArabicMessage;
                    case QuantityMustBeBiggerThanZero: return QuantityMustBeBiggerThanZeroArabicMessage;
                    case HoldPeriodMustBeBiggerThanOne: return HoldPeriodMustBeBiggerThanOneArabicMessage;
                    case OrderHoldPeriodMustBeBiggerThanItemHoldPeriod: return OrderHoldPeriodMustBeBiggerThanItemHoldPeriodArabicMessage;
                    case CannotChangeUserFollowPermissionFromTemplate: return CannotChangeUserFollowPermissionFromTemplateArabicMessage;
                    case CannotCancelOrder: return CannotCancelOrderArabicMessage;
                    case CannotSubmitEmptyOrder: return CannotSubmitEmptyOrderArabicMessage;
                    case CannotUpdateOfferItem: return CannotUpdateOfferItemArabicMessage;
                    case CannotTransferToDisabledUser: return CannotTransferToDisabledUserArabicMessage;
                    case UserIsDisabled: return UserIsDisabledArabicMessage;
                    case CannotCancelOrderInThisStatus: return CannotCancelOrderInThisStatusArabicMessage;
                    case NoSearchResult: return NoSearchResultArabicMessage;
                    case CannotAddItemToOrderInThisStatus: return CannotAddItemToOrderInThisStatusArabicMessage;
                    case UserIsNotActive: return UserIsNotActiveArabicMessage;
                    case CannotDeleteOffer: return CannotDeleteOfferArabicMessage;
                    case CannotDeleteOfferItem: return CannotDeleteOfferItemArabicMessage;
                    case SessionTimeout: return SessionTimeoutArabicMessage;
                    case IncorrectUsernameOrPassword: return IncorrectUsernameOrPasswordArabicMessage;
                    case CannotAddThisItemToThisUser: return CannotAddThisItemToThisUserArabicMessage;
                    case CannotDeleteOfferBecauseItIsItemsUsed: return CannotDeleteOfferBecauseItIsItemsUsedArabicMessage;
                    case NoColumnSelected: return NoColumnSelectedArabicMessage;
                    case CannotInsertConcurrentTransfer: return CannotInsertConcurrentTransferArabicMessage;
                    case CannotAddItemToOrderWhenCatgDisabled: return CannotAddItemToOrderWhenCatgDisabledArabicMessage;
                    case CannotDisabledUsedCurrency: return CannotDisabledUsedCurrencyArabicMessage;
                    case CannotDeleteAllColumns: return CannotDeleteAllColumnsArabicMessage;
                    case AdminCannotLoginFromMobileApplication: return AdminCannotLoginFromMobileApplicationArabicMessage;
                    case CannotEnablePickUpWithoutBranches: return CannotEnablePickUpWithoutBranchesArabicMessage;
                    case CannotUpdateCountryOrCurrencyUserHaveOpenCart: return CannotUpdateCountryOrCurrencyUserHaveOpenCartArabicMessage;
                    case EmptyBarcodes: return EmptyBarcodesArabicMessage;
                    case SomeUsersMayHaveThisCoupon: return SomeUsersMayHaveThisCouponArabicMessage;
                    case CannotInsertUsersToPublicCoupon: return CannotInsertUsersToPublicCouponArabicMessage;
                    case CannotInsertMoreThanUserWithPersonalCoupon: return CannotInsertMoreThanUserWithPersonalCouponArabicMessage;
                    case OrderNotFound: return OrderNotFoundArabicMessage;

                    case CannotCreateOfferPriceMoreThenItemPrice: return CannotCreateOfferPriceMoreThenItemPriceArabicMessage;
                    case CannotCreateOfferPointsMoreThenItemPoints: return CannotCreateOfferPointsMoreThenItemPointsArabicMessage;



                    /*Nexmo*/
                    case ConcurrentVerifications: return ConcurrentVerificationsArabicMessage;
                    case WrongDestinationNumber: return WrongDestinationNumberArabicMessage;
                    case CodeDoesntMatch: return CodeDoesntMatchArabicMessage;
                    case WrongCodeTooManyTimes: return WrongCodeTooManyTimesArabicMessage;

                    /*Nuqaty*/
                    case ReceiverIsInException: return ReceiverIsInExceptionArabicMessage;
                    case YouAreNotAllowedToSendPointsToThisUser: return YouAreNotAllowedToSendPointsToThisUserArabicMessage;
                    case WithdrawSenderIsInException: return WithdrawSenderIsInExceptionArabicMessage;
                    case YouAreNotAllowedToWithdrawPointsFromThisUser: return YouAreNotAllowedToWithdrawPointsFromThisUserArabicMessage;
                    case WithdrawSenderHasNoBalance: return WithdrawSenderHasNoBalanceArabicMessage;
                    case CannotChangeCurrencyOrPriceTypeWithoutHavingPrices: return CannotChangeCurrencyOrPriceTypeWithoutHavingPricesArabicMessage;

                    /*General*/
                    case DuplicatedData: return DuplicatedDataArabicMessage;
                    case NotValidAccessToken: return NotValidAccessTokenArabicMessage;
                    case AdminOrSystemUserCannotBeClient: return AdminOrSystemUserCannotBeClientArabicMessage;
                    case CannotInsertDuplicatedPriceOfferForSameItemInOneOffer: return CannotInsertDuplicatedPriceOfferForSameItemInOneOfferArabicMessage;
                    case WrongPinCode: return WrongPinCodeArabicMessage;
                    case IncorrectPassword: return IncorrectPasswordArabicMessage;
                    case UniqueData: return UniqueDataArabicMessage;

                    case CannotUpdateOrderWhileShipping: return CannotUpdateOrderWhileShippingArabicMessage;
                    case DeliveryBusyCannotSetOrderInShipping: return DeliveryBusyCannotSetOrderInShippingArabicMessage;
                    case ColorNotFound: return ColorNotFoundArabicMessage;
                    case SizeNotFound: return SizeNotFoundArabicMessage;
                    case PriceNotFound: return PriceNotFoundArabicMessage;
                    case CountryNotFound: return CountryNotFoundArabicMessage;
                    case CompanyNotFound: return CompanyNotFoundArabicMessage;
                    case GovernorateNotFound: return GovernorateNotFoundArabicMessage;
                    case UserTypeNotFound: return UserTypeNotFoundArabicMessage;

                    /*License*/
                    case LicenseUnknownError: return LicenseUnknownErrorArabicMessage;
                    case InvalidLicenseFile: return InvalidLicenseFileArabicMessage;
                    case InvalidLicenseFileData: return InvalidLicenseFileArabicMessage;
                    case InvalidItemsCount: return InvalidLicenseFileArabicMessage;
                    case InvalidUsersCount: return InvalidLicenseFileArabicMessage;
                    case InvalidInternetConnection: return InvalidLicenseFileArabicMessage;
                    case LicenseUserLimitExceeded: return InvalidLicenseFileArabicMessage;
                    case LicenseItemLimitExceeded: return LicenseItemLimitExceededArabicMessage;
                    case LicenseHasExpired: return LicenseHasExpiredArabicMessage;
                    case LicenseIsNotActive: return LicenseIsNotActiveArabicMessage;
                    case LicenseExceeded: return LicenseExceededArabicMessage;

                    case CannotUnPostOrderWhenUserCurrencyIsNotSameOfOrderCurrency: return CannotUnPostOrderWhenUserCurrencyIsNotSameOfOrderCurrencyArabicMessage;
                    case CannotCreateOrderWithoutPsychologicalBookImage: return CannotCreateOrderWithoutPsychologicalBookImageArabicMessage;
                    case CannotSubmitOrderWithPsychotherapyMedicineWithoutCoupon: return CannotSubmitOrderWithPsychotherapyMedicineWithoutCouponArabicMessage;
                    case ItemSerialNotFoundOrAlreadyScanned: return ItemSerialNotFoundOrAlreadyScannedArabicMessage;

                    default: return UnknownErrorArabicMessage;
                }
            }
        }


    }
}