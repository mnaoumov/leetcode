using JetBrains.Annotations;

namespace LeetCode._0732_My_Calendar_III;

/// <summary>
/// https://leetcode.com/submissions/detail/816924979/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyCalendarThree Create()
    {
        return new MyCalendarThree1();
    }
}