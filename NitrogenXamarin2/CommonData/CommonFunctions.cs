﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NitrogenXamarin2.CommonData
{
    public static class CommonFunctions
    {
        public static int[,] GetNewTable(int[,] inputTable, int difference)
        {
            int nRow = inputTable.GetLength(0);
            int nColumn = inputTable.GetLength(1);
            int[,] outputTable = new int[nRow, nColumn];
            for (int i = 0; i < nRow; ++i)
            {
                for (int j = 0; j < nColumn; ++j)
                {
                    outputTable[i, j] = inputTable[i, j];
                    if (outputTable[i, j] > 0)
                    {
                        outputTable[i, j] += difference;
                        if (outputTable[i, j] < 0)
                        {
                            outputTable[i, j] = 0;
                        }
                    }
                }
            }
            return outputTable;
        }


        public static void OnLabelTapped(string title, Label label, string text)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            //tapGestureRecognizer.NumberOfTapsRequired = 2; // double-tap
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                await Application.Current.MainPage.DisplayAlert(title, text, "OK");
            };
            label.GestureRecognizers.Add(tapGestureRecognizer);
        }


        public static string GetRegion(RadioButton westND, RadioButton eastND, RadioButton langdonArea)
        {
            if (westND.IsChecked)
            {
                return "W";
            }
            else if (eastND.IsChecked)
            {
                return "E";
            }
            else
            {
                return "L";
            }
        }


        public static string GetRegion(RadioButton westND, RadioButton eastND)
        {
            return westND.IsChecked ? "W" : "E";
        }


        public static string GetTillageType(RadioButton convTill, RadioButton minNotill, RadioButton longTermNotill)
        {
            if (convTill.IsChecked)
            {
                return "C";
            }
            else if (minNotill.IsChecked)
            {
                return "M";
            }
            else
            {
                return "L";
            }
        }


        public static void SetNitrogenCostPicker(Picker nitrogenPicker)
        {
            double startValue = 0.2, commonDifference = 0.1, NumValues = 19;
            List<double> costList = new List<double>();
            for (int i = 0; i < NumValues; i++)
            {
                costList.Add(startValue + i * commonDifference);
            }
            nitrogenPicker.ItemsSource = costList;
            nitrogenPicker.SelectedIndex = 0;
        }


        public static void SetPreviousCropPicker(Picker previousCropPicker)
        {
            List<string> cropList = new List<string>();
            cropList.Add("no nitrogen-supplying crop");
            cropList.Add("Soybean, Dry Bean, Field Pea, Lentil, Chickpea, or harvested Sweet Clover");
            cropList.Add("sugarbeet with yellow leaves at harvest");
            cropList.Add("sugarbeet with yellow-green leaves at harvest");
            cropList.Add("sugarbeet with dark-green leaves at harvest");
            cropList.Add("harvested alfalfa or unharvested sweet clover (5+ plants per sqft)");
            cropList.Add("harvested alfalfa or unharvested sweet clover (3-4 plants per sqft)");
            cropList.Add("harvested alfalfa or unharvested sweet clover (1-2 plants per sqft)");
            cropList.Add("harvested alfalfa or unharvested sweet clover (less than 1 plants per sqft)");
            previousCropPicker.ItemsSource = cropList;
            previousCropPicker.SelectedIndex = 0;
        }

        public static int GetPreviousCropCredit(Picker cropPicker)
        {
            int[] credits = { 0, 40, 0, 30, 80, 150, 100, 50, 0 }; // same order as the previous crops dropdown list
            return credits[cropPicker.SelectedIndex];
        }

        // entry type: "TN"---soil test nitrate N; "OM"---soil organic matter in percentage
        public static bool IsEntryTextValid(Entry entry, string entryType)
        {
            bool isValid = true;
            string t = entry.Text;
            if (string.IsNullOrEmpty(t))
            {
                isValid = false;
            }
            else
            {
                double x = Convert.ToDouble(t);
                if ((x > 100 && entryType == "OM") || (x < 0))
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        // Get the final recommendation (after credit) result
        public static int GetFinalResult(int baseValue, int prevCropNCredit, int soilTestNCredit, int soilOrganicMatterNCredit)
        {
            int x = baseValue - prevCropNCredit - soilTestNCredit - soilOrganicMatterNCredit;
            return x > 0 ? x : 0;
        }

        //
        public static async void DisplayErrorMessage(Entry nitrateNEntry, Entry organicMatterEntry)
        {
            if (IsEntryTextValid(nitrateNEntry, "TN") && !IsEntryTextValid(organicMatterEntry, "OM"))
            {
                await Application.Current.MainPage.DisplayAlert("Input Error", "Your soil organic matter percentage input is invalid!", "OK");
            }
            else if (!IsEntryTextValid(nitrateNEntry, "TN") && IsEntryTextValid(organicMatterEntry, "OM"))
            {
                await Application.Current.MainPage.DisplayAlert("Input Error", "Your soil test nitrate-nitrogen input is invalid!", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Input Error", "Both the soil test nitrate-nitrogen input and the soil organic matter percentage input are invalid!", "OK");
            }
        }
    }
}
