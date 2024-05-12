using JetBrains.Annotations;

namespace LeetCode._0528_Random_Pick_with_Weight;

[PublicAPI]
public interface ISolution
{
    public ISolutionImpl Create(int[] w);
}
