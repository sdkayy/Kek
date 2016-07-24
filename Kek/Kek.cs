using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kek
{
    public class Kek
    {
        /// <summary>
        /// IGSessionIDs are what are used to complete tasks on IG.
        /// </summary>
        internal string IGSessionIDLogin, IGSessionIDRegister;
        /// <summary>
        /// Set to true to see the output as it goes.
        /// </summary>
        internal bool debug;
        /// <summary>
        /// ID of currently logged on user.
        /// </summary>
        internal string LoggedOnID;
        /// <summary>
        /// Set to true upon logging into the constructor
        /// </summary>
        internal bool verified;
        /// <summary>
        /// Kek Constructor
        /// </summary>
        /// <param name="user">Username of person using our library</param>
        /// <param name="pin">Passwrod of person using our library</param>
        /// <param name="_debug">Set to true for debug output</param>
        public Kek(string user, string pin, bool _debug)
        {
            debug = _debug;
            verified = Verify(user, pin);
            //TODO: Constructor
        }

        #region Random UserAgents
        /// <summary>
        /// List of 111 random useragents!
        /// </summary>
        public string[] UAs =
        {
            "Mozilla/5.0 (Macintosh; U; PPC Mac OS X; fi-fi) AppleWebKit/420+ (KHTML, like Gecko) Safari/419.3",
            "Mozilla/5.0 (Macintosh; U; PPC Mac OS X; de-de) AppleWebKit/125.2 (KHTML, like Gecko) Safari/125.7",
            "Mozilla/5.0 (Macintosh; U; PPC Mac OS X; en-us) AppleWebKit/312.8 (KHTML, like Gecko) Safari/312.6",
            "Mozilla/5.0 (Windows; U; Windows NT 5.1; cs-CZ) AppleWebKit/523.15 (KHTML, like Gecko) Version/3.0 Safari/523.15",
            "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US) AppleWebKit/528.16 (KHTML, like Gecko) Version/4.0 Safari/528.16",
            "Mozilla/5.0 (Macintosh; U; PPC Mac OS X 10_5_6; it-it) AppleWebKit/528.16 (KHTML, like Gecko) Version/4.0 Safari/528.16",
            "Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-HK) AppleWebKit/533.18.1 (KHTML, like Gecko) Version/5.0.2 Safari/533.18.5",
            "Mozilla/5.0 (Windows; U; Windows NT 6.1; sv-SE) AppleWebKit/533.19.4 (KHTML, like Gecko) Version/5.0.3 Safari/533.19.4",
            "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/533.20.25 (KHTML, like Gecko) Version/5.0.4 Safari/533.20.27",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_3) AppleWebKit/534.55.3 (KHTML, like Gecko) Version/5.1.3 Safari/534.53.10",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_8_2) AppleWebKit/536.26.17 (KHTML, like Gecko) Version/6.0.2 Safari/536.26.17",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_8_5) AppleWebKit/537.75.14 (KHTML, like Gecko) Version/6.1.3 Safari/537.75.14",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_0) AppleWebKit/600.3.10 (KHTML, like Gecko) Version/8.0.3 Safari/600.3.10",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11) AppleWebKit/601.1.39 (KHTML, like Gecko) Version/9.0 Safari/601.1.39",
            "Mozilla/5.0 (Linux; U; Android 1.5; de-de; HTC Magic Build/CRB17) AppleWebKit/528.5+ (KHTML, like Gecko) Version/3.1.2 Mobile Safari/525.20.1",
            "Mozilla/5.0 (Linux; U; Android 2.1-update1; en-au; HTC_Desire_A8183 V1.16.841.1 Build/ERE27) AppleWebKit/530.17 (KHTML, like Gecko) Version/4.0 Mobile Safari/530.17",
            "Mozilla/5.0 (Linux; U; Android 4.2; en-us; Nexus 10 Build/JVP15I) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Safari/534.30",
            "Mozilla/5.0 (Linux; U; Android-4.0.3; en-us; Galaxy Nexus Build/IML74K) AppleWebKit/535.7 (KHTML, like Gecko) CrMo/16.0.912.75 Mobile Safari/535.7",
            "Mozilla/5.0 (Linux; U; Android-4.0.3; en-us; Xoom Build/IML77) AppleWebKit/535.7 (KHTML, like Gecko) CrMo/16.0.912.75 Safari/535.7",
            "Mozilla/5.0 (Linux; Android 4.0.4; SGH-I777 Build/Task650 & Ktoonsez AOKP) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.166 Mobile Safari/535.19",
            "Mozilla/5.0 (Linux; Android 4.1; Galaxy Nexus Build/JRN84D) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.166 Mobile Safari/535.19",
            "Mozilla/5.0 (iPhone; U; CPU iPhone OS 5_1_1 like Mac OS X; en) AppleWebKit/534.46.0 (KHTML, like Gecko) CriOS/19.0.1084.60 Mobile/9B206 Safari/7534.48.3",
            "Mozilla/5.0 (iPad; U; CPU OS 5_1_1 like Mac OS X; en-us) AppleWebKit/534.46.0 (KHTML, like Gecko) CriOS/19.0.1084.60 Mobile/9B206 Safari/7534.48.3",
            "Mozilla/5.0 (X11; U; Linux x86_64; en-US) AppleWebKit/534.10 (KHTML, like Gecko) Ubuntu/10.10 Chromium/8.0.552.237 Chrome/8.0.552.237 Safari/534.10",
            "Mozilla/5.0 (X11; Linux i686) AppleWebKit/535.7 (KHTML, like Gecko) Ubuntu/11.10 Chromium/16.0.912.21 Chrome/16.0.912.21 Safari/535.7",
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/535.2 (KHTML, like Gecko) Ubuntu/11.04 Chromium/15.0.871.0 Chrome/15.0.871.0 Safari/535.2",
            "Mozilla/5.0 (X11; Linux i686) AppleWebKit/535.1 (KHTML, like Gecko) Ubuntu/10.04 Chromium/14.0.813.0 Chrome/14.0.813.0 Safari/535.1",
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/534.30 (KHTML, like Gecko) Ubuntu/10.10 Chromium/12.0.742.112 Chrome/12.0.742.112 Safari/534.30",
            "Mozilla/5.0 (X11; U; Linux x86_64; en-US) AppleWebKit/534.10 (KHTML, like Gecko) Ubuntu/10.10 Chromium/8.0.552.237 Chrome/8.0.552.237 Safari/534.10",
            "Mozilla/5.0 (Windows; U; Windows NT 5.0; it-IT; rv:1.7.12) Gecko/20050915",
            "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.0.1) Gecko/20020919",
            "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1b2pre) Gecko/20081015 Fennec/1.0a1",
            "Mozilla/5.0 (X11; U; Linux armv7l; en-US; rv:1.9.2a1pre) Gecko/20090322 Fennec/1.0b2pre",
            "Mozilla/5.0 (Android; Linux armv7l; rv:9.0) Gecko/20111216 Firefox/9.0 Fennec/9.0",
            "Mozilla/5.0 (Android; Mobile; rv:12.0) Gecko/12.0 Firefox/12.0",
            "Mozilla/5.0 (Android; Mobile; rv:14.0) Gecko/14.0 Firefox/14.0",
            "Mozilla/5.0 (Mobile; rv:14.0) Gecko/14.0 Firefox/14.0",
            "Mozilla/5.0 (Mobile; rv:17.0) Gecko/17.0 Firefox/17.0",
            "Mozilla/5.0 (Tablet; rv:18.1) Gecko/18.1 Firefox/18.1",
            "Mozilla/5.0 (Android; Mobile; rv:28.0) Gecko/28.0 Firefox/28.0",
            "Mozilla/5.0 (Android; Tablet; rv:29.0) Gecko/29.0 Firefox/29.0",
            "Mozilla/5.0 (Android; Mobile; rv:40.0) Gecko/40.0 Firefox/40.0",
            "Mozilla/5.0 (iPad; CPU iPhone OS 8_3 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) FxiOS/1.0 Mobile/12F69 Safari/600.1.4",
            "Mozilla/5.0 (Windows; U; Win98; en-US; rv:1.5) Gecko/20031007 Firebird/0.7",
            "Mozilla/5.0 (Windows; U; Win95; en-US; rv:1.5) Gecko/20031007 Firebird/0.7",
            "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10.5; en-US; rv:1.9.1b3) Gecko/20090305 Firefox/3.1b3 GTB5",
            "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10.5; ko; rv:1.9.1b2) Gecko/20081201 Firefox/3.1b2",
            "Mozilla/5.0 (X11; U; SunOS sun4u; en-US; rv:1.9b5) Gecko/2008032620 Firefox/3.0b5",
            "Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.8.1.12) Gecko/20080214 Firefox/2.0.0.12",
            "Mozilla/5.0 (Windows; U; Windows NT 5.1; cs; rv:1.9.0.8) Gecko/2009032609 Firefox/3.0.8",
            "Mozilla/5.0 (X11; U; OpenBSD i386; en-US; rv:1.8.0.5) Gecko/20060819 Firefox/1.5.0.5",
            "Mozilla/5.0 (Windows; U; Windows NT 5.0; es-ES; rv:1.8.0.3) Gecko/20060426 Firefox/1.5.0.3",
            "Mozilla/5.0 (Windows; U; WinNT4.0; en-US; rv:1.7.9) Gecko/20050711 Firefox/1.0.5",
            "Mozilla/5.0 (Windows; Windows NT 6.1; rv:2.0b2) Gecko/20100720 Firefox/4.0b2",
            "Mozilla/5.0 (X11; Linux x86_64; rv:2.0b4) Gecko/20100818 Firefox/4.0b4",
            "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.2) Gecko/20100308 Ubuntu/10.04 (lucid) Firefox/3.6 GTB7.1",
            "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:2.0b7) Gecko/20101111 Firefox/4.0b7",
            "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:2.0b8pre) Gecko/20101114 Firefox/4.0b8pre",
            "Mozilla/5.0 (X11; Linux x86_64; rv:2.0b9pre) Gecko/20110111 Firefox/4.0b9pre",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:2.0b9pre) Gecko/20101228 Firefox/4.0b9pre",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:2.2a1pre) Gecko/20110324 Firefox/4.2a1pre",
            "Mozilla/5.0 (X11; U; Linux amd64; rv:5.0) Gecko/20100101 Firefox/5.0 (Debian)",
            "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:6.0a2) Gecko/20110613 Firefox/6.0a2",
            "Mozilla/5.0 (X11; Linux i686 on x86_64; rv:12.0) Gecko/20100101 Firefox/12.0",
            "Mozilla/5.0 (Windows NT 6.1; rv:15.0) Gecko/20120716 Firefox/15.0a2",
            "Mozilla/5.0 (X11; Ubuntu; Linux armv7l; rv:17.0) Gecko/20100101 Firefox/17.0",
            "Mozilla/5.0 (Windows NT 6.1; rv:21.0) Gecko/20130328 Firefox/21.0",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:22.0) Gecko/20130328 Firefox/22.0",
            "Mozilla/5.0 (Windows NT 5.1; rv:25.0) Gecko/20100101 Firefox/25.0",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.8; rv:25.0) Gecko/20100101 Firefox/25.0",
            "Mozilla/5.0 (Windows NT 6.1; rv:28.0) Gecko/20100101 Firefox/28.0",
            "Mozilla/5.0 (X11; Linux i686; rv:30.0) Gecko/20100101 Firefox/30.0",
            "Mozilla/5.0 (Windows NT 5.1; rv:31.0) Gecko/20100101 Firefox/31.0",
            "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0",
            "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:40.0) Gecko/20100101 Firefox/40.0",
            "Mozilla/5.0 (BeOS; U; Haiku BePC; en-US; rv:1.8.1.21pre) Gecko/20090227 BonEcho/2.0.0.21pre",
            "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1.9) Gecko/20071113 BonEcho/2.0.0.9",
            "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1) Gecko/20061026 BonEcho/2.0",
            "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.0.8) Gecko/2009033017 GranParadiso/3.0.8",
            "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10.6; en-US; rv:1.9.2) Gecko/20100411 Lorentz/3.6.3 GTB7.0",
            "Mozilla/5.0 (X11; U; Linux i686; it; rv:1.9.3a1pre) Gecko/20091019 Minefield/3.7a1pre",
            "Mozilla/5.0 (Windows; U; Windows NT 5.0; en-US; rv:1.9.3a4pre) Gecko/20100402 Minefield/3.7a4pre",
            "Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.9.2a2pre) Gecko/20090901 Ubuntu/9.10 (karmic) Namoroka/3.6a2pre",
            "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2a1) Gecko/20090806 Namoroka/3.6a1",
            "Mozilla/5.0 (Windows; U; Windows NT 6.1; cs; rv:1.9.2a2pre) Gecko/20090912 Namoroka/3.6a2pre (.NET CLR 3.5.30729)",
            "Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.9.1b3pre) Gecko/20090109 Shiretoko/3.1b3pre",
            "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1b4pre) Gecko/20090311 Shiretoko/3.1b4pre",
            "Opera/5.11 (Windows 98; U) [en]",
            "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98) Opera 5.12 [en]",
            "Opera/6.0 (Windows 2000; U) [fr]",
            "Mozilla/4.0 (compatible; MSIE 5.0; Windows NT 4.0) Opera 6.01 [en]",
            "Opera/7.03 (Windows NT 5.0; U) [en]",
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1) Opera 7.10 [en]",
            "Opera/9.02 (Windows XP; U; ru)",
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; en) Opera 9.24",
            "Opera/9.51 (Macintosh; Intel Mac OS X; U; en)",
            "Opera/9.70 (Linux i686 ; U; en) Presto/2.2.1",
            "Opera/9.80 (Windows NT 5.1; U; cs) Presto/2.2.15 Version/10.00",
            "Opera/9.80 (Windows NT 6.1; U; sv) Presto/2.7.62 Version/11.01",
            "Opera/9.80 (Windows NT 6.1; U; en-GB) Presto/2.7.62 Version/11.00",
            "Opera/9.80 (Windows NT 6.1; U; zh-tw) Presto/2.7.62 Version/11.01",
            "Opera/9.80 (Windows NT 6.0; U; en) Presto/2.8.99 Version/11.10",
            "Opera/9.80 (X11; Linux i686; U; ru) Presto/2.8.131 Version/11.11",
            "Opera/9.80 (Windows NT 5.1) Presto/2.12.388 Version/12.14",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.12 Safari/537.36 OPR/14.0.1116.4",
            "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/28.0.1500.29 Safari/537.36 OPR/15.0.1147.24 (Edition Next)",
            "Opera/9.80 (Linux armv6l ; U; CE-HTML/1.0 NETTV/3.0.1;; en) Presto/2.6.33 Version/10.60",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36 OPR/20.0.1387.91",
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Oupeng/10.2.1.86910 Safari/534.30",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36 OPR/26.0.1656.60",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2376.0 Safari/537.36 OPR/31.0.1857.0",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.85 Safari/537.36 OPR/32.0.1948.25"

        };
        #endregion

        /// <summary>
        /// Report types
        /// </summary>
        public enum ReportType
        {
            /// <summary>
            /// Spam Post
            /// </summary>
            Spam = 1,
            /// <summary>
            /// Self-Harm
            /// </summary>
            Harm = 2,
            /// <summary>
            /// Drug use
            /// </summary>
            Drugs = 3,
            /// <summary>
            /// Nudity or Porn
            /// </summary>
            Nudity = 4,
            /// <summary>
            /// Graphic Violence(Gore)
            /// </summary>
            Violence = 5,
            /// <summary>
            /// Hate Speech
            /// </summary>
            Hate = 6,
            /// <summary>
            /// Bullying or Harassment
            /// </summary>
            Bullying = 7
        }
        /// <summary>
        /// Don't worry aboot it
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        internal bool Verify(string user, string pin)
        {
            return true;
        }

        #region Functionality (Botting)
        /// <summary>
        /// Get ID of Instagram post
        /// </summary>
        /// <param name="post">Instagram link(e.g. https://www.instagram.com/p/BHON-J1gNsc/)</param>
        /// <returns></returns>
        internal string GetID(string post, string proxy, string useragent)
        {
            WebClient wc = new WebClient();
            WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
            webProxy.BypassProxyOnLocal = false;
            wc.Proxy = webProxy;
            wc.Headers.Add("user-agent", useragent);
            string source = wc.DownloadString(post);
            string ID = string.Empty;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            var content = doc.DocumentNode
                            .Descendants("meta")
                            .Where(n => n.Attributes["property"] != null && n.Attributes["property"].Value == "al:ios:url")
                            .Select(n => n.Attributes["content"].Value)
                            .First();
            StringBuilder sb = new StringBuilder();
            for (int i = 21, n = content.Length; i < n; i++)
            {
                sb.Append(content[i]);
            }
            ID = sb.ToString();
            if (debug)
            {
                Console.WriteLine($"ID: {ID}");
            }
            return ID;
        }

        /// <summary>
        /// Get ID of the profile
        /// </summary>
        /// <param name="name">Name of the profile(username)</param>
        /// <returns></returns>
        internal string GetIDProfile(string name, string proxy, string useragent)
        {
            try
            {
                WebClient wc = new WebClient();
                WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
                webProxy.BypassProxyOnLocal = false;
                wc.Proxy = webProxy;
                wc.Headers.Add("user-agent", useragent);
                string source = wc.DownloadString($"https://www.instagram.com/{name}");
                string pattern = "\"id\": \"(.*)\"";

                string ID = string.Empty;

                foreach (Match item in (new Regex(pattern).Matches(source)))
                {
                    ID = item.Groups[1].Value.Split('"')[0];
                }
                if (debug)
                    Console.WriteLine(ID);
                return ID;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Thrown! {ex}");
                return "ERROR";
            }
        }

        /// <summary>
        /// Login to instagram, this method is for botting!
        /// </summary>
        /// <param name="user">Username of user trying to login</param>
        /// <param name="password">Password of user trying to login</param>
        /// <param name="proxy">Proxy to login with</param>
        /// <param name="useragent">Randomized useragent, <see cref="Kek.UAs"/></param>
        /// <returns>Success(true)/Failed(false)</returns>
        public bool Logon(string user, string password, string proxy, string useragent)
        {
            try
            {
                if (verified)
                {
                    bool loggedOn = false;
                    LoggedOnID = GetIDProfile(user, proxy, useragent);
                    string CSRF = GetCSRFLogon(proxy, useragent);
                    string post = "username=" + user + "&password=" + password;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/login/ajax/");
                    WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
                    webProxy.BypassProxyOnLocal = false;
                    request.Proxy = webProxy;
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.UserAgent = useragent;
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "*/*";
                    request.Referer = "https://www.instagram.com/accounts/login/";
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", CSRF);
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; csrftoken={CSRF}; ig_pr=1; ig_vw=1160");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    loggedOn = html.Contains("\"authenticated\": true");
                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    var cookieTitle = "sessionid";
                    var cookie = response.Headers.GetValues("Set-Cookie").First(x => x.StartsWith(cookieTitle));
                    IGSessionIDLogin = cookie;
                    string[] splitter = IGSessionIDLogin.Split(new string[] { "sessionid=" }, StringSplitOptions.None);
                    IGSessionIDLogin = splitter[1];
                    return loggedOn;
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Turbo a name, this method is for botting!
        /// </summary>
        /// <param name="username">Username to turbo</param>
        /// <param name="proxy">Proxy to turbo with</param>
        /// <param name="useragent">Randomized useragent, <see cref="Kek.UAs"/></param>
        /// <returns>True/False</returns>
        public bool TurboName(string username, string proxy, string useragent)
        {
            try
            {
                if (verified)
                {
                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                    string CSRF = GetCSRF(proxy, useragent);
                    string post = $"first_name={username}&email=turboed{new Random().Next(0, 1000)}%40gmail.com&username={username}&phone_number=&gender=3&biography=&external_url=&chaining_enabled=on";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/edit/");
                    WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
                    webProxy.BypassProxyOnLocal = false;
                    request.Proxy = webProxy;
                    request.Method = "POST";
                    request.Accept = "*/*";
                    request.Host = "www.instagram.com";
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", CSRF);
                    request.KeepAlive = true;
                    request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={CSRF}");
                    request.ProtocolVersion = HttpVersion.Version10;
                    request.Referer = "https://www.instagram.com/accounts/edit/?wo=1";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid={IGSessionIDLogin}%3AVg99013lSewwdHbgutSa9193NbUuE9pV%3A%7B%22_token_ver%22%3A2%2C%22_auth_user_id%22%3A3455245393%2C%22_token%22%3A%223455245393%3Afw4QzyCRWEMCINbv0bMZTngjyPyxXKDk%3A8a1297388f0919512f629d76e15c15000479f8bc787a8a4389f1d89e2557781a%22%2C%22asns%22%3A%7B%2268.135.173.248%22%3A5650%2C%22time%22%3A1466832736%7D%2C%22_auth_user_backend%22%3A%22accounts.backends.CaseInsensitiveModelBackend%22%2C%22last_refreshed%22%3A1466833145.817771%2C%22_platform%22%3A4%7D; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={CSRF}; ds_user_id=3455245393");
                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("ok");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Register a user on instagram, this method is for botting!
        /// </summary>
        /// <param name="user">Username</param>
        /// <param name="password">Password</param>
        /// <param name="email">Email</param>
        /// <param name="name">Name on account</param>
        /// <param name="proxy">Proxy to register with</param>
        /// <param name="useragent">Randomized useragent, <see cref="Kek.UAs"/></param>
        /// <returns>True/False</returns>
        public bool Register(string user, string password, string email, string name, string proxy, string useragent)
        {
            try
            {
                if (verified)
                {
                    name = name.Replace(" ", "+");
                    email = email.Replace("@", "%40");

                    string GetCSRFToken = GetCSRF(proxy, useragent);

                    string post = $"email={email}&password={password}&username={user}&first_name={name}&cb=AQC3WwEvnx3J5gerVDsFBvtZcbvFg1a7QTcoW3hOFij3WWT_Xh8wO8TWg3kQY2RzDf2t9Vzhy13xmJZQA7AdLPDqGrJt6ySjgV8O-s-cDNRWqGXZ4b3O21MsfEuqG0POmFYM45jBa8h-GvZp6ZLghErhFgQDkGgi8TQzHLUHyz6Y5gxCNoOzaR6BR-hRKil4EtvOUdpFpn7GWV7jMFoMcNk7EkhF_gjZmsWyqGFjasDH-A&qs=0%2C15%2C16%2C31%2C107%2C110%2C155%2C157%2C172%2C174%2C185%2C227%2C228%2C233%2C268%2C272%2C287%2C303%2C336%2C337%2C368%2C404%2C419%2C442%2C447%2C473%2C477%2C488%2C491%2C492%2C502%2C513%2C517%2C530%2C531%2C532%2C560%2C599%2C601%2C602%2C659%2C674%7C4%2C11%2C30%2C31%2C37%2C55%2C58%2C64%2C82%2C88%2C98%2C111%2C112%2C122%2C143%2C190%2C205%2C206%2C224%2C253%2C280%2C288%2C293%2C341%2C350%2C361%2C371%2C373%2C390%2C402%2C435%2C445%2C471%2C500%2C510%2C556%2C560%2C561%2C596%2C623%2C657%2C822%7C38%2C79%2C86%2C94%2C96%2C99%2C125%2C136%2C142%2C151%2C157%2C172%2C176%2C197%2C228%2C251%2C257%2C267%2C268%2C284%2C290%2C296%2C327%2C361%2C394%2C396%2C397%2C432%2C450%2C451%2C454%2C460%2C514%2C547%2C548%2C554%2C568%2C575%2C613%2C738%2C758%2C790%7C7%2C15%2C26%2C32%2C39%2C56%2C59%2C65%2C81%2C95%2C96%2C130%2C193%2C197%2C208%2C234%2C286%2C297%2C369%2C376%2C389%2C396%2C409%2C452%2C465%2C466%2C487%2C504%2C550%2C551%2C560%2C563%2C565%2C567%2C576%2C583%2C596%2C613%2C619%2C626%2C659%2C757%7C4%2C14%2C27%2C70%2C89%2C96%2C109%2C119%2C160%2C161%2C162%2C192%2C193%2C222%2C223%2C246%2C269%2C278%2C284%2C297%2C317%2C329%2C342%2C346%2C354%2C413%2C434%2C465%2C490%2C498%2C516%2C545%2C555%2C560%2C564%2C590%2C594%2C596%2C604%2C639%2C718%2C819%7C2%2C29%2C52%2C60%2C80%2C82%2C112%2C116%2C118%2C121%2C122%2C124%2C140%2C201%2C230%2C233%2C236%2C281%2C301%2C313%2C324%2C334%2C373%2C392%2C428%2C431%2C471%2C475%2C480%2C499%2C508%2C529%2C532%2C533%2C536%2C546%2C556%2C591%2C599%2C615%2C624%2C737%7C50%2C52%2C58%2C84%2C85%2C95%2C100%2C140%2C147%2C152%2C185%2C192%2C197%2C221%2C226%2C230%2C250%2C262%2C344%2C354%2C356%2C380%2C423%2C428%2C436%2C437%2C451%2C463%2C476%2C483%2C491%2C496%2C514%2C516%2C522%2C528%2C568%2C577%2C655%2C703%2C726%2C798&guid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/web_create_ajax/ ");
                    WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
                    webProxy.BypassProxyOnLocal = false;
                    request.Proxy = webProxy;
                    request.Method = "POST";
                    request.Accept = "*/*";
                    request.KeepAlive = true;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Referer = "https://www.instagram.com/accounts/login/?signupFirst=true";
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", GetCSRFToken);
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid=IGSCcc9720afdb44b0edb6a99082a45278a5ed788ad9a048ef7a9d8ac225f4e8de5e%3A3gQYCw5bUmzqRoOLprHVAXtFCGMBbT6L%3A%7B%22asns%22%3A%7B%2268.135.173.248%22%3A5650%2C%22time%22%3A1467167986%7D%7D; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={GetCSRFToken}");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    if (debug)
                    {

                    }
                    return html.Contains("\"account_created\": true");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Like a post, This method is for botting!
        /// </summary>
        /// <param name="pic">Post to like</param>
        /// <param name="proxy">Proxy to like with</param>
        /// <param name="useragent">Randomized useragent, <see cref="Kek.UAs"/></param>
        /// <returns>True/False</returns>
        public bool Like(string pic, string proxy, string useragent)
        {
            try
            {
                if (verified)
                {
                    string id = GetID(pic, proxy, useragent);
                    string csrf = GetCSRFPost(pic, proxy, useragent);
                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                    string post = $"";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/web/likes/{id}/like/");
                    WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
                    webProxy.BypassProxyOnLocal = false;
                    request.Proxy = webProxy;
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "*/*";
                    request.Referer = pic;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={IGSessionIDLogin}; csrftoken={csrf}; ig_pr=1; ig_vw=1160");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("ok");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Likes a post on instagram, this method is for botting!
        /// </summary>
        /// <param name="pic">Link to post</param>
        /// <param name="comment">Comment text</param>
        /// <param name="proxy">Proxy to like with</param>
        /// <param name="useragent">Randomized useragent, <see cref="Kek.UAs"/></param>
        /// <returns></returns>
        public bool Comment(string pic, string comment, string proxy, string useragent)
        {
            try
            {
                if (verified)
                {
                    string id = GetID(pic, proxy, useragent);
                    string csrf = GetCSRFPost(pic, proxy, useragent);
                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                    string post = $"comment_text={comment}";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/web/comments/{id}/add/");
                    WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
                    webProxy.BypassProxyOnLocal = false;
                    request.Proxy = webProxy;
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "*/*";
                    request.Referer = pic;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={IGSessionIDLogin}; csrftoken={csrf}; ds_user_id={LoggedOnID}; ig_pr=1; ig_vw=1160");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("ok");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Unlike a post on instagram, this method is for botting!
        /// </summary>
        /// <param name="pic">Link to post to unlike</param>
        /// <param name="proxy">Proxy to unlike with</param>
        /// <param name="useragent">Randomized useragent, <see cref="Kek.UAs"/></param>
        /// <returns></returns>
        public bool Unlike(string pic, string proxy, string useragent)
        {
            try
            {
                if (verified)
                {
                    string id = GetID(pic, proxy, useragent);
                    string csrf = GetCSRFPost(pic, proxy, useragent);
                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                    string post = $"";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/web/likes/{id}/unlike/");
                    WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
                    webProxy.BypassProxyOnLocal = false;
                    request.Proxy = webProxy;
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "*/*";
                    request.Referer = pic;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={IGSessionIDLogin}; csrftoken={csrf}; ig_pr=1; ig_vw=1160");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("ok");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Follow a user on instagram, this method is for botting!
        /// </summary>
        /// <param name="name">Name of profile to follow (username)</param>
        /// <param name="proxy">Proxy to follow with</param>
        /// <param name="useragent">Randomized useragent, <see cref="Kek.UAs"/></param>
        /// <returns></returns>
        public bool Follow(string name, string proxy, string useragent)
        {
            try
            {
                if (verified)
                {
                    string id = GetIDProfile(name, proxy, useragent);
                    string csrf = GetCSRFProfile(name, proxy, useragent);
                    string post = $"";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/web/friendships/" + id + "/follow/");
                    WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
                    webProxy.BypassProxyOnLocal = false;
                    request.Proxy = webProxy;
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.ContentLength = 0;
                    request.Accept = "*/*";
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Referer = "https://www.instagram.com/" + name + "/";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"sessionid={IGSessionIDLogin}; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={csrf}; ds_user_id={LoggedOnID}");
                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("\"result\": \"following\"");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Unfollow a user, this method is for botting
        /// </summary>
        /// <param name="name">Name of the profile to unfollow(username)</param>
        /// <param name="proxy">Proxy to unfollow with</param>
        /// <param name="useragent">Randomized useragent, <see cref="Kek.UAs"/></param>
        /// <returns></returns>
        public bool Unfollow(string name, string proxy, string useragent)
        {
            try
            {
                if (verified)
                {
                    string id = GetIDProfile(name, proxy, useragent);
                    string csrf = GetCSRFProfile(name, proxy, useragent);
                    string post = $"";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/web/friendships/" + id + "/unfollow/");
                    WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
                    webProxy.BypassProxyOnLocal = false;
                    request.Proxy = webProxy;
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.ContentLength = 0;
                    request.Accept = "*/*";
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Referer = "https://www.instagram.com/" + name + "/";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"sessionid={IGSessionIDLogin}; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={csrf}; ds_user_id={LoggedOnID}");
                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("\"result\": \"following\"");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Report a picture on instagram, this method is for botting!
        /// </summary>
        /// <param name="pic">Report a picture</param>
        /// <param name="report">Report type <see cref="Kek.ReportType"/></param>
        /// <param name="proxy">Proxy to like report with</param>
        /// <param name="useragent">Randomized useragent, <see cref="Kek.UAs"/></param>
        /// <returns></returns>
        public bool Report(string pic, ReportType report, string proxy, string useragent)
        {
            try
            {
                if (verified)
                {
                    string id = GetID(pic, proxy, useragent);
                    string csrf = GetCSRFPost(pic, proxy, useragent);
                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                    string post;
                    switch (report)
                    {
                        case ReportType.Spam:
                            post = $"reason_id=1";
                            break;
                        case ReportType.Harm:
                            post = $"reason_id=2";
                            break;
                        case ReportType.Drugs:
                            post = $"reason_id=3";
                            break;
                        case ReportType.Nudity:
                            post = $"reason_id=4";
                            break;
                        case ReportType.Violence:
                            post = $"reason_id=5";
                            break;
                        case ReportType.Hate:
                            post = $"reason_id=6";
                            break;
                        case ReportType.Bullying:
                            post = $"reason_id=7";
                            break;
                        default:
                            post = $"1";
                            break;
                    }
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/media/{id}/flag/");
                    WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
                    webProxy.BypassProxyOnLocal = false;
                    request.Proxy = webProxy;
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "*/*";
                    request.Referer = pic;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={IGSessionIDLogin}; csrftoken={csrf}; ds_user_id={LoggedOnID}; ig_pr=1; ig_vw=1160");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("ok");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
            return false;
        }
        #endregion

        #region Functionality (No Proxy)
        /// <summary>
        /// Checks username, 100% accuraccy but slower than <see cref="CheckName()"/>
        /// </summary>
        /// <param name="user">Username to check</param>
        /// <returns></returns>
        public bool CheckNameBanned(string user)
        {
            string post = "email=abc%40gmail.com&password=123&username=" + user + "&first_name=john+doe";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/web_create_ajax/attempt/");
            string CSRFToken = GetCSRFRegister();
            request.Method = "POST";
            request.Host = "www.instagram.com";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Accept = "*/*";
            request.Referer = "https://www.instagram.com/accounts/login/?signupFirst=true";
            request.Headers.Add("Origin", "https://www.instagram.com");
            request.Headers.Add("X-Instagram-AJAX", "1");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("X-CSRFToken", CSRFToken);
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid=IGSC65ec3226d0e4e12dfcba7be6cc5b75e818daa339e7cdf167a54fc1d1196d4096%3AWtMcnzQLD6RRRtPiLrlYlrWXkyZQmey6%3A%7B%22asns%22%3A%7B%2268.135.173.248%22%3A5650%2C%22time%22%3A1466768354%7D%7D; ig_pr=0.8999999761581421; ig_vw=1517; s_network=; csrftoken={CSRFToken}");

            byte[] postBytes = Encoding.ASCII.GetBytes(post);
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return !html.Contains("\"errors\": {\"username\":");
        }

        /// <summary>
        /// Check if a instagram username is taken
        /// </summary>
        /// <param name="type">What site to check</param>
        /// <param name="name">Name to check</param>
        /// <returns>Available(false)/Taken(true)</returns>
        public bool CheckName(string name)
        {
            if (verified)
            {
                bool valid = false;
                WebClient wc = new WebClient();
                try
                {
                    string html = wc.DownloadString("http://instagram.com/" + name);
                    if (debug)
                    {
                        Console.WriteLine($"Name: {name}, Status: Unavailable");
                    }
                    valid = false;
                }
                catch (Exception ex)
                {
                    if (debug)
                    {
                        Console.WriteLine($"Name: {name}, Status: Available");
                    }
                    valid = true;
                }
                return valid;
            }
            else
            {
                Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                return false;
            }
        }

        /// <summary>
        /// Login to instagram
        /// </summary>
        /// <param name="user">Username of user trying to login</param>
        /// <param name="password">Password of user trying to login</param>
        /// <param name="type">What site user is logging into</param>
        /// <returns>Success(true)/Failed(false)</returns>
        public bool Logon(string user, string password)
        {
            try {
                if (verified)
                {
                    bool loggedOn = false;
                    LoggedOnID = GetIDProfile(user);
                    string CSRF = GetCSRFLogon();
                    string post = "username=" + user + "&password=" + password;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/login/ajax/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "*/*";
                    request.Referer = "https://www.instagram.com/accounts/login/";
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", CSRF);
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; csrftoken={CSRF}; ig_pr=1; ig_vw=1160");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    loggedOn = html.Contains("\"authenticated\": true");
                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    var cookieTitle = "sessionid";
                    var cookie = response.Headers.GetValues("Set-Cookie").First(x => x.StartsWith(cookieTitle));
                    IGSessionIDLogin = cookie;
                    string[] splitter = IGSessionIDLogin.Split(new string[] { "sessionid=" }, StringSplitOptions.None);
                    IGSessionIDLogin = splitter[1];
                    return loggedOn;
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            } 
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Turbo a IG username
        /// </summary>
        /// <param name="username">Username to turbo</param>
        /// <returns></returns>
        public bool TurboName(string username)
        {
            try
            {
                if (verified)
                {
                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                    string CSRF = GetCSRF();
                    string post = $"first_name={username}&email=turboed{new Random().Next(0, 1000)}%40gmail.com&username={username}&phone_number=&gender=3&biography=&external_url=&chaining_enabled=on";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/edit/");
                    request.Method = "POST";
                    request.Accept = "*/*";
                    request.Host = "www.instagram.com";
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", CSRF);
                    request.KeepAlive = true;
                    request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={CSRF}");
                    request.ProtocolVersion = HttpVersion.Version10;
                    request.Referer = "https://www.instagram.com/accounts/edit/?wo=1";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid={IGSessionIDLogin}%3AVg99013lSewwdHbgutSa9193NbUuE9pV%3A%7B%22_token_ver%22%3A2%2C%22_auth_user_id%22%3A3455245393%2C%22_token%22%3A%223455245393%3Afw4QzyCRWEMCINbv0bMZTngjyPyxXKDk%3A8a1297388f0919512f629d76e15c15000479f8bc787a8a4389f1d89e2557781a%22%2C%22asns%22%3A%7B%2268.135.173.248%22%3A5650%2C%22time%22%3A1466832736%7D%2C%22_auth_user_backend%22%3A%22accounts.backends.CaseInsensitiveModelBackend%22%2C%22last_refreshed%22%3A1466833145.817771%2C%22_platform%22%3A4%7D; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={CSRF}; ds_user_id=3455245393");
                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("ok");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Registers a user on instagram
        /// </summary>
        /// <param name="user">Username of account</param>
        /// <param name="password">Password of account</param>
        /// <param name="email">E=Mail of account</param>
        /// <param name="name">Name(displayed under username) of account</param>
        /// <returns>True(logged in)/False(Failed)</returns>
        public bool Register(string user, string password, string email, string name)
        {
            try
            {
                if (verified)
                {
                    name = name.Replace(" ", "+");
                    email = email.Replace("@", "%40");

                    string GetCSRFToken = GetCSRF();

                    string post = $"email={email}&password={password}&username={user}&first_name={name}&cb=AQC3WwEvnx3J5gerVDsFBvtZcbvFg1a7QTcoW3hOFij3WWT_Xh8wO8TWg3kQY2RzDf2t9Vzhy13xmJZQA7AdLPDqGrJt6ySjgV8O-s-cDNRWqGXZ4b3O21MsfEuqG0POmFYM45jBa8h-GvZp6ZLghErhFgQDkGgi8TQzHLUHyz6Y5gxCNoOzaR6BR-hRKil4EtvOUdpFpn7GWV7jMFoMcNk7EkhF_gjZmsWyqGFjasDH-A&qs=0%2C15%2C16%2C31%2C107%2C110%2C155%2C157%2C172%2C174%2C185%2C227%2C228%2C233%2C268%2C272%2C287%2C303%2C336%2C337%2C368%2C404%2C419%2C442%2C447%2C473%2C477%2C488%2C491%2C492%2C502%2C513%2C517%2C530%2C531%2C532%2C560%2C599%2C601%2C602%2C659%2C674%7C4%2C11%2C30%2C31%2C37%2C55%2C58%2C64%2C82%2C88%2C98%2C111%2C112%2C122%2C143%2C190%2C205%2C206%2C224%2C253%2C280%2C288%2C293%2C341%2C350%2C361%2C371%2C373%2C390%2C402%2C435%2C445%2C471%2C500%2C510%2C556%2C560%2C561%2C596%2C623%2C657%2C822%7C38%2C79%2C86%2C94%2C96%2C99%2C125%2C136%2C142%2C151%2C157%2C172%2C176%2C197%2C228%2C251%2C257%2C267%2C268%2C284%2C290%2C296%2C327%2C361%2C394%2C396%2C397%2C432%2C450%2C451%2C454%2C460%2C514%2C547%2C548%2C554%2C568%2C575%2C613%2C738%2C758%2C790%7C7%2C15%2C26%2C32%2C39%2C56%2C59%2C65%2C81%2C95%2C96%2C130%2C193%2C197%2C208%2C234%2C286%2C297%2C369%2C376%2C389%2C396%2C409%2C452%2C465%2C466%2C487%2C504%2C550%2C551%2C560%2C563%2C565%2C567%2C576%2C583%2C596%2C613%2C619%2C626%2C659%2C757%7C4%2C14%2C27%2C70%2C89%2C96%2C109%2C119%2C160%2C161%2C162%2C192%2C193%2C222%2C223%2C246%2C269%2C278%2C284%2C297%2C317%2C329%2C342%2C346%2C354%2C413%2C434%2C465%2C490%2C498%2C516%2C545%2C555%2C560%2C564%2C590%2C594%2C596%2C604%2C639%2C718%2C819%7C2%2C29%2C52%2C60%2C80%2C82%2C112%2C116%2C118%2C121%2C122%2C124%2C140%2C201%2C230%2C233%2C236%2C281%2C301%2C313%2C324%2C334%2C373%2C392%2C428%2C431%2C471%2C475%2C480%2C499%2C508%2C529%2C532%2C533%2C536%2C546%2C556%2C591%2C599%2C615%2C624%2C737%7C50%2C52%2C58%2C84%2C85%2C95%2C100%2C140%2C147%2C152%2C185%2C192%2C197%2C221%2C226%2C230%2C250%2C262%2C344%2C354%2C356%2C380%2C423%2C428%2C436%2C437%2C451%2C463%2C476%2C483%2C491%2C496%2C514%2C516%2C522%2C528%2C568%2C577%2C655%2C703%2C726%2C798&guid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/web_create_ajax/ ");
                    request.Method = "POST";
                    request.Accept = "*/*";
                    request.KeepAlive = true;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Referer = "https://www.instagram.com/accounts/login/?signupFirst=true";
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", GetCSRFToken);
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid=IGSCcc9720afdb44b0edb6a99082a45278a5ed788ad9a048ef7a9d8ac225f4e8de5e%3A3gQYCw5bUmzqRoOLprHVAXtFCGMBbT6L%3A%7B%22asns%22%3A%7B%2268.135.173.248%22%3A5650%2C%22time%22%3A1467167986%7D%7D; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={GetCSRFToken}");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    if (debug)
                    {

                    }
                    return html.Contains("\"account_created\": true");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Likes a post on instagram
        /// </summary>
        /// <param name="pic"></param>
        /// <returns></returns>
        public bool Like(string pic)
        {
            try {
                if (verified)
                {
                    string id = GetID(pic);
                    string csrf = GetCSRFPost(pic);
                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                    string post = $"";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/web/likes/{id}/like/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "*/*";
                    request.Referer = pic;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={IGSessionIDLogin}; csrftoken={csrf}; ig_pr=1; ig_vw=1160");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("ok");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Likes a post on instagram
        /// </summary>
        /// <param name="comment">Comment text</param>
        /// <returns></returns>
        public bool Comment(string pic, string comment)
        {
            try
            {
                if (verified)
                {
                    string id = GetID(pic);
                    string csrf = GetCSRFPost(pic);
                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                    string post = $"comment_text={comment}";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/web/comments/{id}/add/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "*/*";
                    request.Referer = pic;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={IGSessionIDLogin}; csrftoken={csrf}; ds_user_id={LoggedOnID}; ig_pr=1; ig_vw=1160");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("ok");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Unlike a post on instagram
        /// </summary>
        /// <param name="pic"></param>
        /// <returns></returns>
        public bool Unlike(string pic)
        {
            try
            {
                if (verified)
                {
                    string id = GetID(pic);
                    string csrf = GetCSRFPost(pic);
                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                    string post = $"";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/web/likes/{id}/unlike/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "*/*";
                    request.Referer = pic;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={IGSessionIDLogin}; csrftoken={csrf}; ig_pr=1; ig_vw=1160");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("ok");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Follow a user on instagram
        /// </summary>
        /// <param name="name">Name of profile to follow (username)</param>
        /// <returns></returns>
        public bool Follow(string name)
        {
            try
            {
                if (verified)
                {
                    string id = GetIDProfile(name);
                    string csrf = GetCSRFProfile(name);
                    string post = $"";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/web/friendships/" + id + "/follow/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.ContentLength = 0;
                    request.Accept = "*/*";
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Referer = "https://www.instagram.com/" + name + "/";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"sessionid={IGSessionIDLogin}; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={csrf}; ds_user_id={LoggedOnID}");
                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("\"result\": \"following\"");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Unfollow a user
        /// </summary>
        /// <param name="name">Name of the profile to unfollow(username)</param>
        /// <returns></returns>
        public bool Unfollow(string name)
        {
            try {
                if (verified)
                {
                    string id = GetIDProfile(name);
                    string csrf = GetCSRFProfile(name);
                    string post = $"";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/web/friendships/" + id + "/unfollow/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.ContentLength = 0;
                    request.Accept = "*/*";
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Referer = "https://www.instagram.com/" + name + "/";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"sessionid={IGSessionIDLogin}; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={csrf}; ds_user_id={LoggedOnID}");
                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("\"result\": \"following\"");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Report a picture on instagram
        /// </summary>
        /// <param name="pic">Report a picture</param>
        /// <returns></returns>
        public bool Report(string pic, ReportType report)
        {
            try
            {
                if (verified)
                {
                    string id = GetID(pic);
                    string csrf = GetCSRFPost(pic);
                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                    string post;
                    switch (report)
                    {
                        case ReportType.Spam:
                            post = $"reason_id=1";
                            break;
                        case ReportType.Harm:
                            post = $"reason_id=2";
                            break;
                        case ReportType.Drugs:
                            post = $"reason_id=3";
                            break;
                        case ReportType.Nudity:
                            post = $"reason_id=4";
                            break;
                        case ReportType.Violence:
                            post = $"reason_id=5";
                            break;
                        case ReportType.Hate:
                            post = $"reason_id=6";
                            break;
                        case ReportType.Bullying:
                            post = $"reason_id=7";
                            break;
                        default:
                            post = $"1";
                            break;
                    }
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/media/{id}/flag/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "*/*";
                    request.Referer = pic;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={IGSessionIDLogin}; csrftoken={csrf}; ds_user_id={LoggedOnID}; ig_pr=1; ig_vw=1160");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (debug)
                    {
                        Console.WriteLine(html);
                    }
                    return html.Contains("ok");
                }
                else
                {
                    Console.WriteLine("Pay for this or log in kiddo. Fuck you");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (debug)
                    Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
            return false;
        }

        /// <summary>
        /// Get ID of Instagram post
        /// </summary>
        /// <param name="post">Instagram link(e.g. https://www.instagram.com/p/BHON-J1gNsc/)</param>
        /// <returns></returns>
        internal string GetID(string post)
        {
            string source = new System.Net.WebClient().DownloadString(post);
            string ID = string.Empty;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            var content = doc.DocumentNode
                            .Descendants("meta")
                            .Where(n => n.Attributes["property"] != null && n.Attributes["property"].Value == "al:ios:url")
                            .Select(n => n.Attributes["content"].Value)
                            .First();
            StringBuilder sb = new StringBuilder();
            for(int i = 21, n = content.Length; i < n; i++)
            {
                sb.Append(content[i]);
            }
            ID = sb.ToString();
            if(debug)
            {
                Console.WriteLine($"ID: {ID}");
            }
            return ID;
        }

        /// <summary>
        /// Get ID of the profile
        /// </summary>
        /// <param name="name">Name of the profile(username)</param>
        /// <returns></returns>
        internal string GetIDProfile(string name)
        {
            try {
                string source = new System.Net.WebClient().DownloadString($"https://www.instagram.com/{name}");
                string pattern = "\"id\": \"(.*)\"";

                string ID = string.Empty;

                foreach (Match item in (new Regex(pattern).Matches(source)))
                {
                    ID = item.Groups[1].Value.Split('"')[0];
                }
                if (debug)
                    Console.WriteLine(ID);
                return ID;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Thrown! {ex}");
                return "ERROR";
            }
        }
        #endregion

        #region CSRF (No Proxy)
        /// <summary>
        /// Gets CSRF Token for Turboring.
        /// </summary>
        /// <returns>CSRF Token</returns>
        internal string GetCSRF()
        {
            string source = new System.Net.WebClient().DownloadString("https://www.instagram.com/accounts/edit/?wo=1");
            string pattern = "\"csrf_token\": \"(.*)\"";

            string CSRF = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                CSRF = item.Groups[1].Value.Split('"')[0];
            }
            Console.WriteLine(CSRF);
            return CSRF;
        }

        /// <summary>
        /// Gets CSRF Token for Logging in.
        /// </summary>
        /// <returns>CSRF Token</returns>
        internal string GetCSRFLogon()
        {
            string source = new System.Net.WebClient().DownloadString("https://www.instagram.com/accounts/login/");
            string pattern = "\"csrf_token\": \"(.*)\"";

            string CSRF = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                CSRF = item.Groups[1].Value.Split('"')[0];
            }
            Console.WriteLine(CSRF);
            return CSRF;
        }

        /// <summary>
        /// Get CSRF Token for Registering.
        /// </summary>
        /// <returns>CSRF Token</returns>
        internal string GetCSRFRegister()
        {
            string source = new System.Net.WebClient().DownloadString("https://www.instagram.com/accounts/login/?signupFirst=true");
            string pattern = "\"csrf_token\": \"(.*)\"";

            string CSRF = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                CSRF = item.Groups[1].Value.Split('"')[0];
            }
            Console.WriteLine(CSRF);
            return CSRF;
        }

        /// <summary>
        /// Get CSRF Token for liking a post.
        /// </summary>
        /// <returns>CSRF Token</returns>
        internal string GetCSRFPost(string post)
        {
            string source = new System.Net.WebClient().DownloadString(post);
            string pattern = "\"csrf_token\": \"(.*)\"";

            string CSRF = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                CSRF = item.Groups[1].Value.Split('"')[0];
            }
            Console.WriteLine(CSRF);
            return CSRF;
        }

        /// <summary>
        /// Get CSRF Tone for following
        /// </summary>
        /// <param name="name">Name of profile(username)</param>
        /// <returns></returns>
        internal string GetCSRFProfile(string name)
        {
            string source = new System.Net.WebClient().DownloadString($"https://instagram.com/{name}/");
            string pattern = "\"csrf_token\": \"(.*)\"";

            string CSRF = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                CSRF = item.Groups[1].Value.Split('"')[0];
            }
            Console.WriteLine(CSRF);
            return CSRF;
        }
        #endregion

        #region CSRF (Botting)
        /// <summary>
        /// Gets CSRF Token for Turboring.
        /// </summary>
        /// <returns>CSRF Token</returns>
        internal string GetCSRF(string proxy, string useragent)
        {
            WebClient wc = new WebClient();
            WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
            webProxy.BypassProxyOnLocal = false;
            wc.Proxy = webProxy;
            wc.Headers.Add("user-agent", useragent);
            string source = wc.DownloadString("https://www.instagram.com/accounts/edit/?wo=1");
            string pattern = "\"csrf_token\": \"(.*)\"";

            string CSRF = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                CSRF = item.Groups[1].Value.Split('"')[0];
            }
            Console.WriteLine(CSRF);
            return CSRF;
        }

        /// <summary>
        /// Gets CSRF Token for Logging in.
        /// </summary>
        /// <returns>CSRF Token</returns>
        internal string GetCSRFLogon(string proxy, string useragent)
        {
            WebClient wc = new WebClient();
            WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
            webProxy.BypassProxyOnLocal = false;
            wc.Proxy = webProxy;
            wc.Headers.Add("user-agent", useragent);
            string source = wc.DownloadString("https://www.instagram.com/accounts/login/");
            string pattern = "\"csrf_token\": \"(.*)\"";

            string CSRF = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                CSRF = item.Groups[1].Value.Split('"')[0];
            }
            Console.WriteLine(CSRF);
            return CSRF;
        }

        /// <summary>
        /// Get CSRF Token for Registering.
        /// </summary>
        /// <returns>CSRF Token</returns>
        internal string GetCSRFRegister(string proxy, string useragent)
        {
            WebClient wc = new WebClient();
            WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
            webProxy.BypassProxyOnLocal = false;
            wc.Proxy = webProxy;
            wc.Headers.Add("user-agent", useragent);
            string source = wc.DownloadString("https://www.instagram.com/accounts/login/?signupFirst=true");
            string pattern = "\"csrf_token\": \"(.*)\"";

            string CSRF = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                CSRF = item.Groups[1].Value.Split('"')[0];
            }
            Console.WriteLine(CSRF);
            return CSRF;
        }

        /// <summary>
        /// Get CSRF Token for liking a post.
        /// </summary>
        /// <returns>CSRF Token</returns>
        internal string GetCSRFPost(string post, string proxy, string useragent)
        {
            WebClient wc = new WebClient();
            WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
            webProxy.BypassProxyOnLocal = false;
            wc.Proxy = webProxy;
            wc.Headers.Add("user-agent", useragent);
            string source = wc.DownloadString(post);
            string pattern = "\"csrf_token\": \"(.*)\"";

            string CSRF = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                CSRF = item.Groups[1].Value.Split('"')[0];
            }
            Console.WriteLine(CSRF);
            return CSRF;
        }

        /// <summary>
        /// Get CSRF Tone for following
        /// </summary>
        /// <param name="name">Name of profile(username)</param>
        /// <returns></returns>
        internal string GetCSRFProfile(string name, string proxy, string useragent)
        {
            WebClient wc = new WebClient();
            WebProxy webProxy = new WebProxy(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]));
            webProxy.BypassProxyOnLocal = false;
            wc.Proxy = webProxy;
            wc.Headers.Add("user-agent", useragent);
            string source = wc.DownloadString($"https://instagram.com/{name}/");
            string pattern = "\"csrf_token\": \"(.*)\"";

            string CSRF = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                CSRF = item.Groups[1].Value.Split('"')[0];
            }
            Console.WriteLine(CSRF);
            return CSRF;
        }
        #endregion

    }
}
