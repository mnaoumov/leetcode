using JetBrains.Annotations;

namespace LeetCode._0133_Clone_Graph;

[PublicAPI]
public interface ISolution
{
    public Node? CloneGraph(Node? node);
}
