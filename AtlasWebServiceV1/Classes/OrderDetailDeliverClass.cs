using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class OrderDetailDeliverClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int OrderDetailId { get; set; }
        [DataMember(Order = 3)]
        public int Qty { get; set; }
        [DataMember(Order = 4)]
        public string Date { get; set; }
        [DataMember(Order = 5)]
        public bool IsDelivered { get; set; }        
        [DataMember(Order = 6)]
        public int Order { get; set; }

        public OrderDetailDeliverClass PopulateOrderDetailDeliver(string[] fieldNames, SqlDataReader reader)
        {
            var orderDetailDeliver = new OrderDetailDeliverClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    orderDetailDeliver.Id = (int)reader["Id"];

            if (fieldNames.Contains("OrderDetailId"))
                if (!Convert.IsDBNull(reader["OrderDetailId"]))
                    orderDetailDeliver.OrderDetailId = (int)reader["OrderDetailId"];

            if (fieldNames.Contains("Qty"))
                if (!Convert.IsDBNull(reader["Qty"]))
                    orderDetailDeliver.Qty = (int)reader["Qty"];

            if (fieldNames.Contains("Date"))
                if (!Convert.IsDBNull(reader["Date"]))
                    orderDetailDeliver.Date = reader["Date"].ToString();

            if (fieldNames.Contains("IsDelivered"))
                if (!Convert.IsDBNull(reader["IsDelivered"]))
                    orderDetailDeliver.IsDelivered = Convert.ToBoolean(reader["IsDelivered"]);

            return orderDetailDeliver;
        }
    }
}