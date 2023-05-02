using JetBrains.Annotations;

namespace LeetCode._0295_Find_Median_from_Data_Stream;

/// <summary>
/// https://leetcode.com/problems/find-median-from-data-stream/submissions/841676521/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMedianFinder Create()
    {
        return new MedianFinder1();
    }
}
