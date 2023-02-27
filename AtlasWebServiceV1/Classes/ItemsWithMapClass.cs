using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ItemsWithMapClass
   {
      [DataMember(Order = 1)]
      public List<ItemClass> Items { get; set; }
      [DataMember(Order = 2)]
      public CategoriesWithMapClass CategoriesMap { get; set; }
   }
}