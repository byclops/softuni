using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02
{
    class ParkingSystem
    {
        static void Main(string[] args)
        {
            bool[,] test = new bool[10000, 10000];
            for (int i = 0; i < 10000; i++)
            {
                test[i, 0] = true;
            }

            string[] dimensions = Console.ReadLine().Split(' ');
            int r = int.Parse(dimensions[0]);
            int c = int.Parse(dimensions[1]);

            bool[,] parking = new bool[r, c];
            for (int i = 0; i < r; i++)
            {
                parking[i, 0] = true;
            }

            string line = Console.ReadLine();
            while (line != "stop")
            {
                string[] elements = line.Split(' ');
                int entryRow = int.Parse(elements[0]);
                int destRow = int.Parse(elements[1]);
                int destCol = int.Parse(elements[2]);
                int actualCol = FindPlace(parking, destRow, destCol);
                //Console.WriteLine(  "Actual:{0}", actualCol);
                if (actualCol == -1)
                {
                    Console.WriteLine("Row {0} full", destRow);
                }
                else
                {
                    parking[destRow, actualCol] = true;
                    int path = Math.Abs(destRow - entryRow) + actualCol + 1;
                    Console.WriteLine(path);
                }
                line = Console.ReadLine();

            }

            Console.WriteLine();
        }

        public static int FindPlace(bool[,] parking, int destRow, int destCol)
        {
            if (!parking[destRow, destCol])
                return destCol;
            int delta = 1;
            while (true)
            {
                bool rowFullLeft = false;
                if (IsInsideParking(parking, destRow, destCol - delta))
                {
                    if (!parking[destRow, destCol - delta])
                    {
                        return destCol - delta;
                    }

                }
                else
                {
                    rowFullLeft = true;
                }

                if (IsInsideParking(parking, destRow, destCol + delta))
                {
                    if (!parking[destRow, destCol + delta])
                    {
                        return destCol + delta;
                    }
                }
                else
                {
                    if (rowFullLeft) break;
                }

                delta++;
            }
            return -1;
        }

        public static bool IsInsideParking(bool[,] parking, int row, int col)
        {
            if (row >= 0 && col >= 0 && row < parking.GetLength(0) && col < parking.GetLength(1))
                return true;
            return false;

        }
    }
}
