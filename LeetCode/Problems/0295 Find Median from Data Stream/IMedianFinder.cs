using JetBrains.Annotations;

namespace LeetCode.Problems._0295_Find_Median_from_Data_Stream;

public interface IMedianFinder
{
    [UsedImplicitly]
    public void AddNum(int num);

    [UsedImplicitly]
    public double FindMedian();
}
