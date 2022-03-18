using System;
using NitrogenXamarin2.CommonData;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NitrogenXamarin2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CornPage : ContentPage
    {
        public CornPage()
        {
            InitializeComponent();
            TillageDefinitionPopup();
            
        }

        private void TillageDefinitionPopup()
        {
            CommonFunctions.OnLabelTapped("Conventional Tillage", ConvDef, "Tillage greater than 2-inch depth. Thin ammonia shank or strip-till shank does not contribute to conventional till.");
            CommonFunctions.OnLabelTapped("Minimal No-till", MinDef, "No till less than 6 consecutive years; also called short-term no-till.");
            CommonFunctions.OnLabelTapped("Long-term No-till", LongDef, "No till for at least 6 consecutive years.");
        }

        private void OnAnythingChanged()
        {
            //CalculateBtn.IsVisible = true;
            //ResultStack.IsVisible = false;
            //ResultLabel.Text = "";x
            
        }

        private void RegionRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            OnAnythingChanged();
        }

        private void IrrigationTillageRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            OnAnythingChanged();
        }

        private void TextureYieldRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            OnAnythingChanged();
        }
    }
}