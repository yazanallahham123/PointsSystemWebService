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
    
    public partial class back_itemcolorstbl
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ColorId { get; set; }
        public string ColorImageURL { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public string HexValue { get; set; }
        public Nullable<int> LoggedUser { get; set; }
        public Nullable<int> ItemImageIndex { get; set; }
        public Nullable<bool> Disabled { get; set; }
    }
}
