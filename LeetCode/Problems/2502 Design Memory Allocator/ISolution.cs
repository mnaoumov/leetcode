using JetBrains.Annotations;

namespace LeetCode.Problems._2502_Design_Memory_Allocator;

[PublicAPI]
public interface ISolution
{
    public IAllocator Create(int n);
}
