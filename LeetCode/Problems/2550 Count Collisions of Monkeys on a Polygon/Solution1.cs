using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2550_Count_Collisions_of_Monkeys_on_a_Polygon;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-330/submissions/detail/887159676/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MonkeyMove(int n) => (1 << n) - 2;
}
