using JetBrains.Annotations;

namespace LeetCode._0254_Factor_Combinations;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> GetFactors(int n);
}
