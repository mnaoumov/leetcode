using JetBrains.Annotations;

namespace LeetCode.Problems._0451_Sort_Characters_By_Frequency;

/// <summary>
/// https://leetcode.com/submissions/detail/853648038/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string FrequencySort(string s) => string.Join("",
        s.GroupBy(letter => letter).Select(g => (letter: g.Key, count: g.Count())).OrderByDescending(x => x.count)
            .Select(x => new string(x.letter, x.count)));
}
