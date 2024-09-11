namespace LeetCode.Problems._2306_Naming_a_Company;

/// <summary>
/// https://leetcode.com/submissions/detail/894400680/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public long DistinctNames(string[] ideas)
    {
        var prefixSuffixMap = new Dictionary<char, HashSet<string>>();
        var suffixPrefixMap = new Dictionary<string, HashSet<char>>();

        foreach (var idea in ideas)
        {
            var prefix = idea[0];
            var suffix = idea[1..];

            if (!prefixSuffixMap.ContainsKey(prefix))
            {
                prefixSuffixMap[prefix] = new HashSet<string>();
            }

            if (!suffixPrefixMap.ContainsKey(suffix))
            {
                suffixPrefixMap[suffix] = new HashSet<char>();
            }

            prefixSuffixMap[prefix].Add(suffix);
            suffixPrefixMap[suffix].Add(prefix);
        }

        var prefixCounts = new Dictionary<char, int>();

        foreach (var (prefix, suffixes) in prefixSuffixMap)
        {
            prefixCounts[prefix] = ideas.Length - suffixes.Count;
        }

        foreach (var idea in ideas)
        {
            var prefix = idea[0];
            var suffix = idea[1..];

            foreach (var otherPrefix in suffixPrefixMap[suffix].Except(new[] { prefix }))
            {
                prefixCounts[otherPrefix]--;
            }
        }

        return prefixCounts.Values.Select(x => (long) x).Sum();
    }
}
