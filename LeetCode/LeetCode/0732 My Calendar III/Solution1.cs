using NUnit.Framework;

namespace LeetCode._0732_My_Calendar_III;

/// <summary>
/// https://leetcode.com/submissions/detail/816924979/
/// </summary>
[SkipSolution("Wrong Answer")]
public class Solution1 : ISolution
{
    public IMyCalendarThree Create()
    {
        return new MyCalendarThree1();
    }
}