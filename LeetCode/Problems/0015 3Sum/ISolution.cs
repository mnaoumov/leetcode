using JetBrains.Annotations;

namespace LeetCode.Problems._0015_3Sum;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> ThreeSum(int[] nums);
}
