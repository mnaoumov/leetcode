using JetBrains.Annotations;

namespace LeetCode._0039_Combination_Sum;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target);
}