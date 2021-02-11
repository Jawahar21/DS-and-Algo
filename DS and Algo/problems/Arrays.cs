using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace DS_and_Algo.problems
{
    public class Arrays
    {

        #region easy problems

        public static int[] SortedSquares(int[] nums)
        {
            int[] res = new int[nums.Length];
            int p1 = 0, p2 = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (Math.Abs(nums[p1]) > Math.Abs(nums[p2]))
                {
                    res[i] = nums[p1] * nums[p1];
                    p1++;
                }
                else
                {
                    res[i] = nums[p2] * nums[p2];
                    p2--;
                }
            }
            return res;
        }
        /// <summary>
        /// Given a fixed length array arr of integers, duplicate each occurrence of zero, shifting the remaining elements to the right.
        /// Note that elements beyond the length of the original array are not written.
        /// Do the above modifications to the input array in place, do not return anything from your function.
        /// Example 1:
        ///         Input: [1,0,2,3,0,4,5,0]
        ///         Output: null
        ///         Explanation: After calling your function, the input array is modified to: [1,0,0,2,3,0,0,4]
        /// Example 2:
        ///         Input: [1,2,3]
        ///         Output: null
        ///         Explanation: After calling your function, the input array is modified to: [1,2,3]
        ///         
        /// Space complexity approach
        /// </summary>
        /// <param name="arr"></param>
        public static void DuplicateZeros(int[] arr)
        {
            foreach (int elem in arr)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine(" ");
            int[] result = new int[arr.Length];
            int p1 = 0;
            for (int i = 0; i < arr.Length && p1 < arr.Length; i++)
            {
                result[p1] = arr[i];
                if (arr[i] == 0)
                {
                    if (p1 + 1 < arr.Length)
                    {
                        result[p1 + 1] = 0;
                        p1++;
                    }
                }
                p1++;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = result[i];
            }

            foreach (int elem in arr)
            {
                Console.Write(elem + " ");
            }
        }

        /// <summary>
        /// Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
        /// The number of elements initialized in nums1 and nums2 are m and n respectively.You may assume that nums1 has a size equal to m + n such that it has enough space to hold additional elements from nums2.
        /// Example 1:
        ///     Input: nums1 = [1, 2, 3, 0, 0, 0], m = 3, nums2 = [2, 5, 6], n = 3
        ///     Output: [1,2,2,3,5,6]
        /// Example 2:
        ///     Input: nums1 = [1], m = 1, nums2 = [], n = 0
        ///     Output: [1]
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1, p2 = n - 1, curr = m + n - 1;
            while (p1 >= 0 && p2 >= 0)
            {
                if (nums1[p1] >= nums2[p2])
                {
                    nums1[curr--] = nums1[p1--];
                }
                else
                {
                    nums1[curr--] = nums2[p2--];
                }
            }

            while (p2 >= 0)
            {
                nums1[curr--] = nums2[p2--];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int RemoveElement(int[] nums, int val)
        {
            int p1 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[p1++] = nums[i];
                }
            }
            return p1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int[] nums)
        {
            int prevIndex = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[prevIndex] != nums[i])
                {
                    nums[++prevIndex] = nums[i];
                }
            }
            return prevIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool CheckIfExist(int[] arr)
        {
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                int index = Array.BinarySearch(arr, 0, arr.Length, arr[i] * 2);
                if (index >= 0 && index != i) return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool ValidMountainArray(int[] arr)
        {
            if (arr.Length >= 3 && arr[0] < arr[1] && arr[^1] < arr[^2])
            {
                int i = 1;
                while (i < arr.Length - 1 && arr[i] < arr[i + 1])
                {
                    i++;
                }
                if (arr[i] == arr[i + 1]) return false;
                i++;
                while (i < arr.Length - 1 && arr[i] > arr[i + 1])
                {
                    i++;
                }
                if (i == arr.Length - 1) return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] ReplaceElements(int[] arr)
        {
            int greatest = arr[arr.Length - 1];
            arr[arr.Length - 1] = -1;
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                int temp = arr[i];
                arr[i] = greatest;
                if (temp > greatest) greatest = temp;
            }
            return arr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        public static void MoveZeroes(int[] nums)
        {
            int curr = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    continue;
                }
                nums[curr++] = nums[i];
            }

            while (curr < nums.Length)
            {
                nums[curr++] = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[] SortArrayByParity(int[] A)
        {
            int oddPointer = 0;
            int evenPointer = A.Length - 1;
            while (oddPointer < evenPointer)
            {
                while (oddPointer < A.Length && A[oddPointer] % 2 == 0)
                {
                    oddPointer++;
                }
                while (evenPointer >= 0 && A[evenPointer] % 2 != 0)
                {
                    evenPointer--;
                }
                if (oddPointer < evenPointer)
                {
                    int temp = A[oddPointer];
                    A[oddPointer] = A[evenPointer];
                    A[evenPointer] = temp;
                }
                else
                {
                    break;
                }
                oddPointer++;
                evenPointer--;
            }
            return A;

        }

        #endregion

        public static int searchInSorted(int[] arr, int N, int K)
        {

            // Your code here
            if (N <= 0) return -1;
            return binarySearch(arr, 0, N - 1, K);

        }
        private static int binarySearch(int[] arr, int low, int high, int val)
        {
            if (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == val) return mid;
                if (val < arr[mid]) return binarySearch(arr, low, mid - 1, val);
                if (val > arr[mid]) return binarySearch(arr, mid + 1, high, val);
            }
            return -1;
        }
    }
}
