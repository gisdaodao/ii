using ModelClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ArticleandSiteData
{
    public sealed class BmobWebsiteData
    {
        public async static Task<List<T>> GetAllwebsitesinfo<T>(string str)
        {
            List<T> resualist = null;
            string resultstr = await RequestHelper.GetHttpstringrequest(str);
            resualist = (List<T>)JsonConvert.DeserializeObject(resultstr, typeof(T));
            return resualist;
        }
        public async static Task<T> GetAllwebsitesinfoone<T>(string str)
        {
            T resualist;
                string resultstr = await RequestHelper.GetHttpstringrequest(str);
            resualist = (T)JsonConvert.DeserializeObject(resultstr, typeof(T));
            return resualist;
        }
        public async static Task<System.Net.Http.HttpResponseMessage> AddoneWebsite<HttpResponseMessage>(string str,string jsonstr)
        {
            System.Net.Http.HttpResponseMessage resualist;
            resualist = await RequestHelper.PostHttpstringrequest(str, jsonstr);
          //  resualist = (T)JsonConvert.DeserializeObject(resultstr, typeof(T));
            return resualist;
        }
        public async static Task<System.Net.Http.HttpResponseMessage> AddoneWebsiteBystringcontnet<HttpResponseMessage>(string str, StringContent strcontent )
        {
            System.Net.Http.HttpResponseMessage resualist;
            resualist = await RequestHelper.PostHttpstringrequestbystringcontent(str, strcontent);
            //  resualist = (T)JsonConvert.DeserializeObject(resultstr, typeof(T));
            return resualist;
        }
        public async static Task<string> Login(string str, FormUrlEncodedContent strcontent)
        {
            string resualist;
            resualist = await RequestHelper.GetHttpstringrequest(str, strcontent);
            //  resualist = (T)JsonConvert.DeserializeObject(resultstr, typeof(T));
            return resualist;
        }
        public async static Task<T> Loginwithstriing<T>(string str)
        {
            T oneT;
            string resualist;
            resualist = await RequestHelper.GetHttpstringrequest(str);
            oneT = (T)JsonConvert.DeserializeObject(resualist, typeof(T));
            return oneT;
            //  resualist = (T)JsonConvert.DeserializeObject(resultstr, typeof(T));
          //  return resualist;
        }
            List<Info> items = new List<Info>();
        public async static Task<List<Info>> Getrecommendsites(string str)
        {
           
            Stream resualist;
            resualist = await RequestHelper.GetHttpstreamrequest(str);
            XElement p = XElement.Load(resualist);
            List<Info> items = new List<Info>();
            XName xitemname = XName.Get("item");
            IEnumerable<XElement> itemnodes = p.Descendants(xitemname).ToList<XElement>();
            foreach (var b in itemnodes) {
                XName xurl = XName.Get("url");
                XName xname = XName.Get("text");
                XName xdesname = XName.Get("des");
                items.Add(new Info() { des= b.Attributes(xdesname).First().Value, text = b.Attributes(xname).First().Value, dataurl = b.Descendants(xurl).First().Value }); }
            return items;
           
            //  resualist = (T)JsonConvert.DeserializeObject(resultstr, typeof(T));
            //  return resualist;
        }
        public async static Task<Favratesites> Getfavoratesites(string str)
        {
            
            string resualist;
            Favratesites oneT;
            resualist = await RequestHelper.GetHttpstringrequest(str);
            oneT = (Favratesites)JsonConvert.DeserializeObject(resualist, typeof(Favratesites));

            return oneT;
        }
        /// <summary>
            /// 反序列化
            /// </summary>
            /// <param name="type">类型</param>
            /// <param name="xml">XML字符串</param>
            /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
