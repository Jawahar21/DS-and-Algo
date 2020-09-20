using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_and_algo.problems
{
    // All DNA is composed of a series of nucleotides abbreviated as A, C, G, and T, for example: "ACGAATTCCG". 
    // When studying DNA, it is sometimes useful to identify repeated sequences within the DNA.
    //Write a function to find all the 10-letter-long sequences(substrings) that occur more than once in a DNA molecule.

    // Input: s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"
    // Output: ["AAAAACCCCC", "CCCCCAAAAA"]

    /**
     * Explanation: The solution is to add all the 10 letter sequences into the set
     * if any sequence couldn't be added, that means it repeated so we add it to another hashset(which maintains unique set of repeated sequences)
     * But hashing of strings is space consuming, so consider A,C,G,T as 2 bit integers and create of own HASH.
     */
    public class FindRepeatedDnaSequences
    {
        public static IList<string> getSequence(string s)
        {
            HashSet<string> sequencesList = new HashSet<string>();
            HashSet<int> uniqueSeq = new HashSet<int>();
            for (int i = 0; i <= s.Length - 10; i++) {
                int hash = 0;
                for (int j = i; j < i + 10; j++) {
                    hash <<= 2;
                    hash |= getHashNum(s[j]);
                }
                if (!uniqueSeq.Add(hash)) {
                    sequencesList.Add(s.Substring(i, 10));
                }
            }
            return sequencesList.ToArray();
        }

        private static int getHashNum(char c) {
            switch (c) {
                case 'A':
                    return 0;
                case 'C':
                    return 1;
                case 'G':
                    return 2;
                case 'T':
                    return 3;
                default:
                    return 10;
            }
        }
    }
}
