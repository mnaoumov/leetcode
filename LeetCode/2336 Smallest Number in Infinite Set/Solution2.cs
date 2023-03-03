using JetBrains.Annotations;

namespace LeetCode._2336_Smallest_Number_in_Infinite_Set;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ISmallestInfiniteSet Create()
    {
        return new SmallestInfiniteSet2();
    }
}