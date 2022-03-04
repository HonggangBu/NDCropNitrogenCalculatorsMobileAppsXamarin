using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NitrogenXamarin2.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizerPDF_Tapped(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://extension.soils.wisc.edu/wp-content/uploads/sites/68/2016/07/Sawyer-1.pdf", BrowserLaunchMode.SystemPreferred);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.ndsu.edu/snrs/people/faculty/dave_franzen/", BrowserLaunchMode.SystemPreferred);
        }

        private async void MaxReturnN_Button_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://extension.soils.wisc.edu/wp-content/uploads/sites/68/2016/07/Sawyer-1.pdf", BrowserLaunchMode.SystemPreferred);
        }

        private async void SunflowerDoc_Button_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.ndsu.edu/fileadmin/soils.del/pdfs/SF713__Fertilizing_Sunflower.pdf", BrowserLaunchMode.SystemPreferred);

        }

        private async void CornDoc_Button_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.ag.ndsu.edu/publications/crops/soil-fertility-recommendations-for-corn", BrowserLaunchMode.SystemPreferred);

        }

        private async void WheatDoc_Button_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.ag.ndsu.edu/publications/crops/fertilizing-hard-red-spring-wheat-and-durum-1", BrowserLaunchMode.SystemPreferred);

        }
    }
}