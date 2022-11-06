using JetBrains.Annotations;

namespace LeetCode._0133_Clone_Graph;

/// <summary>
/// https://leetcode.com/problems/clone-graph/submissions/837665655/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public Node? CloneGraph(Node? node)
    {
        var clonesDict = new Dictionary<int, Node>();
        return node == null ? null : CloneRecursive(node);

        Node CloneRecursive(Node node2)
        {
            if (clonesDict.ContainsKey(node2.val))
            {
                return clonesDict[node2.val];
            }

            var clone = new Node(node2.val);
            clonesDict[node2.val] = clone;

            foreach (var neighbor in node2.neighbors)
            {
                clone.neighbors.Add(CloneRecursive(neighbor));
            }

            return clone;
        }
    }
}
