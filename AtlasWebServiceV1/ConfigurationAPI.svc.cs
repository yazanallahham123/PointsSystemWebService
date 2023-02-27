using Newtonsoft.Json;
using PointsSystemWebService.Classes;
using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace PointsSystemWebService
{
   // NOTE: Init You can use the "Rename" command on the "Refactor" menu to change the class name "ConfigurationAPI" in code, svc and config file together.
   // NOTE: In order to launch WCF Test Client for testing this service, please select ConfigurationAPI.svc or ConfigurationAPI.svc.cs at the Solution Explorer and start debugging.
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class ConfigurationAPI : IConfigurationAPI
   {
      public ResultClass<List<ConnectionFileClass>> GetConnections()
      {
         ResultClass<List<ConnectionFileClass>> result = new ResultClass<List<ConnectionFileClass>>();

         try
         {
            //Load JSON
            List<ConnectionFileClass> items = new List<ConnectionFileClass>();
            var appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            string FilePath = Path.Combine(appPath, @"Configuration\ConnectionString.json");

            using (StreamReader reader = new StreamReader(FilePath))
            {
               string json = reader.ReadToEnd();
               items = JsonConvert.DeserializeObject<List<ConnectionFileClass>>(json);
            }

             result.Code = Errors.Success;
            result.Message = "";
            result.Result = items;
            return result;
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
               Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "GetConnections", e.Source, "");
            }
            result.Result = null;
            return result;
         }

      }


   }
}
