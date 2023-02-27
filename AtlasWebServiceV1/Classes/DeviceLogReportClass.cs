using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class DeviceLogReportClass
    {
        [DataMember(Order = 1)]
        public List<DeviceLogClass> DeviceLogList { get; set; }
        [DataMember(Order = 2)]
        public int TotalInstalls { get; set; }
        [DataMember(Order = 3)]
        public int TotalAndroidInstalls { get; set; }
        [DataMember(Order = 4)]
        public int TotalIosInstalls { get; set; }
    }
}