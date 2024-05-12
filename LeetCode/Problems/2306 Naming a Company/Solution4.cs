using JetBrains.Annotations;

namespace LeetCode._2306_Naming_a_Company;

/// <summary>
/// https://leetcode.com/submissions/detail/894406360/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
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

        var result = 0L;

        foreach (var prefix1 in prefixSuffixMap.Keys)
        {
            var suffixes1 = prefixSuffixMap[prefix1];

            foreach (var prefix2 in prefixSuffixMap.Keys.Where(prefix2 => prefix2 > prefix1))
            {
                var suffixes2 = prefixSuffixMap[prefix2].ToHashSet();
                var count = suffixes2.Count;
                suffixes2.IntersectWith(suffixes1);

                if (suffixes2.Count == 0)
                {
                    result += 2L * count;
                }
            }
        }

        return result;
    }
}
