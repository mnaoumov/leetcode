using JetBrains.Annotations;

namespace LeetCode._0622_Design_Circular_Queue;

/// <summary>
/// https://leetcode.com/submissions/detail/807882544/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyCircularQueue Create(int k)
    {
        return new MyCircularQueue1(k);
    }
}