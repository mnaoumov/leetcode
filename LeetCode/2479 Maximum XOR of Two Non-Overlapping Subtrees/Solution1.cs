using JetBrains.Annotations;

namespace LeetCode._2479_Maximum_XOR_of_Two_Non_Overlapping_Subtrees;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    const int MaxBitIndex = 62;

    public long MaxXor(int n, int[][] edges, int[] values)
    {
        var neighbors = Enumerable.Range(0, n).Select(_ => new HashSet<int>()).ToArray();

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var processedNodes = new HashSet<int>();
        var trieRoot = new TrieNode();
        BuildGraph(0, null);

        long result = 0;

        var nodes1 = new[] { trieRoot };
        var nodes2 = new[] { trieRoot };

        var nodesToSkip = new HashSet<GraphNode>();

        for (var i = MaxBitIndex; i >= 0; i++)
        {
            var nodes11 = nodes1.Select(t => t.ZeroNode).OfType<TrieNode>().ToArray();
            var nodes12 = nodes1.Select(t => t.OneNode).OfType<TrieNode>().ToArray();
            var graphNodes11 = nodes11.SelectMany(t => t.GraphNodes).ToHashSet();
            graphNodes11.ExceptWith(nodesToSkip);
            var graphNodes12 = nodes12.SelectMany(t => t.GraphNodes).ToHashSet();
            graphNodes12.ExceptWith(nodesToSkip);

            if (graphNodes12.Count < graphNodes11.Count)
            {
                (graphNodes11, graphNodes12, nodes11, nodes12) =
                    (graphNodes12, graphNodes11, nodes12, nodes11);
            }

            var nodes21 = nodes2.Select(t => t.ZeroNode).OfType<TrieNode>().ToArray();
            var nodes22 = nodes2.Select(t => t.OneNode).OfType<TrieNode>().ToArray();
            var graphNodes21 = nodes11.SelectMany(t => t.GraphNodes).ToHashSet();
            graphNodes21.ExceptWith(nodesToSkip);
            var graphNodes22 = nodes12.SelectMany(t => t.GraphNodes).ToHashSet();
            graphNodes22.ExceptWith(nodesToSkip);

            var nodesWithoutMatchingOtherBitCandidate = new List<GraphNode>();
            var nodesWithoutMatchingSameBitCandidate = new List<GraphNode>();

            var hasBit = false;

            foreach (var node in graphNodes11)
            {
                var otherBitCandidates = graphNodes11.ToHashSet();
                otherBitCandidates.ExceptWith(node.OverlappingNodes);

                if (otherBitCandidates.Any())
                {
                    hasBit = true;
                    break;
                }

                nodesWithoutMatchingOtherBitCandidate.Add(node);
                var sameBitCandidates = graphNodes11.ToHashSet();
                sameBitCandidates.ExceptWith(node.OverlappingNodes);

                if (!sameBitCandidates.Any())
                {
                    nodesWithoutMatchingSameBitCandidate.Add(node);
                }
            }

            if (hasBit)
            {
                result += 1L << i;
                nodes1 = nodes11;
                foreach (var node in nodesWithoutMatchingOtherBitCandidate)
                {
                    nodesToSkip.Add(node);
                }
            }
            else
            {
                nodes1 = nodes11.Concat(nodes12).ToArray();
                foreach (var node in nodesWithoutMatchingSameBitCandidate)
                {
                    nodesToSkip.Add(node);
                }
            }
        }

        return result;

        void BuildGraph(int node, GraphNode? parent)
        {
            processedNodes.Add(node);
            var childNodes = neighbors[node].ToHashSet();
            childNodes.ExceptWith(processedNodes);
            var graphNode = new GraphNode
            {
                Value = values[node],
                Parent = parent
            };

            foreach (var childNode in childNodes)
            {
                BuildGraph(childNode, graphNode);
            }

            trieRoot.AddGraphNode(graphNode);
        }
    }

    public class GraphNode
    {
        private readonly GraphNode? _parent;
        public int Value { get; init; }
        private long? _subtreeValueSum;
        public List<GraphNode> OverlappingNodes { get; } = new();

        public GraphNode()
        {
            OverlappingNodes.Add(this);
        }

        public GraphNode? Parent
        {
            get => _parent;
            init
            {
                _parent = value;

                if (_parent == null)
                {
                    return;
                }

                _parent.ChildNodes.Add(this);

                var ancestor = _parent;

                while (ancestor != null)
                {
                    OverlappingNodes.Add(ancestor);
                    ancestor.OverlappingNodes.Add(this);
                    ancestor = ancestor.Parent;
                }
            }
        }

        private List<GraphNode> ChildNodes { get; } = new();

        public long GetSubtreeValueSum()
        {
            if (_subtreeValueSum is { } value)
            {
                return value;
            }

            value = Value + ChildNodes.Sum(c => c.GetSubtreeValueSum());
            _subtreeValueSum = value;
            return value;
        }
    }

    public class TrieNode
    {
        public TrieNode? ZeroNode { get; private set; }
        public TrieNode? OneNode { get; private set; }
        private readonly TrieNode? _parentNode;
        public List<GraphNode> GraphNodes { get; } = new();

        public TrieNode(TrieNode? parentNode = null)
        {
            _parentNode = parentNode;
        }

        private TrieNode GetOrAddBit(long bit)
        {
            if (bit == 0)
            {
                return ZeroNode ??= new TrieNode(this);
            }

            return OneNode ??= new TrieNode(this);
        }

        public void AddGraphNode(GraphNode graphNode)
        {
            var value = graphNode.GetSubtreeValueSum();
            var trieNode = this;

            for (var i = MaxBitIndex; i >= 0; i--)
            {
                var bit = value >> i & 1;
                trieNode = trieNode.GetOrAddBit(bit);
            }

            trieNode.RegisterGraphNode(graphNode);
        }

        private void RegisterGraphNode(GraphNode graphNode)
        {
            GraphNodes.Add(graphNode);
            _parentNode?.RegisterGraphNode(graphNode);
        }
    }
}
