using PointsSystemWebService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PointsSystemWebService
{
   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDeveloperAPI" in both code and config file together.
   [ServiceContract]
   public interface IDeveloperAPI
   {
      //Testing
      [OperationContract]
      [WebInvoke(Method = "POST",
      ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "JSON/CheckMobileVerificationCode_Test")]
      ResultClass<CheckMobileVerificationCodeClass> CheckMobileVerificationCode_Test(string MobileNo, string requestid, string code);

      [OperationContract]
      [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "JSON/deleteUserColumn_Fortesting")]
      void deleteUserColumn_Fortesting();

      [OperationContract]
      [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
     ResponseFormat = WebMessageFormat.Json,
     BodyStyle = WebMessageBodyStyle.Wrapped,
     UriTemplate = "JSON/DeleteUser_Dev")]
      ResultClass<UserClass> DeleteUser_Dev(int UserId, string MobileNumber);

   }
}
