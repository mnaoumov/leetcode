using JetBrains.Annotations;

namespace LeetCode._0018_4Sum;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> FourSum(int[] nums, int target);
}
