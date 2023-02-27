using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class TagsTypeClass
    {
        public TagTypeClass TagType { get; set; }

        public List<TagClass> Tags { get; set; }
    }
}