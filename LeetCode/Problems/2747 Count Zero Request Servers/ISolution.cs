using JetBrains.Annotations;

namespace LeetCode.Problems._2747_Count_Zero_Request_Servers;

[PublicAPI]
public interface ISolution
{
    public int[] CountServers(int n, int[][] logs, int x, int[] queries);
}
