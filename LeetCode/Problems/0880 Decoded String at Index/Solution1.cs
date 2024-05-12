using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._0880_Decoded_String_at_Index;

/// <summary>
/// https://leetcode.com/submissions/detail/1060912060/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public string DecodeAtIndex(string s, int k)
    {
        var sb = new StringBuilder();

        foreach (var letter in s)
        {
            if (char.IsLetter(letter))
            {
                sb.Append(letter);

                if (TryGetResult() is {} ans)
                {
                    return ans;
                }
            }
            else
            {
                var count = letter - '0';
                var currentStr = sb.ToString();
                for (var i = 0; i < count - 1; i++)
                {
                    sb.Append(currentStr);

                    if (TryGetResult() is { } ans)
                    {
                        return ans;
                    }
                }
            }
        }

        throw new InvalidOperationException();

        string? TryGetResult() => sb.Length >= k ? sb[k - 1].ToString() : null;
    }
}
