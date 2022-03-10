using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NitrogenXamarin2.CommonData;

namespace NitrogenXamarin2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SunflowerPage : ContentPage
    {
        public SunflowerPage()
        {
            InitializeComponent();

            sfPricePicker.SelectedIndex = 0;
            CommonFunctions.SetNitrogenCostPicker(sfNitrogenCostPicker);
            CommonFunctions.SetPreviousCropPicker(sfPreviousCropPicker);

            CommonFunctions.OnLabelTapped("Conventional Tillage", ConvDef, "Tillage greater than 2-inch depth. Thin ammonia shank or strip-till shank does not contribute to conventional till.");
            CommonFunctions.OnLabelTapped("Minimal No-till", MinDef, "No till less than 6 consecutive years; also called short-term no-till.");
            CommonFunctions.OnLabelTapped("Long-term No-till", LongDef, "No till for at least 6 consecutive years.");

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

        // 
        private int GetSunflowerFinalResult()
        {
            int sfPI = sfPricePicker.SelectedIndex;
            int NPI = sfNitrogenCostPicker.SelectedIndex;
            int bv = GetBaseValue(sfPI, NPI);
            int sfCropCredit = CommonFunctions.GetPreviousCropCredit(sfPreviousCropPicker);
            double x = Convert.ToDouble(soilTestNEntry.Text);
            int tn = (int)Math.Round(x);
            double y = Convert.ToDouble(soilOrganicMatterEntry.Text);
            int om = (int)Math.Round(y);
            return CommonFunctions.GetFinalResult(bv, sfCropCredit, tn, om);
        }

        private async void CalculateBtn_Clicked(object sender, EventArgs e)
        {
            if (CommonFunctions.IsEntryTextValid(soilTestNEntry, "TN") && CommonFunctions.IsEntryTextValid(soilOrganicMatterEntry, "OM"))
            {
                await DisplayAlert("N Recommendation After Credits", "" + GetSunflowerFinalResult() + "        " + "± 20  lbs/acre", "OK");
            }
            else
            {
                CommonFunctions.DisplayErrorMessage(soilTestNEntry, soilOrganicMatterEntry);
            }
        }

    }
}