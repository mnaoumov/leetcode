using JetBrains.Annotations;

namespace LeetCode.Problems._1539_Kth_Missing_Positive_Number;

[PublicAPI]
public interface ISolution
{
    public int FindKthPositive(int[] arr, int k);
}
