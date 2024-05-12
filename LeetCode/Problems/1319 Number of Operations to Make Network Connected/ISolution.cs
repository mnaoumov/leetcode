using JetBrains.Annotations;

namespace LeetCode.Problems._1319_Number_of_Operations_to_Make_Network_Connected;

[PublicAPI]
public interface ISolution
{
    public int MakeConnected(int n, int[][] connections);
}
