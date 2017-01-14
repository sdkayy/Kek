using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Kek.Utils
{
    public class Post
    {
        public Post()
        {

        }

        public delegate void NewPost(object obj, PostArgs args);

        public event NewPost OnNewPost;

        internal string temp = string.Empty;
        internal string latestCode = string.Empty;
        public void WaitForPost(string username)
        {
            while(true)
            {
                string last = CheckNewPost(username);
                if (temp.Equals(string.Empty))
                {
                    temp = last;
                }
                else if (temp.Equals(last))
                {
                    continue;
                }
                else if (!temp.Equals(last))
                {
                    PostArgs myArgs = new PostArgs($"{username} posted", $"https://instagram.com/p/{latestCode}/");
                    OnNewPost(this, myArgs);
                    break;
                }
                Thread.Sleep(150);
            }
        }

        internal string CheckNewPost(string username)
        {
            try
            {
                string raw = new WebClient().DownloadString($"https://instagram.com/{username}/");
                string JSONToParse = GetJson(raw);
                dynamic job = JsonConvert.DeserializeObject(JSONToParse);
                latestCode = job.entry_data.ProfilePage[0].user.media.nodes[0].code;
                string latestID = job.entry_data.ProfilePage[0].user.media.nodes[0].id; //Get Latest Posts ID
                return latestID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return "";
            }
        }

        internal string GetJson(string r)
        {
            string pattern = "window._sharedData = (.*)";

            string JSON = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(r)))
            {
                JSON = item.Groups[1].Value.Split(new string[] { ";</script>" }, StringSplitOptions.None)[0];
            }
            return JSON;
        }

        /// <summary>
        /// Likes a post on instagram
        /// </summary>
        /// <param name="pic"></param>
        /// <returns></returns>
        public bool Like(string pic)
        {
            try
            {
                string id = GetID(pic);
                string csrf = new CSRF().returnCSRFToken(pic);
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
                request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={Kek.IGSessionIDLogin}; csrftoken={csrf}; ig_pr=1; ig_vw=1160");

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
        /// Likes a post on instagram
        /// </summary>
        /// <param name="comment">Comment text</param>
        /// <returns></returns>
        public bool Comment(string pic, string comment)
        {
            try
            {
                string id = GetID(pic);
                string csrf = new CSRF().returnCSRFToken(pic);
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
                request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={Kek.IGSessionIDLogin}; csrftoken={csrf}; ds_user_id={Kek.LoggedOnID}; ig_pr=1; ig_vw=1160");

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
        /// Unlike a post on instagram
        /// </summary>
        /// <param name="pic">Url of image to unlike</param>
        /// <returns>True/False</returns>
        public bool Unlike(string pic)
        {
            try
            {
                string id = GetID(pic);
                string csrf = new CSRF().returnCSRFToken(pic);
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
                request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={Kek.IGSessionIDLogin}; csrftoken={csrf}; ig_pr=1; ig_vw=1160");

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
        /// Report a picture on instagram
        /// </summary>
        /// <param name="pic">Report a picture</param>
        /// <returns></returns>
        public bool Report(string pic, Kek.ReportType report)
        {
            try
            {
                string id = GetID(pic);
                string csrf = new CSRF().returnCSRFToken(pic);
                System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                string post;
                switch (report)
                {
                    case Kek.ReportType.Spam:
                        post = $"reason_id=1";
                        break;
                    case Kek.ReportType.Harm:
                        post = $"reason_id=2";
                        break;
                    case Kek.ReportType.Drugs:
                        post = $"reason_id=3";
                        break;
                    case Kek.ReportType.Nudity:
                        post = $"reason_id=4";
                        break;
                    case Kek.ReportType.Violence:
                        post = $"reason_id=5";
                        break;
                    case Kek.ReportType.Hate:
                        post = $"reason_id=6";
                        break;
                    case Kek.ReportType.Bullying:
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
                request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={Kek.IGSessionIDLogin}; csrftoken={csrf}; ds_user_id={Kek.LoggedOnID}; ig_pr=1; ig_vw=1160");

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
            return false;
        }

        /// <summary>
        /// Get ID of Instagram post
        /// </summary>
        /// <param name="post">Instagram link(e.g. https://www.instagram.com/p/BHON-J1gNsc/)</param>
        /// <returns>Photo Unique ID</returns>
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
            for (int i = 21, n = content.Length; i < n; i++)
            {
                sb.Append(content[i]);
            }
            ID = sb.ToString();
            Console.WriteLine($"ID: {ID}");
            return ID;
        }
    }
}
