namespace LeetCode.Problems._0352_Data_Stream_as_Disjoint_Intervals;

[PublicAPI]
public interface ISummaryRanges
{
    void AddNum(int value);
    int[][] GetIntervals();
}
