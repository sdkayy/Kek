using System.Text.RegularExpressions;

namespace Kek.Utils
{
    class CSRF
    {

        public CSRF() { }

        public string returnCSRFToken(string url)
        {
            string source = new System.Net.WebClient().DownloadString("https://www.instagram.com/accounts/edit/?wo=1");
            string pattern = "\"csrf_token\": \"(.*)\"";

            string CSRF = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                CSRF = item.Groups[1].Value.Split('"')[0];
            }
            return CSRF;
        }
    }
}
