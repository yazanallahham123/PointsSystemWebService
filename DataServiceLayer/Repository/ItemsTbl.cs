//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataServiceLayer.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemsTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemsTbl()
        {
            this.BarcodesTbl = new HashSet<BarcodesTbl>();
            this.ItemBookingDaysTbl = new HashSet<ItemBookingDaysTbl>();
            this.ItemColorsSizesPricesTbl = new HashSet<ItemColorsSizesPricesTbl>();
            this.ItemColorsSizesTbl = new HashSet<ItemColorsSizesTbl>();
            this.ItemColorsTbl = new HashSet<ItemColorsTbl>();
            this.ItemImagesTbl = new HashSet<ItemImagesTbl>();
            this.ItemLikesTbl = new HashSet<ItemLikesTbl>();
            this.ItemMatchedItemsTbl = new HashSet<ItemMatchedItemsTbl>();
            this.ItemMatchedItemsTbl1 = new HashSet<ItemMatchedItemsTbl>();
            this.ItemPricesTbl = new HashSet<ItemPricesTbl>();
            this.ItemQuantitiesTbl = new HashSet<ItemQuantitiesTbl>();
            this.ItemRatingsTbl = new HashSet<ItemRatingsTbl>();
            this.ItemsCompaniesTbl = new HashSet<ItemsCompaniesTbl>();
            this.ItemsCountriesTbl = new HashSet<ItemsCountriesTbl>();
            this.ItemSerialsTbl = new HashSet<ItemSerialsTbl>();
            this.ItemSeriesTbl = new HashSet<ItemSeriesTbl>();
            this.ItemsGovernoratesTbl = new HashSet<ItemsGovernoratesTbl>();
            this.ItemSizesTbl = new HashSet<ItemSizesTbl>();
            this.ItemsUsersTypesTbl = new HashSet<ItemsUsersTypesTbl>();
            this.ItemTagsTbl = new HashSet<ItemTagsTbl>();
            this.ItemWishlistsTbl = new HashSet<ItemWishlistsTbl>();
            this.OceanMatjarItemsTbl = new HashSet<OceanMatjarItemsTbl>();
            this.OffersDetailRulesTbl = new HashSet<OffersDetailRulesTbl>();
            this.OffersDetailsTbl = new HashSet<OffersDetailsTbl>();
            this.OrderDetailsTbl = new HashSet<OrderDetailsTbl>();
            this.StyleDetailsItemsTbl = new HashSet<StyleDetailsItemsTbl>();
        }
    
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Code { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public int DefaultPriceTypeId { get; set; }
        public bool Disabled { get; set; }
        public string Notes { get; set; }
        public string ImageURL { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int CategoryId { get; set; }
        public Nullable<int> LoggedUser { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public Nullable<bool> IsWholeSale { get; set; }
        public string SizeImageURL { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public Nullable<int> ItemTypeId { get; set; }
        public Nullable<int> ItemDepartmentId { get; set; }
        public Nullable<bool> HasStartDateBooking { get; set; }
        public Nullable<System.DateTime> StartDateBooking { get; set; }
        public Nullable<bool> HasEndDateBooking { get; set; }
        public Nullable<System.DateTime> EndDateBooking { get; set; }
        public Nullable<bool> OnRequest { get; set; }
        public string OnRequestArabicMessage { get; set; }
        public string OnRequestEnglishMessage { get; set; }
        public Nullable<int> OnRequestDays { get; set; }
        public string ItemURL { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishTitle { get; set; }
        public Nullable<bool> ShowCarouselInItemsList { get; set; }
        public Nullable<bool> ShowDescriptionInItemsList { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BarcodesTbl> BarcodesTbl { get; set; }
        public virtual BrandsTbl BrandsTbl { get; set; }
        public virtual CategoriesTbl CategoriesTbl { get; set; }
        public virtual CountriesTbl CountriesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemBookingDaysTbl> ItemBookingDaysTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemColorsSizesPricesTbl> ItemColorsSizesPricesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemColorsSizesTbl> ItemColorsSizesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemColorsTbl> ItemColorsTbl { get; set; }
        public virtual ItemDepartmentsTbl ItemDepartmentsTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemImagesTbl> ItemImagesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemLikesTbl> ItemLikesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemMatchedItemsTbl> ItemMatchedItemsTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemMatchedItemsTbl> ItemMatchedItemsTbl1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemPricesTbl> ItemPricesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemQuantitiesTbl> ItemQuantitiesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemRatingsTbl> ItemRatingsTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemsCompaniesTbl> ItemsCompaniesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemsCountriesTbl> ItemsCountriesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemSerialsTbl> ItemSerialsTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemSeriesTbl> ItemSeriesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemsGovernoratesTbl> ItemsGovernoratesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemSizesTbl> ItemSizesTbl { get; set; }
        public virtual ItemTypesTbl ItemTypesTbl { get; set; }
        public virtual PriceTypesTbl PriceTypesTbl { get; set; }
        public virtual UsersTbl UsersTbl { get; set; }
        public virtual UsersTbl UsersTbl1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemsUsersTypesTbl> ItemsUsersTypesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemTagsTbl> ItemTagsTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemWishlistsTbl> ItemWishlistsTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OceanMatjarItemsTbl> OceanMatjarItemsTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OffersDetailRulesTbl> OffersDetailRulesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OffersDetailsTbl> OffersDetailsTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetailsTbl> OrderDetailsTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StyleDetailsItemsTbl> StyleDetailsItemsTbl { get; set; }
    }
}
