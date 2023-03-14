using NitrogenXamarin2.CommonData;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NitrogenXamarin2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SunflowerPage : ContentPage
    {
        public SunflowerPage()
        {
            InitializeComponent();
            InitalizeSomeUI();
            TillageDefinitionPopup();
        }

        private void InitalizeSomeUI()
        {
            sfPricePicker.SelectedIndex = 9;
            CommonFunctions.SetNitrogenCostPicker(sfNitrogenCostPicker, 4);
            CommonFunctions.SetPreviousCropPicker(sfPreviousCropPicker);
        }

        private void TillageDefinitionPopup()
        {
            CommonFunctions.OnLabelTapped("Conventional Tillage", ConvDef, "Tillage greater than 2-inch depth. Thin ammonia shank or strip-till shank does not contribute to conventional till.");
            CommonFunctions.OnLabelTapped("Minimal No-till", MinDef, "No till equal or less than 5 consecutive years; also called short-term no-till.");
            CommonFunctions.OnLabelTapped("Long-term No-till", LongDef, "No till for more than 5 consecutive years.");
        }

        // 
        private string GetSunflowerType()
        {
            if (oilseedRBtn.IsChecked)
                return "O";
            else
                return "C";
        }
        
        // 
        private string GetSelectionString()
        {
            return CommonFunctions.GetRegion(westRBtn, eastRBtn, langdonRBtn) + GetSunflowerType() + CommonFunctions.GetTillageType(ConventionalTillRBtn, MinNotillRBtn, LongtermNotillRBtn);
        }

        // 
        private int GetBaseValue(int sfPriceIndex, int NPriceIndex)
        {
            int x = 0;
            switch (GetSelectionString())
            {
                case "WOC":
                    x = SunflowerBaseTables.sfWOC[sfPriceIndex, NPriceIndex];
                    break;
                case "WOM":
                    x = SunflowerBaseTables.sfWOM[sfPriceIndex, NPriceIndex];
                    break;
                case "WOL":
                    x = SunflowerBaseTables.sfWOL[sfPriceIndex, NPriceIndex];
                    break;
                case "WCC":
                    x = SunflowerBaseTables.sfWCC[sfPriceIndex, NPriceIndex];
                    break;
                case "WCM":
                    x = SunflowerBaseTables.sfWCM[sfPriceIndex, NPriceIndex];
                    break;
                case "WCL":
                    x = SunflowerBaseTables.sfWCL[sfPriceIndex, NPriceIndex];
                    break;

                case "EOC":
                    x = SunflowerBaseTables.sfEOC[sfPriceIndex, NPriceIndex];
                    break;
                case "EOM":
                    x = SunflowerBaseTables.sfEOM[sfPriceIndex, NPriceIndex];
                    break;
                case "EOL":
                    x = SunflowerBaseTables.sfEOL[sfPriceIndex, NPriceIndex];
                    break;
                case "ECC":
                    x = SunflowerBaseTables.sfECC[sfPriceIndex, NPriceIndex];
                    break;
                case "ECM":
                    x = SunflowerBaseTables.sfECM[sfPriceIndex, NPriceIndex];
                    break;
                case "ECL":
                    x = SunflowerBaseTables.sfECL[sfPriceIndex, NPriceIndex];
                    break;

                case "LOC":
                    x = SunflowerBaseTables.sfLOC[sfPriceIndex, NPriceIndex];
                    break;
                case "LOM":
                    x = SunflowerBaseTables.sfLOM[sfPriceIndex, NPriceIndex];
                    break;
                case "LOL":
                    x = SunflowerBaseTables.sfLOL[sfPriceIndex, NPriceIndex];
                    break;
                case "LCC":
                    x = SunflowerBaseTables.sfLCC[sfPriceIndex, NPriceIndex];
                    break;
                case "LCM":
                    x = SunflowerBaseTables.sfLCM[sfPriceIndex, NPriceIndex];
                    break;
                case "LCL":
                    x = SunflowerBaseTables.sfLCL[sfPriceIndex, NPriceIndex];
                    break;

                default:
                    break;
            }
            return x;
        }

        private void CalculateBtn_Clicked(object sender, EventArgs e)
        {
            if (CommonFunctions.IsEntryTextValid(soilTestNEntry, "TN") && CommonFunctions.IsEntryTextValid(soilOrganicMatterEntry, "OM"))
            {
                //await DisplayAlert("N Recommendation After Credits", "" + GetSunflowerFinalResult() + "        " + "± 20  lbs/acre", "OK");
                CalculateBtn.IsVisible = false; 
                ResultStack.IsVisible = true;
                int cropPriceIndex = sfPricePicker.SelectedIndex;
                int nitrogenPriceIndex = sfNitrogenCostPicker.SelectedIndex;
                int baseValue = GetBaseValue(cropPriceIndex, nitrogenPriceIndex);
                ResultLabel.Text = "" + CommonFunctions.GetSpecificFinalResult(baseValue, sfPreviousCropPicker, soilTestNEntry, soilOrganicMatterEntry) + "    ± 20  lbs/acre";
            }
            else
            {
                CommonFunctions.DisplayErrorMessage(soilTestNEntry, soilOrganicMatterEntry);
            }
        }

        private void RegionRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void TillageRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void SunflowerTypeRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void SunflowerPricePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void SunflowerPreviousCropPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void SunflowerNitrogenCostPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void SoilTestNEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void SoilOrganicMatterEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }
    }
}