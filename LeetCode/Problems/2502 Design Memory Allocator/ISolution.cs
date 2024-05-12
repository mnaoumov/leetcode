using JetBrains.Annotations;

namespace LeetCode._2502_Design_Memory_Allocator;

[PublicAPI]
public interface ISolution
{
    public IAllocator Create(int n);
}
