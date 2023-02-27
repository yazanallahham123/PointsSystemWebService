using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class OrderSerialClass
    {
        [DataMember(Order = 1)]
        public string Serial { get; set; }

        [DataMember(Order = 2)]
        public string Code { get; set; }

        [DataMember(Order = 3)]
        public int Order { get; set; }

        public OrderSerialClass PopulateOrderSerial(string[] fieldNames, SqlDataReader reader)
        {
            var orderSerial = new OrderSerialClass();

            if (fieldNames.Contains("Code"))
                if (!Convert.IsDBNull(reader["Code"]))
                    orderSerial.Code = reader["Code"].ToString();

            if (fieldNames.Contains("Serial"))
                if (!Convert.IsDBNull(reader["Serial"]))
                    orderSerial.Serial = reader["Serial"].ToString();
            return orderSerial;

        }
    }
}