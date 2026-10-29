namespace LeetCode.Problems._1940_Longest_Common_Subsequence_Between_Sorted_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/1273728609/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> LongestCommonSubsequence(int[][] arrays)
    {
        var set = arrays[0].ToHashSet();

        for (var i = 1; i < arrays.Length; i++)
        {
            set.IntersectWith(arrays[i]);

            if (set.Count == 0)
            {
                return Array.Empty<int>();
            }
        }

        return set.OrderBy(x => x).ToArray();
    }
}
