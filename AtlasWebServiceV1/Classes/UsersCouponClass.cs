using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class UsersCouponClass
    {

        [DataMember(Order = 2)]
        public CouponClass Coupon { get; set; }
        [DataMember(Order = 3)]
        public List<UserClass_Short> UsersCoupon { get; set; }

    }
}