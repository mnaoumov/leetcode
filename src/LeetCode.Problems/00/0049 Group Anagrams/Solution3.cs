namespace LeetCode.Problems._0049_Group_Anagrams;

/// <seealso href="https://leetcode.com/submissions/detail/829025009/"/>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        return strs
            .GroupBy(str => new string(str.ToCharArray().OrderBy(x => x).ToArray()))
            .Select(g => g.ToArray())
            .ToArray<IList<string>>();
    }
}
