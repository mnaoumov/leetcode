namespace LeetCode.Problems._2502_Design_Memory_Allocator;

[PublicAPI]
public interface IAllocator
{
    int Allocate(int size, int mID);
    int Free(int mID);
}
