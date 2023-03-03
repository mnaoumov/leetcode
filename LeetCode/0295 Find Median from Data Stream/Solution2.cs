using JetBrains.Annotations;

namespace LeetCode._0295_Find_Median_from_Data_Stream;

/// <summary>
/// https://leetcode.com/submissions/detail/908021635/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IMedianFinder Create()
    {
        return new MedianFinder2();
    }
}