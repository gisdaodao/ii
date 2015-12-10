using ArticleandSiteData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace SplitViewOptions
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            DataTransferManager.GetForCurrentView().DataRequested += dataTransferManager_DataRequested;
        }
     async   void dataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataRequest request = args.Request;
            //We are going to use an async API to talk to the webview, so get a deferral for the results
            DataRequestDeferral deferral = args.Request.GetDeferral();
            DataPackage dp = await homewebview.CaptureSelectedContentToDataPackageAsync();
            if (dp != null && dp.GetView().AvailableFormats.Count >0)
            { // Webview has a selection, so we'll share its data package
                dp.Properties.Title = "来自多彩浏览器的分享";
                request.Data = dp;
            }
            else { 
                // No selection, so we'll share the url of the webview
                DataPackage myData = new DataPackage();
                myData.SetWebLink(homewebview.Source);
                myData.Properties.Title = "来自多彩浏览器的分享";
                myData.Properties.Description = homewebview.Source.ToString();
                request.Data = myData; }
            deferral.Complete();
        }
     
            private async void getscreen_Click(object sender, RoutedEventArgs e)
        {
            InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream();
            await homewebview.CapturePreviewToStreamAsync(ms);
            IBuffer ibuffer =await toBuffer(ms);
            SaveImage(ibuffer);
            //Create a small thumbnail
            //int longlength = 180, width = 0, height = 0;
            //double srcwidth = homewebview.ActualWidth, srcheight = homewebview.ActualHeight;
            //double factor = srcwidth / srcheight; if (factor < 1)
            //{ height = longlength; width = (int)(longlength * factor); }
            //else { width = longlength; height = (int)(longlength / factor); }
            //BitmapSource small = await resize(width, height, ms);          
        }
        async Task<Windows.Storage.Streams.IBuffer> toBuffer(Windows.Storage.Streams.IRandomAccessStream stream)
        {
            var buffer = new Windows.Storage.Streams.Buffer((uint)stream.Size);
            var ibuffer = await stream.ReadAsync(buffer, (uint)stream.Size, Windows.Storage.Streams.InputStreamOptions.None);
            return ibuffer;
        }
        private async Task<BitmapSource> resize(int width, int height, Windows.Storage.Streams.IRandomAccessStream source)
    {
            WriteableBitmap small = new WriteableBitmap(width, height);
        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(source);
        BitmapTransform transform = new BitmapTransform();
        transform.ScaledHeight = (uint)height; transform.ScaledWidth = (uint)width;
        PixelDataProvider pixelData = await decoder.GetPixelDataAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, transform, ExifOrientationMode.RespectExifOrientation, ColorManagementMode.DoNotColorManage);
        pixelData.DetachPixelData().CopyTo(small.PixelBuffer);
        return small;
        }
    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            homewebview.Navigate(new Uri(App.homesiteurl, UriKind.RelativeOrAbsolute));
        }
        private async void settofavorate_Click(object sender, RoutedEventArgs e)
        {
            if (App.loginuser == null) return;
            string jsonstr = string.Empty;            
            jsonstr = "{" + "\"" + "articleurl" + "\"" + ":" + "\"" + homewebview.Source.AbsoluteUri + "\"" + "," + "\"" + "contentname" + "\"" + ":" + "\"" + homewebview.DocumentTitle + "\"" + "," + "\"" + "userid" + "\"" + ":" + "\"" + App.loginuser.objectId + "\"" + "}";
            StringContent content = new StringContent(jsonstr);
            HttpResponseMessage oneHttpResponseMessage= await  BmobWebsiteData.AddoneWebsiteBystringcontnet<HttpResponseMessage>(App.userarticleorsiteurl, content);
            if (oneHttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                MessageDialog one = new MessageDialog("收藏成功");
                await one.ShowAsync();
            }
            else
            {
                MessageDialog one = new MessageDialog("收藏失败");
              await  one.ShowAsync();
            }


        }

        private void share_Click(object sender, RoutedEventArgs e)
        {
           // Show the share UI
                DataTransferManager.ShowShareUI();
        }

        private void searchbtn_Click(object sender, RoutedEventArgs e)
        {
            string text = searchbox.Text;
            string url = "https://www.baidu.com/s?wd=" + text;
            homewebview.Navigate(new Uri(url, UriKind.RelativeOrAbsolute));
        }

        private void openbtn_Click(object sender, RoutedEventArgs e)
        {
            string str = searchbox.Text;
            if (str.StartsWith("http") || str.StartsWith("www"))
            {
                Uri oneuri = new Uri(str, UriKind.RelativeOrAbsolute);
                homewebview.Navigate(oneuri);
            }
            else if (false)
            {

            }
            else
            { }
        }

        private void homewebview_NewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs args)
        {
            homewebview.Navigate(args.Uri);
            args.Handled = true;
        }

        private void backwebbtn_Click(object sender, RoutedEventArgs e)
        {
            if (homewebview.CanGoBack)
            {
                homewebview.GoBack();
            }
            else
            {
                if(this.Frame.CanGoBack)
                {
                    this.Frame.GoBack();
                }
            }

        }

        private async void webdefault_Click(object sender, RoutedEventArgs e)
        {
        var options = new Windows.System.LauncherOptions();
            options.TreatAsUntrusted = true;
            await Launcher.LaunchUriAsync(new  Uri( homewebview.Source.AbsoluteUri), options);
            await Windows.System.Launcher.LaunchUriAsync(new Uri(homewebview.Source.AbsoluteUri,UriKind.RelativeOrAbsolute));
        }
        private async void SaveImage(IBuffer pixelBuffer)
        {
            //Rendu du composant Xaml, ici le graphique 'Syncfusion.Chart', sous forme d'image en mémoire.
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
            //await renderTargetBitmap.RenderAsync(doughnutMadelin, (int)myDoughnutActualWidth, (int)myDoughnut.ActualHeight);
            // var pixelBuffer = await renderTargetBitmap.GetPixelsAsync();

            var localFolder = Windows.Storage.KnownFolders.PicturesLibrary;
            string filepicname = homewebview.DocumentTitle;
          //  var localFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var saveFile = await localFolder.CreateFileAsync(filepicname+".png", Windows.Storage.CreationCollisionOption.OpenIfExists);

            // Encodage de l'image en mémoire dans le fichier désigné sur le disque
            using (var fileStream = await saveFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite))
            {
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, fileStream);

                encoder.SetPixelData(
                    BitmapPixelFormat.Rgba8,
                    BitmapAlphaMode.Premultiplied,
                    (uint)homewebview.ActualWidth,
                    (uint)homewebview.ActualHeight,
                    DisplayInformation.GetForCurrentView().LogicalDpi,
                    DisplayInformation.GetForCurrentView().LogicalDpi,
                    pixelBuffer.ToArray());

                await encoder.FlushAsync();
            }
            MessageDialog one = new MessageDialog("截图保存到图片库");
            await one.ShowAsync();
        }
    }
}
