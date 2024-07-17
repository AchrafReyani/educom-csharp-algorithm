using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("How many elements should be in the list? Please enter a number:");
        int n = int.Parse(Console.ReadLine());

        List<int> randomList = GenerateRandomList(n);

        Console.WriteLine("\nUnsorted list:");
        PrintList(randomList);

        // ShiftHighestSort
        ShiftHighestSort shiftHighestSort = new ShiftHighestSort();
        List<int> sortedShiftHighest = SortAndTime(shiftHighestSort, randomList);
        ValidateSorted(sortedShiftHighest);

        // KeepListSorted
        KeepListSorted keepListSorted = new KeepListSorted();
        List<int> sortedKeepList = SortAndTime(keepListSorted, randomList);
        ValidateSorted(sortedKeepList);

        // RotateSort
        RotateSort rotateSort = new RotateSort();
        List<int> sortedRotate = SortAndTime(rotateSort, randomList);
        ValidateSorted(sortedRotate);
    }

    static List<int> GenerateRandomList(int n)
    {
        List<int> randomList = new List<int>();
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            randomList.Add(random.Next(-99, 100)); // numbers between -99 and 99
        }
        return randomList;
    }

    static void PrintList(List<int> list)
    {
        int maxPrint = Math.Min(200, list.Count);
        for (int i = 0; i < maxPrint; i++)
        {
            Console.Write($"{list[i]} ");
        }
        Console.WriteLine();
    }

    static List<int> SortAndTime(dynamic sorter, List<int> list)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        List<int> sortedList = sorter.Sort(list);
        stopwatch.Stop();

        Console.WriteLine("\nSorted list:");
        PrintList(sortedList);
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms");

        return sortedList;
    }

    static void ValidateSorted(List<int> sortedList)
    {
        for (int i = 1; i < sortedList.Count; i++)
        {
            if (sortedList[i] < sortedList[i - 1])
            {
                Console.WriteLine("SortError: List has not been sorted correctly.");
                return;
            }
        }
        Console.WriteLine("Sortvalidation: List has been correctly sorted");
    }
}
