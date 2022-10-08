namespace LeetCode._0622_Design_Circular_Queue;

/// <summary>
/// https://leetcode.com/submissions/detail/807894085/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public IMyCircularQueue Create(int k)
    {
        return new MyCircularQueue2(k);
    }
}