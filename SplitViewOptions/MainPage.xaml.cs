using ArticleandSiteData;
using ModelClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SplitViewOptions
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
      
        string url = "http://www.letv.com/"; string name = "lll";
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string jsonstr = string.Empty;
          
            // IsWindows10OrGreater
            //  ALLSitesResult resultlist =await  BmobWebsiteData.GetAllwebsitesinfoone<ALLSitesResult>(App.getallsiteurl);
            if (string.IsNullOrEmpty(jsonstr))
            {
                //  return;
            }
            // @"{ ""url"": ""http://cili006.com/""}"；
            jsonstr = "{" + "\"" + "url" + "\"" + ":" + "\"" + url + "\"" + "," + "\"" + "name" + "\"" + ":" + "\"" + name + "\"" + "}";
           // var responce = await BmobWebsiteData.AddoneWebsite<ALLSitesResult>(App.getallsiteurl, jsonstr);
            this.MainFrame.Navigate(typeof(HomePage));
            //  Debug.WriteLine(Version.)
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            this.MySplitView.IsPaneOpen = this.MySplitView.IsPaneOpen ? false : true;
        }

        private void RadioButtonPaneItem_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;

            if (radioButton != null)
            {
                switch (radioButton.Tag.ToString())
                {
                    case "Map":
                        this.MainFrame.Navigate(typeof(MapPage));
                        break;
                }
            }
        }

        private void LoginRadioButton(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(LoginPage));
        }
        private void mostusedpage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(AddmostusedPage));
        }

        private void navigateclick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(NavigatePage));
        }

        private void homeclick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(HomePage));
        }

        private void myfavorate(object sender, RoutedEventArgs e)
        {
            if (App.loginuser != null)
            {
                this.MainFrame.Navigate(typeof(MyfavoratePage));
            }
            else
            {
                this.MainFrame.Navigate(typeof(LoginPage));
            }


        }
        private void searchbtn_Click(object sender, RoutedEventArgs e)
        {
            string text = searchbox.Text;
            string url = "https://www.baidu.com/s?wd=" + text;
            App.homesiteurl = url;
            MainFrame.Navigate(typeof(HomePage));
          //  homewebview.Navigate(new Uri(url, UriKind.RelativeOrAbsolute));
        }

        private void openbtn_Click(object sender, RoutedEventArgs e)
        {
            string str = searchbox.Text;
            if (str.StartsWith("http") || str.StartsWith("www"))
            {
             //   Uri oneuri = new Uri(str, UriKind.RelativeOrAbsolute);
                App.homesiteurl = str;
                MainFrame.Navigate(typeof(HomePage));
            }
            else if (false)
            {

            }
            else
            { }
        }

        private void aboutclick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(AboutPage));
        }
    }
}
