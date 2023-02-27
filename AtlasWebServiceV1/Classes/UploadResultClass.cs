using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class UploadResultClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string URL { get; set; }
        [DataMember(Order = 3)]
        public string OriginalFilename { get; set; }
        [DataMember(Order = 4)]
        public bool IsUploaded { get; set; }

        [DataMember(Order = 5)]
        public List<string> WorkSheetList { get; set; }
    }
}