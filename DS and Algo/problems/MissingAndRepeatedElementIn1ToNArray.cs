using System;
using System.Collections.Generic;

namespace problems
{
    public static class MissingAndRepeatedElementIn1ToNArray
    {
        /*
         * O(N) is the time complexity
         * O(N) is the space complexity
         * @param inputArray - array of size N which contains numbers 1 to N 
         */
        public static void printTheNumbers(int[] inputArray)
        {
            int repeatedNum = 0, missingNum = 0;
            Dictionary<int, int> mapOfNumberAndIndex = new Dictionary<int, int>();
            // N operations
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (!mapOfNumberAndIndex.TryAdd(inputArray[i], i))
                {
                    repeatedNum = inputArray[i];
                }
            }
            // N operations
            for (int i = 1; i <= inputArray.Length; i++)
            {
                if (!mapOfNumberAndIndex.ContainsKey(i))
                {
                    missingNum = i;
                    break;
                }
            }
            Console.WriteLine("Repeated Number: " + repeatedNum);
            Console.WriteLine("Missing Number: " + missingNum);
        }

        public static void printNumbersGFG(int[] arr)
        {
			int n = arr.Length;
			/* Will hold xor of all elements 
		and numbers from 1 to n */
			int xor1;

			/* Will have only single set bit of xor1 */
			int set_bit_no;

			int i;
			int x = 0;
			int y = 0;

			xor1 = arr[0];

			/* Get the xor of all array elements */
			for (i = 1; i < n; i++)
				xor1 = xor1 ^ arr[i];

			/* XOR the previous result with numbers from 
			1 to n*/
			for (i = 1; i <= n; i++)
				xor1 = xor1 ^ i;

			/* Get the rightmost set bit in set_bit_no */
			set_bit_no = xor1 & ~(xor1 - 1);

			/* Now divide elements in two sets by comparing 
			rightmost set bit of xor1 with bit at same 
			position in each element. Also, get XORs of two 
			sets. The two XORs are the output elements.The 
			following two for loops serve the purpose */
			for (i = 0; i < n; i++)
			{
				if ((arr[i] & set_bit_no) != 0)

					/* arr[i] belongs to first set */
					x = x ^ arr[i];

				else

					/* arr[i] belongs to second set*/
					y = y ^ arr[i];
			}
			for (i = 1; i <= n; i++)
			{
				if ((i & set_bit_no) != 0)

					/* i belongs to first set */
					x = x ^ i;

				else

					/* i belongs to second set*/
					y = y ^ i;
			}

			/* *x and *y hold the desired output elements */
		}
	}
}
