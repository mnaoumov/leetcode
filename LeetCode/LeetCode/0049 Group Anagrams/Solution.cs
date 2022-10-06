namespace LeetCode._0049_Group_Anagrams;

/// <summary>
/// https://leetcode.com/submissions/detail/815529506/
/// </summary>
public class Solution : ISolution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        return strs
            .GroupBy(str => new string(str.ToCharArray().OrderBy(x => x).ToArray()))
            .Select(g => g.ToArray())
            .ToArray<IList<string>>();
    }
}