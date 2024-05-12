using JetBrains.Annotations;

namespace LeetCode.Problems._0622_Design_Circular_Queue;

[PublicAPI]
public interface ISolution
{
    IMyCircularQueue Create(int k);
}
