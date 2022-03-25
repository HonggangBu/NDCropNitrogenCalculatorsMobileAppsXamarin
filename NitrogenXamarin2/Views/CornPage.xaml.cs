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
            InitalizeSomeUI();
        }

        private void TillageDefinitionPopup()
        {
            CommonFunctions.OnLabelTapped("Conventional Tillage", ConvDef, "Tillage greater than 2-inch depth. Thin ammonia shank or strip-till shank does not contribute to conventional till.");
            CommonFunctions.OnLabelTapped("Minimal No-till", MinDef, "No till less than 6 consecutive years; also called short-term no-till.");
            CommonFunctions.OnLabelTapped("Long-term No-till", LongDef, "No till for at least 6 consecutive years.");
        }

        private void InitalizeSomeUI()
        {
            CommonFunctions.SetCropPricePicker(CornPricePicker, 6, 2, 11, 1);
            CommonFunctions.SetNitrogenCostPicker(CornNitrogenCostPicker, 4);
            CommonFunctions.SetPreviousCropPicker(CornPreviousCropPicker);
        }

        private void OnAnythingChanged()
        {
            CalculateBtn.IsVisible = true;
            ResultStack.IsVisible = false;
            ResultLabel.Text = "";
        }

        private void IrrigationRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            OnAnythingChanged();
            IrrigationHidingStack.IsVisible = nonirrigatedRBtn.IsChecked;
        }

        private void RegionRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            OnAnythingChanged();
            RegionChange();
        }

        private void RegionChange()
        {
            if (WestRBtn.IsChecked)
            {
                TillageFrame.IsVisible = false;
                TextureRiskFrame.IsVisible = false;
            }
            else
            {
                TillageFrame.IsVisible = true;
                TextureRiskFrameVisibility();
            }
        }

        private void TillageRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            OnAnythingChanged();
            TextureRiskFrameVisibility();
        }


        private void TextureRiskFrameVisibility()
        {
            if (EastRBtn.IsChecked)
            {
                TextureRiskFrame.IsVisible = !LongNotillRBtn.IsChecked;
            }
            else
            {
                TextureRiskFrame.IsVisible = false;
            }
        }


        private void TextureRiskRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            OnAnythingChanged();
        }

        private void CornPricePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnAnythingChanged();
        }

        private void CornNitrogenCostPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnAnythingChanged();
        }

        private void CornPreviousCropPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnAnythingChanged();
        }

        private void SoilTestNEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnAnythingChanged();
        }

        private void SoilOrganicMatterEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnAnythingChanged();
        }

        private string GetTextureRiskType()
        {
            if (MediumTextureRBtn.IsChecked)
            {
                return "MT";
            }
            else if (HighClayHighRiskRBtn.IsChecked)
            {
                return "HH";
            }
            else if (HighClayLowRiskRBtn.IsChecked)
            {
                return "HL";
            }
            else
            {
                return "HM";
            }
        }

        private string GetSelectionString()
        {
            string s = "";
            if (irrigatedRBtn.IsChecked)
            {
                s = "I";
            }
            else
            {
                if (WestRBtn.IsChecked)
                {
                    s = "W";
                }
                else if (LangdonRBtn.IsChecked)
                {
                    s = "L" + CommonFunctions.GetTillageType(ConvTillRBtn, MinimalNotillRBtn, LongNotillRBtn);
                }
                else if (CentralRBtn.IsChecked)
                {
                    s = "C" + CommonFunctions.GetTillageType(ConvTillRBtn, MinimalNotillRBtn, LongNotillRBtn);
                }
                else // eastern region selected
                {
                    if (LongNotillRBtn.IsChecked)
                    {
                        s = "EL";
                    }
                    else
                    {
                        s = "E" + CommonFunctions.GetTillageType(ConvTillRBtn, MinimalNotillRBtn, LongNotillRBtn) + GetTextureRiskType();
                    }
                }
            }
            return s;
        }

        private int GetBaseValue(int cornPriceIndex, int NPriceIndex)
        {
            int x = 0;
            switch (GetSelectionString())
            {
                case "I":
                    x = CornBaseTables.irrigated[cornPriceIndex, NPriceIndex];
                    break;
                case "W":
                    x = CornBaseTables.westLongNoTill[cornPriceIndex, NPriceIndex];
                    break;
                case "LC":
                    x = CornBaseTables.langdonConvTill[cornPriceIndex, NPriceIndex];
                    break;
                case "LM":
                    x = CornBaseTables.langdonMinNoTill[cornPriceIndex, NPriceIndex];
                    break;
                case "LL":
                    x = CornBaseTables.langdonLongNoTill[cornPriceIndex, NPriceIndex];
                    break;
                case "CC":
                    x = CornBaseTables.centralConvTill[cornPriceIndex, NPriceIndex];
                    break;
                case "CM":
                    x = CornBaseTables.centralMinNoTill[cornPriceIndex, NPriceIndex];
                    break;
                case "CL":
                    x = CornBaseTables.centralLongNoTill[cornPriceIndex, NPriceIndex];
                    break;
                case "EL":
                    x = CornBaseTables.eastLongNoTill[cornPriceIndex, NPriceIndex];
                    break;
                case "ECMT":
                    x = CornBaseTables.eastConvTillMediumTexture[cornPriceIndex, NPriceIndex];
                    break;
                case "ECHH":
                    x = CornBaseTables.eastConvTillHighClayHighRisk[cornPriceIndex, NPriceIndex];
                    break;
                case "ECHL":
                    x = CornBaseTables.eastConvTillHighClayLowRisk[cornPriceIndex, NPriceIndex];
                    break;
                case "ECHM":
                    x = CornBaseTables.eastConvTillMediumLeachingRisk[cornPriceIndex, NPriceIndex];
                    break;
                case "EMMT":
                    x = CornBaseTables.eastMinNoTillMediumTexture[cornPriceIndex, NPriceIndex];
                    break;
                case "EMHH":
                    x = CornBaseTables.eastMinNoTillHighClayHighRisk[cornPriceIndex, NPriceIndex];
                    break;
                case "EMHL":
                    x = CornBaseTables.eastMinNoTillHighClayLowRisk[cornPriceIndex, NPriceIndex];
                    break;
                case "EMHM":
                    x = CornBaseTables.eastMinNoTillMediumLeachingRisk[cornPriceIndex, NPriceIndex];
                    break;
                default:
                    DisplayAlert("ERROR", "Something is Wrong with the selection string!", "OK");
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
                int cropPriceIndex = CornPricePicker.SelectedIndex;
                int nitrogenPriceIndex = CornNitrogenCostPicker.SelectedIndex;
                int baseValue = GetBaseValue(cropPriceIndex, nitrogenPriceIndex);
                ResultLabel.Text = "" + CommonFunctions.GetSpecificFinalResult(baseValue, CornPreviousCropPicker, soilTestNEntry, soilOrganicMatterEntry) + "    ± 30  lbs/acre";
            }
            else
            {
                CommonFunctions.DisplayErrorMessage(soilTestNEntry, soilOrganicMatterEntry);
            }
        }

       
    }
}