using System;
using System.Collections.Generic;

namespace Org
{
    public class ShiftHighestSort
    {
        // The array to be sorted
        private List<int> array = new List<int>();

        // The Sort method that sorts the input list using a bubble sort algorithm
        public List<int> Sort(List<int> input)
        {
            // Copy the input list to the array field
            array = new List<int>(input);
            int n = array.Count;

            // Outer loop for the number of passes needed
            for (int i = 0; i < n - 1; i++)
            {
                // Inner loop for each comparison in the current pass
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Compare adjacent elements and swap if they are in the wrong order
                    if (array[j] > array[j + 1])
                    {
                        Swap(j, j + 1);
                    }
                }
            }

            // Return the sorted array
            return array;
        }

        // Helper method to swap two elements in the array
        private void Swap(int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
