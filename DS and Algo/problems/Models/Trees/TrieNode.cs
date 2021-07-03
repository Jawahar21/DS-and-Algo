using System;
using System.Collections.Generic;
using System.Text;

namespace DS_and_Algo.problems.Models.Trees
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public bool isEndOfWord = false;
        public int sum = 0;
    }
}
