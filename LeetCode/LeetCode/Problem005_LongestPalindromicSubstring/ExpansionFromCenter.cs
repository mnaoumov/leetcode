namespace LeetCode.Problem005_LongestPalindromicSubstring
{
    public class ExpansionFromCenter : ISolution
    {
        public string LongestPalindrome(string s)
        {
            var max = "";
            var n = s.Length;
            for (int l = 0; l < 2 * n; l++)
            {
                for (int i = l / 2, j = l - i; i >= 0 && j < n; i--, j++)
                {
                    if (s[i] != s[j])
                        break;
                    if (max.Length < j - i + 1)
                        max = s.Substring(i, j - i + 1);
                }
            }

            return max;
        }
    }
}