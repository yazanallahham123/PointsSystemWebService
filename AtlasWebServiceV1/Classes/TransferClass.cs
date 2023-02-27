using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class TransferClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string Date { get; set; }
      [DataMember(Order = 3)]
      public int Sender_UserId { get; set; }
      [DataMember(Order = 4)]
      public string Sender_Name { get; set; }
      [DataMember(Order = 5)]
      public int Receiver_UserId { get; set; }
      [DataMember(Order = 6)]
      public string Receiver_Name { get; set; }
      [DataMember(Order = 7)]
      public double Amount { get; set; }
      [DataMember(Order = 8)]
      public string Notes { get; set; }
      [DataMember(Order = 9)]
      public string TransferCode { get; set; }
      [DataMember(Order = 10)]
      public int TransferStatusId { get; set; }
      [DataMember(Order = 11)]
      public string TransferStatus { get; set; }
      [DataMember(Order = 12)]
      public int TransferMethodId { get; set; }
      [DataMember(Order = 13)]
      public string TransferMethod { get; set; }
      [DataMember(Order = 14)]
      public double MainBalance { get; set; }

      [DataMember(Order = 15)]
      public double Sender_TotalSent { get; set; }

      [DataMember(Order = 16)]
      public double Sender_TotalReceived { get; set; }

      [DataMember(Order = 17)]
      public double Sender_TotalReceivedWaiting { get; set; }

      [DataMember(Order = 18)]
      public UserClass Senders { get; set; }
      [DataMember(Order = 19)]
      public UserClass Receivers { get; set; }

      [DataMember(Order = 20)]
      public int Order { get; set; }






      public TransferClass PopulateTransfer(string[] fieldNames, SqlDataReader reader)
      {
         var transfer = new TransferClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               transfer.Id = (int)reader["Id"];

         if (fieldNames.Contains("Date"))
            if (!Convert.IsDBNull(reader["Date"]))
               transfer.Date = reader["Date"].ToString();

         if (fieldNames.Contains("Sender_UserId"))
            if (!Convert.IsDBNull(reader["Sender_UserId"]))
               transfer.Sender_UserId = (int)reader["Sender_UserId"];

         if (fieldNames.Contains("Sender_Name"))
            if (!Convert.IsDBNull(reader["Sender_Name"]))
               transfer.Sender_Name = reader["Sender_Name"].ToString();

         if (fieldNames.Contains("Receiver_UserId"))
            if (!Convert.IsDBNull(reader["Receiver_UserId"]))
               transfer.Receiver_UserId = (int)reader["Receiver_UserId"];

         if (fieldNames.Contains("Receiver_Name"))
            if (!Convert.IsDBNull(reader["Receiver_Name"]))
               transfer.Receiver_Name = reader["Receiver_Name"].ToString();

         if (fieldNames.Contains("Amount"))
            if (!Convert.IsDBNull(reader["Amount"]))
               transfer.Amount = Convert.ToDouble(reader["Amount"]);

         if (fieldNames.Contains("Notes"))
            if (!Convert.IsDBNull(reader["Notes"]))
               transfer.Notes = reader["Notes"].ToString();

         if (fieldNames.Contains("TransferCode"))
            if (!Convert.IsDBNull(reader["TransferCode"]))
               transfer.TransferCode = reader["TransferCode"].ToString();

         if (fieldNames.Contains("TransferMethodId"))
            if (!Convert.IsDBNull(reader["TransferMethodId"]))
               transfer.TransferMethodId = (int)reader["TransferMethodId"];

         if (fieldNames.Contains("TransferMethod"))
            if (!Convert.IsDBNull(reader["TransferMethod"]))
               transfer.TransferMethod = reader["TransferMethod"].ToString();

         if (fieldNames.Contains("TransferStatusId"))
            if (!Convert.IsDBNull(reader["TransferStatusId"]))
               transfer.TransferStatusId = (int)reader["TransferStatusId"];

         if (fieldNames.Contains("TransferStatus"))
            if (!Convert.IsDBNull(reader["TransferStatus"]))
               transfer.TransferStatus = reader["TransferStatus"].ToString();

         if (fieldNames.Contains("MainBalance"))
            if (!Convert.IsDBNull(reader["MainBalance"]))
               transfer.MainBalance = Convert.ToDouble(reader["MainBalance"]);

         if (fieldNames.Contains("Sender_TotalSent"))
            if (!Convert.IsDBNull(reader["Sender_TotalSent"]))
               transfer.Sender_TotalSent = Convert.ToDouble(reader["Sender_TotalSent"]);

         if (fieldNames.Contains("Sender_TotalReceived"))
            if (!Convert.IsDBNull(reader["Sender_TotalReceived"]))
               transfer.Sender_TotalReceived = Convert.ToDouble(reader["Sender_TotalReceived"]);

         if (fieldNames.Contains("Sender_TotalReceivedWaiting"))
            if (!Convert.IsDBNull(reader["Sender_TotalReceivedWaiting"]))
               transfer.Sender_TotalReceivedWaiting = Convert.ToDouble(reader["Sender_TotalReceivedWaiting"]);

         transfer.Senders = new UserClass().PopulateUser(fieldNames, reader, "Senders_");

         transfer.Receivers = new UserClass().PopulateUser(fieldNames, reader, "Receivers_");

         return transfer;
      }
   }
}