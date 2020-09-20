using System.Text;

namespace problems
{
    public static class BinaryRepresentationOfNumbers
    {
        // This is my implementation
        public static string getBinaryRepresentation(int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 31; i >= 0; i--)
            {
                sb.Append((n & 1 << i) > 0 ? "1" : "0");
            }
            return sb.ToString();
        }

        // This is efficeint way
        public static string getBinaryRepresentationEfficient(int n)
        {
            string bit ="";
            if (n > 1)
            {
                bit = getBinaryRepresentationEfficient(n/2);
            }
            return bit + (n%2).ToString();
        }
    }
}