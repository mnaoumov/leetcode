using JetBrains.Annotations;

namespace LeetCode.Problems._0134_Gas_Station;

[PublicAPI]
public interface ISolution
{
    public int CanCompleteCircuit(int[] gas, int[] cost);
}
