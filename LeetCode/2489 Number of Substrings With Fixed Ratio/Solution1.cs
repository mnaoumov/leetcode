using JetBrains.Annotations;

namespace LeetCode._2489_Number_of_Substrings_With_Fixed_Ratio;

/// <summary>
/// https://leetcode.com/submissions/detail/870855799/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long FixedRatio(string s, int num1, int num2)
    {
        var zeroCount = 0;
        var funcCounts = new Dictionary<long, int>
        {
            [num1] = 1
        };

        for (var i = 0; i < s.Length; i++)
        {
            zeroCount += s[i] == '0' ? 1 : 0;
            var func = 1L * (num1 + num2) * zeroCount - num1 * i;
            funcCounts[func] = funcCounts.GetValueOrDefault(func) + 1;
        }

        return funcCounts.Values.Sum(count => 1L * count * (count - 1) / 2);
    }
}
