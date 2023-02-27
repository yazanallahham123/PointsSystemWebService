using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ComplaintClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public bool IsComment { get; set; }

        [DataMember(Order = 3)]
        public int ParentId { get; set; }



        [DataMember(Order = 5)]
        public int UserId { get; set; }
        [DataMember(Order = 6)]
        public string UserFullName { get; set; }
        [DataMember(Order = 7)]
        public string UserMobileNumber { get; set; }


        [DataMember(Order = 8)]
        public int ComplaintTypeId { get; set; }
        [DataMember(Order = 9)]
        public string ComplaintTypeArabicName { get; set; }
        [DataMember(Order = 10)]
        public string ComplaintTypeEnglishName { get; set; }

        [DataMember(Order = 11)]
        public int ComplaintStatusId { get; set; }
        [DataMember(Order = 12)]
        public string ComplaintStatusArabicName { get; set; }
        [DataMember(Order = 13)]
        public string ComplaintStatusEnglishName { get; set; }

        [DataMember(Order = 14)]
        public int ReferenceId { get; set; }

        [DataMember(Order = 15)]
        public string Description { get; set; }

        [DataMember(Order = 16)]
        public string ImageURL { get; set; }
        [DataMember(Order = 17)]
        public string Date { get; set; }
        [DataMember(Order = 18)]
        public string ClosingDate { get; set; }
        [DataMember(Order = 19)]
        public string ItemArabicName { get; set; }
        [DataMember(Order = 20)]
        public string ItemEnglishName { get; set; }
        [DataMember(Order = 21)]
        public string ItemImageURL { get; set; }
        [DataMember(Order = 22)]
        public string OrderInitDate { get; set; }
        [DataMember(Order = 23)]
        public int Order { get; set; }

        public ComplaintClass PopulateComplaint(string[] fieldNames, SqlDataReader reader)
        {
            var complaint = new ComplaintClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    complaint.Id = (int)reader["Id"];

            if (fieldNames.Contains("IsComment"))
                if (!Convert.IsDBNull(reader["IsComment"]))
                    complaint.IsComment = (bool)reader["IsComment"];

            if (fieldNames.Contains("ParentId"))
                if (!Convert.IsDBNull(reader["ParentId"]))
                    complaint.ParentId = (int)reader["ParentId"];


            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    complaint.UserId = (int)reader["UserId"];

            if (fieldNames.Contains("ComplaintTypeId"))
                if (!Convert.IsDBNull(reader["ComplaintTypeId"]))
                    complaint.ComplaintTypeId = (int)reader["ComplaintTypeId"];

            if (fieldNames.Contains("ComplaintStatusId"))
                if (!Convert.IsDBNull(reader["ComplaintStatusId"]))
                    complaint.ComplaintStatusId = (int)reader["ComplaintStatusId"];

            if (fieldNames.Contains("ReferenceId"))
                if (!Convert.IsDBNull(reader["ReferenceId"]))
                    complaint.ReferenceId = (int)reader["ReferenceId"];

            if (fieldNames.Contains("Description"))
                if (!Convert.IsDBNull(reader["Description"]))
                    complaint.Description = reader["Description"].ToString();

            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    complaint.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("Date"))
                if (!Convert.IsDBNull(reader["Date"]))
                    complaint.Date = reader["Date"].ToString();

            if (fieldNames.Contains("ClosingDate"))
                if (!Convert.IsDBNull(reader["ClosingDate"]))
                    complaint.ClosingDate = reader["ClosingDate"].ToString();

            if (fieldNames.Contains("ItemArabicName"))
                if (!Convert.IsDBNull(reader["ItemArabicName"]))
                    complaint.ItemArabicName = reader["ItemArabicName"].ToString();

            if (fieldNames.Contains("ItemEnglishName"))
                if (!Convert.IsDBNull(reader["ItemEnglishName"]))
                    complaint.ItemEnglishName = reader["ItemEnglishName"].ToString();

            if (fieldNames.Contains("ItemImageURL"))
                if (!Convert.IsDBNull(reader["ItemImageURL"]))
                    complaint.ItemImageURL = reader["ItemImageURL"].ToString();

            if (fieldNames.Contains("OrderInitDate"))
                if (!Convert.IsDBNull(reader["OrderInitDate"]))
                    complaint.OrderInitDate = reader["OrderInitDate"].ToString();
            if (fieldNames.Contains("UserFullName"))
                if (!Convert.IsDBNull(reader["UserFullName"]))
                    complaint.UserFullName = reader["UserFullName"].ToString();
            if (fieldNames.Contains("UserMobileNumber"))
                if (!Convert.IsDBNull(reader["UserMobileNumber"]))
                    complaint.UserMobileNumber = reader["UserMobileNumber"].ToString();
            if (fieldNames.Contains("ComplaintTypeArabicName"))
                if (!Convert.IsDBNull(reader["ComplaintTypeArabicName"]))
                    complaint.ComplaintTypeArabicName = reader["ComplaintTypeArabicName"].ToString();
            if (fieldNames.Contains("ComplaintTypeEnglishName"))
                if (!Convert.IsDBNull(reader["ComplaintTypeEnglishName"]))
                    complaint.ComplaintTypeEnglishName = reader["ComplaintTypeEnglishName"].ToString();
            if (fieldNames.Contains("ComplaintStatusArabicName"))
                if (!Convert.IsDBNull(reader["ComplaintStatusArabicName"]))
                    complaint.ComplaintStatusArabicName = reader["ComplaintStatusArabicName"].ToString();
            if (fieldNames.Contains("ComplaintStatusEnglishName"))
                if (!Convert.IsDBNull(reader["ComplaintStatusEnglishName"]))
                    complaint.ComplaintStatusEnglishName = reader["ComplaintStatusEnglishName"].ToString();

            return complaint;
        }
    }
    public class ComplaintDataClass
    {
        [DataMember(Order = 1)]
        public ComplaintClass Complaint { get; set; }
        [DataMember(Order = 2)]
        public List<ComplaintClass> Comments { get; set; }
    }
}