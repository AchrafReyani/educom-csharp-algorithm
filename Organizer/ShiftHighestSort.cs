﻿using System;
using System.Collections.Generic;

public class ShiftHighestSort
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
        for (int i = 0; i < end; i++)
        {
            for (int j = 0; j < end - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Swap elements
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}
