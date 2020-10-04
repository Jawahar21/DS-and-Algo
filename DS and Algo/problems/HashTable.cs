using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_and_Algo.problems
{
    public class HashTable
    {
        /**
         * Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
            You may assume that each input would have exactly one solution, and you may not use the same element twice.
            You can return the answer in any order.

            Example 1:

            Input: nums = [2,7,11,15], target = 9
            Output: [0,1]
            Output: Because nums[0] + nums[1] == 9, we return [0, 1].

            Example 2:

            Input: nums = [3,2,4], target = 6
            Output: [1,2]

            Example 3:
            Input: nums = [3,3], target = 6
            Output: [0,1]
         * **/
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numIndexPair = new Dictionary<int, int>();
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                if (numIndexPair.ContainsKey(target - nums[i]))
                {
                    result[0] = i;
                    result[1] = numIndexPair[target - nums[i]];
                    return result;
                }
                if (!numIndexPair.ContainsKey(nums[i]))
                {
                    // handling duplicates
                    numIndexPair.Add(nums[i], i);
                }

            }
            return result;
        }


        /*
         * Write an algorithm to determine if a number n is "happy".
         * A happy number is a number defined by the following process: Starting with any positive integer, 
         * replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), 
         * or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.
         * Return True if n is a happy number, and False if not.
         * 
         * Input: 19
         * Output: true
         * Explanation: 
         * 12 + 92 = 82
         * 82 + 22 = 68
         * 62 + 82 = 100
         * 12 + 02 + 02 = 1
         * **/
        public static bool IsHappy(int n)
        {
            HashSet<int> digitsSquaredNumbers = new HashSet<int>();
            while (digitsSquaredNumbers.Add(n))
            {
                int squaredSum = 0;
                while (n > 0)
                {
                    int d = n % 10;
                    squaredSum += d * d;
                    n /= 10;
                }
                if (squaredSum == 1)
                {
                    return true;
                }
                else
                {
                    n = squaredSum;
                }
            }
            return false;
        }

        /*
         * You are playing the Bulls and Cows game with your friend.
            You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
            The number of "bulls", which are digits in the guess that are in the correct position.
            The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. 
            Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
            Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
            The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.

            Refer leetcode hashtable Bulls and Cows medium problem for examples
         * **/
        public static string GetHint(string secret, string guess)
        {
            Dictionary<char, int> mapOfNumberAndCount = new Dictionary<char, int>();
            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (!mapOfNumberAndCount.TryAdd(secret[i], 1))
                {
                    mapOfNumberAndCount[secret[i]]++;
                }
            }

            for (int i = 0; i < guess.Length; i++)
            {
                if (mapOfNumberAndCount.ContainsKey(guess[i]))
                {
                    if (secret[i].Equals(guess[i]))
                    {
                        bulls++;
                        if (mapOfNumberAndCount[guess[i]] > 0)
                        {
                            mapOfNumberAndCount[guess[i]]--;
                        }
                        else
                        {
                            cows--;
                        }
                    }
                    else
                    {
                        if (mapOfNumberAndCount[guess[i]] > 0)
                        {
                            cows++;
                            mapOfNumberAndCount[guess[i]]--;
                        }

                    }
                }
            }
            return bulls + "A" + cows + "B";
        }

        /*
         * Given a non-empty array of integers, return the k most frequent elements.
         * Example 1:

            Input: nums = [1,1,1,2,2,3], k = 2
            Output: [1,2]
            Example 2:
            
            Input: nums = [1], k = 1
            Output: [1]
         * **/
        public static int[] TopKFrequent(int[] nums, int k)
        {
            List<int>[] bucket = new List<int>[nums.Length + 1];
            Dictionary<int, int> numCountMap = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!numCountMap.TryAdd(num, 1))
                {
                    numCountMap[num]++;
                }
            }

            foreach (KeyValuePair<int, int> numCountPair in numCountMap)
            {
                if (bucket[numCountPair.Value] == null) bucket[numCountPair.Value] = new List<int>();
                bucket[numCountPair.Value].Add(numCountPair.Key);
            }
            int[] result = new int[k];
            for (int i = bucket.Length - 1; i > 0; i--)
            {
                if (bucket[i] != null)
                {
                    for (int j = 0; j < bucket[i].Count && k != 0; j++)
                    {
                        result[k-- - 1] = bucket[i][j];
                    }
                    if (k == 0) break;
                }
            }
            return result;
        }

        /*
         * Given an array of strings strs, group the anagrams together. You can return the answer in any order.
         * An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
         * typically using all the original letters exactly once.
         * Example 1:

            Input: strs = ["eat","tea","tan","ate","nat","bat"]
            Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
            Example 2:
            
            Input: strs = [""]
            Output: [[""]]
            Example 3:
            
            Input: strs = ["a"]
            Output: [["a"]]
         * **/
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> anagrams = new Dictionary<string, IList<string>>();
            foreach (string str in strs)
            {
                char[] charArray = new char[26];
                foreach (char c in str)
                {
                    charArray[c - 'a']++;
                }
                string stringKey = new string(charArray);
                if (anagrams.ContainsKey(stringKey))
                {
                    anagrams[stringKey].Add(str);
                }
                else
                {
                    anagrams[stringKey] = new List<string>() { str };
                }
            }
            return anagrams.Values.ToList();
        }

        /*
         * Determine if a 9x9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

            Each row must contain the digits 1-9 without repetition.
            Each column must contain the digits 1-9 without repetition.
            Each of the 9 3x3 sub-boxes of the grid must contain the digits 1-9 without repetition.

            Solution explanation: The idea is to create a hash key for each position such that,
                when duplicate hash is found when repeated in row, or in column, or in 3X3 grid of sudoku
            - hash 4 in 7th row as 7(4) - ensures uniqueness in row
            - hash 4 in 1st column as (4)1 - ensures uniqueness in column
            - hash 4 in 7th row 1st column  as 7/3 (4) 1/3 which is 2(4)0 - ensures uniqueness in 3X3 grid.   
         * **/
        public static bool IsValidSudoku(char[][] board)
        {
            HashSet<string> keys = new HashSet<string>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        string num = "(" + board[i][j] + ")";

                        if (!keys.Add(i + num) || !keys.Add(num + j) || !keys.Add(i / 3 + num + j / 3))
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }

        /*
         * Given a string, sort it in decreasing order based on the frequency of characters.

            Example 1:
            Input:
            "tree"
            
            Output:
            "eert"
            
            Explanation:
            'e' appears twice while 'r' and 't' both appear once.
            So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.
            
            Example 2:
            Input:
            "cccaaa"
            
            Output:
            "cccaaa"
            
            Explanation:
            Both 'c' and 'a' appear three times, so "aaaccc" is also a valid answer.
            Note that "cacaca" is incorrect, as the same characters must be together.
            
            Example 3:
            Input:
            "Aabb"
            
            Output:
            "bbAa"
            
            Explanation:
            "bbaA" is also a valid answer, but "Aabb" is incorrect.
            Note that 'A' and 'a' are treated as two different characters

            Solution: To use bucket sort
         * **/
        public static string FrequencySort(string s)
        {
            StringBuilder sb = new StringBuilder();
            List<char>[] buckets = new List<char>[s.Length + 1];
            Dictionary<char, int> charFrequencyMap = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!charFrequencyMap.TryAdd(c, 1))
                {
                    charFrequencyMap[c]++;
                }
            }

            foreach (KeyValuePair<char, int> charFrequencyPair in charFrequencyMap)
            {
                if (buckets[charFrequencyPair.Value] == null)
                {
                    buckets[charFrequencyPair.Value] = new List<char>();
                }
                for (int i = 0; i < charFrequencyPair.Value; i++)
                {
                    buckets[charFrequencyPair.Value].Add(charFrequencyPair.Key);
                }
            }

            for (int i = buckets.Length - 1; i > 0; i--)
            {
                if (buckets[i] != null)
                {
                    sb.Append(buckets[i].ToArray());
                }
            }
            return sb.ToString();
        }

        /**
         * Given an array of citations (each citation is a non-negative integer) of a researcher, write a function to compute the researcher's h-index.

            According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers have at least h citations each, and the other N − h papers have no more than h citations each."
            
            Example:
            
            Input: citations = [3,0,6,1,5]
            Output: 3 
            Explanation: [3,0,6,1,5] means the researcher has 5 papers in total and each of them had 
                         received 3, 0, 6, 1, 5 citations respectively. 
                         Since the researcher has 3 papers with at least 3 citations each and the remaining 
                         two with no more than 3 citations each, her h-index is 3.
            Note: If there are several possible values for h, the maximum one is taken as the h-index.
         */
        public static int HIndex(int[] citations)
        {
            int[] buckets = new int[citations.Length + 1];
            foreach (int citation in citations) {
                if (citation > citations.Length)
                {
                    buckets[citations.Length]++;
                }
                else {
                    buckets[citation]++;
                }
            }
            int count = 0;
            for (int i = buckets.Length-1; i >= 0; i--) {
                count += buckets[i];
                if (count >= i) {
                    return i;
                }
            }
            return 0;
        }

        /*
         * Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.

            Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.
            The order of output does not matter.

            Example 1:
            Input:
            s: "cbaebabacd" p: "abc"
            
            Output:
            [0, 6]
            
            Explanation:
            The substring with start index = 0 is "cba", which is an anagram of "abc".
            The substring with start index = 6 is "bac", which is an anagram of "abc".
            
            Example 2:
            Input:
            s: "abab" p: "ab"
            
            Output:
            [0, 1, 2]
            
            Explanation:
            The substring with start index = 0 is "ab", which is an anagram of "ab".
            The substring with start index = 1 is "ba", which is an anagram of "ab".
            The substring with start index = 2 is "ab", which is an anagram of "ab".
         * **/
        public static IList<int> FindAnagrams(string s, string p)
        {
            IList<int> result = new List<int>();
            int binaryHashOfP = 0;
            foreach (char c in p) {
                binaryHashOfP |= 1 << (c - 'a');
            }
            for (int i = 0; i < s.Length - p.Length + 1; i++) {
                int binaryHashOfSubS = 0;
                for (int j = i; j < i + p.Length; j++) {
                    binaryHashOfSubS |= 1 << (s[j] - 'a');
                }
                if (binaryHashOfSubS == binaryHashOfP) {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
