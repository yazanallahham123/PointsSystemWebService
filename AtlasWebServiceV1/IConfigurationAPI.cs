using PointsSystemWebService.Classes;
using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PointsSystemWebService
{
   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IConfigurationAPI" in both code and config file together.
   [ServiceContract]
   public interface IConfigurationAPI
   {
      [OperationContract]
      [WebInvoke(Method = "POST",
      ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "JSON/GetConnections")]
      ResultClass<List<ConnectionFileClass>> GetConnections();
   }
}
