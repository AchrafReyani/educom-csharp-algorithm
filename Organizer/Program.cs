using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Org
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Prompt the user to enter the number of elements to sort
            Console.WriteLine("Enter amount of numbers to sort:");
            int number = Convert.ToInt32(Console.ReadLine());

            // Generate a list of random integers
            List<int> thisList = MakeList(number);
            ShowList("List", thisList);

            Stopwatch stopWatch = new Stopwatch();

            // ShiftHighestSort sorting
            ShiftHighestSort newSort = new ShiftHighestSort();
            stopWatch.Start();
            List<int> sortedList = newSort.Sort(thisList);
            stopWatch.Stop();
            ShowList("sortedList", sortedList);
            Console.WriteLine($"ShiftHighestSort elapsed time: {stopWatch.ElapsedMilliseconds} ms");

            // RotateSort sorting
            stopWatch.Reset();
            RotateSort<int> rotate = new RotateSort<int>(Comparer<int>.Default);
            stopWatch.Start();
            List<int> rotatedList = rotate.Sort(thisList);
            stopWatch.Stop();
            ShowList("rotatedList", rotatedList);
            Console.WriteLine($"RotateSort elapsed time: {stopWatch.ElapsedMilliseconds} ms");
        }

        // Generate a list of N random integers between -99 and 99
        static List<int> MakeList(int N)
        {
            var rand = new Random();
            var newList = new List<int>();

            for (int i = 0; i < N; i++)
            {
                newList.Add(rand.Next(-99, 99));
            }

            return newList;
        }

        // Display the list with a specified label
        public static void ShowList(string label, List<int> theList)
        {
            int count = theList.Count;
            if (count > 200)
            {
                count = 200; // Do not show more than 200 numbers
            }
            Console.WriteLine();
            Console.Write(label);
            Console.Write(':');
            for (int index = 0; index < count; index++)
            {
                if (index % 20 == 0) // When index can be divided by 20 exactly, start a new line
                {
                    Console.WriteLine();
                }
                // Show each number right aligned within 3 characters, with a comma and a space
                Console.Write($"{theList[index],3}, ");
            }
            Console.WriteLine();
        }
    }
}
