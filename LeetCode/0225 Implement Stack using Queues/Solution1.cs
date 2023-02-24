using JetBrains.Annotations;

namespace LeetCode._0225_Implement_Stack_using_Queues;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyStack Create()
    {
        return new MyStack1();
    }
}
