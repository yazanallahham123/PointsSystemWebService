using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WooCommerceNET;

namespace PointsSystemWebService.Classes.WooCommerce
{
    public class RestAPIHelper : RestAPI
    {
        public RestAPIHelper(string url, string key, string secret, bool authorizedHeader = true,
            Func<string, string> jsonSerializeFilter = null,
            Func<string, string> jsonDeserializeFilter = null,
            Action<HttpWebRequest> requestFilter = null) : base(url, key, secret, authorizedHeader, jsonSerializeFilter, jsonDeserializeFilter, requestFilter)
        {
        }

        public override T DeserializeJSon<T>(string jsonString) { if (jsonString.Trim().StartsWith("<")) jsonString = jsonString.Substring(jsonString.IndexOf("{"), jsonString.Length - jsonString.IndexOf("{")); return JsonConvert.DeserializeObject<T>(jsonString); }

        public override string SerializeJSon<T>(T t)
        {
            return JsonConvert.SerializeObject(t);
        }
    }
}