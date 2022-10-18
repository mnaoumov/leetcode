using JetBrains.Annotations;

namespace LeetCode._0078_Subsets;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> Subsets(int[] nums);
}