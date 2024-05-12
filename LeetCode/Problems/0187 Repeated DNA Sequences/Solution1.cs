using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._0187_Repeated_DNA_Sequences;

/// <summary>
/// https://leetcode.com/submissions/detail/902682127/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        if (s.Length < 10)
        {
            return Array.Empty<string>();
        }

        var sb = new StringBuilder(s[..10]);
        var tenLetterLongSequences = new HashSet<string>
        {
            sb.ToString()
        };

        var result = new HashSet<string>();

        for (var i = 10; i < s.Length; i++)
        {
            sb.Remove(0, 1);
            sb.Append(s[i]);
            var sequence = sb.ToString();

            if (!tenLetterLongSequences.Add(sequence))
            {
                result.Add(sequence);
            }
        }

        return result.ToArray();
    }
}
