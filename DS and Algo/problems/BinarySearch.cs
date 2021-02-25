﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DS_and_Algo.problems
{
    public class BinarySearch
    {
        /// <summary>
        /// Given a non-negative integer x, compute and return the square root of x.
        /// Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int MySqrt(int x)
        {
            if (x == 0 || x == 1) return x;
            int low = 1;
            int high = x / 2;
            while (true)
            {
                int mid = low + (high - low) / 2;
                if (mid == x / mid) return mid;
                if (mid > (x / mid)) { high = mid - 1; continue; }
                if ((mid + 1) > (x / (mid + 1))) return mid;
                else { low = mid + 1; }
            }

        }

        /// <summary>
        /// We are playing the Guess Game. The game is as follows:
        /// I pick a number from 1 to n.You have to guess which number I picked.
        /// Every time you guess wrong, I will tell you whether the number I picked is higher or lower than your guess.
        /// You call a pre-defined API int guess(int num), which returns 3 possible results:
        /// -1: The number I picked is lower than your guess (i.e.pick<num).
        /// 1: The number I picked is higher than your guess (i.e.pick > num).
        /// 0: The number I picked is equal to your guess(i.e.pick == num).
        /// Return the number that I picked.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GuessNumber(int n)
        {
            int low = 1, high = n;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                // int guessResult = guess(mid);
                int guessResult = 0;
                if (guessResult == 0) return mid;
                if (guessResult == -1) high = mid - 1;
                if (guessResult == 1) low = mid + 1;
            }
            return 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search(int[] nums, int target)
        {
            if (nums.Length == 1)
            {
                if (nums[0] == target) return 0;
                return -1;
            }

            int low = 0, high = nums.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] > nums[high]) low = mid + 1;
                else
                {
                    high = mid;
                }
            }
            int pivot = low;
            if (pivot == 0)
            {
                return BinarySearchMethod(nums, 0, nums.Length - 1, target);
            }
            if (nums[pivot] <= target && target <= nums[nums.Length - 1])
            {
                return BinarySearchMethod(nums, pivot, nums.Length - 1, target);
            }
            if (nums[0] <= target && target <= nums[pivot - 1])
            {
                return BinarySearchMethod(nums, 0, pivot - 1, target);
            }
            return -1;
        }

        public static int BinarySearchMethod(int[] nums, int low, int high, int target)
        {
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] == target) return mid;
                if (target < nums[mid])
                {
                    high = mid - 1;
                }
                if (target > nums[mid])
                {
                    low = mid + 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// Input: n = 5, bad = 4
        /// Output: 4
        /// Explanation:
        /// call isBadVersion(3) -> false
        /// call isBadVersion(5) -> true
        /// call isBadVersion(4) -> true
        /// Then 4 is the first bad version.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int low = 1, high = n;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                //if (this.IsBadVersion(mid))
                if (true)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return low;
        }
    }
}
