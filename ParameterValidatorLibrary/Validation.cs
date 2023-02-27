using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Reflection;
using System.ServiceModel.Channels;

namespace ParameterValidatorLibrary
{
   public class Validation { }

   public class ValidationParameterInspector : IParameterInspector, IDispatchMessageInspector
    {
      public object BeforeCall(string operationName, object[] inputs)
      {
         for (int index = 0; index < inputs.Length; index++)
         {
            var param = inputs[index];
            if (param != null)
            {
               var paramName = param.GetType().Name;
               if (paramName.ToLower() == "string")   //if param is simple type and just a string 
               {
                  if (param.ToString().Contains("'"))
                  {
                     inputs[index] = param.ToString().Replace("'", "''");
                     Infrastructure.LogHack(operationName, param.ToString());
                  }
               }
               else //If its in complex type then check the prop if its string
               {
                  foreach (var prop in param.GetType().GetProperties())
                  {
                     try
                     {
                        if (prop.PropertyType.Name.ToLower() == "string")   //if param is simple type and just a string 
                        {
                           var propValue = prop.GetValue(param, null);
                                    if (propValue != null)
                                    {
                                        if (propValue.ToString().Contains("'"))
                                        {
                                            Infrastructure.LogHack(operationName, param.ToString());
                                            prop.SetValue(param, propValue.ToString().Replace("'", "''"));
                                        }
                                    }
                        }
                        else if (prop.Module.Name == "PointsSystemWebService.dll"
                        || prop.PropertyType.FullName.Split('.')[0] == "PointsSystemWebService")  //if its from our code base classes
                        {
                           CheckClassProp(prop, operationName);
                        }
                     }

                     catch (Exception ) { }
                  }


                  inputs[index] = param;
               }
            }
         }

         return null;
      }

      private object CheckClassProp(PropertyInfo param1, string operationName)
      {
         foreach (var prop1 in param1.PropertyType.GetProperties())
         {
            try
            {
               if (prop1.PropertyType.Name.ToLower() == "string")   //if param is simple type and just a string 
               {
                  var propValue = prop1.GetValue((object)param1, null);

                  if (propValue.ToString().Contains("'"))
                  {
                     Infrastructure.LogHack(operationName, param1.ToString());
                     prop1.SetValue(param1, propValue.ToString().Replace("'", "''"));
                  }
               }
               else if (prop1.Module.Name == "PointsSystemWebService.dll"
                  || prop1.PropertyType.FullName.Split('.')[0] == "PointsSystemWebService") //if its from our code base classes
               {
                  CheckClassProp(prop1, operationName);
               }
            }

            catch (Exception ) { }
         }

         return param1;
      }

      private static void ThrowFaultException()
      {

         //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";

         //var wfc = new WebFaultException<Response>(new Response(false, Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ClientErrorMsg"])), System.Net.HttpStatusCode.OK);
         //throw wfc;
      }


      public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
      {
         //if (operationName == "Login")
         //{
         //var x = (ResultClass<UserClass>)returnValue;
         //if (x.Result != null)
         //   Console.WriteLine(x.Result.Password);


         //for (int index = 0; index < outputs.Length; index++)
         //{
         //   if (index == 0)
         //   {
         //      // execute the method level validators
         //      if ((string)outputs[index] == "test12345")
         //         throw new FaultException("Your Error Message");
         //   }
         //}
         //}
      }

        object IDispatchMessageInspector.AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return request;
        }

        void IDispatchMessageInspector.BeforeSendReply(ref Message reply, object correlationState)
        {

            Message m = correlationState as Message;

            
            HttpResponseMessageProperty prop;
            if (reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
            {
                prop = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
            }
            else
            {
                prop = new HttpResponseMessageProperty();
                reply.Properties.Add(HttpResponseMessageProperty.Name, prop);
            }


            HttpRequestMessageProperty requestHeaders = null;
            if (m.Properties.ContainsKey(HttpRequestMessageProperty.Name))
                requestHeaders = (HttpRequestMessageProperty)m.Properties[HttpRequestMessageProperty.Name];


            string loggedUser = requestHeaders.Headers["LoggedUser"];

            try
            {
                var result = BalanceUpdater.SendUpdatedBalance(Convert.ToInt32(loggedUser));
                var userBadgesRes = BalanceUpdater.GetUserBadges(Convert.ToInt32(loggedUser));

                if ((result != null) & (result?.Result != null) & (result?.Code == 0))
                {
                    var user = result.Result;

                    prop.Headers.Add("TotalSent", user.TotalSent.ToString());
                    prop.Headers.Add("TotalReceived", user.TotalReceived.ToString());
                    prop.Headers.Add("PointsBalance", user.PointsBalance.ToString());
                    //prop.Headers.Add("TotalSent_Waiting", user.TotalSent_Waiting.ToString());
                    prop.Headers.Add("TotalReceived_Waiting", user.TotalReceived_Waiting.ToString());
                    prop.Headers.Add("OrdersPoints", user.OrdersPoints.ToString());
                    prop.Headers.Add("OrdersPointsFromGifts", user.OrdersPointsFromGifts.ToString());
                    prop.Headers.Add("GiftsPoints", user.GiftsPoints.ToString());
                    prop.Headers.Add("TotalReceivedGiftsPoints", user.TotalReceivedGiftsPoints.ToString());
                    prop.Headers.Add("TotalSentFromGiftsPoints", user.TotalSentFromGiftsPoints.ToString());
                    
                }

                if ((userBadgesRes != null) & (userBadgesRes?.Result != null) & (userBadgesRes?.Code == 0))
                {
                    var badges = userBadgesRes.Result;
                    prop.Headers.Add("LastOpenOrderBadgeCount", badges.LastOpenOrderBadgeCount.ToString());
                    prop.Headers.Add("AllNotificationsCount", badges.AllNotificationsCount.ToString());
                    prop.Headers.Add("TotalLikesCount", badges.TotalLikesCount.ToString());
                    prop.Headers.Add("TotalWishlistsCount", badges.TotalWishlistsCount.ToString());
                    
                }
            }
            catch (Exception ee)
            {
                try
                {
                    prop.Headers.Add("TotalSent", ee.Message);
                    prop.Headers.Add("TotalReceived", "error");
                    prop.Headers.Add("PointsBalance", "error");
                    //prop.Headers.Add("TotalSent_Waiting", "error");
                    prop.Headers.Add("TotalReceived_Waiting", "error");
                    prop.Headers.Add("OrdersPoints", "error");
                    prop.Headers.Add("GiftsPoints", "error");
                    prop.Headers.Add("OrdersPointsFromGifts", "error");
                    prop.Headers.Add("TotalReceivedGiftsPoints", "error");
                    prop.Headers.Add("TotalSentFromGiftsPoints", "error");

                    prop.Headers.Add("LastOpenOrderBadgeCount", "error");
                    prop.Headers.Add("AllNotificationsCount", "error");
                    prop.Headers.Add("TotalLikesCount", "error");
                    prop.Headers.Add("TotalWishlistsCount", "error");
                   

                }
                catch (Exception ex)
                {
                   
                }
            }
        }
    }


   public class CustomBehaviorSection : BehaviorExtensionElement
   {
      private const string EnabledAttributeName = "enabled";

      [ConfigurationProperty(EnabledAttributeName, DefaultValue = true, IsRequired = false)]
      public bool Enabled
      {
         get { return (bool)base[EnabledAttributeName]; }
         set { base[EnabledAttributeName] = value; }
      }

      public override Type BehaviorType { get { return typeof(ValidationBehavior); } }

      protected override object CreateBehavior() { return new ValidationBehavior(this.Enabled); }

   }
}
