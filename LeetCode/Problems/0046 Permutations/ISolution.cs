using JetBrains.Annotations;

namespace LeetCode._0046_Permutations;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> Permute(int[] nums);
}
