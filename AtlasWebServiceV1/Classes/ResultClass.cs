using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ResultClass<T>
   {
      [DataMember(Order = 1)]
      public int Code { get; set; }
      [DataMember(Order = 2)]
      public string Message { get; set; }
      [DataMember(Order = 3)]
      public T Result { get; set; }


      public ResultClass()
      {
         //Task.Delay(600).ContinueWith(x => FCMClass.CallDb_OnChange());
         //FCMClass.CallDb_OnChange();
      }

   }
}