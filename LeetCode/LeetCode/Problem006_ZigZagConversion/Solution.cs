using System.Text;

namespace LeetCode.Problem006_ZigZagConversion
{
    public class Solution : ISolution
    {
        public string Convert(string s, int numRows)
        {
            var period = 2 * numRows - 2;

            var sb = new StringBuilder();

            for (int i = 0; i < numRows; i++)
            {
                var j = period - i;
                var skipJ = i == 0 || i == numRows - 1;
                var nextI = i;
                var nextJ = j;
                while (nextI < s.Length)
                {
                    sb.Append(s[nextI]);
                    if (!skipJ && nextJ < s.Length)
                        sb.Append(s[nextJ]);
                    nextI += period;
                    nextJ += period;
                }
            }

            return sb.ToString();
        }
    }
}