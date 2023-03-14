using NitrogenXamarin2.CommonData;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NitrogenXamarin2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WheatPage : ContentPage
    {
        public WheatPage()
        {
            InitializeComponent();
            InitalizeSomeUI();
            ProductivityDefinitionPopup();
            TillageDefinitionPopup();
        }

        private void InitalizeSomeUI()
        {
            CommonFunctions.SetCropPricePicker(WheatPricePicker, 8, 3, 13, 1);
            CommonFunctions.SetNitrogenCostPicker(WheatNitrogenCostPicker, 4);
            CommonFunctions.SetPreviousCropPicker(WheatPreviousCropPicker);
        }

        private void ProductivityDefinitionPopup()
        {
            CommonFunctions.OnLabelTapped("High Historical Productiviy", HighDef, "Western ND: historical yields more than 50 bushels/acre" + "\n\n" + "Eastern ND and Langdon Area: historical yields more than 60 bushels/acre");
            CommonFunctions.OnLabelTapped("Medium Historical Productiviy", MediumDef, "Western ND: historical yields between 30 bushels/acre and 50 bushels/acre" + "\n\n" + "Eastern ND and Langdon Area: historical yields between 40 bushels/acre and 60 bushels/acre");
            CommonFunctions.OnLabelTapped("Low Historical Productiviy", LowDef, "Western ND: historical yields less than 30 bushels/acre" + "\n\n" + "Eastern ND and Langdon Area: historical yields less than 40 bushels/acre");
        }

        private void TillageDefinitionPopup()
        {
            CommonFunctions.OnLabelTapped("Conventional Tillage", ConvDef, "Tillage greater than 2-inch depth. Thin ammonia shank or strip-till shank does not contribute to conventional till.");
            CommonFunctions.OnLabelTapped("Minimal No-till", MinDef, "No till less than 6 consecutive years; also called short-term no-till.");
            CommonFunctions.OnLabelTapped("Long-term No-till", LongDef, "No till for more than 5 consecutive years.");
        }

        private string GetProductivity()
        {
            if (HighProductivityRBtn.IsChecked)
            {
                return "H";
            }
            else if (MediumProductivityRBtn.IsChecked)
            {
                return "M";
            }
            else
            {
                return "L";
            }
        }

        private string GetSelectionString()
        {
            return CommonFunctions.GetRegion(westRBtn, eastRBtn, langdonRBtn) + GetProductivity() + CommonFunctions.GetTillageType(ConventionalTillRBtn, MinNotillRBtn, LongtermNotillRBtn);
        }


        private int GetBaseValue(int wheatPriceIndex, int NPriceIndex)
        {
            int x = 0;
            switch (GetSelectionString())
            {
                case "ELC":
                    x = WheatBaseTables.wheatELC[wheatPriceIndex, NPriceIndex];
                    break;
                case "ELM":
                    x = WheatBaseTables.wheatELM[wheatPriceIndex, NPriceIndex];
                    break;
                case "ELL":
                    x = WheatBaseTables.wheatELL[wheatPriceIndex, NPriceIndex];
                    break;
                case "EMC":
                    x = WheatBaseTables.wheatEMC[wheatPriceIndex, NPriceIndex];
                    break;
                case "EMM":
                    x = WheatBaseTables.wheatEMM[wheatPriceIndex, NPriceIndex];
                    break;
                case "EML":
                    x = WheatBaseTables.wheatEML[wheatPriceIndex, NPriceIndex];
                    break;
                case "EHC":
                    x = WheatBaseTables.wheatEHC[wheatPriceIndex, NPriceIndex];
                    break;
                case "EHM":
                    x = WheatBaseTables.wheatEHM[wheatPriceIndex, NPriceIndex];
                    break;
                case "EHL":
                    x = WheatBaseTables.wheatEHL[wheatPriceIndex, NPriceIndex];
                    break;

                case "WLC":
                    x = WheatBaseTables.wheatWLC[wheatPriceIndex, NPriceIndex];
                    break;
                case "WLM":
                    x = WheatBaseTables.wheatWLM[wheatPriceIndex, NPriceIndex];
                    break;
                case "WLL":
                    x = WheatBaseTables.wheatWLL[wheatPriceIndex, NPriceIndex];
                    break;
                case "WMC":
                    x = WheatBaseTables.wheatWMC[wheatPriceIndex, NPriceIndex];
                    break;
                case "WMM":
                    x = WheatBaseTables.wheatWMM[wheatPriceIndex, NPriceIndex];
                    break;
                case "WML":
                    x = WheatBaseTables.wheatWML[wheatPriceIndex, NPriceIndex];
                    break;
                case "WHC":
                    x = WheatBaseTables.wheatWHC[wheatPriceIndex, NPriceIndex];
                    break;
                case "WHM":
                    x = WheatBaseTables.wheatWHM[wheatPriceIndex, NPriceIndex];
                    break;
                case "WHL":
                    x = WheatBaseTables.wheatWHL[wheatPriceIndex, NPriceIndex];
                    break;

                case "LLC":
                    x = WheatBaseTables.wheatLLC[wheatPriceIndex, NPriceIndex];
                    break;
                case "LLM":
                    x = WheatBaseTables.wheatLLM[wheatPriceIndex, NPriceIndex];
                    break;
                case "LLL":
                    x = WheatBaseTables.wheatLLL[wheatPriceIndex, NPriceIndex];
                    break;
                case "LMC":
                    x = WheatBaseTables.wheatLMC[wheatPriceIndex, NPriceIndex];
                    break;
                case "LMM":
                    x = WheatBaseTables.wheatLMM[wheatPriceIndex, NPriceIndex];
                    break;
                case "LML":
                    x = WheatBaseTables.wheatLML[wheatPriceIndex, NPriceIndex];
                    break;
                case "LHC":
                    x = WheatBaseTables.wheatLHC[wheatPriceIndex, NPriceIndex];
                    break;
                case "LHM":
                    x = WheatBaseTables.wheatLHM[wheatPriceIndex, NPriceIndex];
                    break;
                case "LHL":
                    x = WheatBaseTables.wheatLHL[wheatPriceIndex, NPriceIndex];
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
                int cropPriceIndex = WheatPricePicker.SelectedIndex;
                int nitrogenPriceIndex = WheatNitrogenCostPicker.SelectedIndex;
                int baseValue = GetBaseValue(cropPriceIndex, nitrogenPriceIndex);
                ResultLabel.Text = "" + CommonFunctions.GetSpecificFinalResult(baseValue, WheatPreviousCropPicker,soilTestNEntry,soilOrganicMatterEntry) + "    ± 30  lbs/acre";
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

        private void ProductivityRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void WheatPricePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void WheatNitrogenCostPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonFunctions.OnAnythingChanged(CalculateBtn, ResultStack, ResultLabel);
        }

        private void WheatPreviousCropPicker_SelectedIndexChanged(object sender, EventArgs e)
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