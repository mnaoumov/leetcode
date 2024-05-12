using JetBrains.Annotations;

namespace LeetCode.Problems._0791_Custom_Sort_String;

/// <summary>
/// https://leetcode.com/submissions/detail/898988019/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string CustomSortString(string order, string s)
    {
        var letterIndexMap = new Dictionary<char, int>();

        for (var i = 0; i < order.Length; i++)
        {
            letterIndexMap[order[i]] = i;
        }

        return string.Concat(s.OrderBy(letter => letterIndexMap.GetValueOrDefault(letter)));
    }
}
