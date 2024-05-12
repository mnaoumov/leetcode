using JetBrains.Annotations;

namespace LeetCode._2900_Longest_Unequal_Adjacent_Groups_Subsequence_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-115/submissions/detail/1075012710/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> GetWordsInLongestSubsequence(int n, string[] words, int[] groups)
    {
        var ans = new List<string>();
        var lastGroup = -1;

        for (var i = 0; i < n; i++)
        {
            var group = groups[i];

            if (group == lastGroup)
            {
                continue;
            }

            lastGroup = group;
            ans.Add(words[i]);
        }

        return ans;
    }
}
