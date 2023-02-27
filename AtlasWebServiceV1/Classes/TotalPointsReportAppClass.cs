using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class TotalPointsReportAppClass
    {
        [DataMember(Order = 1)]
        public List<TotalPointsReportClass> Senders { get; set; }
        [DataMember(Order = 2)]
        public List<TotalPointsReportClass> Receivers { get; set; }
        [DataMember(Order = 3)]
        public List<TotalPointsReportClass> Orders { get; set; }

    }
}