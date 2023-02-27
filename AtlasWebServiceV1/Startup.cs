using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PointsSystemWebService.Startup))]

namespace PointsSystemWebService
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

         //test
      }
   }
}
