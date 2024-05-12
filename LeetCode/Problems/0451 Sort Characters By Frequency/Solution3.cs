using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._0451_Sort_Characters_By_Frequency;

/// <summary>
/// https://leetcode.com/submissions/detail/854283450/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public string FrequencySort(string s)
    {
        var countsMap = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());

        var max = countsMap.Values.Max();

        var countGroups = new List<char>?[max + 1];

        foreach (var (letter, count) in countsMap)
        {
            countGroups[count] ??= new List<char>();
            countGroups[count]!.Add(letter);
        }

        var sb = new StringBuilder();

        for (var count = max; count >= 1; count--)
        {
            if (countGroups[count] is not { } group)
            {
                continue;
            }

            foreach (var letter in group)
            {
                sb.Append(letter, count);
            }
        }

        return sb.ToString();
    }
}
