using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class GovernorateWithCitiesAndLocationsClass
    {
        [DataMember(Order = 1)]
        public GovernorateClass Governorate;
        [DataMember(Order = 2)]
        public List<CityClass> Cities;
        [DataMember(Order = 3)]
        public List<LocationClass> Locations;
    }
}