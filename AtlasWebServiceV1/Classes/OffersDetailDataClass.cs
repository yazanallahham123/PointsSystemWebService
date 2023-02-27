using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   public class OffersDetailDataClass
   {
      [DataMember(Order = 1)]
      public OffersDetailClass OffersDetail { get; set; }

      [DataMember(Order = 2)]
      public List<OfferDetailPriceClass> Prices{ get; set; }
   }

}