using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._0899_Orderly_Queue;

/// <summary>
/// https://leetcode.com/problems/orderly-queue/submissions/837687875/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public string OrderlyQueue(string s, int k)
    {
        var result = s;

        if (s.Length < k)
        {
            k = s.Length;
        }

        while (true)
        {
            var min = Enumerable.Range(0, k).Select(i => MoveLetter(result, i)).Min()!;

            if (string.Compare(result, min, StringComparison.Ordinal) <= 0)
            {
                return result;
            }

            result = min;
        }
    }

    private static string MoveLetter(string str, int letterIndex)
    {
        var sb = new StringBuilder(str);
        sb.Remove(letterIndex, 1);
        sb.Append(str[letterIndex]);
        return sb.ToString();
    }
}
