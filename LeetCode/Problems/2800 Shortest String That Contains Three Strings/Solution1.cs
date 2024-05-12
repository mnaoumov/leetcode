using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._2800_Shortest_String_That_Contains_Three_Strings;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-356/submissions/detail/1007344133/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string MinimumString(string a, string b, string c)
    {
        var permutations = new[]
        {
            new[] { a, b, c },
            new[] { a, c, b },
            new[] { b, a, c },
            new[] { b, c, a },
            new[] { c, a, b },
            new[] { c, b, a }
        };

        return permutations.Select(BuildShortest).OrderBy(s => s.Length).ThenBy(s => s).First();
    }

    private static string BuildShortest(string[] permutation)
    {
        var sb = new StringBuilder();

        foreach (var str in permutation)
        {
            var result = sb.ToString();

            if (result.Contains(str))
            {
                continue;
            }

            for (var j = str.Length - 1; j >= 0; j--)
            {
                if (!result.EndsWith(str[..j]))
                {
                    continue;
                }

                sb.Append(str[j..]);
                break;
            }
        }

        return sb.ToString();
    }
}
