using JetBrains.Annotations;

namespace LeetCode._2336_Smallest_Number_in_Infinite_Set;

/// <summary>
/// https://leetcode.com/submissions/detail/908108746/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public ISmallestInfiniteSet Create()
    {
        return new SmallestInfiniteSet1();
    }
}