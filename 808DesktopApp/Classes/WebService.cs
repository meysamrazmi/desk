using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace _808DesktopApp.Classes
{
    public class WebService
    {
        private static string baseUrl = "https://civil808.com/desktop/";
        private static string contentType = "application/json";
        private static string source = "desktop";
        private static string version = "1";
        private static int TimeOut = 13000;

        public static UserLogin login(string username_email, string password)
        {
            try
            {
                var url = baseUrl + "user/login2";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = TimeOut;
                var model = new
                {
                    hash = "50e185c2e0c2bc30215338db776022c92ecbc441fd933688c6bf4f274c863c60",
                    username_email,
                    password,
                    source,
                    version
                };

                var data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(model));

                request.Method = "POST";
                request.ContentType = contentType;
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (responseString.Contains("username or password"))
                        throw new Exception("نام کاربری یا رمز عبور اشتباه است");
                    throw new Exception(responseString);
                }
                else
                {
                    return JsonConvert.DeserializeObject<UserLogin>(responseString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ورود به برنامه", ex);
            }
        }

        public static void logout(UserLogin userLogin)
        {
            try
            {
                var url = baseUrl + "user/logout";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = TimeOut;
                request.ContentType = contentType;
                request.Headers.Add("Cookie:" + userLogin.session_name + "=" + userLogin.sessid);
                request.Headers.Add("X-CSRF-Token:" + userLogin.token);
                request.Method = "POST";
                request.ContentLength = 0;

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(responseString);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خروج از برنامه", ex);
            }
        }

        public static MyProduct myProducts(UserLogin userLogin)
        {
            try
            {
                var url = baseUrl + "user/" + userLogin.user.uid + "/purchased_products?hash=50e185c2e0c2bc30215338db776022c92ecbc441fd933688c6bf4f274c863c60&parameter[source]=" + source + "&parameter[version]=" + version;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = TimeOut;

                request.Method = "GET";
                request.ContentType = contentType;
                request.Headers.Add("Cookie:" + userLogin.session_name + "=" + userLogin.sessid);

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(responseString);
                }
                else
                {
                    return JsonConvert.DeserializeObject<MyProduct>(responseString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در فراخوانی محصولات خریداری ", ex);
            }
        }

        public static Bookmark myBookmarks(UserLogin userLogin)
        {
            try
            {
                var url = baseUrl + "user/" + userLogin.user.uid + "/bookmarks?parameter[hash]=50e185c2e0c2bc30215338db776022c92ecbc441fd933688c6bf4f274c863c60&parameter[source]=" + source + "&parameter[version]=" + version;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = TimeOut;

                request.Method = "GET";
                request.ContentType = contentType;
                request.Headers.Add("Cookie:" + userLogin.session_name + "=" + userLogin.sessid);

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(responseString);
                }
                else
                {
                    return JsonConvert.DeserializeObject<Bookmark>(responseString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در فراخوانی محصولات بوکمارک ", ex);
            }
        }

        public static UserLogin userInfo(UserLogin userLogin)
        {
            try
            {
                var url = baseUrl + "user/" + userLogin.user.uid + "?parameter[hash]=50e185c2e0c2bc30215338db776022c92ecbc441fd933688c6bf4f274c863c60&parameter[source]=" + source + "&parameter[version]=" + version;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = TimeOut;

                request.Method = "GET";
                request.ContentType = contentType;
                request.Headers.Add("Cookie:" + userLogin.session_name + "=" + userLogin.sessid);

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(responseString);
                }
                else
                {
                    var user = JsonConvert.DeserializeObject<User>(responseString);
                    var profile = JsonConvert.DeserializeObject<Profile>(responseString);
                    userLogin.user = user;
                    userLogin.profile = profile;

                    return userLogin;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در فراخوانی اطلاعات کاربری ", ex);
            }
        }

        public static LastContent lastContent()
        {
            try
            {
                var url = baseUrl + "content?hash=0b6c8fbeb5039858c98be380301f2115ca46777d90d5a4b04788739f332442d2&parameter[source]=" + source + "&parameter[version]=" + version;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = TimeOut;

                request.Method = "GET";
                request.ContentType = contentType;

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(responseString);
                }
                else
                {
                    return JsonConvert.DeserializeObject<LastContent>(responseString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در فراخوانی آخرین محتوا ", ex);
            }
        }

        public static LastContent suggestion(UserLogin userLogin)
        {
            try
            {
                var url = baseUrl + "content/list/suggestion?parameter[hash]=0b6c8fbeb5039858c98be380301f2115ca46777d90d5a4b04788739f332442d2&parameter[source]=" + source + "&parameter[version]=" + version;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = TimeOut;

                request.Method = "GET";
                request.ContentType = contentType;
                request.Headers.Add("Cookie:" + userLogin.session_name + "=" + userLogin.sessid);

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(responseString);
                }
                else
                {
                    return JsonConvert.DeserializeObject<LastContent>(responseString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در فراخوانی پیشنهادات ", ex);
            }
        }

        public static AllVersion getAllVersion()
        {
            try
            {
                var url = baseUrl + "versions?hash=b64f48c6627588417677702db830ccb2ace3c3020aaa7947174f53e923b57230&type=" + source;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = TimeOut;
                request.ContentType = contentType;
                request.Method = "GET";
                request.ContentLength = 0;

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(responseString);
                }
                else
                {
                    return JsonConvert.DeserializeObject<AllVersion>(responseString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا دریافت آخرین نسخه", ex);
            }
        }

        public static int createSystem_Info(SystemInfo systemInfo,UserLogin userLogin)
        {
            try
            {
                var url = baseUrl + "system_info";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("Cookie:" + userLogin.session_name + "=" + userLogin.sessid);
                request.Headers.Add("X-CSRF-Token:" + userLogin.token);
                request.Headers.Add("Cache-Control:" + "no-cache");
                request.Timeout = TimeOut;
                var model = new
                {
                    hash = "689acec7ad164bc3fd8cf780339a052df8dda2618c26bdcdd27c79124ed36b92",
                    systemInfo.cpu_model,
                    systemInfo.cpu_serial,
                    systemInfo.hdd_serial,
                    systemInfo.main_board_serial,
                    source,
                    version
                };

                var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

                request.Method = "POST";
                request.ContentType = contentType;
                request.ContentLength = data.Length;


                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(responseString);
                }
                else
                {
                    var tempDate = JsonConvert.DeserializeObject<List<int>>(responseString);
                    return tempDate[0];
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("500"))
                    throw new Exception("خطا در ثبت یا ویرایش", ex);
                if (ex.Message.Contains("406"))
                    throw new Exception("کاربر مشخص نشده", ex);
                throw new Exception("خطا", ex);
            }
        }

        public static bool deleteSystem_Info(UserLogin userLogin)
        {
            try
            {
                var url = baseUrl + "system_info/" + userLogin.systemInfoId + "?parameter[hash]=689acec7ad164bc3fd8cf780339a052df8dda2618c26bdcdd27c79124ed36b92&parameter[source]=" + source + "&parameter[version]=" + version;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = TimeOut;

                request.Method = "DELETE";
                request.ContentType = contentType;
                request.ContentLength = 0;
                request.Headers.Add("Cookie:" + userLogin.session_name + "=" + userLogin.sessid);
                request.Headers.Add("X-CSRF-Token:" + userLogin.token);

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(responseString);
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                    throw new Exception("اطلاعات یافت نشد", ex);
                throw new Exception("خطا", ex);
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }
    }
}
