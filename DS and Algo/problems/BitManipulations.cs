using System;

namespace problems
{
    public static class BitManipulations
    {
        // This is my implementation
        public static int getSetBits(int n)
        {
            if (n == 0) return 0;
            return 1 + getSetBits(n & (n - 1));
        }

        // Given a non-empty array of integers, every element appears twice except for one. Find that single one.
        // constraints no extra memory, linear time taken.
        // leet code easy problem
        public static int SingleNumber(int[] nums)
        {
            int singleNumber = 0;
            foreach (int num in nums)
            {
                singleNumber = singleNumber ^ num;
            }
            return singleNumber;
        }

        // Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.
        // You may assume that the array is non-empty and the majority element always exist in the array.
        // leet code easy problem
        public static int MajorityElement(int[] nums)
        {
            int majorityElement = nums[0];
            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (majorityElement == nums[i]) count++;
                else count--;

                if (count == 0) { majorityElement = nums[i]; count = 1; }
            }
            return majorityElement;
        }

        // Reverse bits of a given 32 bits unsigned integer.
        // Input: 00000010100101000001111010011100
        // Output: 00111001011110000010100101000000
        public static uint ReverseBits(uint n)
        {
            uint reversedBits = 0;
            for (int i = 0; i < 31; i++)
            {
                if ((n & 1) == 1)
                {
                    reversedBits++;
                }
                reversedBits = reversedBits << 1;
                n = n >> 1;
            }
            return reversedBits;

        }

        // Given a non-empty array of integers, every element appears three times except for one, which appears exactly once. 
        // Find that single one.
        // constraints no extra memory, linear time taken.
        // leet code medium problem
        public static int SingleNumber2(int[] nums)
        {
            int singleNum = 0;
            for (int i = 31; i >= 0; i--)
            {
                int sum = 0;
                foreach (int num in nums)
                {
                    if ((num & (1 << i)) != 0)
                    {
                        sum++;
                    }
                }
                if (sum % 3 == 1)
                {
                    singleNum |= 1 << i;
                }
            }
            return singleNum;
        }

        // Given an integer array nums, in which exactly two elements appear only once and all the other elements appear exactly twice. 
        // Find the two elements that appear only once. You can return the answer in any order.
        // constraints no extra memory, linear time taken.
        // leet code medium problem
        public static int[] SingleNumber3(int[] nums)
        {
            int xoredNum = 0;
            foreach (int num in nums)
            {
                xoredNum ^= num;
            }
            int rightSetBitPosition = xoredNum & ~(xoredNum - 1);
            int x = 0, y = 0;
            foreach (int num in nums)
            {
                if ((num & rightSetBitPosition) != 0)
                {
                    x ^= num;
                }
                else
                {
                    y ^= num;
                }
            }
            return new int[] { x, y };
        }

        /**
         * Given a range [m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.

            Example 1:
            Input: [5,7]
            Output: 4

            Example 2:
            Input: [0,1]
            Output: 0
         */
        public static int RangeBitwiseAnd(int m, int n)
        {
            while (n >= m)
            {
                n &= n - 1;
            }
            return n;
        }

        /*
         * Given a string array words, find the maximum value of length(word[i]) * length(word[j]) where the two words do not share common letters. 
         * You may assume that each word will contain only lower case letters. If no such two words exist, return 0.

            Example 1:
            
            Input: ["abcw","baz","foo","bar","xtfn","abcdef"]
            Output: 16 
            Explanation: The two words can be "abcw", "xtfn".
            Example 2:
            
            Input: ["a","ab","abc","d","cd","bcd","abcd"]
            Output: 4 
            Explanation: The two words can be "ab", "cd".
            Example 3:
            
            Input: ["a","aa","aaa","aaaa"]
            Output: 0 
            Explanation: No such pair of words.
         * 
         * 
         */
        public static int MaxProduct(string[] words)
        {
            int[] bitRepresentationOfWords = new int[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    bitRepresentationOfWords[i] = bitRepresentationOfWords[i] | 1 << (words[i][j] - 'a' + 1);
                }
            }

            int maxProd = 0;
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if ((bitRepresentationOfWords[i] & bitRepresentationOfWords[j]) == 0 && words[i].Length * words[j].Length > maxProd)
                    {
                        maxProd = words[i].Length * words[j].Length;
                    }
                }
            }
            return maxProd;
        }

        public static bool IsPowerOfTwo(int n)
        {
            if (n == 0) return false;
            if ((n & n - 1) > 0)
            {
                return false;
            }
            return true;
        }

        /*
         * Given a positive integer n and you can do operations as follow:

            If n is even, replace n with n/2.
            If n is odd, you can replace n with either n + 1 or n - 1.
            What is the minimum number of replacements needed for n to become 1?
            
            Example 1:
            
            Input:
            8
            
            Output:
            3
            
            Explanation:
            8 -> 4 -> 2 -> 1
            Example 2:
            
            Input:
            7
            
            Output:
            4
            
            Explanation:
            7 -> 8 -> 4 -> 2 -> 1
            or
            7 -> 6 -> 3 -> 2 -> 1

            Explanation: The idea is to remove the no. of 1 in the number at any point of time. 
            But removing 1 everytime is not a correct option.
            111011 -> 111010 -> 11101 -> 11100 -> 1110 -> 111 -> 1000 -> 100 -> 10 -> 1
            And yet, this is not the best way because

            111011 -> 111100 -> 11110 -> 1111 -> 10000 -> 1000 -> 100 -> 10 -> 1

            3 is an exception
         */
        public static int IntegerReplacement(int n)
        {
            if (n == int.MaxValue) return 32;
            if (n != 1)
            {
                if (n % 2 == 0)
                {
                    return 1 + IntegerReplacement(n / 2);
                }
                else if (n == 3 || getSetBits(n + 1) > getSetBits(n - 1))
                {
                    return 1 + IntegerReplacement(n - 1);
                }
                else
                {
                    return 1 + IntegerReplacement(n + 1);
                }
            }
            return 0;
        }

        // Xor gives sum if bits are not same
        // if bits are same that sum is not considered. So its a carry which needs to be added to the bit sum again
        public static int addNumbersWithoutXor(int a, int b)
        {
            while (b != 0)
            {
                // carry generated by bit addition of these 2 bits
                int carry = a & b;

                // sum obtained by addition of bits
                a = a ^ b;
                // get carry and add it to a in next iteration
                b = carry << 1;
            }
            return a;
        }

        /**
         * Given a non negative integer number num. For every numbers i in the range 0 ≤ i ≤ num 
         * calculate the number of 1's in their binary representation and return them as an array.

            Example 1:

            Input: 2
            Output: [0,1,1]
            Example 2:
            
            Input: 5
            Output: [0,1,1,2,1,2]
         * 
         * Explanation: odd numbers have '1' in the unit bit place, even numbers will have '0' in the even bit place
         * x / 2 will have same number of bits if x is even, no. of bits - 1 if x is odd.
         * so previously calculated bits count is used to find bits for new numbers in sequence
         * **/
        public static int[] CountBits(int n)
        {
            int[] countArray = new int[n + 1];
            for(int i=1; i <= n; i++)
            {
                countArray[i] = countArray[i / 2] + (i & 1);
            }
            return countArray;
        }

    }
}