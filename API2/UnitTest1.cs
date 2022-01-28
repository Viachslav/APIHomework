using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System.Collections.Generic;
using Xunit;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Docs.v1;
using Google.Apis.Docs.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json.Linq;

namespace API2
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetCookieAndLoginWithThem()
        {

            var body = new Dictionary<string, string>
               {
                    {"ulogin", "art1613122"},
                    {"upassword", "505558545" }
               };

            var headers = new Dictionary<string, string>
               {
                   {"content-type", "application/x-www-form-urlencoded"}
               };

            var response = API_HELPER.SendApiLogin(body, headers, "https://my.soyuz.in.ua/", Method.POST);

            var cookie = API_HELPER.ExtractCookie(response, "zbs_lang"); // работает и без него, подтягивает автоматически
            var cookie2 = API_HELPER.ExtractCookie(response, "ulogin");
            var cookie3 = API_HELPER.ExtractCookie(response, "upassword");




            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://my.soyuz.in.ua");
            System.Threading.Thread.Sleep(15000);

            chrome.Manage().Cookies.AddCookie(cookie);
            chrome.Manage().Cookies.AddCookie(cookie2);
            chrome.Manage().Cookies.AddCookie(cookie3);



            chrome.Navigate().GoToUrl("https://my.soyuz.in.ua/index.php/");

            chrome.Close();

        }

        [Fact]
        public void TestGetAndSendCookies1()
        {


            var body = new Dictionary<string, string>
            {
                 {"login_name", "slavutich765@mail.ru"},
                 {"login_password", "v83814f1sxc" }
            };

            var headers = new Dictionary<string, string>
            {
                {"content-type", "application/json"}
            };

            var response = API_HELPER.SendApiLogin(body, headers, "https://rezka.ag/", Method.POST);

            var cookie = API_HELPER.ExtractCookie(response, "PHPSESSID");
            var cookie1 = API_HELPER.ExtractCookie(response, "dle_user_taken");
            var cookie2 = API_HELPER.ExtractCookie(response, "dle_user_token");



            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://rezka.ag/");
            System.Threading.Thread.Sleep(15000);

            chrome.Manage().Cookies.AddCookie(cookie);
            chrome.Manage().Cookies.AddCookie(cookie1);
            chrome.Manage().Cookies.AddCookie(cookie2);



            chrome.Navigate().GoToUrl("https://rezka.ag/");

            chrome.Close();
        }

        [Fact]
        public void TestGetAndSendCookies2()
        {


            var body = new Dictionary<string, string>
            {
                 {"LoginForm[email]", "mega_svetlanad@ukr.net"},
                 {"LoginForm[passw]", "77uzer020" }
            };

            var headers = new Dictionary<string, string>
            {
                {"content-type", "application/x-www-form-urlencoded"}
            };

            var response = API_HELPER.SendApiLogin(body, headers, "https://dneprvoda.com.ua/ru/site/login", Method.POST);

            var cookie = API_HELPER.ExtractCookie(response, "PHPSESSID");
            var cookie1 = API_HELPER.ExtractCookie(response, "_csrf");



            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://dneprvoda.com.ua/ru");
            System.Threading.Thread.Sleep(15000);

            chrome.Manage().Cookies.AddCookie(cookie);
            chrome.Manage().Cookies.AddCookie(cookie1);

            chrome.Navigate().GoToUrl("https://dneprvoda.com.ua/ru/user/10287");

            chrome.Close();
        }

        [Fact]
        public void TestDownloadImage()
        {

            //first method
            IWebDriver chrome = new ChromeDriver();
            var image = ImageDownloader.GetPicture("https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/Google_Photos_icon_%282020%29.svg/1200px-Google_Photos_icon_%282020%29.svg.png");
        }


        [Fact]
        public void TestDownloadImage2()
        {
            WebClient client = new WebClient();
            client.DownloadFile("https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/Google_Photos_icon_%282020%29.svg/1200px-Google_Photos_icon_%282020%29.svg.png", @"C:\Users\slavu\OneDrive\Рабочий стол\API2\aaa.jpeg");
        }



        //[Fact]
        //public void TestUploadImage2()
        //{
        //    RestClient client = new RestClient("https://imgbb.com/json");

        //    RestRequest request = new RestRequest(Method.POST);

        //    var json = System.IO.File.ReadAllText("BodyCred.json");
        //      var objects = JArray.Parse(json); // parse as array  
        //    foreach(JObject root in objects)
        //    {
        //        foreach (KeyValuePair<string, JToken> app in root)
        //        {
        //            var appName = app.Key;
        //            var description = (string)app.Value["Description"];
        //            var value = (string)app.Value["Value"];
        //        }
        //    }
        //    var body = new FileStream("BodyCred.json", FileMode.Open, FileAccess.Read);



        //    var headers = new Dictionary<string, string>
        //       {
        //           {"content-type", "application/json"}
        //       };

        //    IRestResponse response = client.Execute(request);
        //    IWebDriver chrome = new ChromeDriver();
        //    chrome.Navigate().GoToUrl("https://imgbb.com/upload");

        //}







    }

}
