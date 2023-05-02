using JetBrains.Annotations;

namespace LeetCode._0732_My_Calendar_III;

/// <summary>
/// https://leetcode.com/submissions/detail/816937661/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IMyCalendarThree Create()
    {
        return new MyCalendarThree2();
    }
}
