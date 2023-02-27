using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ECashCallBackResultClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public bool IsSuccess { get; set; }
        [DataMember(Order = 3)]
        public string Message { get; set; }
        [DataMember(Order = 4)]
        public string OrderRef { get; set; }
        [DataMember(Order = 5)]
        public string TransactionNo { get; set; }
        [DataMember(Order = 6)]
        public string Amount { get; set; }
        [DataMember(Order = 7)]
        public string Token { get; set; }
        [DataMember(Order = 8)]
        public string Date { get; set; }


        public ECashCallBackResultClass PopulateECashCallBack(string[] fieldNames, SqlDataReader reader)
        {
            ECashCallBackResultClass eCashCallBackResultClass = new ECashCallBackResultClass();
            if (fieldNames.Contains("IsSuccess"))
                if (!Convert.IsDBNull(reader["IsSuccess"]))
                    eCashCallBackResultClass.IsSuccess = Convert.ToBoolean(reader["IsSuccess"]);

            if (fieldNames.Contains("Message"))
                if (!Convert.IsDBNull(reader["Message"]))
                    eCashCallBackResultClass.Message = reader["Message"].ToString();

            if (fieldNames.Contains("TransactionNo"))
                if (!Convert.IsDBNull(reader["TransactionNo"]))
                    eCashCallBackResultClass.TransactionNo = reader["TransactionNo"].ToString();

            if (fieldNames.Contains("OrderRef"))
                if (!Convert.IsDBNull(reader["OrderRef"]))
                    eCashCallBackResultClass.OrderRef = reader["OrderRef"].ToString();

            if (fieldNames.Contains("Token"))
                if (!Convert.IsDBNull(reader["Token"]))
                    eCashCallBackResultClass.Token = reader["Token"].ToString();

            if (fieldNames.Contains("Amount"))
                if (!Convert.IsDBNull(reader["Amount"]))
                    eCashCallBackResultClass.Amount = reader["Amount"].ToString();

            if (fieldNames.Contains("Date"))
                if (!Convert.IsDBNull(reader["Date"]))
                    eCashCallBackResultClass.Date = reader["Date"].ToString();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    eCashCallBackResultClass.Id = (int)reader["Id"];

            return eCashCallBackResultClass;
        }
    }
}