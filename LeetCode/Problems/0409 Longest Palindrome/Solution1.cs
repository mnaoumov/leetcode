namespace LeetCode.Problems._0409_Longest_Palindrome;

/// <summary>
/// https://leetcode.com/submissions/detail/914082097/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestPalindrome(string s)
    {
        var result = 0;
        var oddCountTaken = false;

        foreach (var count in s.GroupBy(letter => letter).Select(g => g.Count()))
        {
            if (count % 2 == 0)
            {
                result += count;
            }
            else
            {
                result += count - 1;

                if (oddCountTaken)
                {
                    continue;
                }

                oddCountTaken = true;
                result++;
            }
        }

        return result;
    }
}
