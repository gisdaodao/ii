using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArticleandSiteData
{
   public class RequestHelper
    {
        public static async Task<string> GetHttpstringrequest(string requesturl)
        {
            var myClient = new HttpClient();
            var myRequest = new HttpRequestMessage(HttpMethod.Get, requesturl);
            myRequest.Version = Version.Parse("1.1");
            myRequest.Headers.Add("X-Bmob-Application-Id", "39dfc34280e39b5411c3e450466da0f2");
            myRequest.Headers.Add("X-Bmob-REST-API-Key", "4b59ff42a72875986c89551344a2b218");
            Debug.WriteLine(myRequest.Version.ToString());
            var response = await myClient.SendAsync(myRequest);
            string streamcontent = await response.Content.ReadAsStringAsync();
            return streamcontent;
        }
        public static async Task<Stream> GetHttpstreamrequest(string requesturl)
        {
            var myClient = new HttpClient();
            var myRequest = new HttpRequestMessage(HttpMethod.Get, requesturl);
            myRequest.Version = Version.Parse("1.1");
            myRequest.Headers.Add("X-Bmob-Application-Id", "39dfc34280e39b5411c3e450466da0f2");
            myRequest.Headers.Add("X-Bmob-REST-API-Key", "4b59ff42a72875986c89551344a2b218");
            Debug.WriteLine(myRequest.Version.ToString());
            var response = await myClient.SendAsync(myRequest);
            Stream streamcontent = await response.Content.ReadAsStreamAsync();
            return streamcontent;
        }
        public static async Task<string> GetHttpstringrequest(string requesturl, FormUrlEncodedContent ONEcontent)
        {
            var myClient = new HttpClient();
            var myRequest = new HttpRequestMessage(HttpMethod.Get, requesturl);
            myRequest.Version = Version.Parse("1.1");
            myRequest.Headers.Add("X-Bmob-Application-Id", "39dfc34280e39b5411c3e450466da0f2");
            myRequest.Headers.Add("X-Bmob-REST-API-Key", "4b59ff42a72875986c89551344a2b218");
            // List<  KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            //pairs.Add(new KeyValuePair<string, string>("username", "gisdaodao123@126.com"));
            //      pairs.Add(new KeyValuePair<string, string>("password", "asd1234"));
            //FormUrlEncodedContent ONEcontent = new FormUrlEncodedContent(pairs);
            myRequest.Content = ONEcontent;
            Debug.WriteLine(myRequest.Version.ToString());
            var response = await myClient.SendAsync(myRequest);
            string streamcontent = await response.Content.ReadAsStringAsync();
            return streamcontent;
        }
        public static async Task<HttpResponseMessage> PostHttpstringrequest(string requesturl,string jsonstr)
        {
            var myClient = new HttpClient();
            var myRequest = new HttpRequestMessage(HttpMethod.Post, requesturl);
            // HttpContent content = new StringContent(@"{ ""url"": ""http://cili006.com/""}");
            HttpContent content = new StringContent(jsonstr,UTF8Encoding.UTF8, "text/plain");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // Send a request asynchronously continue when complete 
            myRequest.Content = content;
            //myRequest.Version = Version.Parse("1.1");
            myRequest.Headers.Add("X-Bmob-Application-Id", "39dfc34280e39b5411c3e450466da0f2");
            myRequest.Headers.Add("X-Bmob-REST-API-Key", "4b59ff42a72875986c89551344a2b218");
            //HttpContent content= 
            //myRequest.Content=
            //// This property represents the client preference for the HTTP protocol version.
            //// The default value for UWP apps is 2.0.
            //Debug.WriteLine(myRequest.Version.ToString());
            var response = await myClient.SendAsync(myRequest);
            return response;
            //string streamcontent = await response.Content.ReadAsStringAsync();
            //return streamcontent;
        }
        public static async Task<HttpResponseMessage> PostHttpstringrequestbystringcontent(string requesturl, StringContent content)
        {
            var myClient = new HttpClient();
            var myRequest = new HttpRequestMessage(HttpMethod.Post, requesturl);
            // HttpContent content = new StringContent(@"{ ""url"": ""http://cili006.com/""}");
       
           content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // Send a request asynchronously continue when complete 
            myRequest.Content = content;
            //myRequest.Version = Version.Parse("1.1");
            myRequest.Headers.Add("X-Bmob-Application-Id", "39dfc34280e39b5411c3e450466da0f2");
            myRequest.Headers.Add("X-Bmob-REST-API-Key", "4b59ff42a72875986c89551344a2b218");
            //HttpContent content= 
            //myRequest.Content=
            //// This property represents the client preference for the HTTP protocol version.
            //// The default value for UWP apps is 2.0.
            //Debug.WriteLine(myRequest.Version.ToString());
            var response = await myClient.SendAsync(myRequest);
            return response;
            //string streamcontent = await response.Content.ReadAsStringAsync();
            //return streamcontent;
        }
      
       
    }
}
