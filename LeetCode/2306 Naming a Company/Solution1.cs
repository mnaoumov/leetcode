using JetBrains.Annotations;

namespace LeetCode._2306_Naming_a_Company;

/// <summary>
/// https://leetcode.com/submissions/detail/894389121/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
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

                result += correspondingSuffixes.Except(otherSuffixes).Count();
            }
        }

        return result;
    }
}
