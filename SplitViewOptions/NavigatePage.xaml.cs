using ArticleandSiteData;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class NavigatePage : Page
    {
        public NavigatePage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.NavigationMode==NavigationMode.New)
            {
                List<Info> allsite = await BmobWebsiteData.Getrecommendsites(App.recommendsiteurl);
                navigateviewer.ItemsSource = allsite;
            }
        }

        private void Border_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Border obj = sender as Border;
            Info oneinfo = obj.DataContext as Info;
            App.homesiteurl = oneinfo.dataurl;
            this.Frame.Navigate(typeof(HomePage));
           
        }
    }
}
