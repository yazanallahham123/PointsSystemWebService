using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Text;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class OrderClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string CreatedDate { get; set; }
        [DataMember(Order = 3)]
        public double RequiredPoints { get; set; }
        [DataMember(Order = 4)]
        public double TotalQty { get; set; }
        [DataMember(Order = 5)]
        public int ItemsCount { get; set; }
        [DataMember(Order = 6)]
        public string UserNote { get; set; }
        [DataMember(Order = 7)]
        public string AdminNote { get; set; }
        [DataMember(Order = 8)]
        public string StatusNote { get; set; }
        [DataMember(Order = 9)]
        public string DeliveryDate { get; set; }
        [DataMember(Order = 10)]
        public string InitDate { get; set; }
        [DataMember(Order = 11)]
        public string ShippingDate { get; set; }
        [DataMember(Order = 12)]
        public bool IsPosted { get; set; }
        [DataMember(Order = 13)]
        public string PostDate { get; set; }
        [DataMember(Order = 14)]
        public int UserId { get; set; }
        [DataMember(Order = 15)]
        public int DeliveredBy { get; set; }
        [DataMember(Order = 16)]
        public int InitedBy { get; set; }
        [DataMember(Order = 17)]
        public int ShippedBy { get; set; }
        [DataMember(Order = 18)]
        public string UserUsername { get; set; }
        [DataMember(Order = 19)]
        public string UserFullName { get; set; }
        [DataMember(Order = 20)]
        public string DeliveredByUsername { get; set; }
        [DataMember(Order = 21)]
        public string DeliveredByFullName { get; set; }
        [DataMember(Order = 22)]
        public string InitedByUsername { get; set; }
        [DataMember(Order = 23)]
        public string InitedByFullName { get; set; }
        [DataMember(Order = 24)]
        public string ShippedByUsername { get; set; }
        [DataMember(Order = 25)]
        public string ShippedByFullName { get; set; }
        [DataMember(Order = 26)]
        public int StatusId { get; set; }
        [DataMember(Order = 27)]
        public string StatusArabicName { get; set; }
        [DataMember(Order = 28)]
        public string StatusEnglishName { get; set; }
        [DataMember(Order = 29)]
        public UserClass OrderUser { get; set; }

        [DataMember(Order = 30)]
        public string OfferArabicName { get; set; }
        [DataMember(Order = 31)]
        public string OfferEnglishName { get; set; }

        [DataMember(Order = 32)]
        public string TotalPrice { get; set; }
        [DataMember(Order = 33)]
        public int Order { get; set; }

        [DataMember(Order = 34)]
        public int CurrencyId { get; set; }
        [DataMember(Order = 35)]
        public string CurrencyArabicName { get; set; }
        [DataMember(Order = 36)]
        public string CurrencyEnglishName { get; set; }
        [DataMember(Order = 37)]
        public string CurrencyArabicCode { get; set; }
        [DataMember(Order = 38)]
        public string CurrencyEnglishCode { get; set; }
        [DataMember(Order = 39)]
        public string AddressDescription { get; set; }
        [DataMember(Order = 40)]
        public double Longitude { get; set; }
        [DataMember(Order = 41)]
        public double Latitude { get; set; }

        [DataMember(Order = 51)]
        public int UserAddressId { get; set; }
        [DataMember(Order = 52)]
        public string UserAddressName { get; set; }
        [DataMember(Order = 55)]
        public int DeliveryPlaceId { get; set; }
        [DataMember(Order = 56)]
        public string DeliveryPlaceArabicName { get; set; }
        [DataMember(Order = 57)]
        public string DeliveryPlaceEnglishName { get; set; }


        [DataMember(Order = 50)]
        public int DeliveryUserId { get; set; }
        [DataMember(Order = 51)]
        public string DeliveryUserFullName { get; set; }
        [DataMember(Order = 52)]
        public string DeliveryUserMobileNumber { get; set; }
        [DataMember(Order = 53)]
        public double DeliveryUserAvgRating { get; set; }

        [DataMember(Order = 54)]
        public double OrderAvgRating { get; set; }
        [DataMember(Order = 55)]
        public string DeliveryUserNote { get; set; }
        [DataMember(Order = 56)]
        public string StartDeliveryDate { get; set; }

        [DataMember(Order = 69)]
        public int CountryId { get; set; }
        [DataMember(Order = 70)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 71)]
        public string CountryEnglishName { get; set; }

        [DataMember(Order = 66)]
        public int GovernorateId { get; set; }
        [DataMember(Order = 67)]
        public string GovernorateArabicName { get; set; }
        [DataMember(Order = 68)]
        public string GovernorateEnglishName { get; set; }

        [DataMember(Order = 69)]
        public int CityId { get; set; }
        [DataMember(Order = 70)]
        public string CityArabicName { get; set; }
        [DataMember(Order = 71)]
        public string CityEnglishName { get; set; }

        [DataMember(Order = 69)]
        public int LocationId { get; set; }
        [DataMember(Order = 70)]
        public string LocationArabicName { get; set; }
        [DataMember(Order = 71)]
        public string LocationEnglishName { get; set; }

        [DataMember(Order = 72)]
        public string BlockNo { get; set; }
        [DataMember(Order = 73)]
        public string Street { get; set; }
        [DataMember(Order = 74)]
        public string Building { get; set; }
        [DataMember(Order = 75)]
        public string Floor { get; set; }
        [DataMember(Order = 76)]
        public string ApartmentNo { get; set; }
        [DataMember(Order = 77)]
        public string AddressNote { get; set; }

        public int BranchId { get; set; }
        [DataMember(Order = 78)]
        public string BranchArabicName { get; set; }
        [DataMember(Order = 79)]
        public string BranchEnglishName { get; set; }

        [DataMember(Order = 80)]
        public int PaymentTypeId { get; set; }
        [DataMember(Order = 81)]
        public string PaymentTypeArabicName { get; set; }
        [DataMember(Order = 82)]
        public string PaymentTypeEnglishName { get; set; }

        [DataMember(Order = 83)]
        public string PaymentSerialNumber { get; set; }

        [DataMember(Order = 84)]
        public int OrderTypeId { get; set; }
        [DataMember(Order = 85)]
        public string OrderTypeArabicName { get; set; }
        [DataMember(Order = 86)]
        public string OrderTypeEnglishName { get; set; }
        [DataMember(Order = 87)]
        public string TotalSeriesPrice { get; set; }
        [DataMember(Order = 88)]
        public double TotalSeriesQty { get; set; }
        [DataMember(Order = 88)]
        public int SeriesItemsCount { get; set; }

        [DataMember(Order = 66)]
        public bool IsImmediateDelivery { get; set; }
        [DataMember(Order = 67)]
        public double DeliveryCost { get; set; }
        [DataMember(Order = 68)]
        public string DeliveryPeriodFrom { get; set; }
        [DataMember(Order = 69)]
        public string DeliveryPeriodTo { get; set; }
        [DataMember(Order = 70)]
        public string LocationDeliveryDate { get; set; }
        [DataMember(Order = 70)]
        public string DeliveryDayTime { get; set; }

        [DataMember(Order = 71)]
        public bool HasOnRequest { get; set; }
        [DataMember(Order = 72)]
        public int MaxRequestDays { get; set; }
        [DataMember(Order = 73)]
        public string OrderDiscount { get; set; }
        [DataMember(Order = 74)]
        public string FinalPrice { get; set; }

        [DataMember(Order = 75)]
        public int CouponId { get; set; }
        [DataMember(Order = 76)]
        public string CouponValue { get; set; }
        [DataMember(Order = 77)]
        public int CouponValueType { get; set; }
        [DataMember(Order = 78)]
        public string Extras { get; set; }


        [DataMember(Order = 78)]
        public double Credit { get; set; }
        [DataMember(Order = 79)]
        public double Balance { get; set; }
        [DataMember(Order = 80)]
        public double OrderAmount { get; set; }
        [DataMember(Order = 81)]
        public double LastPaymentAmount { get; set; }
        [DataMember(Order = 82)]
        public string LastPaymentDate { get; set; }
        [DataMember(Order = 83)]
        public double TotalSales { get; set; }
        [DataMember(Order = 84)]
        public bool IsCheckedByManager { get; set; }
        [DataMember(Order = 85)]
        public bool NeedsCheckByManager { get; set; }

        [DataMember(Order = 85)]
        public bool ManagerApprove { get; set; }

        [DataMember(Order = 85)]
        public int ManagerUserId { get; set; }

        [DataMember(Order = 85)]
        public string ManagerCheckDate { get; set; }

        [DataMember(Order = 85)]
        public string ManagerFullName{ get; set; }
        [DataMember(Order = 85)]
        public int TotalQtyToDeliver { get; set; }
        [DataMember(Order = 85)]
        public int TotalDeliveredQty { get; set; }
        [DataMember(Order = 85)]
        public List<OrderSerialClass> OrderSerials { get; set; }

        [DataMember(Order = 85)]
        public string PaymentId { get; set; }


        public ResultClass<double>GetTotalOrderGrantPoints(int OrderId)
        {
            ResultClass<double>result = new ResultClass<double>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetTotalOrderGrantPoints";
                    List<SqlParameter>Params = new List<SqlParameter>()
               {
                  new SqlParameter("OrderId", OrderId),
               };

                    cmd.Parameters.AddRange(Params.ToArray());

                    SqlDataReader reader = cmd.ExecuteReader();
                    var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i =>reader.GetName(i)).ToArray();
                    if (reader.HasRows)
                    {
                        double TotalGrantedPoints = 0;
                        reader.Read();

                        if (fieldNames.Contains("TotalGrantedPoints"))
                            if (!Convert.IsDBNull(reader["TotalGrantedPoints"]))
                                TotalGrantedPoints = Convert.ToDouble(reader["TotalGrantedPoints"]);
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = TotalGrantedPoints;
                        return result;
                    }
                    else
                    {
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = 0;
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                int code;
                if (Int32.TryParse(e.Message, out code))
                {
                    result.Code = code;
                    result.Message = Errors.GetErrorMessage(code);
                }
                else
                {
                    result.Code = Errors.UnknownError;
                    result.Message = Errors.GetErrorMessage(result.Code);
                    Errors.LogError(7, e.Message, e.StackTrace, "1.0.3", "API", "GetTotalOrderGrantPoints", e.Source, "");
                }
                result.Result = 0;
                return result;
            }
        }

        public void sendOrderEmails(int OrderId, List<string>emails, string ordertitle, string orderbody) {
            foreach (var item in emails)
            {


                ResultClass<List<OrderDetailClass>>details = GetOrderDetails(OrderId);
            string orderDetails = "";
            if (details.Result != null)
            {
                ResultClass<OrderClass> order = GetOrder(details.Result[0].OrderId);

                string singleDetail = "";
                string footer = "";
                double total = 0.0;

                if (details.Result.Count>0)
                {
                        orderDetails = "<!doctype html>" +
    "<html>" +
    "<head>" +
    "<meta charset = \"utf-8\">" +
     "<meta name = \"viewport\" content = \"width=device-width, initial-scale=1\">" +
        "<title>MAGILLA Invoice</title>" +
           "<style>" +
               "body{" +
                            "font-family:'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;" +
                            "text-align:center;" +
                        "color:#777;" +

        "}" +

                        "body h1{" +
                            "font-weight:300;" +
                            "margin-bottom:0px;" +
                            "padding-bottom:0px;" +
                        "color:#000;" +

        "}" +
                        "body h3{" +
                            "font-weight:300;" +
                            "margin-top:10px;" +
                            "margin-bottom:20px;" +
                            "font-style:italic;" +
                        "color:#555;" +
        "}" +

                        "body a{" +
                        "color:#06F;" +

        "}" +

        ".invoice-box{" +
                            "max-width:800px;" +
                        "margin: auto;" +
                        "padding: 30px;" +
                        "border: 1px solid #eee;" +

            "box-shadow:0 0 10px rgba(0, 0, 0, .15);" +
                            "font-size:16px;" +
                            "line-height:24px;" +
                            "font-family:'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;" +
                        "color:#555;" +

        "}" +

        ".invoice-box table{" +
                        "width: 100%;" +
                            "line-height:inherit;" +
                            "text-align:left;" +
                        "}" +

        ".invoice-box table td{" +
         "               padding: 5px;" +
                         "   vertical-align:top;" +
                        "              }" +

                      ".invoice-box table tr td:nth-child(2){" +
                            "text-align:right;" +
                        "}" +

        ".invoice-box table tr.top table td{" +
         "                   padding-bottom:20px;" +
          "              }" +

        ".invoice-box table tr.top table td.title{" +
         "                   font-size:45px;" +
          "                  line-height:45px;" +
           "             color:#333;" +


       " }" +

        ".invoice-box table tr.information table td{" +
                 "           padding-bottom:40px;" +
                  "      }" +

        ".invoice-box table tr.heading td{" +
            "            background:#eee;" +

           " border-bottom:1px solid #ddd;" +

           " font-weight:bold;" +
              "          }" +

                    ".invoice-box table tr.details td{" +
                      "      padding-bottom:20px;" +
                     "   }" +

       " .invoice-box table tr.item td{" +
              "              border-bottom:1px solid #eee;" +

       " }" +

      "  .invoice-box table tr.item.last td{" +
                  "          border-bottom:none;" +
                    "    }" +

        ".invoice-box table tr.total td:nth-child(2){" +
           "                 border-top:2px solid #eee;" +

           " font-weight:bold;" +
                  "      }" +

                   "     @media only screen and (max-width: 600px) {" +
           " .invoice-box table tr.top table td{" +
                 "           width: 100%;" +
                   "         display: block;" +
                    "            text-align:center;" +
                    "        }" +

            ".invoice-box table tr.information table td{" +
                         "   width: 100%;" +
                         "   display: block;" +
                         "       text-align:center;" +
                          "  }" +
                     "   }" +

     "   </style>" +
    "</head>" +
    "<body>" +
    "<h2>Dear " + order.Result.UserFullName +
    "<h2>Thanks for shopping with us, We will inform you about your order once it become in process.if you have any inqueries please don't hesitate to contact us on e-shop@phoenix.sy</h1>" +
    "   <div class=\"invoice-box\">" +
    "<table cellpadding = \"0\" cellspacing=\"0\">" +
    "<tr class=\"top\">" +
    "<td colspan = \"2\">" +
    "<table>" +
    "<tr>" +
    "<td class=\"title\">" +
    "<img src = \"https://phoenix.developitech.com/Uploads/Photos/Bands/magilla_logo.png\" style=\"width:100%; max-width:300px; \">" +
     "</td>" +
    "<td>" +
    "Invoice #: " + order.Result.Id.ToString() + "<br>" +
    "Created: " + order.Result.CreatedDate + "<br>" +
    "Posted Date: " + order.Result.PostDate +
    "</td>" +
    "<td>" +
    "Status: " + order.Result.StatusEnglishName+
    "</td>" +
    "</tr>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "<tr class=\"information\">" +
    "<td colspan = \"2\">" +
    "<table>" +
    "<tr>" +
    "<td>" +
    "MAGILLA.<br>" +
    "Damascus, Syria<br>" +
    "Shaalan, Phoenix Mall" +
    "</td>" +
    "<td>" +
    "Online Order.<br>" +
    order.Result.UserFullName + "<br>" +
    order.Result.UserUsername + "<br>" +
    "</td>" +
    "<td>";
                        if (order.Result.OrderTypeId == 2)
                        {
                            orderDetails = orderDetails + "Address:<br>" +
                            "Delivery : "+order.Result.GovernorateEnglishName + " - " + order.Result.CityEnglishName + " - " + order.Result.Street + " - " + order.Result.AddressNote + "<br>";
                        }
                        else
                        {
                            if (order.Result.OrderTypeId == 3)
                            {
                                orderDetails = orderDetails + "Address:<br>" +
                                "From Branch : "+order.Result.BranchEnglishName+"<br>";
                            }
                            else
                            {
                                orderDetails = orderDetails + "Address:<br>" +
                                "<br>";
                            }
                        }
                        orderDetails = orderDetails + "</td>" +
"</tr>" +
"</table>" +
"</td>" +
"</tr>";
                    orderDetails = orderDetails + "<tr class=\"heading\"><td>Item</td><td>QTY.</td><td>Payment Method</td><td>Price</td><td>Points</td></tr>";
                    foreach (var od in details.Result)
                    {
                        total = total + (Convert.ToDouble(od.TotalPrice));
                        singleDetail = "<tr class=\"item\"><td>" + od.ItemEnglishName + " - " + od.ColorEnglishName + " - " + od.SizeEnglishName + "</td><td>" + od.Qty.ToString() + "</td><td>"+od.PaymentMethodEnglishName+"</td><td>" + od.PriceCurrencyArabicCode + " " + od.TotalPrice + "</td><td>" + od.TotalPoints.ToString() +" PTS"+"</td></tr>";
                        orderDetails = orderDetails + singleDetail;
                    }
                    footer = "<tr class=\"total\"><td></td><td></td><td></td><td>Total: " + details.Result[0].PriceCurrencyEnglishCode+" "+ total.ToString() + "</td><td>"+order.Result.RequiredPoints.ToString()+" PTS"+"</td></tr>";

                    orderDetails = orderDetails + footer;

                    orderDetails = orderDetails +
                        "</table>"+
"</div>"+
"<script data-cfasync = \"false\" src=\"/cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js\"></script></body>"+
 "    </html>";
                }
            }

                var fromAddress = new MailAddress(Config.EmailUsername, "MAGILLA Online");
                var toAddress = new MailAddress(item, "");
                string fromPassword = Config.EmailPassword;
                string subject = ordertitle;
                string body = orderDetails;
         
                var smtp = new SmtpClient
                {
                    Host = Config.EmailSMTPHost,
                    Port = Convert.ToInt32(Config.EmailSMTPPort),
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                })
                {
                    smtp.Send(message);
                }
            }
        }

        public ResultClass<UserClass> GetUser(int LoggedUser, int UserId, bool WithAccessToken)
        {
            ResultClass<UserClass> result = new ResultClass<UserClass>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetUsers";
                    SqlParameter Param = new SqlParameter("UserId", UserId);
                    cmd.Parameters.Add(Param);
                    Param = new SqlParameter("LoggedUser", 7);
                    cmd.Parameters.Add(Param);
                    Param = new SqlParameter("WithAccessToken", WithAccessToken);
                    cmd.Parameters.Add(Param);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                        List<UserClass> Users = new List<UserClass>();
                        UserClass user;
                        reader.Read();
                        user = new UserClass().PopulateUser(fieldNames, reader);
                        user.Order = 1;

                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = user;
                        return result;
                    }
                    else
                    {
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = null;
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                int code;
                if (Int32.TryParse(e.Message, out code))
                {
                    result.Code = code;
                    result.Message = Errors.GetErrorMessage(code);
                }
                else
                {
                    result.Code = Errors.UnknownError;
                    result.Message = Errors.GetErrorMessage(result.Code);
                    Errors.LogError(LoggedUser, e.Message, e.StackTrace, "1.0.3", "API", "GetUser", e.Source, "");
                }
                result.Result = null;
                return result;
            }
        }

        public bool ProcessUpdateOrderNotifications(OrderClass OldOrderData)
        {
            try
            {
                if (OldOrderData.IsPosted != IsPosted)
                {
                    ResultClass<List<NotificationTypesClass>>NotificationsTypesResult = NotificationsHelperClass.GetNotificationsTypes();
                    List<NotificationTypesClass>ChangeOrderStatusNotifications = new List<NotificationTypesClass>();
                    if (NotificationsTypesResult.Result != null)
                    {
                        string ChangeOrderStatusNotificationTitle = "";
                        string ChangeOrderStatusNotificationContent = "";

                        List<NotificationTypesClass>NotificationsTypes = NotificationsTypesResult.Result;
                        ChangeOrderStatusNotifications = NotificationsTypes.FindAll(x =>x.Id == StatusId);
                        ChangeOrderStatusNotificationContent = ChangeOrderStatusNotifications[0].Name;

                        if ((OldOrderData.IsPosted == false) && (IsPosted == true))
                            ChangeOrderStatusNotificationTitle = "طلبية جديدة";
                        else
                            ChangeOrderStatusNotificationTitle = "الغاء ترحيل طلبية جديدة";

                        int NotificationType = 0;

                        if (!IsPosted)
                        {
                            NotificationType = 94;
                            ChangeOrderStatusNotificationContent = ChangeOrderStatusNotificationTitle;
                        }
                        else
                            NotificationType = StatusId;

                        List<int>admins;
                        List<string>adminsemails;
                        string adminsUsers = "";
                        ChangeOrderStatusNotificationContent = ChangeOrderStatusNotificationContent + " : " + Id.ToString();
                        //get Sender and admins users
                        admins = NotificationsHelperClass.GetAdminNotificationsUsers(StatusId).Result;
                        adminsemails = NotificationsHelperClass.GetAdminNotificationsUsersEmail(StatusId).Result;

                        if (admins == null)
                            admins = new List<int>();

                        for (int i = 0; i <admins.Count; i++)
                        {
                            if (admins[i] != UserId)
                                adminsUsers = adminsUsers + admins[i].ToString() + ",";
                        }

                        if (adminsUsers.EndsWith(","))
                            adminsUsers = adminsUsers.Substring(0, adminsUsers.Length - 1);

                        if (adminsUsers.Trim() != "")
                        {
                            WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                            request.Method = "POST";
                            request.ContentType = "application/json; charset=UTF-8";
                            var postData = "{\"Receivers\":[" + adminsUsers + "],\"NotificationTitle\":\"" + ChangeOrderStatusNotificationTitle + "\",\"NotificationContent\":\"" + ChangeOrderStatusNotificationContent + "\",\"NotificationType\":\"" + StatusId.ToString() + "\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                            var data = Encoding.UTF8.GetBytes(postData);
                            request.ContentLength = data.Length;
                            var stream = request.GetRequestStream();
                            stream.Write(data, 0, data.Length);
                            WebResponse response = request.GetResponse();
                            StreamReader Reader = new StreamReader(response.GetResponseStream());
                            string onesignal_responseLine = Reader.ReadToEnd();
                        }

                        sendOrderEmails(Id, adminsemails, ChangeOrderStatusNotificationTitle, ChangeOrderStatusNotificationContent);

                        List<string> ul = new List<string>();

                        ResultClass<UserClass> u = GetUser(7, UserId, false);
                        if (u.Result != null)
                            if (u.Result.Email != null)
                                if (u.Result.Email.Trim() != "")
                                    ul.Add(u.Result.Email);

                        sendOrderEmails(Id, ul, ChangeOrderStatusNotificationTitle, ChangeOrderStatusNotificationContent);
                    }
                }
                //Status Changed
                if (OldOrderData.StatusId != StatusId)
                {
                    if ((StatusId == 92) || (StatusId == 96))
                    {
                        string newOrderToDeliverNotificationTitle = "طلبية للتوصيل";
                        string newOrderToDeliverNotificationContent = "طلبية جديدة للتوصيل: " + Id.ToString();
                        
                        WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                        request.Method = "POST";
                        request.ContentType = "application/json; charset=UTF-8";
                        var postData = "{\"Receivers\":[" + DeliveryUserId.ToString() + "],\"NotificationTitle\":\"" + newOrderToDeliverNotificationTitle + "\",\"NotificationContent\":\"" + newOrderToDeliverNotificationContent + "\",\"NotificationType\":\"" + StatusId.ToString() + "\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                        var data = Encoding.UTF8.GetBytes(postData);
                        request.ContentLength = data.Length;
                        var stream = request.GetRequestStream();
                        stream.Write(data, 0, data.Length);
                        WebResponse response = request.GetResponse();
                        StreamReader Reader = new StreamReader(response.GetResponseStream());
                        string onesignal_responseLine = Reader.ReadToEnd();
                    }

                    if ((StatusId != 90) && (StatusId != 95))
                    {

                        ResultClass<List<NotificationTypesClass>>NotificationsTypesResult = NotificationsHelperClass.GetNotificationsTypes();
                        List<NotificationTypesClass>ChangeOrderStatusNotifications = new List<NotificationTypesClass>();
                        if (NotificationsTypesResult.Result != null)
                        {
                            List<NotificationTypesClass>NotificationsTypes = NotificationsTypesResult.Result;
                            ChangeOrderStatusNotifications = NotificationsTypes.FindAll(x =>x.Id == StatusId);
                            string ChangeOrderStatusNotificationTitle = "";
                            string ChangeOrderStatusNtificationContent = "";
                            if (ChangeOrderStatusNotifications.Count>0)
                            {
                                ChangeOrderStatusNotificationTitle = "تغيير حالة طلبية";
                                ChangeOrderStatusNtificationContent = "تغيير حالة طلبية : " + Id.ToString() + " " + ChangeOrderStatusNotifications[0].Name;

                                WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                                request.Method = "POST";
                                request.ContentType = "application/json; charset=UTF-8";
                                var postData = "{\"Receivers\":[" + UserId.ToString() + "],\"NotificationTitle\":\"" + ChangeOrderStatusNotificationTitle + "\",\"NotificationContent\":\"" + ChangeOrderStatusNtificationContent + "\",\"NotificationType\":\"" + StatusId.ToString() + "\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                                var data = Encoding.UTF8.GetBytes(postData);
                                request.ContentLength = data.Length;
                                var stream = request.GetRequestStream();
                                stream.Write(data, 0, data.Length);
                                WebResponse response = request.GetResponse();
                                StreamReader Reader = new StreamReader(response.GetResponseStream());
                                string onesignal_responseLine = Reader.ReadToEnd();
                            }


                            double totalGrantedPoints = GetTotalOrderGrantPoints(Id).Result;
                            if ((StatusId == 93) && (totalGrantedPoints>0))
                            {
                                ChangeOrderStatusNotifications = NotificationsTypes.FindAll(x =>x.Id == 14);
                                string OrderGrantPointsNotificationTitle = "";
                                string OrderGrantPointsNtificationContent = "";
                                if (ChangeOrderStatusNotifications.Count>0)
                                {
                                    OrderGrantPointsNotificationTitle = ChangeOrderStatusNotifications[0].Name;
                                    OrderGrantPointsNtificationContent = ChangeOrderStatusNotifications[0].Name + " رقم :  " + Id.ToString() + " الرصيد المحول هو: " + totalGrantedPoints.ToString() + " نقطة";

                                    WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                                    request.Method = "POST";
                                    request.ContentType = "application/json; charset=UTF-8";
                                    var postData = "{\"Receivers\":[" + UserId.ToString() + "],\"NotificationTitle\":\"" + OrderGrantPointsNotificationTitle + "\",\"NotificationContent\":\"" + OrderGrantPointsNtificationContent + "\",\"NotificationType\":\"" + StatusId.ToString() + "\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                                    var data = Encoding.UTF8.GetBytes(postData);
                                    request.ContentLength = data.Length;
                                    var stream = request.GetRequestStream();
                                    stream.Write(data, 0, data.Length);
                                    WebResponse response = request.GetResponse();
                                    StreamReader Reader = new StreamReader(response.GetResponseStream());
                                    string onesignal_responseLine = Reader.ReadToEnd();
                                }
                            }

                            List<string> ul = new List<string>();

                            ResultClass<UserClass> u = GetUser(7, UserId, false);
                            if (u.Result != null)
                                if (u.Result.Email != null)
                                    if (u.Result.Email.Trim() != "")
                                        ul.Add(u.Result.Email);

                            sendOrderEmails(Id, ul, ChangeOrderStatusNotificationTitle, ChangeOrderStatusNtificationContent);


                        }
                    }

                    if (StatusId != 90)
                    {
                        List<int>admins;
                        string adminsUsers = "";
                        //get Sender and admins users
                        admins = NotificationsHelperClass.GetAdminNotificationsUsers(StatusId).Result;

                        if (admins == null)
                            admins = new List<int>();

                        for (int i = 0; i <admins.Count; i++)
                        {
                            if (admins[i] != UserId)
                                adminsUsers = adminsUsers + admins[i].ToString() + ",";
                        }

                        if (adminsUsers.EndsWith(","))
                            adminsUsers = adminsUsers.Substring(0, adminsUsers.Length - 1);

                        if (adminsUsers.Trim() != "")
                        {
                            ResultClass<List<NotificationTypesClass>>NotificationsTypesResult = NotificationsHelperClass.GetNotificationsTypes();
                            List<NotificationTypesClass>ChangeOrderStatusNotifications = new List<NotificationTypesClass>();
                            if (NotificationsTypesResult.Result != null)
                            {
                                List<NotificationTypesClass>NotificationsTypes = NotificationsTypesResult.Result;
                                ChangeOrderStatusNotifications = NotificationsTypes.FindAll(x =>x.Id == StatusId);
                                string ChangeOrderStatusNotificationTitle = "";
                                string ChangeOrderStatusNtificationContent = "";
                                if (ChangeOrderStatusNotifications.Count>0)
                                {
                                    ChangeOrderStatusNotificationTitle = "تغيير حالة طلبية";
                                    ChangeOrderStatusNtificationContent = "تغيير حالة طلبية : " + Id.ToString() + " " + ChangeOrderStatusNotifications[0].Name;

                                    WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                                    request.Method = "POST";
                                    request.ContentType = "application/json; charset=UTF-8";
                                    var postData = "{\"Receivers\":[" + adminsUsers + "],\"NotificationTitle\":\"" + ChangeOrderStatusNotificationTitle + "\",\"NotificationContent\":\"" + ChangeOrderStatusNtificationContent + "\",\"NotificationType\":\"" + StatusId.ToString() + "\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                                    var data = Encoding.UTF8.GetBytes(postData);
                                    request.ContentLength = data.Length;
                                    var stream = request.GetRequestStream();
                                    stream.Write(data, 0, data.Length);
                                    WebResponse response = request.GetResponse();
                                    StreamReader Reader = new StreamReader(response.GetResponseStream());
                                    string onesignal_responseLine = Reader.ReadToEnd();
                                }
                            }
                        }
                    }

                    if (OldOrderData.IsPosted == true)
                    {
                        if ((DeliveryUserId > 0) && (StatusId == 92))
                        {
                            ResultClass<List<NotificationTypesClass>>NotificationsTypesResult = NotificationsHelperClass.GetNotificationsTypes();
                            List<NotificationTypesClass>DeliveryNotifications = new List<NotificationTypesClass>();
                            if (NotificationsTypesResult.Result != null)
                            {
                                List<NotificationTypesClass>NotificationsTypes = NotificationsTypesResult.Result;
                                DeliveryNotifications = NotificationsTypes.FindAll(x =>x.Id == 401);
                                string DeliveryNotificationTitle = "";
                                string DeliveryNtificationContent = "";
                                if (DeliveryNotifications.Count>0)
                                {
                                    DeliveryNotificationTitle = DeliveryNotifications[0].Name;
                                    DeliveryNtificationContent = DeliveryNotifications[0].Name + " Order NO :  " + Id.ToString();

                                    WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                                    request.Method = "POST";
                                    request.ContentType = "application/json; charset=UTF-8";
                                    var postData = "{\"Receivers\":[" + DeliveryUserId.ToString() + "],\"NotificationTitle\":\"" + DeliveryNotificationTitle + "\",\"NotificationContent\":\"" + DeliveryNtificationContent + "\",\"NotificationType\":\"" + "401" + "\",\"Platform\":\"\",\"SourceId\":\"" + Id.ToString() + "\"}";
                                    var data = Encoding.UTF8.GetBytes(postData);
                                    request.ContentLength = data.Length;
                                    var stream = request.GetRequestStream();
                                    stream.Write(data, 0, data.Length);
                                    WebResponse response = request.GetResponse();
                                    StreamReader Reader = new StreamReader(response.GetResponseStream());
                                    string onesignal_responseLine = Reader.ReadToEnd();
                                }
                            }
                        }
                    }
                }

                if ((NeedsCheckByManager) && (!IsCheckedByManager))
                {
                    ResultClass<List<NotificationTypesClass>> NotificationsTypesResult = NotificationsHelperClass.GetNotificationsTypes();
                    List<NotificationTypesClass> ChangeOrderStatusNotifications = new List<NotificationTypesClass>();
                    if (NotificationsTypesResult.Result != null)
                    {
                        string OrderNeedsManagerApproveNotificationTitle = "";
                        string OrderNeedsManagerApproveNotificationContent = "";
                        int NotificationType = 400;

                        if ((OldOrderData.NeedsCheckByManager == false) && (NeedsCheckByManager == true))
                        {
                            OrderNeedsManagerApproveNotificationTitle = "طلبية بحاجة إلى تدقيق";
                            OrderNeedsManagerApproveNotificationContent = "يرجى تدقيق الطلبية رقم : " + Id.ToString();
                            NotificationType = 400;

                        }
                        else
                        {
                            if ((OldOrderData.NeedsCheckByManager == true) && (NeedsCheckByManager == false))
                            {
                                if ((OldOrderData.ManagerApprove == false) && (ManagerApprove == false))
                                {
                                    OrderNeedsManagerApproveNotificationTitle = "تم تدقيق الطلبية";
                                    OrderNeedsManagerApproveNotificationContent = "تم رفض الطلبية رقم : " + Id.ToString();
                                    NotificationType = 401;
                                }
                                else
                                {
                                    if ((OldOrderData.ManagerApprove == false) && (ManagerApprove == true))
                                    {
                                        OrderNeedsManagerApproveNotificationTitle = "تم تدقيق الطلبية";
                                        OrderNeedsManagerApproveNotificationContent = "تم قبول الطلبية رقم : " + Id.ToString();
                                        NotificationType = 402;
                                    }

                                }
                            }
                        }



                        List<int> admins;
                        List<string> adminsemails;
                        string adminsUsers = "";
                        //get Sender and admins users
                        admins = NotificationsHelperClass.GetAdminNotificationsUsers(StatusId).Result;
                        adminsemails = NotificationsHelperClass.GetAdminNotificationsUsersEmail(StatusId).Result;

                        if (admins == null)
                            admins = new List<int>();

                        for (int i = 0; i < admins.Count; i++)
                        {
                            if (admins[i] != UserId)
                                adminsUsers = adminsUsers + admins[i].ToString() + ",";

                            NotificationClass n = new NotificationClass();
                            n.ToUser = admins[i];
                            n.NotificationTitle = OrderNeedsManagerApproveNotificationTitle;
                            n.NotificationContent = OrderNeedsManagerApproveNotificationContent;
                            n.Type = NotificationType;
                            NotificationsHelperClass.CreateNotification(n);
                        }

                        if (adminsUsers.EndsWith(","))
                            adminsUsers = adminsUsers.Substring(0, adminsUsers.Length - 1);

                        if (adminsUsers.Trim() != "")
                        {
                            WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                            request.Method = "POST";
                            request.ContentType = "application/json; charset=UTF-8";
                            var postData = "{\"Receivers\":[" + adminsUsers + "],\"NotificationTitle\":\"" + OrderNeedsManagerApproveNotificationTitle + "\",\"NotificationContent\":\"" + OrderNeedsManagerApproveNotificationContent + "\",\"NotificationType\":\"" + NotificationType.ToString() + "\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                            var data = Encoding.UTF8.GetBytes(postData);
                            request.ContentLength = data.Length;
                            var stream = request.GetRequestStream();
                            stream.Write(data, 0, data.Length);
                            WebResponse response = request.GetResponse();
                            StreamReader Reader = new StreamReader(response.GetResponseStream());
                            string onesignal_responseLine = Reader.ReadToEnd();
                        }

                        sendOrderEmails(Id, adminsemails, OrderNeedsManagerApproveNotificationTitle, OrderNeedsManagerApproveNotificationContent);

                        List<string> ul = new List<string>();

                        ResultClass<UserClass> u = GetUser(7, UserId, false);
                        if (u.Result != null)
                            if (u.Result.Email != null)
                                if (u.Result.Email.Trim() != "")
                                    ul.Add(u.Result.Email);

                        sendOrderEmails(Id, ul, OrderNeedsManagerApproveNotificationTitle, OrderNeedsManagerApproveNotificationContent);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                string x = e.Message;
                return false;
            }
        }

        public ResultClass<List<OrderDetailClass>>GetOrderDetails(int OrderId)
        {
            ResultClass<List<OrderDetailClass>>result = new ResultClass<List<OrderDetailClass>>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetOrderDetails";
                    List<SqlParameter>Params = new List<SqlParameter>();
                    if (OrderId != 0)
                    {
                        Params.Add(new SqlParameter("OrderId", OrderId));
                    }
                    cmd.Parameters.AddRange(Params.ToArray());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<OrderDetailClass>OrderDetails = new List<OrderDetailClass>();
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i =>reader.GetName(i)).ToArray();
                        OrderDetailClass id;
                        int order = 0;
                        while (reader.Read())
                        {
                            order += 1;
                            id = new OrderDetailClass().PopulateOrderDetail(fieldNames, reader);

                            id.Order = order;
                            OrderDetails.Add(id);
                        }
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = OrderDetails;
                        return result;
                    }
                    else
                    {
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = null;
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                int code;
                if (Int32.TryParse(e.Message, out code))
                {
                    result.Code = code;
                    result.Message = Errors.GetErrorMessage(code);
                }
                else
                {
                    result.Code = Errors.UnknownError;
                    result.Message = Errors.GetErrorMessage(result.Code);
                    Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "GetOrderDetails", e.Source, "");
                }
                result.Result = null;
                return result;
            }
        }


        public ResultClass<OrderClass> GetOrder(int Id)
        {
            ResultClass<OrderClass> result = new ResultClass<OrderClass>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetOrders";
                    List<SqlParameter> Params = new List<SqlParameter>();
                    if (Id != 0)
                    {
                        Params.Add(new SqlParameter("Id", Id));

                    }
                    Params.Add(new SqlParameter("LoggedUser", 7));
                    cmd.Parameters.AddRange(Params.ToArray());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                        OrderClass id;
                        reader.Read();
                        id = new OrderClass().PopulateOrderClass(fieldNames, reader);

                        id.Order = 1;
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = id;
                        return result;
                    }
                    else
                    {
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = null;
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                int code;
                if (Int32.TryParse(e.Message, out code))
                {
                    result.Code = code;
                    result.Message = Errors.GetErrorMessage(code);
                }
                else
                {
                    result.Code = Errors.UnknownError;
                    result.Message = Errors.GetErrorMessage(result.Code);
                    Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "GetOrder", e.Source, "");
                }
                result.Result = null;
                return result;
            }
        }


        public OrderClass PopulateOrderClass(string[] fieldNames, SqlDataReader reader)
        {
            var order = new OrderClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    order.Id = (int)reader["Id"];

            if (fieldNames.Contains("CreatedDate"))
                if (!Convert.IsDBNull(reader["CreatedDate"]))
                    order.CreatedDate = reader["CreatedDate"].ToString();

            if (fieldNames.Contains("RequiredPoints"))
                if (!Convert.IsDBNull(reader["RequiredPoints"]))
                    order.RequiredPoints = (double)reader["RequiredPoints"];

            if (fieldNames.Contains("TotalQty"))
                if (!Convert.IsDBNull(reader["TotalQty"]))
                    order.TotalQty = (double)reader["TotalQty"];

            if (fieldNames.Contains("TotalPrice"))
                if (!Convert.IsDBNull(reader["TotalPrice"]))
                    order.TotalPrice = reader["TotalPrice"].ToString();


            if (fieldNames.Contains("ItemsCount"))
                if (!Convert.IsDBNull(reader["ItemsCount"]))
                    order.ItemsCount = (int)reader["ItemsCount"];

            if (fieldNames.Contains("UserNote"))
                if (!Convert.IsDBNull(reader["UserNote"]))
                    order.UserNote = reader["UserNote"].ToString();

            if (fieldNames.Contains("AdminNote"))
                if (!Convert.IsDBNull(reader["AdminNote"]))
                    order.AdminNote = reader["AdminNote"].ToString();

            if (fieldNames.Contains("StatusNote"))
                if (!Convert.IsDBNull(reader["StatusNote"]))
                    order.StatusNote = reader["StatusNote"].ToString();

            if (fieldNames.Contains("DeliveryDate"))
                if (!Convert.IsDBNull(reader["DeliveryDate"]))
                    order.DeliveryDate = reader["DeliveryDate"].ToString();

            if (fieldNames.Contains("InitDate"))
                if (!Convert.IsDBNull(reader["InitDate"]))
                    order.InitDate = reader["InitDate"].ToString();

            if (fieldNames.Contains("ShippingDate"))
                if (!Convert.IsDBNull(reader["ShippingDate"]))
                    order.ShippingDate = reader["ShippingDate"].ToString();

            if (fieldNames.Contains("IsPosted"))
                if (!Convert.IsDBNull(reader["IsPosted"]))
                    order.IsPosted = (bool)reader["IsPosted"];

            if (fieldNames.Contains("PostDate"))
                if (!Convert.IsDBNull(reader["PostDate"]))
                    order.PostDate = reader["PostDate"].ToString();

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    order.UserId = (int)reader["UserId"];

            if (fieldNames.Contains("DeliveredBy"))
                if (!Convert.IsDBNull(reader["DeliveredBy"]))
                    order.DeliveredBy = (int)reader["DeliveredBy"];

            if (fieldNames.Contains("InitedBy"))
                if (!Convert.IsDBNull(reader["InitedBy"]))
                    order.InitedBy = (int)reader["InitedBy"];

            if (fieldNames.Contains("ShippedBy"))
                if (!Convert.IsDBNull(reader["ShippedBy"]))
                    order.ShippedBy = (int)reader["ShippedBy"];

            if (fieldNames.Contains("UserUsername"))
                if (!Convert.IsDBNull(reader["UserUsername"]))
                    order.UserUsername = reader["UserUsername"].ToString();

            if (fieldNames.Contains("UserFullName"))
                if (!Convert.IsDBNull(reader["UserFullName"]))
                    order.UserFullName = reader["UserFullName"].ToString();

            if (fieldNames.Contains("DeliveredByUsername"))
                if (!Convert.IsDBNull(reader["DeliveredByUsername"]))
                    order.DeliveredByUsername = reader["DeliveredByUsername"].ToString();

            if (fieldNames.Contains("DeliveredByFullName"))
                if (!Convert.IsDBNull(reader["DeliveredByFullName"]))
                    order.DeliveredByFullName = reader["DeliveredByFullName"].ToString();

            if (fieldNames.Contains("InitedByUsername"))
                if (!Convert.IsDBNull(reader["InitedByUsername"]))
                    order.InitedByUsername = reader["InitedByUsername"].ToString();

            if (fieldNames.Contains("InitedByFullName"))
                if (!Convert.IsDBNull(reader["InitedByFullName"]))
                    order.InitedByFullName = reader["InitedByFullName"].ToString();

            if (fieldNames.Contains("ShippedByUsername"))
                if (!Convert.IsDBNull(reader["ShippedByUsername"]))
                    order.ShippedByUsername = reader["ShippedByUsername"].ToString();

            if (fieldNames.Contains("ShippedByFullName"))
                if (!Convert.IsDBNull(reader["ShippedByFullName"]))
                    order.ShippedByFullName = reader["ShippedByFullName"].ToString();

            if (fieldNames.Contains("StatusId"))
                if (!Convert.IsDBNull(reader["StatusId"]))
                    order.StatusId = (int)reader["StatusId"];

            if (fieldNames.Contains("StatusArabicName"))
                if (!Convert.IsDBNull(reader["StatusArabicName"]))
                    order.StatusArabicName = reader["StatusArabicName"].ToString();

            if (fieldNames.Contains("StatusEnglishName"))
                if (!Convert.IsDBNull(reader["StatusEnglishName"]))
                    order.StatusEnglishName = reader["StatusEnglishName"].ToString();

            order.OrderUser = new UserClass().PopulateUser(fieldNames, reader, "OrderUser_");

            if (fieldNames.Contains("OfferArabicName"))
                if (!Convert.IsDBNull(reader["OfferArabicName"]))
                    order.OfferArabicName = reader["OfferArabicName"].ToString();

            if (fieldNames.Contains("OfferEnglishName"))
                if (!Convert.IsDBNull(reader["OfferEnglishName"]))
                    order.OfferEnglishName = reader["OfferEnglishName"].ToString();

            if (fieldNames.Contains("CurrencyId"))
                if (!Convert.IsDBNull(reader["CurrencyId"]))
                    order.CurrencyId = (int)reader["CurrencyId"];

            if (fieldNames.Contains("CurrencyArabicName"))
                if (!Convert.IsDBNull(reader["CurrencyArabicName"]))
                    order.CurrencyArabicName = reader["CurrencyArabicName"].ToString();

            if (fieldNames.Contains("CurrencyEnglishName"))
                if (!Convert.IsDBNull(reader["CurrencyEnglishName"]))
                    order.CurrencyEnglishName = reader["CurrencyEnglishName"].ToString();

            if (fieldNames.Contains("CurrencyArabicCode"))
                if (!Convert.IsDBNull(reader["CurrencyArabicCode"]))
                    order.CurrencyArabicCode = reader["CurrencyArabicCode"].ToString();

            if (fieldNames.Contains("CurrencyEnglishCode"))
                if (!Convert.IsDBNull(reader["CurrencyEnglishCode"]))
                    order.CurrencyEnglishCode = reader["CurrencyEnglishCode"].ToString();

            if (fieldNames.Contains("AddressDescription"))
                if (!Convert.IsDBNull(reader["AddressDescription"]))
                    order.AddressDescription = reader["AddressDescription"].ToString();

            if (fieldNames.Contains("Longitude"))
                if (!Convert.IsDBNull(reader["Longitude"]))
                    order.Longitude = (double)reader["Longitude"];

            if (fieldNames.Contains("Latitude"))
                if (!Convert.IsDBNull(reader["Latitude"]))
                    order.Latitude = (double)reader["Latitude"];

            if (fieldNames.Contains("UserAddressId"))
                if (!Convert.IsDBNull(reader["UserAddressId"]))
                    order.UserAddressId = (int)reader["UserAddressId"];

            if (fieldNames.Contains("UserAddressName"))
                if (!Convert.IsDBNull(reader["UserAddressName"]))
                    order.UserAddressName = reader["UserAddressName"].ToString();

            if (fieldNames.Contains("DeliveryPlaceId"))
                if (!Convert.IsDBNull(reader["DeliveryPlaceId"]))
                    order.DeliveryPlaceId = (int)reader["DeliveryPlaceId"];


            if (fieldNames.Contains("DeliveryPlaceArabicName"))
                if (!Convert.IsDBNull(reader["DeliveryPlaceArabicName"]))
                    order.DeliveryPlaceArabicName = reader["DeliveryPlaceArabicName"].ToString();


            if (fieldNames.Contains("DeliveryPlaceEnglishName"))
                if (!Convert.IsDBNull(reader["DeliveryPlaceEnglishName"]))
                    order.DeliveryPlaceEnglishName = reader["DeliveryPlaceEnglishName"].ToString(); ;


            if (fieldNames.Contains("DeliveryUserId"))
                if (!Convert.IsDBNull(reader["DeliveryUserId"]))
                    order.DeliveryUserId = (int)reader["DeliveryUserId"];

            if (fieldNames.Contains("DeliveryUserFullName"))
                if (!Convert.IsDBNull(reader["DeliveryUserFullName"]))
                    order.DeliveryUserFullName = reader["DeliveryUserFullName"].ToString();

            if (fieldNames.Contains("DeliveryUserAvgRating"))
                if (!Convert.IsDBNull(reader["DeliveryUserAvgRating"]))
                    order.DeliveryUserAvgRating = (double)reader["DeliveryUserAvgRating"];


            if (fieldNames.Contains("DeliveryUserMobileNumber"))
                if (!Convert.IsDBNull(reader["DeliveryUserMobileNumber"]))
                    order.DeliveryUserMobileNumber = reader["DeliveryUserMobileNumber"].ToString();

            if (fieldNames.Contains("OrderAvgRating"))
                if (!Convert.IsDBNull(reader["OrderAvgRating"]))
                    order.OrderAvgRating = (double)reader["OrderAvgRating"];

            if (fieldNames.Contains("DeliveryUserNote"))
                if (!Convert.IsDBNull(reader["DeliveryUserNote"]))
                    order.DeliveryUserNote = reader["DeliveryUserNote"].ToString();

            if (fieldNames.Contains("StartDeliveryDate"))
                if (!Convert.IsDBNull(reader["StartDeliveryDate"]))
                    order.StartDeliveryDate = reader["StartDeliveryDate"].ToString();

            if (fieldNames.Contains("CountryId"))
                if (!Convert.IsDBNull(reader["CountryId"]))
                    order.CountryId = Convert.ToInt32(reader["CountryId"]);

            if (fieldNames.Contains("GovernorateId"))
                if (!Convert.IsDBNull(reader["GovernorateId"]))
                    order.GovernorateId = Convert.ToInt32(reader["GovernorateId"]);

            if (fieldNames.Contains("CityId"))
                if (!Convert.IsDBNull(reader["CityId"]))
                    order.CityId = Convert.ToInt32(reader["CityId"]);

            if (fieldNames.Contains("LocationId"))
                if (!Convert.IsDBNull(reader["LocationId"]))
                    order.LocationId = Convert.ToInt32(reader["LocationId"]);

            if (fieldNames.Contains("BlockNo"))
                if (!Convert.IsDBNull(reader["BlockNo"]))
                    order.BlockNo = reader["BlockNo"].ToString();

            if (fieldNames.Contains("Street"))
                if (!Convert.IsDBNull(reader["Street"]))
                    order.Street = reader["Street"].ToString();

            if (fieldNames.Contains("Building"))
                if (!Convert.IsDBNull(reader["Building"]))
                    order.Building = reader["Building"].ToString();

            if (fieldNames.Contains("Floor"))
                if (!Convert.IsDBNull(reader["Floor"]))
                    order.Floor = reader["Floor"].ToString();

            if (fieldNames.Contains("ApartmentNo"))
                if (!Convert.IsDBNull(reader["ApartmentNo"]))
                    order.ApartmentNo = reader["ApartmentNo"].ToString();

            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    order.CountryArabicName = reader["CountryArabicName"].ToString();
            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    order.CountryEnglishName = reader["CountryEnglishName"].ToString();


            if (fieldNames.Contains("GovernorateArabicName"))
                if (!Convert.IsDBNull(reader["GovernorateArabicName"]))
                    order.GovernorateArabicName = reader["GovernorateArabicName"].ToString();
            if (fieldNames.Contains("GovernorateEnglishName"))
                if (!Convert.IsDBNull(reader["GovernorateEnglishName"]))
                    order.GovernorateEnglishName = reader["GovernorateEnglishName"].ToString();

            if (fieldNames.Contains("CityArabicName"))
                if (!Convert.IsDBNull(reader["CityArabicName"]))
                    order.CityArabicName = reader["CityArabicName"].ToString();
            if (fieldNames.Contains("CityEnglishName"))
                if (!Convert.IsDBNull(reader["CityEnglishName"]))
                    order.CityEnglishName = reader["CityEnglishName"].ToString();

            if (fieldNames.Contains("LocationArabicName"))
                if (!Convert.IsDBNull(reader["LocationArabicName"]))
                    order.LocationArabicName = reader["LocationArabicName"].ToString();
            if (fieldNames.Contains("LocationEnglishName"))
                if (!Convert.IsDBNull(reader["LocationEnglishName"]))
                    order.LocationEnglishName = reader["LocationEnglishName"].ToString();

            if (fieldNames.Contains("PaymentTypeId"))
                if (!Convert.IsDBNull(reader["PaymentTypeId"]))
                    order.PaymentTypeId = (int)reader["PaymentTypeId"];

            if (fieldNames.Contains("PaymentTypeArabicName"))
                if (!Convert.IsDBNull(reader["PaymentTypeArabicName"]))
                    order.PaymentTypeArabicName = reader["PaymentTypeArabicName"].ToString();

            if (fieldNames.Contains("PaymentTypeEnglishName"))
                if (!Convert.IsDBNull(reader["PaymentTypeEnglishName"]))
                    order.PaymentTypeEnglishName = reader["PaymentTypeEnglishName"].ToString();

            if (fieldNames.Contains("PaymentSerialNumber"))
                if (!Convert.IsDBNull(reader["PaymentSerialNumber"]))
                    order.PaymentSerialNumber = reader["PaymentSerialNumber"].ToString();


            if (fieldNames.Contains("BranchId"))
                if (!Convert.IsDBNull(reader["BranchId"]))
                    order.BranchId = (int)reader["BranchId"];

            if (fieldNames.Contains("BranchArabicName"))
                if (!Convert.IsDBNull(reader["BranchArabicName"]))
                    order.BranchArabicName = reader["BranchArabicName"].ToString();

            if (fieldNames.Contains("BranchEnglishName"))
                if (!Convert.IsDBNull(reader["BranchEnglishName"]))
                    order.BranchEnglishName = reader["BranchEnglishName"].ToString();

            if (fieldNames.Contains("OrderTypeId"))
                if (!Convert.IsDBNull(reader["OrderTypeId"]))
                    order.OrderTypeId = (int)reader["OrderTypeId"];

            if (fieldNames.Contains("OrderTypeArabicName"))
                if (!Convert.IsDBNull(reader["OrderTypeArabicName"]))
                    order.OrderTypeArabicName = reader["OrderTypeArabicName"].ToString();

            if (fieldNames.Contains("OrderTypeEnglishName"))
                if (!Convert.IsDBNull(reader["OrderTypeEnglishName"]))
                    order.OrderTypeEnglishName = reader["OrderTypeEnglishName"].ToString();

            if (fieldNames.Contains("TotalSeriesQty"))
                if (!Convert.IsDBNull(reader["TotalSeriesQty"]))
                    order.TotalSeriesQty = (double)reader["TotalSeriesQty"];

            if (fieldNames.Contains("TotalSeriesPrice"))
                if (!Convert.IsDBNull(reader["TotalSeriesPrice"]))
                    order.TotalSeriesPrice = reader["TotalSeriesPrice"].ToString();

            if (fieldNames.Contains("SeriesItemsCount"))
                if (!Convert.IsDBNull(reader["SeriesItemsCount"]))
                    order.SeriesItemsCount = (int)reader["SeriesItemsCount"];

            if (fieldNames.Contains("IsImmediateDelivery"))
                if (!Convert.IsDBNull(reader["IsImmediateDelivery"]))
                    order.IsImmediateDelivery = Convert.ToBoolean(reader["IsImmediateDelivery"]);

            if (fieldNames.Contains("DeliveryCost"))
                if (!Convert.IsDBNull(reader["DeliveryCost"]))
                    order.DeliveryCost = Convert.ToDouble(reader["DeliveryCost"]);

            if (fieldNames.Contains("DeliveryPeriodFrom"))
                if (!Convert.IsDBNull(reader["DeliveryPeriodFrom"]))
                    order.DeliveryPeriodFrom = reader["DeliveryPeriodFrom"].ToString();

            if (fieldNames.Contains("DeliveryPeriodTo"))
                if (!Convert.IsDBNull(reader["DeliveryPeriodTo"]))
                    order.DeliveryPeriodTo = reader["DeliveryPeriodTo"].ToString();

            if (fieldNames.Contains("LocationDeliveryDate"))
                if (!Convert.IsDBNull(reader["LocationDeliveryDate"]))
                    order.LocationDeliveryDate = reader["LocationDeliveryDate"].ToString();


            order.DeliveryDayTime = "";

            if (fieldNames.Contains("LocationDeliveryDate"))
                if (!Convert.IsDBNull(reader["LocationDeliveryDate"]))
                    order.DeliveryDayTime = reader["LocationDeliveryDate"].ToString();

            if (fieldNames.Contains("DeliveryPeriodFrom"))
                if (!Convert.IsDBNull(reader["DeliveryPeriodFrom"]))
                    order.DeliveryDayTime = order.DeliveryDayTime + " - " + reader["DeliveryPeriodFrom"].ToString();

            if (fieldNames.Contains("DeliveryPeriodTo"))
                if (!Convert.IsDBNull(reader["DeliveryPeriodTo"]))
                    order.DeliveryDayTime = order.DeliveryDayTime + " - " + reader["DeliveryPeriodTo"].ToString();

            if (fieldNames.Contains("HasOnRequest"))
                if (!Convert.IsDBNull(reader["HasOnRequest"]))
                    order.HasOnRequest = Convert.ToBoolean(reader["HasOnRequest"]);

            if (fieldNames.Contains("MaxRequestDays"))
                if (!Convert.IsDBNull(reader["MaxRequestDays"]))
                    order.MaxRequestDays = Convert.ToInt32(reader["MaxRequestDays"]);

            if (fieldNames.Contains("OrderDiscount"))
                if (!Convert.IsDBNull(reader["OrderDiscount"]))
                    order.OrderDiscount = reader["OrderDiscount"].ToString();

            if (fieldNames.Contains("FinalPrice"))
                if (!Convert.IsDBNull(reader["FinalPrice"]))
                    order.FinalPrice = reader["FinalPrice"].ToString();

            if (fieldNames.Contains("CouponId"))
                if (!Convert.IsDBNull(reader["CouponId"]))
                    order.CouponId = Convert.ToInt32(reader["CouponId"]);

            if (fieldNames.Contains("CouponValue"))
                if (!Convert.IsDBNull(reader["CouponValue"]))
                    order.CouponValue = reader["CouponValue"].ToString();

            if (fieldNames.Contains("CouponValueType"))
                if (!Convert.IsDBNull(reader["CouponValueType"]))
                    order.CouponValueType = Convert.ToInt32(reader["CouponValueType"]);

            if (fieldNames.Contains("Extras"))
                if (!Convert.IsDBNull(reader["Extras"]))
                    order.Extras = reader["Extras"].ToString();


            if (fieldNames.Contains("Credit"))
                if (!Convert.IsDBNull(reader["Credit"]))
                    order.Credit = Convert.ToDouble(reader["Credit"]);

            if (fieldNames.Contains("Balance"))
                if (!Convert.IsDBNull(reader["Balance"]))
                    order.Balance = Convert.ToDouble(reader["Balance"]);


            if (fieldNames.Contains("OrderAmount"))
                if (!Convert.IsDBNull(reader["OrderAmount"]))
                    order.OrderAmount = Convert.ToDouble(reader["OrderAmount"]);

            if (fieldNames.Contains("LastPaymentAmount"))
                if (!Convert.IsDBNull(reader["LastPaymentAmount"]))
                    order.LastPaymentAmount = Convert.ToDouble(reader["LastPaymentAmount"]);

            if (fieldNames.Contains("LastPaymentDate"))
                if (!Convert.IsDBNull(reader["LastPaymentDate"]))
                    order.LastPaymentDate = reader["LastPaymentDate"].ToString();

            if (fieldNames.Contains("TotalSales"))
                if (!Convert.IsDBNull(reader["TotalSales"]))
                    order.TotalSales = Convert.ToDouble(reader["TotalSales"]);

            if (fieldNames.Contains("IsCheckedByManager"))
                if (!Convert.IsDBNull(reader["IsCheckedByManager"]))
                    order.IsCheckedByManager = Convert.ToBoolean(reader["IsCheckedByManager"]);

            if (fieldNames.Contains("NeedsCheckByManager"))
                if (!Convert.IsDBNull(reader["NeedsCheckByManager"]))
                    order.NeedsCheckByManager = Convert.ToBoolean(reader["NeedsCheckByManager"]);

            if (fieldNames.Contains("ManagerApprove"))
                if (!Convert.IsDBNull(reader["ManagerApprove"]))
                    order.ManagerApprove = Convert.ToBoolean(reader["ManagerApprove"]);

            if (fieldNames.Contains("ManagerUserId"))
                if (!Convert.IsDBNull(reader["ManagerUserId"]))
                    order.ManagerUserId = Convert.ToInt32(reader["ManagerUserId"]);

            if (fieldNames.Contains("ManagerCheckDate"))
                if (!Convert.IsDBNull(reader["ManagerCheckDate"]))
                    order.ManagerCheckDate = reader["ManagerCheckDate"].ToString();

            if (fieldNames.Contains("ManagerFullName"))
                if (!Convert.IsDBNull(reader["ManagerFullName"]))
                    order.ManagerFullName = reader["ManagerFullName"].ToString();

            if (fieldNames.Contains("TotalQtyToDeliver"))
                if (!Convert.IsDBNull(reader["TotalQtyToDeliver"]))
                    order.TotalQtyToDeliver = Convert.ToInt32(reader["TotalQtyToDeliver"]);

            if (fieldNames.Contains("TotalDeliveredQty"))
                if (!Convert.IsDBNull(reader["TotalDeliveredQty"]))
                    order.TotalDeliveredQty = Convert.ToInt32(reader["TotalDeliveredQty"]);

            if (fieldNames.Contains("PaymentId"))
                if (!Convert.IsDBNull(reader["PaymentId"]))
                    order.PaymentId = reader["PaymentId"].ToString();

            return order;
        }


    }


}