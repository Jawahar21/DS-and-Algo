using System;
using System.Collections.Generic;
using System.Text;
using DS_and_Algo.problems.Models.Trees;

namespace DS_and_Algo.problems
{
    public class Trie
    {
        private TrieNode root;
        /** Initialize your data structure here. */
        public Trie()
        {
            root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            TrieNode curr = root;
            foreach (char c in word)
            {
                if (!curr.children.ContainsKey(c))
                {
                    TrieNode newNode = new TrieNode();
                    curr.children.Add(c, newNode);
                }
                curr = curr.children[c];
            }
            curr.isEndOfWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            return GetPrefixNode(word)?.isEndOfWord ?? false;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            if (GetPrefixNode(prefix) != null) return true;
            return false;
        }

        private TrieNode GetPrefixNode(string prefix)
        {
            TrieNode curr = root;
            foreach (char c in prefix)
            {
                if (!curr.children.ContainsKey(c)) return null;
                curr = curr.children[c];
            }
            return curr;
        }
    }

    public class MapSum
    {
        private TrieNode root;

        /** Initialize your data structure here. */
        public MapSum()
        {
            root = new TrieNode();
        }

        public void Insert(string key, int val)
        {

            if (GetPrefixNode(key)?.isEndOfWord ?? false)
            {
                // update
                Update(key, val);
            }
            else
            {
                // sum up
                SumUp(key, val);
            }

        }

        public int Sum(string prefix)
        {
            TrieNode curr = root;
            foreach (char c in prefix)
            {
                if (!curr.children.ContainsKey(c)) return 0;
                curr = curr.children[c];
            }
            return curr.sum;
        }

        private void SumUp(string key, int val)
        {
            TrieNode curr = root;
            foreach (char c in key)
            {
                if (!curr.children.ContainsKey(c))
                {
                    curr.children[c] = new TrieNode();
                }
                curr.children[c].sum += val;
                curr = curr.children[c];
            }
            curr.isEndOfWord = true;
        }

        private void Update(string key, int val)
        {
            TrieNode curr = root;
            foreach (char c in key)
            {
                curr.children[c].sum = val;
                curr = curr.children[c];
            }
        }

        private TrieNode GetPrefixNode(string prefix)
        {
            TrieNode curr = root;
            foreach (char c in prefix)
            {
                if (!curr.children.ContainsKey(c)) return null;
                curr = curr.children[c];
            }
            return curr;
        }
    }
}
