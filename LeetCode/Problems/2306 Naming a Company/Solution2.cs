using JetBrains.Annotations;

namespace LeetCode.Problems._2306_Naming_a_Company;

/// <summary>
/// https://leetcode.com/submissions/detail/894394837/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long DistinctNames(string[] ideas)
    {
        var prefixSuffixMap = new Dictionary<char, HashSet<string>>();

        foreach (var idea in ideas)
        {
            var prefix = idea[0];
            var suffix = idea[1..];

            if (!prefixSuffixMap.ContainsKey(prefix))
            {
                prefixSuffixMap[prefix] = new HashSet<string>();
            }

            prefixSuffixMap[prefix].Add(suffix);
        }

        var result = 0L;

        foreach (var idea in ideas)
        {
            var prefix = idea[0];
            var suffix = idea[1..];

            var otherSuffixes = prefixSuffixMap[prefix];

            foreach (var (otherPrefix, correspondingSuffixes) in prefixSuffixMap)
            {
                if (otherPrefix == prefix || correspondingSuffixes.Contains(suffix))
                {
                    continue;
                }

                var correspondingSuffixes2 = correspondingSuffixes.ToHashSet();
                correspondingSuffixes2.ExceptWith(otherSuffixes);
                result += correspondingSuffixes2.Count;
            }
        }

        return result;
    }
}
