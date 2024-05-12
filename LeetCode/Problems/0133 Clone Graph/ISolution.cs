using JetBrains.Annotations;

namespace LeetCode.Problems._0133_Clone_Graph;

[PublicAPI]
public interface ISolution
{
    public Node? CloneGraph(Node? node);
}
