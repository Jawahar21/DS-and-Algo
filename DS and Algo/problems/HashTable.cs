using System.Collections.Generic;
using System.Linq;

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
            for (int i = 0; i < nums.Length; i++) {
                if(numIndexPair.ContainsKey(target - nums[i]))
                {
                    result[0] = i;
                    result[1] = numIndexPair[target - nums[i]];
                    return result;
                }
                if (!numIndexPair.ContainsKey(nums[i])) {
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
                while(n > 0)
                {
                    int d = n % 10;
                    squaredSum += d * d;
                    n /= 10;
                }
                if(squaredSum == 1)
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
        public static string GetHint(string secret, string guess) {
            Dictionary<char, int> mapOfNumberAndCount = new Dictionary<char, int>();
            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < secret.Length; i++) {
                if (!mapOfNumberAndCount.TryAdd(secret[i], 1)) {
                    mapOfNumberAndCount[secret[i]]++;
                }
            }

            for (int i = 0; i < guess.Length; i++) {
                if (mapOfNumberAndCount.ContainsKey(guess[i])) {
                    if (secret[i].Equals(guess[i]))
                    {
                        bulls++;
                        if (mapOfNumberAndCount[guess[i]] > 0)
                        {
                            mapOfNumberAndCount[guess[i]]--;
                        }
                        else {
                            cows--;
                        }
                    }
                    else {
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
            foreach (int num in nums) {
                if (!numCountMap.TryAdd(num, 1)) {
                    numCountMap[num]++;
                }
            }

            foreach (KeyValuePair<int, int> numCountPair in numCountMap) {
                if (bucket[numCountPair.Value] == null) bucket[numCountPair.Value] = new List<int>();
                bucket[numCountPair.Value].Add(numCountPair.Key);
            }
            int[] result = new int[k];
            for (int i = bucket.Length - 1 ; i > 0; i--) {
                if (bucket[i] != null) {
                    for (int j = 0; j < bucket[i].Count && k!=0; j++) {
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
            foreach (string str in strs) {
                char[] charArray = new char[26];
                foreach(char c in str) {
                    charArray[c - 'a']++;
                }
                string stringKey = new string(charArray);
                if (anagrams.ContainsKey(stringKey))
                {
                    anagrams[stringKey].Add(str);
                }
                else {
                    anagrams[stringKey] = new List<string>() { str };
                }
            }
            return anagrams.Values.ToList();
        }
    }
}
