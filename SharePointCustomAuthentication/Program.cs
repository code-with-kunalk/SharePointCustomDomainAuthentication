using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointCustomAuthentication
{
    class Program
    {
        static void Main(string[] args)
        {
            string hostUrl = "";
            string username = "";
            string password = "";

        }

        private static void Authenticate(string hostUrl, string username, string password)
        {
            var authenticationHelper = new AuthenticationHelper();
            var cookieContainer = authenticationHelper.GetFedAuthCookieViaScreenScrape(username, password, hostUrl, IsBposMigration(hostUrl));
        }

        private static bool IsBposMigration(string hostUrl)
        {
            hostUrl = hostUrl.ToLowerInvariant();
            if (hostUrl.Contains("sharepoint.microsoftonline.com") ||
                hostUrl.Contains("noam.microsoftonline.com") ||
                hostUrl.Contains("emea.microsoftonline.com") ||
                hostUrl.Contains("apac.microsoftonline.com"))
                return true;
            return false;
        }
    }
}
