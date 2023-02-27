using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class OfferDataClass
   {
      [DataMember(Order = 1)]
      public OfferClass OfferClass { get; set; }
      [DataMember(Order = 2)]
      public List<OffersGovernorateClass> Governorates { get; set; }
      [DataMember(Order = 3)]
      public List<OffersCompanyClass> Companies { get; set; }
      [DataMember(Order = 4)]
      public List<OffersUsersTypeClass> UsersTypes { get; set; }
      [DataMember(Order = 5)]
      public List<OffersCountryClass> Countries { get; set; }
    }
}