using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class CategoryTreeClass<T>
   {
      [DataMember(Order = 1)]
      public int id { get; set; }
      [DataMember(Order = 2)]
      public string text { get; set; }
        [DataMember(Order = 3)]
        public string type { get; set; }
        [DataMember(Order = 4)]
      public IEnumerable<CategoryTreeClass<T>> children { get; set; }
   }
}