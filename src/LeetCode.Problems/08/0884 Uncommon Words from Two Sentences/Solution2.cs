namespace LeetCode.Problems._0884_Uncommon_Words_from_Two_Sentences;

/// <summary>
/// https://leetcode.com/submissions/detail/1393551234/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string[] UncommonFromSentences(string s1, string s2)
    {
        var counts1 = GetWordsCounts(s1);
        var counts2 = GetWordsCounts(s2);
        return counts1.Where(kvp => kvp.Value == 1 && !counts2.ContainsKey(kvp.Key))
            .Concat(counts2.Where(kvp => kvp.Value == 1 && !counts1.ContainsKey(kvp.Key)))
            .Select(kvp => kvp.Key)
            .ToArray();
    }

    private static Dictionary<string, int> GetWordsCounts(string s) => s
        .Split(' ')
        .GroupBy(word => word)
        .ToDictionary(g => g.Key, g => g.Count());
}
