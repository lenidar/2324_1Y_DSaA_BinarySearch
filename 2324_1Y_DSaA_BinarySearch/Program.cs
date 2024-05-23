using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2324_1Y_DSaA_BinarySearch
{
    internal class Program
    {
        /// <summary>
        /// Binary search is a search algorithm that searches using division
        /// 
        /// Binary search would only work if the collection is sorted
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] numArr = new int[20];
            bool[] numFound = new bool[20];
            string uInput = "";
            int numSearch = 0;
            int[] binarySearch = new int[] { 0, 10, 19};
            int searchCount = 0;
            int addSearch = 0;
            int searchResult = 0;


            for (int x = 0; x < numArr.Length; x++)
                numArr[x] = rnd.Next(1, 101);

            foreach (int num in numArr)
                Console.Write(num + "   ");

            Console.WriteLine("\nLets assume these are the only numbers in the collection....");
            Console.WriteLine("And we need to look for a specific number.\n");

            while (numSearch <= 0)
            {
                Console.Write("What is the number we shall be looking for? ");
                uInput = Console.ReadLine();
                try
                {
                    numSearch = int.Parse(uInput);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to continue...");
                }
            }

            Console.WriteLine($"\nWe shall be looking for all instances of the number {numSearch}...");
            Console.WriteLine("But before we do... we need to sort the collection...");

            // bubble sort
            int temp = 0;
            for (int a = 0; a < numArr.Length; a++)
            {
                for (int x = 0; x < numArr.Length - 1; x++)
                {
                    if (numArr[x] > numArr[x + 1])
                    {
                        temp = numArr[x];
                        numArr[x] = numArr[x + 1];
                        numArr[x + 1] = temp;
                    }
                }
            }

            Console.WriteLine("The sorted collection...");
            foreach (int num in numArr)
                Console.Write(num + "   ");

            Console.WriteLine("\nBeginning the binary search...");

            while (true)
            {
                Console.WriteLine("Highlighting the points of interst");
                for (int x = 0; x < numArr.Length; x++)
                {
                    if (binarySearch.Contains(x))
                        Console.ForegroundColor = ConsoleColor.Green;
                    if (binarySearch[1] == x)
                        Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.Write(numArr[x] + "    ");
                    Console.ResetColor();

                }
                Console.WriteLine("\nTake note of the midpoint as it will determine if we search to the left or right of it...");
                if (numArr[binarySearch[1]] == numSearch)
                {
                    numFound[binarySearch[1]] = true;
                    searchResult++;
                    break;
                }
                else if (numArr[binarySearch[1]] < numSearch) // right
                {
                    binarySearch[0] = binarySearch[1];
                    binarySearch[1] = (binarySearch[0] + binarySearch[2]) / 2;
                }
                else // left
                {
                    binarySearch[2] = binarySearch[1];
                    binarySearch[1] = (binarySearch[0] + binarySearch[2]) / 2;
                }
                searchCount++;
                Console.ReadKey();
            }
            Console.WriteLine($"\nI have found where the number is, now im checking if there are others like it...");
            addSearch = binarySearch[1] - 1;
            while (true) // search left
            {
                if (numArr[addSearch] == numSearch)
                {
                    numFound[addSearch] = true;
                    searchCount++;
                    addSearch--;
                    searchResult++;
                }
                else
                    break;
            }
            addSearch = binarySearch[1] + 1;
            while (true) // search right
            {
                if (numArr[addSearch] == numSearch)
                {
                    numFound[addSearch] = true;
                    searchCount++;
                    addSearch++;
                    searchResult++;
                }
                else
                    break;
            }

            for (int y = 0; y < numArr.Length; y++)
            {
                if (numFound[y])
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(numArr[y] + "   ");
                Console.ResetColor();
            }
            Console.WriteLine($"\n\nDone searching! After {searchCount} comparisons, I have found {searchResult} results for {numSearch}.");
            Console.ReadKey();
        }
    }
}
