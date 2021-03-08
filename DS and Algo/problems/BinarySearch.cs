using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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

        /// <summary>
        /// A peak element is an element that is strictly greater than its neighbors.
        /// Given an integer array nums, find a peak element, and return its index.If the array contains multiple peaks, return the index to any of the peaks.
        /// You may imagine that nums[-1] = nums[n] = -∞.
        /// 
        /// Example 1:
        /// Input: nums = [1,2,3,1]
        /// Output: 2
        /// Explanation: 3 is a peak element and your function should return the index number 2.
        /// Example 2:
        /// Input: nums = [1,2,1,3,5,6,4]
        /// Output: 5
        /// Explanation: Your function can return either index number 1 where the peak element is 2, or index number 5 where the
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindPeakElement(int[] nums)
        {
            int low = 0, high = nums.Length - 1;
            while (low + 1 < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid - 1] < nums[mid])
                {
                    low = mid;
                }
                else
                {
                    high = mid;
                }
            }

            if (nums[low] < nums[high]) return high;
            return low;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] SearchRange(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1;
            int[] res = new int[2] { -1, -1 };
            while (low + 1 < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] < target)
                {
                    low = mid;
                }
                else
                {
                    high = mid;
                }
            }
            if (nums[low] == target) res[0] = low;
            else if (nums[high] == target) res[0] = high;

            low = 0; high = nums.Length - 1;
            while (low + 1 < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] > target)
                {
                    high = mid;
                }
                else
                {
                    low = mid;
                }
            }
            if (nums[low] == target) res[1] = low;
            else if (nums[high] == target) res[1] = high;
            return res;
        }

        /// <summary>
        /// TODO: Understand this solution
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            int left = 0;
            int right = arr.Length - k;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (x - arr[mid] > arr[mid + k] - x)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            int[] result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = arr[left + i];
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsPerfectSquare(int num)
        {
            if (num == 1) return true;
            int low = 1, high = num / 2;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (num / mid == mid) return true;
                if (num / mid < mid) { high = mid - 1; }
                else { low = mid + 1; }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static char NextGreatestLetter(char[] letters, char target)
        {
            if (letters[0] > target) return letters[0];
            int low = 0, high = letters.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (letters[mid] > target) high = mid;
                else low = mid + 1;
            }
            if (low == letters.Length - 1)
            {
                if (!(letters[low] > target)) return letters[0];
            }
            return letters[low];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMin(int[] nums)
        {
            int low = 0, high = nums.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] > nums[high])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            return nums[low];
        }

        /// <summary>
        /// Ex = [2,2,2,0,1,2], [1,3,4], [1,3,3], [3,1,1]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMinWithDuplicatesInSortedArray(int[] nums)
        {
            int low = 0, high = nums.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] > nums[high])
                {
                    low = mid + 1;
                }
                else if (nums[mid] < nums[low])
                {
                    high = mid;
                    low++;
                }
                else if (nums[low] < nums[mid])
                {
                    high = mid;
                }
                else
                {
                    high--;
                }
            }
            return nums[low];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> set = new HashSet<int>(nums1);
            List<int> res = new List<int>();
            foreach (int num in nums2)
            {
                if (set.Contains(num))
                {
                    res.Add(num);
                    set.Remove(num);
                }
            }
            return res.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] IntersectWithDuplicates(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> countArray = new Dictionary<int, int>();
            for(int i = 0; i < nums1.Length; i++)
            {
                if (countArray.ContainsKey(nums1[i]))
                {
                    countArray[nums1[i]]++;
                }
                else
                {
                    countArray.Add(nums1[i], 1);
                }
            }
            List<int> res = new List<int>();
            for (int i = 0; i < nums2.Length; i++)
            {
                if (countArray.ContainsKey(nums2[i]))
                {
                    res.Add(nums2[i]);
                    if (countArray[nums2[i]] == 1)
                    {
                        countArray.Remove(nums2[i]);
                    }
                    else
                    {
                        countArray[nums2[i]]--;
                    }
                }
            }
            return res.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            int low = 0, high = numbers.Length - 1;
            while(true)
            {
                int sum = numbers[low] + numbers[high];
                if (sum == target) return new int[2] { low + 1, high + 1 };
                else if(sum > target)
                {
                    high--;
                }
                else
                {
                    low++;
                }
            }
        }
    }
}
