using JetBrains.Annotations;

namespace LeetCode._1756_Design_Most_Recently_Used_Queue;

[PublicAPI]
public interface ISolution
{
    public IMRUQueue Create(int n);
}
