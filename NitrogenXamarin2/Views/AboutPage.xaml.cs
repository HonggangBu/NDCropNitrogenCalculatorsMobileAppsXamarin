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
    }
}