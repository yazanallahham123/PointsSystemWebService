using PointsSystemWebService.Classes;
using PointsSystemWebService.Classes.Authentication;
using PointsSystemWebService.Classes.Core;
using SwaggerWcf;
using SwaggerWcf.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Configuration;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.ServiceModel.Activation;

namespace PointsSystemWebService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //SqlDependency.Start(WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            //FCMClass.initSQLDep();

            SwaggerWcfEndpoint.FilterVisibleTags = FilterVisibleTags;
            SwaggerWcfEndpoint.FilterHiddenTags = FilterHiddenTags;
            SwaggerWcfEndpoint.DisableSwaggerUI = false;
            

            RouteTable.Routes.Add(new ServiceRoute("v1/rest", new WebServiceHostFactory(), typeof(PointsServiceAPI)));
            RouteTable.Routes.Add(new ServiceRoute("api-docs", new WebServiceHostFactory(), typeof(SwaggerWcfEndpoint)));


            var info = new Info
            {
                Title = "New Matjar System Web Service",
                Description = "Sample Service to test New Matjar System",
                Version = "0.0.2"
                // etc
            };

            SwaggerWcfEndpoint.Configure(info);

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string sessionId = Session.SessionID;
            try
            {
                //Calligra
                //WebRequest request = WebRequest.Create("https://www.yallaasouq.com:9994/NotificationsServiceAPI.svc/JSON/FakeCall");
                //WebRequest request = WebRequest.Create("https://www.yallaasouq.com:6545/NotificationsServiceAPI.svc/JSON/FakeCall");
                //request.Method = "GET";
                //WebResponse response = request.GetResponse();
                //Errors.LogError(1, "Calling Notification Service", "Calling Notification Service", "1.0.3", "API", "Session_Start", "", "");
            }
            catch (Exception x)
            { Errors.LogError(1, x.Message, x.StackTrace, "1.0.3", "API", "Session_Start", x.Source, ""); }

        }




        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Access");
                HttpContext.Current.Response.AddHeader("Access-Control-Expose-Headers", "Access");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }


            string loggedUser = HttpContext.Current.Request.Headers["LoggedUser"];

            //if ((HttpContext.Current.Request.Url.Host == "localhost") && (Config.PaypassLoggedUserInSwagger))
            //    HttpContext.Current.Request.Headers["LoggedUser"] = "7";

            //Auth Check (Access Token + Application Token + SessionTimeout)
            if (HttpContext.Current.Request.Url.Host != "localhost")
            {
                if (Config.CheckApplicationToken)
                {
                    if (Config.ApplicationToken != HttpContext.Current.Request.Headers["ApplicationToken"])
                        Config.ReturnErrorResponse<string>(Errors.MissingHeader);
                }
                if (Config.CheckAccessToken)
                {
                    if (HttpContext.Current.Request.HttpMethod == "GET" ||
                        HttpContext.Current.Request.HttpMethod == "POST")
                    {
                        var code = TokenValidator.IsValidateToken();
                        if (code != Errors.Success)
                        {
                            //Token is Not Valid
                            string json = CredentialsValidator.UnAuthorizeAccessJson(code);

                            Config.ReturnErrorResponse(code, json);
                        }
                        else
                        {
                            //Token Valid -- Check Session Time if Valid
                            if (Config.CheckSessionTimeout)
                            {
                                loggedUser = HttpContext.Current.Request.Headers["LoggedUser"];
                                string source = HttpContext.Current.Request.Headers["Source"];

                                if (String.IsNullOrWhiteSpace(source))
                                    Config.ReturnErrorResponse<string>(Errors.MissingHeader);

                                else if (source == "Web") //Check for session timeout 
                                {
                                    var sessionResult = UserSession.UpdateUserSession(Convert.ToInt32(loggedUser));
                                    if (sessionResult.Code != 0)
                                        Config.ReturnErrorResponse(sessionResult.Code, sessionResult);
                                    //else pass 
                                }
                                else if (source != "MobileApplication") //any header value not "MobileApplication"
                                    Config.ReturnErrorResponse<string>(Errors.MissingHeader);
                            }
                        }
                    }
                    else
                        HttpContext.Current.Response.AddHeader("Access", "1");
                }
            }      //END Auth Check (Access Token + Application Token + SessionTimeout)
        }



        protected void Application_EndRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            //SqlDependency.Stop(WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        }


        private static List<string> FilterVisibleTags(string path, List<string> visibleTags)
        {
            return visibleTags;
        }

        private static List<string> FilterHiddenTags(string path, List<string> hiddenTags)
        {
            return hiddenTags;
        }
    }
}