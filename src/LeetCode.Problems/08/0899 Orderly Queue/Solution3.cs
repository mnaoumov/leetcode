using System.Text;

namespace LeetCode.Problems._0899_Orderly_Queue;

/// <summary>
/// https://leetcode.com/problems/orderly-queue/submissions/837690030/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public string OrderlyQueue(string s, int k)
    {
        var result = s;
        var candidates = new HashSet<string> { s };

        if (s.Length < k)
        {
            k = s.Length;
        }

        while (true)
        {
            var min = Enumerable.Range(0, k).Select(i => MoveLetter(s, i)).Min()!;

            if (string.Compare(min, s, StringComparison.Ordinal) < 0)
            {
                result = min;
            }

            s = min;

            if (!candidates.Add(s))
            {
                return result;
            }
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
