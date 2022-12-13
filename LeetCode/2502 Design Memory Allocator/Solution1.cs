using JetBrains.Annotations;

namespace LeetCode._2502_Design_Memory_Allocator;

/// <summary>
/// https://leetcode.com/submissions/detail/859016671/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IAllocator Create(int n)
    {
        return new Allocator1(n);
    }
}
