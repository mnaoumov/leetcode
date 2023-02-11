using JetBrains.Annotations;

namespace LeetCode._2306_Naming_a_Company;

/// <summary>
/// https://leetcode.com/submissions/detail/894412523/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
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

        foreach (var prefix1 in prefixSuffixMap.Keys)
        {
            foreach (var prefix2 in prefixSuffixMap.Keys.Where(prefix2 => prefix2 > prefix1))
            {
                var suffixes1 = prefixSuffixMap[prefix1].ToHashSet();
                var suffixes2 = prefixSuffixMap[prefix2].ToHashSet();
                suffixes1.ExceptWith(prefixSuffixMap[prefix2]);
                suffixes2.ExceptWith(prefixSuffixMap[prefix1]);
                result += 2L * suffixes1.Count * suffixes2.Count;
            }
        }

        return result;
    }
}
