namespace problems
{
    public static class LongestPalindromicSubstring
    {

        public static string GetString(string inputString)
        {
            string prevLargest = "";
            bool needToCheckPalindrome = false;
            int i, j;
            if (inputString.Length % 2 == 0)
            {
                i = 0; j = i + 1;
            }
            else
            {
                i = j = 0;
            }
            while (j < inputString.Length)
            {
                if (inputString[i].Equals(inputString[j]))
                {
                    string subString = inputString.Substring(i, j - i + 1);
                    if (needToCheckPalindrome)
                    {
                        if (isPalindrome(subString))
                        {
                            prevLargest = subString;
                            needToCheckPalindrome = false;
                        }
                    }
                    else
                    {
                        prevLargest = subString;
                    }

                    if (i - 1 < 0)
                    {
                        i++; j++;
                        needToCheckPalindrome = true;
                    }
                    else
                    {
                        i--; j++;
                    }
                }
                else
                {
                    i++; j++;
                    needToCheckPalindrome = true;
                }
            }
            if (prevLargest.Length == 0 && inputString.Length != 0)
            {
                return inputString[0].ToString();
            }
            return prevLargest;
        }

        private static bool isPalindrome(string inputString)
        {
            int i = 0, j = inputString.Length - 1;
            while (i <= j)
            {
                if (!inputString[i++].Equals(inputString[j--]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}