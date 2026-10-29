namespace LeetCode.Problems._0696_Count_Binary_Substrings;

/// <summary>
/// https://leetcode.com/problems/count-binary-substrings/submissions/1923904228/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CountBinarySubstrings(string s)
    {
        var groupSizes = new List<int>();
        var lastDigit = s[0] == '0' ? '1' : '0';

        foreach (var digit in s)
        {
            if (digit == lastDigit)
            {
                groupSizes[^1]++;
            }
            else
            {
                groupSizes.Add(1);
                lastDigit = digit;
            }
        }

        var ans = 0;

        for (var i = 0; i < groupSizes.Count - 1; i++)
        {
            ans += Math.Min(groupSizes[i], groupSizes[i + 1]);
        }

        return ans;
    }
}
