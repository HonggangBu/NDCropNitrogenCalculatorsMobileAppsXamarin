using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
