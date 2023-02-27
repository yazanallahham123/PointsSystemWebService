using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class GovernorateWithCitiesClass
    {
        [DataMember(Order = 1)]
        public GovernorateClass Governorate;
        [DataMember(Order = 2)]
        public List<CityClass> Cities;
    }
}