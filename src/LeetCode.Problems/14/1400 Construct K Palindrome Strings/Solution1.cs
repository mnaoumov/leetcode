namespace LeetCode.Problems._1400_Construct_K_Palindrome_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/1504729074/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanConstruct(string s, int k)
    {
        if (s.Length < k)
        {
            return false;
        }

        var letterCounts = s.GroupBy(letter => letter).Select(g => g.Count());

        var oddCounts = letterCounts.Count(count => count % 2 == 1);
        return oddCounts <= k;
    }
}
