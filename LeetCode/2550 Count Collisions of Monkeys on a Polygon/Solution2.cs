using JetBrains.Annotations;

namespace LeetCode._2550_Count_Collisions_of_Monkeys_on_a_Polygon;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-330/submissions/detail/887162535/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MonkeyMove(int n)
    {
        var result = 1;

        for (var i = 0; i < n; i++)
        {
            result = result * 2 % 1_000_000_007;
        }

        result -= 2;

        return result;
    }
}
