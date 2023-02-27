using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class DashboardClass
    {
        [DataMember(Order = 1)]
        public int PendingOrdersCount { get; set; }
        [DataMember(Order = 2)]
        public int StartedOrdersCount { get; set; }
        [DataMember(Order = 3)]
        public int ShippingOrdersCount { get; set; }
        [DataMember(Order = 4)]
        public int DeliveredOrdersCount { get; set; }
        [DataMember(Order = 5)]
        public int CancelledOrdersCount { get; set; }
        [DataMember(Order = 6)]
        public int RefusedOrdersCount { get; set; }
        [DataMember(Order = 7)]
        public int TotalOrdersCount { get; set; }


        [DataMember(Order = 8)]
        public double PendingOrdersPriceValue { get; set; }
        [DataMember(Order = 9)]
        public double StartedOrdersPriceValue { get; set; }
        [DataMember(Order = 10)]
        public double ShippingOrdersPriceValue { get; set; }
        [DataMember(Order = 11)]
        public double DeliveredOrdersPriceValue { get; set; }
        [DataMember(Order = 12)]
        public double CancelledOrdersPriceValue { get; set; }
        [DataMember(Order = 13)]
        public double RefusedOrdersPriceValue { get; set; }
        [DataMember(Order = 14)]
        public double TotalOrdersPriceValue { get; set; }



        [DataMember(Order = 15)]
        public double PendingOrdersPointsValue { get; set; }
        [DataMember(Order = 16)]
        public double StartedOrdersPointsValue { get; set; }
        [DataMember(Order = 17)]
        public double ShippingOrdersPointsValue { get; set; }
        [DataMember(Order = 18)]
        public double DeliveredOrdersPointsValue { get; set; }
        [DataMember(Order = 19)]
        public double CancelledOrdersPointsValue { get; set; }
        [DataMember(Order = 20)]
        public double RefusedOrdersPointsValue { get; set; }
        [DataMember(Order = 21)]
        public double TotalOrdersPointsValue { get; set; }

        [DataMember(Order = 22)]
        public int TotalUsersCount { get; set; }



        public DashboardClass PopulateDashboard(DashboardClass dashboard, string[] fieldNames, SqlDataReader reader)
        {
            if (fieldNames.Contains("PendingOrdersCount"))
                if (!Convert.IsDBNull(reader["PendingOrdersCount"]))
                    dashboard.PendingOrdersCount = Convert.ToInt32(reader["PendingOrdersCount"]);


            if (fieldNames.Contains("StartedOrdersCount"))
                if (!Convert.IsDBNull(reader["StartedOrdersCount"]))
                    dashboard.StartedOrdersCount = Convert.ToInt32(reader["StartedOrdersCount"]);

            if (fieldNames.Contains("ShippingOrdersCount"))
                if (!Convert.IsDBNull(reader["ShippingOrdersCount"]))
                    dashboard.ShippingOrdersCount = Convert.ToInt32(reader["ShippingOrdersCount"]);

            if (fieldNames.Contains("DeliveredOrdersCount"))
                if (!Convert.IsDBNull(reader["DeliveredOrdersCount"]))
                    dashboard.DeliveredOrdersCount = Convert.ToInt32(reader["DeliveredOrdersCount"]);

            if (fieldNames.Contains("CancelledOrdersCount"))
                if (!Convert.IsDBNull(reader["CancelledOrdersCount"]))
                    dashboard.CancelledOrdersCount = Convert.ToInt32(reader["CancelledOrdersCount"]);

            if (fieldNames.Contains("RefusedOrdersCount"))
                if (!Convert.IsDBNull(reader["RefusedOrdersCount"]))
                    dashboard.RefusedOrdersCount = Convert.ToInt32(reader["RefusedOrdersCount"]);

            if (fieldNames.Contains("TotalOrdersCount"))
                if (!Convert.IsDBNull(reader["TotalOrdersCount"]))
                    dashboard.TotalOrdersCount = Convert.ToInt32(reader["TotalOrdersCount"]);


            if (fieldNames.Contains("PendingOrdersPriceValue"))
                if (!Convert.IsDBNull(reader["PendingOrdersPriceValue"]))
                    dashboard.PendingOrdersPriceValue = Convert.ToDouble(reader["PendingOrdersPriceValue"]);

            if (fieldNames.Contains("StartedOrdersPriceValue"))
                if (!Convert.IsDBNull(reader["StartedOrdersPriceValue"]))
                    dashboard.StartedOrdersPriceValue = Convert.ToDouble(reader["StartedOrdersPriceValue"]);

            if (fieldNames.Contains("ShippingOrdersPriceValue"))
                if (!Convert.IsDBNull(reader["ShippingOrdersPriceValue"]))
                    dashboard.ShippingOrdersPriceValue = Convert.ToDouble(reader["ShippingOrdersPriceValue"]);

            if (fieldNames.Contains("DeliveredOrdersPriceValue"))
                if (!Convert.IsDBNull(reader["DeliveredOrdersPriceValue"]))
                    dashboard.DeliveredOrdersPriceValue = Convert.ToDouble(reader["DeliveredOrdersPriceValue"]);

            if (fieldNames.Contains("CancelledOrdersPriceValue"))
                if (!Convert.IsDBNull(reader["CancelledOrdersPriceValue"]))
                    dashboard.CancelledOrdersPriceValue = Convert.ToDouble(reader["CancelledOrdersPriceValue"]);

            if (fieldNames.Contains("RefusedOrdersPriceValue"))
                if (!Convert.IsDBNull(reader["RefusedOrdersPriceValue"]))
                    dashboard.RefusedOrdersPriceValue = Convert.ToDouble(reader["RefusedOrdersPriceValue"]);

            if (fieldNames.Contains("TotalOrdersPriceValue"))
                if (!Convert.IsDBNull(reader["TotalOrdersPriceValue"]))
                    dashboard.TotalOrdersPriceValue = Convert.ToDouble(reader["TotalOrdersPriceValue"]);



            if (fieldNames.Contains("PendingOrdersPointsValue"))
                if (!Convert.IsDBNull(reader["PendingOrdersPointsValue"]))
                    dashboard.PendingOrdersPointsValue = Convert.ToDouble(reader["PendingOrdersPointsValue"]);

            if (fieldNames.Contains("StartedOrdersPointsValue"))
                if (!Convert.IsDBNull(reader["StartedOrdersPointsValue"]))
                    dashboard.StartedOrdersPointsValue = Convert.ToDouble(reader["StartedOrdersPointsValue"]);

            if (fieldNames.Contains("ShippingOrdersPointsValue"))
                if (!Convert.IsDBNull(reader["ShippingOrdersPointsValue"]))
                    dashboard.ShippingOrdersPointsValue = Convert.ToDouble(reader["ShippingOrdersPointsValue"]);

            if (fieldNames.Contains("DeliveredOrdersPointsValue"))
                if (!Convert.IsDBNull(reader["DeliveredOrdersPointsValue"]))
                    dashboard.DeliveredOrdersPointsValue = Convert.ToDouble(reader["DeliveredOrdersPointsValue"]);

            if (fieldNames.Contains("CancelledOrdersPointsValue"))
                if (!Convert.IsDBNull(reader["CancelledOrdersPointsValue"]))
                    dashboard.CancelledOrdersPointsValue = Convert.ToDouble(reader["CancelledOrdersPointsValue"]);

            if (fieldNames.Contains("RefusedOrdersPointsValue"))
                if (!Convert.IsDBNull(reader["RefusedOrdersPointsValue"]))
                    dashboard.RefusedOrdersPointsValue = Convert.ToDouble(reader["RefusedOrdersPointsValue"]);

            if (fieldNames.Contains("TotalOrdersPointsValue"))
                if (!Convert.IsDBNull(reader["TotalOrdersPointsValue"]))
                    dashboard.TotalOrdersPointsValue = Convert.ToDouble(reader["TotalOrdersPointsValue"]);


            if (fieldNames.Contains("TotalUsersCount"))
                if (!Convert.IsDBNull(reader["TotalUsersCount"]))
                    dashboard.TotalUsersCount = Convert.ToInt32(reader["TotalUsersCount"]);

            return dashboard;
        }
    }
}