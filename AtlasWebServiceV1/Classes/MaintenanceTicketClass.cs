using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class MaintenanceTicketClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int UserId { get; set; }
        [DataMember(Order = 3)]
        public string CreatedDate { get; set; }
        [DataMember(Order = 4)]
        public int StatusId { get; set; }
        [DataMember(Order = 5)]
        public string Description { get; set; }
        [DataMember(Order = 6)]
        public string Notes { get; set; }
        [DataMember(Order = 7)]
        public string Address { get; set; }
        [DataMember(Order = 8)]
        public string ImageURL { get; set; }
        [DataMember(Order = 9)]
        public string StatusArabicName { get; set; }
        [DataMember(Order = 10)]
        public string StatusEnglishName { get; set; }
        [DataMember(Order = 11)]
        public int Order { get; set; }


        public MaintenanceTicketClass PopulateClass(string[] fieldNames, SqlDataReader reader)
        {
            var obj = new MaintenanceTicketClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    obj.Id = (int)reader["Id"];

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    obj.UserId = (int)reader["UserId"];

            if (fieldNames.Contains("CreatedDate"))
                if (!Convert.IsDBNull(reader["CreatedDate"]))
                    obj.CreatedDate = reader["CreatedDate"].ToString();

            if (fieldNames.Contains("StatusId"))
                if (!Convert.IsDBNull(reader["StatusId"]))
                    obj.StatusId = (int)reader["StatusId"];

            if (fieldNames.Contains("Description"))
                if (!Convert.IsDBNull(reader["Description"]))
                    obj.Description = reader["Description"].ToString();

            if (fieldNames.Contains("Notes"))
                if (!Convert.IsDBNull(reader["Notes"]))
                    obj.Notes = reader["Notes"].ToString();

            if (fieldNames.Contains("Address"))
                if (!Convert.IsDBNull(reader["Address"]))
                    obj.Address = reader["Address"].ToString();

            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    obj.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("StatusArabicName"))
                if (!Convert.IsDBNull(reader["StatusArabicName"]))
                    obj.StatusArabicName = reader["StatusArabicName"].ToString();

            if (fieldNames.Contains("StatusEnglishName"))
                if (!Convert.IsDBNull(reader["StatusEnglishName"]))
                    obj.StatusEnglishName = reader["StatusEnglishName"].ToString();

            return obj;
        }
    }
}