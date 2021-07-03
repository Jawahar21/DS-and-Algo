using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DS_and_Algo.Algorithms
{
    public class Sorting
    {
        /// <summary>
        /// Best case: O(n2)
        /// Worst case: O(n2)
        /// Avg case: O(n2)
        /// 
        /// This is useful when we have lots of data in the disk and we cannot load it in memory to sort.
        /// So this does less number of swaps and useful in such scenario.
        /// Selection sort does n swaps where as n2 comparisions
        /// very less memory consumption
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }

        /// <summary>
        /// Bubble sort performs best in case of an already sorted array
        /// best case: O(n)
        /// worst case: O(n2)
        /// avg case: O(n2)
        /// 
        /// bubble sort does n2 swaps and n2 comparisions in worst case
        /// it is slower than insertion and selection sort.
        /// it is only faster in case of already sorted array.
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                bool done = true;

                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        done = false;
                    }
                }

                if (done == true) return;
            }
        }

        /// <summary>
        /// Insertion sort is useful in case of pre sorted array. 
        /// it reduces swaps and comparisons in case of pre sorted array
        /// 
        /// its worst case scenario is a reverse sorted array when the comparisons and swaps are n2.
        /// In majority of cases it perfoms better than selection and insertion sort.
        /// 
        /// best case: O(n) sorted array
        /// worst case O(n2) 
        /// avg case o(n2)
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                    j--;
                }
            }
        }

        /// <summary>
        /// Quick sort works by divide and conquer.
        /// The comparisons are reduced to half at each iteration in ideal case.
        /// 
        /// The best case:
        /// Best case occurs when the partitions are evenly balanced. 
        /// That is the partitions size is same in case of odd length array and has only 1 difference in case of even length array.
        /// Time complexity is O(N logN).
        /// Space complexity is O(logn) calculated based on recursive call stacks stored.
        /// 
        /// The worst case:
        /// Worst case occurs when the partitions are split in a bad way
        /// that is one partition size being 0 and other partiion size being n-1;
        /// This occurs in case of already sorted array.
        /// Time complexity is O(n2);
        /// Space complexity is O(n);
        /// 
        /// This worst case scenario can be avoided by considering a randomized pivot element and moving it to the last.
        /// With this the quick sort is as quick as merge sort without using extra space
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);
                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, high);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivotElement = arr[high];
            int pivotIndex = low;
            for (int i = low; i < high; i++)
            {
                if (arr[i] <= pivotElement)
                {
                    Swap(arr, i, pivotIndex);
                    pivotIndex++;
                }
            }
            Swap(arr, pivotIndex, high);
            return pivotIndex;
        }

        private static void Swap(int[] arr, int index1, int index2)
        {
            if (index1 == index2) return;
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }


        /// <summary>
        /// Merge sort also purely works on divide and conquer method.
        /// The comparisions are reduced to half to matter what
        /// It always takes O(nlongn) time complexity and extra space of O(n)
        /// 
        /// best case: 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public static void MergeSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int mid = low + (high - low) / 2;
                MergeSort(arr, low, mid);
                MergeSort(arr, mid + 1, high);
                Merge(arr, low, mid, high);
            }
        }

        private static void Merge(int[] arr, int low, int mid, int high)
        {
            int i = low, j = mid + 1, k = 0;
            int[] temp = new int[high - low + 1];
            while (i <= mid && j <= high)
            {
                if (arr[i] < arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                }
            }

            while (i <= mid)
            {
                temp[k++] = arr[i++];
            }

            while (j <= high)
            {
                temp[k++] = arr[j++];
            }

            i = low;
            for (k = 0; k < temp.Length; k++)
            {
                arr[i++] = temp[k];
            }
        }
    }
}
