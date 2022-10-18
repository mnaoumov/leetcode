using JetBrains.Annotations;

namespace LeetCode._0502_IPO;

[PublicAPI]
public interface ISolution
{
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital);
}