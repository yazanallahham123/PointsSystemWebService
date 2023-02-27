using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class UnknownSerialClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Serial{ get; set; }
        [DataMember(Order = 3)]
        public string Code { get; set; }
        [DataMember(Order = 4)]
        public string Date { get; set; }
        [DataMember(Order = 5)]
        public int UserId { get; set; }
        [DataMember(Order = 6)]
        public string FullName { get; set; }
        [DataMember(Order = 7)]
        public int StatusId { get; set; }
        [DataMember(Order = 8)]
        public string StatusArabicName { get; set; }
        [DataMember(Order = 9)]
        public string StatusEnglishName { get; set; }
        [DataMember(Order = 10)]
        public int Order { get; set; }

        public UnknownSerialClass PopulateUnknownSerial(string[] fieldNames, SqlDataReader reader)
        {
            var UnknownSerial = new UnknownSerialClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    UnknownSerial.Id = (int)reader["Id"];

            if (fieldNames.Contains("Serial"))
                if (!Convert.IsDBNull(reader["Serial"]))
                    UnknownSerial.Serial = reader["Serial"].ToString();

            if (fieldNames.Contains("Code"))
                if (!Convert.IsDBNull(reader["Code"]))
                    UnknownSerial.Code = reader["Code"].ToString();

            if (fieldNames.Contains("Date"))
                if (!Convert.IsDBNull(reader["Date"]))
                    UnknownSerial.Date = reader["Date"].ToString();

            if (fieldNames.Contains("StatusArabicName"))
                if (!Convert.IsDBNull(reader["StatusArabicName"]))
                    UnknownSerial.StatusArabicName = reader["StatusArabicName"].ToString();

            if (fieldNames.Contains("StatusEnglishName"))
                if (!Convert.IsDBNull(reader["StatusEnglishName"]))
                    UnknownSerial.StatusEnglishName = reader["StatusEnglishName"].ToString();

            if (fieldNames.Contains("FullName"))
                if (!Convert.IsDBNull(reader["FullName"]))
                    UnknownSerial.FullName = reader["FullName"].ToString();

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    UnknownSerial.UserId = (int)reader["UserId"];

            if (fieldNames.Contains("StatusId"))
                if (!Convert.IsDBNull(reader["StatusId"]))
                    UnknownSerial.StatusId = (int)reader["StatusId"];

            return UnknownSerial;
        }

        }
    }