using JetBrains.Annotations;

namespace LeetCode._1192_Critical_Connections_in_a_Network;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections);
}
