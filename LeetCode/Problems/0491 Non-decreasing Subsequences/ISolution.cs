using JetBrains.Annotations;

namespace LeetCode.Problems._0491_Non_decreasing_Subsequences;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> FindSubsequences(int[] nums);
}
