// ReSharper disable All
#pragma warning disable
namespace LeetCode.Problems._0049_Group_Anagrams;

/// <seealso href="https://leetcode.com/submissions/detail/815529506/"/>
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
