using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NitrogenXamarin2.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
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
            await Browser.OpenAsync("https://www.ndsu.edu/agriculture/extension/publications/fertilizing-sunflower", BrowserLaunchMode.SystemPreferred);
        }

        private async void CornDoc_Button_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.ndsu.edu/agriculture/extension/publications/soil-fertility-recommendations-corn", BrowserLaunchMode.SystemPreferred);
        }

        private async void WheatDoc_Button_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.ndsu.edu/agriculture/extension/publications/fertilizing-hard-red-spring-wheat-and-durum", BrowserLaunchMode.SystemPreferred);
        }
    }
}