using JetBrains.Annotations;

namespace LeetCode._0491_Non_decreasing_Subsequences;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> FindSubsequences(int[] nums);
}
