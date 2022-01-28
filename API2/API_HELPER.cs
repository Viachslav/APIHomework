using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Extensions;
using OpenQA.Selenium;
using System.IO;


namespace API2
{
    public static class API_HELPER
    {
        public static IRestResponse SendApiLogin(object body, Dictionary <string, string> headers, string link, Method type) 
        {
            RestClient client = new RestClient(link) 
            {
                Timeout = 300000
            };
            RestRequest request = new RestRequest(type);
            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            bool isBodyJSon = false;
            foreach (var header in headers)
            {
                if (header.Value.Contains("application/json")) ;
                {
                    isBodyJSon = true;
                    break;
                }
            }
            if (isBodyJSon)
            {
                foreach (var data in (Dictionary <string, string>) body)
                {
                    request.AddParameter(data.Key, data.Value);
                }
            }
            else
            {
                request.AddJsonBody(body);
                request.RequestFormat = DataFormat.Json;
            }
                    
            IRestResponse response = client.Execute(request);

            return response;
        }

        public static Cookie ExtractCookie(IRestResponse response, string name)
        {
            Cookie res = null;
            foreach (var cookie in response.Cookies)
                if (cookie.Name.Equals(name))
                    res = new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, null);
            return res;
        }

        public static List<Cookie> ExtractAllCookies (IRestResponse response)
        {
            List<Cookie> cookies = new List<Cookie>();
            foreach (var cookie in response.Cookies)
                cookies.Add(new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, null));

           return cookies;
            
        }

       
    }
}
