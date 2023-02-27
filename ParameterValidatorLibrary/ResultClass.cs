using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace ParameterValidatorLibrary
{

   public class ResultClass<T>
   {

      public int Code { get; set; }

      public string Message { get; set; }

      public T Result { get; set; }


      public ResultClass()
      {
         //Task.Delay(600).ContinueWith(x => FCMClass.CallDb_OnChange());
         
      }

   }
}