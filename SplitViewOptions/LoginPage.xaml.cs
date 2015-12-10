using ArticleandSiteData;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace SplitViewOptions
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        

        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            //      List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            //      pairs.Add(new KeyValuePair<string, string>("username", "gisdaodao123@126.com"));
            //      pairs.Add(new KeyValuePair<string, string>("password", "asd1234"));
            //      FormUrlEncodedContent ONEcontent = new FormUrlEncodedContent(pairs);
            //string jsonstr=await      BmobWebsiteData.Login(App.loginsiteurl, ONEcontent);
            // HttpUtility.UrlEncode
            string loginurl = "?username="+ username .Text+ "&&password="+userpassword.Text;
            LoginReturnUser jsonstr = await BmobWebsiteData.Loginwithstriing<LoginReturnUser>(App.loginsiteurl+ loginurl);
            // System.Uri.EscapeDataString("字符");

            if (jsonstr.objectId != null)
            {
                App.loginuser = jsonstr;
                Windows.Storage.ApplicationDataContainer localSettings =
    Windows.Storage.ApplicationData.Current.LocalSettings;
                if (jsonstr.phone == null)
                {
                    jsonstr.phone = "15952003521";
                }

                localSettings.Values["objectId"] = jsonstr.objectId;
                localSettings.Values["username"] = jsonstr.username;
                localSettings.Values["updatedAt"] = jsonstr.updatedAt;
                localSettings.Values["sessionToken"] = jsonstr.sessionToken;
                localSettings.Values["createdAt"] = jsonstr.createdAt;
                MessageDialog one = new MessageDialog("登录成功");
                one.ShowAsync();
            }
            else
            {
                MessageDialog one = new MessageDialog("登录失败");
                one.ShowAsync();
            }
        
        }

        private  async void registerbrn_Click(object sender, RoutedEventArgs e)
        {
           string jsonstr = "{" + "\"" + "username" + "\"" + ":" + "\"" + registeruername.Text + "\"" + "," + "\"" + "password" + "\"" + ":" + "\"" + registeuerpassword.Text + "\""+ "," + "\"" + "phone" + "\"" + ":" + "\"" + registeuerpassword.Text + "\"" + "}";
           var responce = await BmobWebsiteData.AddoneWebsite<ALLSitesResult>(App.getallsiteurl, jsonstr);
            if(responce.StatusCode== System.Net.HttpStatusCode.Created)
            {
                MessageDialog one = new MessageDialog("注册成功,请登录");
              await  one.ShowAsync();
            }
            else
            {
                MessageDialog one = new MessageDialog("注册失败");
               await one.ShowAsync();
            }
        }



    }
}
