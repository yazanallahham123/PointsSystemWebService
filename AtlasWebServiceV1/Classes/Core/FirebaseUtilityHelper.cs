using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PointsSystemWebService.Classes.Core
{
    public class FirebaseUtilityHelper
    {
        private static void InitFirebaseApp()
        {

            string serverPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            string googleCredentialPath = Config.GoogleCredentialPath;//serverPath + "Resources\\machlah-d3fa808df0bd.json";
            Errors.LogError(0, googleCredentialPath, googleCredentialPath, "1.0.3", "API", "InitFirebaseApp", "", "");
            try
            {
                if (FirebaseApp.DefaultInstance == null)
                {
                    FirebaseApp.Create(new AppOptions()
                    {
                        //Credential = GoogleCredential.GetApplicationDefault(),

                        Credential = GoogleCredential.FromStream(File.OpenRead(googleCredentialPath)),

                        //Credential = GoogleCredential.GetApplicationDefault(),
                        //ServiceAccountId = "firebase-adminsdk-scu7r@matjar-5ee46.iam.gserviceaccount.com",
                    });
                }
            }
            catch (Exception e)
            {
                Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "InitFirebaseApp", e.Source, "");
                Errors.LogError(0, e.InnerException.Message, e.StackTrace, "1.0.3", "API", "InitFirebaseApp1", e.Source, "");
                Errors.LogError(0, e.InnerException.InnerException.Message, e.StackTrace, "1.0.3", "API", "InitFirebaseApp2", e.Source, "");
            }


        }

        public static async Task<string> GenerateFirebaseTokenAsync(string uid, Dictionary<string, object> additionalClaims)
        {
            try { InitFirebaseApp(); }
            catch (Exception e)
            {
                Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "InitFirebaseApp", e.Source, "");
                Errors.LogError(0, e.InnerException.Message, e.StackTrace, "1.0.3", "API", "InitFirebaseApp1", e.Source, "");
            }

            string customToken = string.Empty;

            try
            {
                customToken = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(uid, additionalClaims);
            }
            catch (Exception e)
            {
                Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "CreateCustomTokenAsync", e.Source, "");
                Errors.LogError(0, e.InnerException.Message, e.StackTrace, "1.0.3", "API", "CreateCustomTokenAsync", e.Source, "");

            }
            // Send token back to client

            //Console.WriteLine(customToken);

            return customToken;
        }

    }
}