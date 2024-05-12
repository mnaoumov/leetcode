using JetBrains.Annotations;

namespace LeetCode._0632_Smallest_Range_Covering_Elements_from_K_Lists;

[PublicAPI]
public interface ISolution
{
    public int[] SmallestRange(IList<IList<int>> nums);
}
