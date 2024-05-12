using JetBrains.Annotations;

namespace LeetCode.Problems._0799_Champagne_Tower;

[PublicAPI]
public interface ISolution
{
    // ReSharper disable InconsistentNaming
    public double ChampagneTower(int poured, int query_row, int query_glass);
    // ReSharper restore InconsistentNaming
}
