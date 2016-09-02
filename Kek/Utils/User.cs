using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Kek.Utils
{
    class User
    {
        public User()
        {

        }

        /// <summary>
        /// Log a user into Instagram.
        /// </summary>
        /// <param name="user">Username of user</param>
        /// <param name="password">Password of user</param>
        /// <returns>True/False</returns>
        public bool Login(string user, string password)
        {
            try
            {
                bool loggedOn = false;
                Kek.LoggedOnID = GetIDProfile(user);
                string CSRF = new CSRF().returnCSRFToken("https://instagram.com/");
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
                Console.WriteLine(html);
                var cookieTitle = "sessionid";
                var cookie = response.Headers.GetValues("Set-Cookie").First(x => x.StartsWith(cookieTitle));
                Kek.IGSessionIDLogin = cookie;
                string[] splitter = Kek.IGSessionIDLogin.Split(new string[] { "sessionid=" }, StringSplitOptions.None);
                Kek.IGSessionIDLogin = splitter[1];
                return loggedOn;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Register a user on Instagram
        /// </summary>
        /// <param name="user">Desired username</param>
        /// <param name="password">Password for account</param>
        /// <param name="email">Email to sign-up with</param>
        /// <param name="name">Display name</param>
        /// <returns></returns>
        public bool Register(string user, string password, string email, string name)
        {
            try
            {
                name = name.Replace(" ", "+");
                email = email.Replace("@", "%40");

                string GetCSRFToken = new CSRF().returnCSRFToken("https://instagram.com");

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
                return html.Contains("\"account_created\": true");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Change username of logged in user.
        /// </summary>
        /// <param name="username">Desired username</param>
        /// <returns>True/False</returns>
        public bool ChangeUsername(string username)
        {
            try
            {
                System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                string CSRF = new CSRF().returnCSRFToken("https://www.instagram.com/accounts/edit/");
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
                request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid={Kek.IGSessionIDLogin}%3AVg99013lSewwdHbgutSa9193NbUuE9pV%3A%7B%22_token_ver%22%3A2%2C%22_auth_user_id%22%3A3455245393%2C%22_token%22%3A%223455245393%3Afw4QzyCRWEMCINbv0bMZTngjyPyxXKDk%3A8a1297388f0919512f629d76e15c15000479f8bc787a8a4389f1d89e2557781a%22%2C%22asns%22%3A%7B%2268.135.173.248%22%3A5650%2C%22time%22%3A1466832736%7D%2C%22_auth_user_backend%22%3A%22accounts.backends.CaseInsensitiveModelBackend%22%2C%22last_refreshed%22%3A1466833145.817771%2C%22_platform%22%3A4%7D; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={CSRF}; ds_user_id=3455245393");
                byte[] postBytes = Encoding.ASCII.GetBytes(post);
                request.ContentLength = postBytes.Length;
                Stream requestStream = request.GetRequestStream();

                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(html);
                return html.Contains("ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Follow a user on Instagram
        /// </summary>
        /// <param name="name">Name of user to follow</param>
        /// <returns>True/False</returns>
        public bool Follow(string name)
        {
            try
            {
                string id = GetIDProfile(name);
                string csrf = new CSRF().returnCSRFToken($"https://instagram.com/{name}/");
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
                request.Headers.Add("Cookie", $"sessionid={Kek.IGSessionIDLogin}; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={csrf}; ds_user_id={Kek.LoggedOnID}");
                byte[] postBytes = Encoding.ASCII.GetBytes(post);
                request.ContentLength = postBytes.Length;
                Stream requestStream = request.GetRequestStream();

                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                Console.WriteLine(html);
                return html.Contains("\"result\": \"following\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Unfollow a certain user on Instagram
        /// </summary>
        /// <param name="name">user to unfollow</param>
        /// <returns>True/False</returns>
        public bool Unfollow(string name)
        {
            try
            {
                string id = GetIDProfile(name);
                string csrf = new CSRF().returnCSRFToken($"https://instagram.com/{name}/");
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
                request.Headers.Add("Cookie", $"sessionid={Kek.IGSessionIDLogin}; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={csrf}; ds_user_id={Kek.LoggedOnID}");
                byte[] postBytes = Encoding.ASCII.GetBytes(post);
                request.ContentLength = postBytes.Length;
                Stream requestStream = request.GetRequestStream();

                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                Console.WriteLine(html);
                return html.Contains("\"result\": \"following\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Throw: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Get ID of the profile
        /// </summary>
        /// <param name="name">Name of the profile(username)</param>
        /// <returns></returns>
        internal string GetIDProfile(string name)
        {
            try
            {
                string source = new System.Net.WebClient().DownloadString($"https://www.instagram.com/{name}");
                string pattern = "\"id\": \"(.*)\"";

                string ID = string.Empty;

                foreach (Match item in (new Regex(pattern).Matches(source)))
                {
                    ID = item.Groups[1].Value.Split('"')[0];
                }
                Console.WriteLine(ID);
                return ID;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Thrown! {ex}");
                return "ERROR";
            }
        }
    }
}
