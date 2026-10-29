namespace LeetCode.Problems._0295_Find_Median_from_Data_Stream;

public interface IMedianFinder
{
    [UsedImplicitly]
    void AddNum(int num);

    [UsedImplicitly]
    double FindMedian();
}
