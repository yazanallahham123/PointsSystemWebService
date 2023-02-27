using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class PrestigakMainPageDataClass
    {
        [DataMember(Order = 1)]
        public List<ItemDepartmentDataClass> DepartmentsData { get; set; }
        [DataMember(Order = 2)]
        public List<StyleClass> Styles { get; set; }
        [DataMember(Order = 2)]
        public List<StyleDataClass> StylesData { get; set; }
        [DataMember(Order = 3)]
        public List<StoryClass> Stories { get; set; }
        [DataMember(Order = 4)]
        public List<BrandClass> Brands { get; set; }
    }
}