using NitrogenXamarin2.CommonData;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NitrogenXamarin2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BarleyPage : ContentPage
	{
		public BarleyPage ()
		{
			InitializeComponent ();
            InitalizeSomeUI();
            TillageDefinitionPopup();
        }

        private void InitalizeSomeUI()
        {
            CommonFunctions.SetCropPricePicker(BarleyPricePicker, 4, 3, 10, 1);
            CommonFunctions.SetNitrogenCostPicker(BarleyNitrogenCostPicker, 4);
            CommonFunctions.SetPreviousCropPicker(BarleyPreviousCropPicker);
        }

        private void TillageDefinitionPopup()
        {
            CommonFunctions.OnLabelTapped("Conventional Tillage", ConvDef, "Tillage greater than 2-inch depth. Thin ammonia shank or strip-till shank does not contribute to conventional till.");
            CommonFunctions.OnLabelTapped("Long-term No-till", LongDef, "No till for more than 5 consecutive years.");
        }

        private string GetSelectionString()
        {
            return CommonFunctions.GetRegion(westRBtn, eastRBtn, langdonRBtn) + CommonFunctions.GetTillageType(ConventionalTillRBtn, LongtermNotillRBtn);
        }

        private int GetBaseValue(int barleyPriceIndex, int NPriceIndex)
        {
            int x = 0;
            switch (GetSelectionString())
            {
                case "EC":
                    x = BarleyBaseTables.barleyEC[barleyPriceIndex, NPriceIndex];
                    break;
                case "EL":
                    x = BarleyBaseTables.barleyEL[barleyPriceIndex, NPriceIndex];
                    break;
                case "WC":
                    x = BarleyBaseTables.barleyWC[barleyPriceIndex, NPriceIndex];
                    break;
                case "WL":
                    x = BarleyBaseTables.barleyWL[barleyPriceIndex, NPriceIndex];
                    break;
                case "LC":
                    x = BarleyBaseTables.barleyLC[barleyPriceIndex, NPriceIndex];
                    break;
                case "LL":
                    x = BarleyBaseTables.barleyLL[barleyPriceIndex, NPriceIndex];
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
                CalculateBtn.IsVisible = false;
                ResultStack.IsVisible = true;
                int cropPriceIndex = BarleyPricePicker.SelectedIndex;
                int nitrogenPriceIndex = BarleyNitrogenCostPicker.SelectedIndex;
                int baseValue = GetBaseValue(cropPriceIndex, nitrogenPriceIndex);
                ResultLabel.Text = "" + CommonFunctions.GetSpecificFinalResult(baseValue, BarleyPreviousCropPicker, soilTestNEntry, soilOrganicMatterEntry) + "    ± 15  lbs/acre";
            }
            else
            {
                CommonFunctions.DisplayErrorMessage(soilTestNEntry, soilOrganicMatterEntry);
            }
        }

        private void RegionRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn,ResultStack,ResultLabel);
        }

        private void TillageRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void BarleyPricePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void BarleyNitrogenCostPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void BarleyPreviousCropPicker_SelectedIndexChanged(object sender, EventArgs e)
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