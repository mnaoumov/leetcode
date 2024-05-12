using JetBrains.Annotations;

namespace LeetCode.Problems._0368_Largest_Divisible_Subset;

[PublicAPI]
public interface ISolution
{
    public IList<int> LargestDivisibleSubset(int[] nums);
}
