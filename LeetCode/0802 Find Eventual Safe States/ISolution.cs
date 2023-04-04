using JetBrains.Annotations;

namespace LeetCode._0802_Find_Eventual_Safe_States;

[PublicAPI]
public interface ISolution
{
    public IList<int> EventualSafeNodes(int[][] graph);
}
