using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class FirebaseDeliveryUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmployeeCode { get; set; }
        public string Username { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string ResidenceType { get; set; }
        public string ImageURL { get; set; }

    }
}