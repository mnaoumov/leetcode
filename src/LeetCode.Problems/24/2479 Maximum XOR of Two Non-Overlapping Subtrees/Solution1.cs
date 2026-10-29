namespace LeetCode.Problems._2479_Maximum_XOR_of_Two_Non_Overlapping_Subtrees;

/// <summary>
/// https://leetcode.com/submissions/detail/874379924/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    private const int MaxBitIndex = 62;

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

        var trieNodePairs = new List<(TrieNode, TrieNode)> { (trieRoot, trieRoot) };

        var graphNodesToSkip = new HashSet<GraphNode>();

        for (var i = MaxBitIndex; i >= 0; i--)
        {
            var differentBitPairs = new List<(TrieNode?, TrieNode?)>();
            var sameBitPairs = new List<(TrieNode?, TrieNode?)>();

            foreach (var pair in trieNodePairs)
            {
                differentBitPairs.Add((pair.Item1.ZeroNode, pair.Item2.OneNode));
                sameBitPairs.Add((pair.Item1.ZeroNode, pair.Item2.ZeroNode));
                sameBitPairs.Add((pair.Item1.OneNode, pair.Item2.OneNode));

                if (!ReferenceEquals(pair.Item1, pair.Item2))
                {
                    differentBitPairs.Add((pair.Item2.ZeroNode, pair.Item1.OneNode));
                }
            }

            differentBitPairs = differentBitPairs.Where(pair => HasMatchingGraphNodes(pair.Item1, pair.Item2)).ToList();

            if (differentBitPairs.Count > 0)
            {
                result += 1 << i;
                trieNodePairs = differentBitPairs!;
            }
            else
            {
                trieNodePairs = sameBitPairs.Where(pair => HasMatchingGraphNodes(pair.Item1, pair.Item2)).ToList()!;
            }

            continue;

            bool HasMatchingGraphNodes(TrieNode? trieNode1, TrieNode? trieNode2)
            {
                if (trieNode1 == null || trieNode2 == null)
                {
                    return false;
                }

                var graphNodes1 = trieNode1.GraphNodes.ToHashSet();
                var graphNodes2 = trieNode2.GraphNodes.ToHashSet();
                graphNodes1.ExceptWith(graphNodesToSkip);
                graphNodes2.ExceptWith(graphNodesToSkip);

                if (graphNodes1.Count > graphNodes2.Count)
                {
                    (graphNodes1, graphNodes2) = (graphNodes2, graphNodes1);
                }

                foreach (var graphNode in graphNodes1)
                {
                    var graphNodes2Copy = graphNodes2.ToHashSet();
                    graphNodes2Copy.ExceptWith(graphNode.OverlappingNodes);

                    if (graphNodes2Copy.Count > 0)
                    {
                        return true;
                    }

                    graphNodesToSkip.Add(graphNode);
                }

                return false;
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
