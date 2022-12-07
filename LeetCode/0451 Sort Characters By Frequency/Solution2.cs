using System.Text;
using JetBrains.Annotations;

namespace LeetCode._0451_Sort_Characters_By_Frequency;

/// <summary>
/// https://leetcode.com/submissions/detail/854014525/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string FrequencySort(string s)
    {
        var letters = s.OrderBy(letter => letter).ToArray();

        var sequences = new List<string>();

        var sb = new StringBuilder();

        foreach (var letter in letters)
        {
            if (sb.Length > 0 && letter != sb[^1])
            {
                sequences.Add(sb.ToString());
                sb.Clear();
            }

            sb.Append(letter);
        }

        sequences.Add(sb.ToString());

        return string.Join("", sequences.OrderByDescending(seq => seq.Length));
    }
}
