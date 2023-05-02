using JetBrains.Annotations;

namespace LeetCode._0090_Subsets_II;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> SubsetsWithDup(int[] nums);
}
