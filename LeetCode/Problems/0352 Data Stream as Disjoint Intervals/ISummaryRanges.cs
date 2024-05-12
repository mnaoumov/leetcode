using JetBrains.Annotations;

namespace LeetCode._0352_Data_Stream_as_Disjoint_Intervals;

[PublicAPI]
public interface ISummaryRanges
{
    public void AddNum(int value);
    public int[][] GetIntervals();
}
