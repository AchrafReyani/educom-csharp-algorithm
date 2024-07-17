using System;
using System.Collections.Generic;

public class KeepListSorted
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
        for (int i = start + 1; i <= end; i++)
        {
            int selected = array[i];
            int j = i - 1;
            while (j >= start && array[j] > selected)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = selected;
        }
    }
}
