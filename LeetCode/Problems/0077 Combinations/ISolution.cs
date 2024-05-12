using JetBrains.Annotations;

namespace LeetCode.Problems._0077_Combinations;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> Combine(int n, int k);
}
