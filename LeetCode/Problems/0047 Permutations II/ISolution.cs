using JetBrains.Annotations;

namespace LeetCode._0047_Permutations_II;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> PermuteUnique(int[] nums);
}
