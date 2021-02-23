using System;
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
    }
}
