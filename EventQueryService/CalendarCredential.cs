using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;

namespace EventQueryService
{
    public class CalendarCredential
    {
        private static string[] Scopes = { CalendarService.Scope.CalendarReadonly };

        public UserCredential GetCredential()
        {
            UserCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            return credential;
        }

    }
}
