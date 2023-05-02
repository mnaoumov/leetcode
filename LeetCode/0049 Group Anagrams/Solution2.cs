// ReSharper disable All
using JetBrains.Annotations;

namespace LeetCode._0049_Group_Anagrams;

/// <summary>
/// https://leetcode.com/submissions/detail/815529506/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        return strs
            .GroupBy(str => new string(str.ToCharArray().OrderBy(x => x).ToArray()))
            .Select(g => g.ToArray())
            .ToArray();
    }
}
