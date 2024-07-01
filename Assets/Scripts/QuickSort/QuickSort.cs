using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IQuickSort
{
    public int[] QSort(int[] nums, int lowerPos, int higherPos);
    public int LocatePivot(int lowerPos, int higherPos);
}


public class QuickSort: IQuickSort
{
    //Sort from lower to higher value

    int[] sortedList;
    public int[] QSort(int[] toSortList, int low, int high)
    {
        sortedList = toSortList;
        if (low < high)
        {
            int pivotLocation = LocatePivot(low, high);
            QSort(sortedList, low, pivotLocation);
            QSort(sortedList, pivotLocation + 1, high);
        }

        return sortedList;
    }

    public int LocatePivot(int low, int high)
    {
        int pivot = sortedList[low];
        int leftwall = low;

        int lastSwap = leftwall;
        for (int i = low; i <= high; i++)
        {
            if (sortedList[i] < pivot)
            {
                (sortedList[i], sortedList[leftwall]) = (sortedList[leftwall], sortedList[i]);
                lastSwap = i;
                leftwall++;
            }
        }
        (sortedList[lastSwap], sortedList[leftwall]) = (sortedList[leftwall], sortedList[lastSwap]);

        return leftwall; 
    }

}