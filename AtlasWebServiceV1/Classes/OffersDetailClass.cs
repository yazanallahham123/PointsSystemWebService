using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class OffersDetailClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int OfferId { get; set; }
        [DataMember(Order = 3)]
        public int ItemId { get; set; }
        [DataMember(Order = 4)]
        public bool HasInitQuantity { get; set; }
        [DataMember(Order = 5)]
        public double InitQuantity { get; set; }
        [DataMember(Order = 7)]
        public bool Disabled { get; set; }
        [DataMember(Order = 8)]
        public string Notes { get; set; }
        [DataMember(Order = 9)]
        public double SoldQuantity { get; set; }
        [DataMember(Order = 10)]
        public double RemainingQuantity { get; set; }
        [DataMember(Order = 11)]
        public int CreatedBy { get; set; }
        [DataMember(Order = 12)]
        public int UpdateBy { get; set; }
        [DataMember(Order = 13)]
        public string CreateDate { get; set; }
        [DataMember(Order = 14)]
        public string UpdateDate { get; set; }

        [DataMember(Order = 15)]
        public string OfferArabicName { get; set; }
        [DataMember(Order = 16)]
        public string OfferEnglishName { get; set; }
        [DataMember(Order = 17)]
        public string ItemArabicName { get; set; }
        [DataMember(Order = 18)]
        public string ItemEnglishName { get; set; }
        [DataMember(Order = 19)]
        public string CreatedByUsername { get; set; }
        [DataMember(Order = 20)]
        public string CreatedByFullName { get; set; }
        [DataMember(Order = 21)]
        public string UpdateByUsername { get; set; }
        [DataMember(Order = 22)]
        public string UpdateByFullName { get; set; }
        [DataMember(Order = 23)]
        public double ReservedQuantity { get; set; }
        [DataMember(Order = 24)]
        public int Order { get; set; }

        [DataMember(Order = 26)]
        public bool HasPriceOffer { get; set; }

        [DataMember(Order = 28)]
        public int ItemColorId { get; set; }

        [DataMember(Order = 29)]
        public int ColorId { get; set; }

        [DataMember(Order = 30)]
        public string ColorArabicName { get; set; }

        [DataMember(Order = 31)]
        public string ColorEnglishName { get; set; }

        [DataMember(Order = 32)]
        public int ItemSizeId { get; set; }

        [DataMember(Order = 33)]
        public int SizeId { get; set; }


        [DataMember(Order = 34)]
        public string SizeArabicName { get; set; }

        [DataMember(Order = 35)]
        public string SizeEnglishName { get; set; }

        public OffersDetailClass PopulateOffersDetail(string[] fieldNames, SqlDataReader reader)
        {
            var offersDetail = new OffersDetailClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    offersDetail.Id = (int)reader["Id"];

            if (fieldNames.Contains("OfferId"))
                if (!Convert.IsDBNull(reader["OfferId"]))
                    offersDetail.OfferId = (int)reader["OfferId"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    offersDetail.ItemId = (int)reader["ItemId"];

            if (fieldNames.Contains("HasInitQuantity"))
                if (!Convert.IsDBNull(reader["HasInitQuantity"]))
                    offersDetail.HasInitQuantity = (bool)reader["HasInitQuantity"];

            if (fieldNames.Contains("InitQuantity"))
                if (!Convert.IsDBNull(reader["InitQuantity"]))
                    offersDetail.InitQuantity = (double)reader["InitQuantity"];

            if (fieldNames.Contains("Disabled"))
                if (!Convert.IsDBNull(reader["Disabled"]))
                    offersDetail.Disabled = (bool)reader["Disabled"];

            if (fieldNames.Contains("Notes"))
                if (!Convert.IsDBNull(reader["Notes"]))
                    offersDetail.Notes = reader["Notes"].ToString();

            if (fieldNames.Contains("SoldQuantity"))
                if (!Convert.IsDBNull(reader["SoldQuantity"]))
                    offersDetail.SoldQuantity = (double)reader["SoldQuantity"];

            if (fieldNames.Contains("RemainingQuantity"))
                if (!Convert.IsDBNull(reader["RemainingQuantity"]))
                    offersDetail.RemainingQuantity = (double)reader["RemainingQuantity"];

            if (fieldNames.Contains("ReservedQuantity"))
                if (!Convert.IsDBNull(reader["ReservedQuantity"]))
                    offersDetail.ReservedQuantity = (double)reader["ReservedQuantity"];

            if (fieldNames.Contains("CreatedBy"))
                if (!Convert.IsDBNull(reader["CreatedBy"]))
                    offersDetail.CreatedBy = (int)reader["CreatedBy"];

            if (fieldNames.Contains("UpdateBy"))
                if (!Convert.IsDBNull(reader["UpdateBy"]))
                    offersDetail.UpdateBy = (int)reader["UpdateBy"];

            if (fieldNames.Contains("CreateDate"))
                if (!Convert.IsDBNull(reader["CreateDate"]))
                    offersDetail.CreateDate = reader["CreateDate"].ToString();

            if (fieldNames.Contains("UpdateDate"))
                if (!Convert.IsDBNull(reader["UpdateDate"]))
                    offersDetail.UpdateDate = reader["UpdateDate"].ToString();

            if (fieldNames.Contains("OfferArabicName"))
                if (!Convert.IsDBNull(reader["OfferArabicName"]))
                    offersDetail.OfferArabicName = reader["OfferArabicName"].ToString();

            if (fieldNames.Contains("OfferEnglishName"))
                if (!Convert.IsDBNull(reader["OfferEnglishName"]))
                    offersDetail.OfferEnglishName = reader["OfferEnglishName"].ToString();

            if (fieldNames.Contains("ItemArabicName"))
                if (!Convert.IsDBNull(reader["ItemArabicName"]))
                    offersDetail.ItemArabicName = reader["ItemArabicName"].ToString();

            if (fieldNames.Contains("ItemEnglishName"))
                if (!Convert.IsDBNull(reader["ItemEnglishName"]))
                    offersDetail.ItemEnglishName = reader["ItemEnglishName"].ToString();

            if (fieldNames.Contains("CreatedByUsername"))
                if (!Convert.IsDBNull(reader["CreatedByUsername"]))
                    offersDetail.CreatedByUsername = reader["CreatedByUsername"].ToString();

            if (fieldNames.Contains("CreatedByFullName"))
                if (!Convert.IsDBNull(reader["CreatedByFullName"]))
                    offersDetail.CreatedByFullName = reader["CreatedByFullName"].ToString();

            if (fieldNames.Contains("UpdateByUsername"))
                if (!Convert.IsDBNull(reader["UpdateByUsername"]))
                    offersDetail.UpdateByUsername = reader["UpdateByUsername"].ToString();

            if (fieldNames.Contains("UpdateByFullName"))
                if (!Convert.IsDBNull(reader["UpdateByFullName"]))
                    offersDetail.UpdateByFullName = reader["UpdateByFullName"].ToString();

            if (fieldNames.Contains("HasPriceOffer"))
                if (!Convert.IsDBNull(reader["HasPriceOffer"]))
                    offersDetail.HasPriceOffer = Convert.ToBoolean(reader["HasPriceOffer"]);

            if (fieldNames.Contains("ItemColorId"))
                if (!Convert.IsDBNull(reader["ItemColorId"]))
                    offersDetail.ItemColorId = (int)reader["ItemColorId"];

            if (fieldNames.Contains("ColorId"))
                if (!Convert.IsDBNull(reader["ColorId"]))
                    offersDetail.ColorId = (int)reader["ColorId"];

            if (fieldNames.Contains("ColorArabicName"))
                if (!Convert.IsDBNull(reader["ColorArabicName"]))
                    offersDetail.ColorArabicName = reader["ColorArabicName"].ToString();

            if (fieldNames.Contains("ColorEnglishName"))
                if (!Convert.IsDBNull(reader["ColorEnglishName"]))
                    offersDetail.ColorEnglishName = reader["ColorEnglishName"].ToString();

            if (fieldNames.Contains("ItemSizeId"))
                if (!Convert.IsDBNull(reader["ItemSizeId"]))
                    offersDetail.ItemSizeId = (int)reader["ItemSizeId"];

            if (fieldNames.Contains("SizeId"))
                if (!Convert.IsDBNull(reader["SizeId"]))
                    offersDetail.SizeId = (int)reader["SizeId"];

            if (fieldNames.Contains("SizeArabicName"))
                if (!Convert.IsDBNull(reader["SizeArabicName"]))
                    offersDetail.SizeArabicName = reader["SizeArabicName"].ToString();

            if (fieldNames.Contains("SizeEnglishName"))
                if (!Convert.IsDBNull(reader["SizeEnglishName"]))
                    offersDetail.SizeEnglishName = reader["SizeEnglishName"].ToString();

            return offersDetail;
        }
    }
}