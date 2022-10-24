using JetBrains.Annotations;

namespace LeetCode._0622_Design_Circular_Queue;

/// <summary>
/// https://leetcode.com/submissions/detail/807894085/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IMyCircularQueue Create(int k)
    {
        return new MyCircularQueue3(k);
    }
}