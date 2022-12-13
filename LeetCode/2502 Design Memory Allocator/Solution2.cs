using JetBrains.Annotations;

namespace LeetCode._2502_Design_Memory_Allocator;

/// <summary>
/// https://leetcode.com/submissions/detail/859018226/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IAllocator Create(int n)
    {
        return new Allocator2(n);
    }
}
