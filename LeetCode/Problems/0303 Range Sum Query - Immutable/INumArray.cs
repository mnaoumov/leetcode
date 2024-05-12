using JetBrains.Annotations;

namespace LeetCode.Problems._0303_Range_Sum_Query___Immutable;

[PublicAPI]
public interface INumArray
{
    public int SumRange(int left, int right);
}
