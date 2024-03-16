using JetBrains.Annotations;

namespace LeetCode._3080_Mark_Elements_on_Array_by_Performing_Queries;

[PublicAPI]
public interface ISolution
{
    public long[] UnmarkedSumArray(int[] nums, int[][] queries);
}
