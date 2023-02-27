using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class DeviceLogClass
    {

        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public int UserId { get; set; }

        [DataMember(Order = 3)]
        public string FullName { get; set; }

        [DataMember(Order = 4)]
        public string Username { get; set; }

        [DataMember(Order = 5)]
        public string Model { get; set; }

        [DataMember(Order = 6)]
        public string Platform { get; set; }

        [DataMember(Order = 7)]
        public string Version { get; set; }

        [DataMember(Order = 8)]
        public string UUID { get; set; }

        [DataMember(Order = 9)]
        public string Manufacture { get; set; }

        [DataMember(Order = 10)]
        public string Date { get; set; }

        [DataMember(Order = 11)]
        public int Lunchcount { get; set; }

        [DataMember(Order = 12)]
        public string MobileNo { get; set; }

        [DataMember(Order = 13)]
        public UserClass DeviceUser { get; set; }

        [DataMember(Order = 14)]
        public int Order { get; set; }
    }
}