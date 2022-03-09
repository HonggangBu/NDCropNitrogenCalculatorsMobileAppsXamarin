using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            CommonFunctions.SetNitrogenCostPicker(sfNitrogenCostPicker);
            CommonFunctions.SetPreviousCropPicker(sfPreviousCropPicker);
            //testLabel.Text = " "+ SunflowerBaseTables.sfWOC[0, 3] +" ";
            //DisplayAlert("Region", CommonFunctions.GetRegion(westRBtn,eastRBtn,langdonRBtn), "OK");

            CommonFunctions.OnLabelTapped("Conventional Tillage", ConvDef, "Tillage greater than 2-inch depth. Thin ammonia shank or strip-till shank does not contribute to conventional till.");
            CommonFunctions.OnLabelTapped("Minimal No-till", MinDef, "No till less than 6 consecutive years; also called short-term no-till.");
            CommonFunctions.OnLabelTapped("Long-term No-till", LongDef, "No till for at least 6 consecutive years.");

            sfPricePicker.SelectedIndex = 0;
            //double sfPrice = (double)sfPricePicker.SelectedItem;
            //double sfNPrice = (double)sfNitrogenCostPicker.SelectedItem;
            //int sfCropCredit = CommonFunctions.GetPreviousCropCredit(sfPreviousCropPicker);
           
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
        private int GetBaseValue(int sfPrice, int NPrice, string selectionString)
        {
            int x = 0;
            switch (selectionString)
            {
                case "WOC":
                    x = SunflowerBaseTables.sfWOC[sfPrice, NPrice];
                    break;
                case "WOM":
                    x = SunflowerBaseTables.sfWOM[sfPrice, NPrice];
                    break;
                case "WOL":
                    x = SunflowerBaseTables.sfWOL[sfPrice, NPrice];
                    break;
                case "WCC":
                    x = SunflowerBaseTables.sfWCC[sfPrice, NPrice];
                    break;
                case "WCM":
                    x = SunflowerBaseTables.sfWCM[sfPrice, NPrice];
                    break;
                case "WCL":
                    x = SunflowerBaseTables.sfWCL[sfPrice, NPrice];
                    break;

                case "EOC":
                    x = SunflowerBaseTables.sfEOC[sfPrice, NPrice];
                    break;
                case "EOM":
                    x = SunflowerBaseTables.sfEOM[sfPrice, NPrice];
                    break;
                case "EOL":
                    x = SunflowerBaseTables.sfEOL[sfPrice, NPrice];
                    break;
                case "ECC":
                    x = SunflowerBaseTables.sfECC[sfPrice, NPrice];
                    break;
                case "ECM":
                    x = SunflowerBaseTables.sfECM[sfPrice, NPrice];
                    break;
                case "ECL":
                    x = SunflowerBaseTables.sfECL[sfPrice, NPrice];
                    break;

                case "LOC":
                    x = SunflowerBaseTables.sfLOC[sfPrice, NPrice];
                    break;
                case "LOM":
                    x = SunflowerBaseTables.sfLOM[sfPrice, NPrice];
                    break;
                case "LOL":
                    x = SunflowerBaseTables.sfLOL[sfPrice, NPrice];
                    break;
                case "LCC":
                    x = SunflowerBaseTables.sfLCC[sfPrice, NPrice];
                    break;
                case "LCM":
                    x = SunflowerBaseTables.sfLCM[sfPrice, NPrice];
                    break;
                case "LCL":
                    x = SunflowerBaseTables.sfLCL[sfPrice, NPrice];
                    break;

                default:
                    break;
            }
            return x;
        }
        
        // Get the final recommendation (after credit) result
        private int GetFinalResult()
        {
            int x = 0;
            return x;
        }
    }
}