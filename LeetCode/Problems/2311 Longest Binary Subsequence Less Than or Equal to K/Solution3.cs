namespace LeetCode.Problems._2311_Longest_Binary_Subsequence_Less_Than_or_Equal_to_K;

/// <summary>
/// https://leetcode.com/problems/longest-binary-subsequence-less-than-or-equal-to-k/submissions/1678792262/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int LongestSubsequence(string s, int k)
    {
        var value = 0;
        var ans = 0;
        var length = 0;
        var oneIndices = new List<int>();

        for (var index = 0; index < s.Length; index++)
        {
            var digit = s[index] - '0';

            if (digit == 1)
            {
                oneIndices.Add(index);
            }

            value = value * 2 + digit;
            length++;

            if (value > k)
            {
                value -= 1 << index - oneIndices[0];
                length--;
                oneIndices.RemoveAt(0);
            }

            ans = Math.Max(ans, length);
        }

        return ans;
    }
}
