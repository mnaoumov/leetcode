using JetBrains.Annotations;

namespace LeetCode._0232_Implement_Queue_using_Stacks;

/// <summary>
/// https://leetcode.com/submissions/detail/860437570/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyQueue Create()
    {
        return new MyQueue1();
    }
}
