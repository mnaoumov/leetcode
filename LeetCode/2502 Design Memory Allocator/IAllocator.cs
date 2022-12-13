using JetBrains.Annotations;

namespace LeetCode._2502_Design_Memory_Allocator;

[PublicAPI]
public interface IAllocator
{
    public int Allocate(int size, int mID);
    public int Free(int mID);
}
