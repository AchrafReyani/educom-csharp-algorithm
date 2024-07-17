using System;
using System.Collections.Generic;

public class RotateSort
{
    private List<int> array;

    public List<int> Sort(List<int> input)
    {
        this.array = new List<int>(input);
        SortFunction(0, array.Count - 1);
        return this.array;
    }

    private void SortFunction(int start, int end)
    {
        if (start < end)
        {
            int pivot = Partitioning(start, end);
            SortFunction(start, pivot - 1);
            SortFunction(pivot + 1, end);
        }
    }

    private int Partitioning(int start, int end)
    {
        int pivotValue = array[end];
        int i = start - 1;

        for (int j = start; j < end; j++)
        {
            if (array[j] <= pivotValue)
            {
                i++;
                // Swap array[i] and array[j]
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        // Swap array[i+1] and array[end] (pivot)
        int temp2 = array[i + 1];
        array[i + 1] = array[end];
        array[end] = temp2;

        return i + 1;
    }
}
