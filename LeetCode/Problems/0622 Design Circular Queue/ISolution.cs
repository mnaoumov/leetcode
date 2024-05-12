using JetBrains.Annotations;

namespace LeetCode._0622_Design_Circular_Queue;

[PublicAPI]
public interface ISolution
{
    IMyCircularQueue Create(int k);
}
