using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class UserNotificationClass
    {

        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public int LoggedUser { get; set; }

        [DataMember(Order = 2)]
        public int Type { get; set; }

        [DataMember(Order = 3)]
        public string FromDate { get; set; }

        [DataMember(Order = 4)]
        public string ToDate { get; set; }

        [DataMember(Order = 5)]
        public string Content { get; set; }

        [DataMember(Order = 6)]
        public string Title { get; set; }

    }
}