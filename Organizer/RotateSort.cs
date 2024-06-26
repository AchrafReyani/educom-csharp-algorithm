using System;
using System.Collections.Generic;

namespace Org
{
    public class RotateSort<T>
    {
        // Property to store the comparer used for sorting
        public IComparer<T> Comparer { get; set; }

        // Default constructor
        public RotateSort() { }

        // Constructor that takes a comparer as an argument
        public RotateSort(IComparer<T> comparer)
        {
            this.Comparer = comparer;
        }

        // Sort method that sorts the input list
        public List<T> Sort(List<T> input)
        {
            // Return the input if it's null or has fewer than 2 elements
            if (input == null || input.Count < 2)
            {
                return input;
            }

            // Throw an exception if the comparer is not set
            if (Comparer == null)
            {
                throw new InvalidOperationException("Comparer is not set.");
            }

            // Find the index of the smallest element
            int smallestIndex = FindSmallestIndex(input);
            // Rotate the array so that the smallest element is at the start
            Rotate(input, smallestIndex);
            // Sort the array using the comparer
            input.Sort(Comparer);
            // Return the sorted array
            return input;
        }

        // Method to find the index of the smallest element in the array
        private int FindSmallestIndex(List<T> array)
        {
            int smallestIndex = 0;
            for (int i = 1; i < array.Count; i++)
            {
                // Update the smallestIndex if a smaller element is found
                if (Comparer.Compare(array[i], array[smallestIndex]) < 0)
                {
                    smallestIndex = i;
                }
            }
            return smallestIndex;
        }

        // Method to rotate the array so that the element at the given index is at the start
        private void Rotate(List<T> array, int index)
        {
            // If the index is 0, no rotation is needed
            if (index == 0)
                return;

            // Create a temporary list to store the rotated array
            List<T> temp = new List<T>(array.Count);

            // Add the elements from the index to the end of the array
            for (int i = index; i < array.Count; i++)
            {
                temp.Add(array[i]);
            }

            // Add the elements from the start of the array to the index
            for (int i = 0; i < index; i++)
            {
                temp.Add(array[i]);
            }

            // Copy the rotated elements back to the original array
            for (int i = 0; i < array.Count; i++)
            {
                array[i] = temp[i];
            }
        }
    }
}
