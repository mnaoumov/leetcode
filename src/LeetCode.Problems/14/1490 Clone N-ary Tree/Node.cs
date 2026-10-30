#pragma warning disable CA1051
namespace LeetCode.Problems._1490_Clone_N_ary_Tree;

public class Node
{
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    public int val;
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    public IList<Node> children;

    // ReSharper disable once MemberCanBePrivate.Global
    public Node() : this(0, new List<Node>())
    {
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public Node(int val) : this(val, new List<Node>())
    {
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public Node(int val, IList<Node> children)
    {
        this.val = val;
        this.children = children;
    }

    public static Node? CreateOrNull(int?[] values)
    {
        var rootParent = new Node();
        var previousLevelNodes = new List<Node> { rootParent };
        var currentLevelNodes = new List<Node>();

        var parentIndex = 0;

        foreach (var value in values)
        {
            if (value != null)
            {
                var node = new Node(value.Value);
                previousLevelNodes[parentIndex].children.Add(node);
                currentLevelNodes.Add(node);
            }
            else
            {
                parentIndex++;

                if (parentIndex != previousLevelNodes.Count)
                {
                    continue;
                }

                parentIndex = 0;
                previousLevelNodes = currentLevelNodes;
                currentLevelNodes = new List<Node>();
            }
        }

        return rootParent.children.FirstOrDefault();
    }

    public override string ToString() => $"{{{val}}}";

    /// <summary>
    /// Compares trees by shape and values. <see cref="Node"/> itself keeps reference equality, as LeetCode's does.
    /// </summary>
    public static IEqualityComparer<Node?> StructuralComparer { get; } = new NodeStructuralComparer();

    private sealed class NodeStructuralComparer : IEqualityComparer<Node?>
    {
        // Equal trees share every level-order prefix, so hashing a bounded prefix keeps the Equals contract.
        private const int HashedPrefixLength = 64;

        /// <summary>
        /// Compares with an explicit stack, so a deep tree does not overflow the stack. A pair of nodes already compared
        /// is not compared again, so a cyclic structure terminates.
        /// </summary>
        public bool Equals(Node? x, Node? y)
        {
            if (x == null || y == null)
            {
                return x == y;
            }

            var comparedPairs = new HashSet<(Node, Node)>(ReferencePairComparer<Node>.Instance);
            var stack = new Stack<(Node, Node)>();
            stack.Push((x, y));

            while (stack.Count > 0)
            {
                var (a, b) = stack.Pop();

                if (ReferenceEquals(a, b) || !comparedPairs.Add((a, b)))
                {
                    continue;
                }

                if (a.val != b.val || a.children.Count != b.children.Count)
                {
                    return false;
                }

                for (var i = 0; i < a.children.Count; i++)
                {
                    stack.Push((a.children[i], b.children[i]));
                }
            }

            return true;
        }

        public int GetHashCode(Node? obj)
        {
            var hashCode = new HashCode();

            if (obj == null)
            {
                return hashCode.ToHashCode();
            }

            var queue = new Queue<Node>();
            queue.Enqueue(obj);

            for (var i = 0; i < HashedPrefixLength && queue.Count > 0; i++)
            {
                var node = queue.Dequeue();
                hashCode.Add(node.val);
                hashCode.Add(node.children.Count);

                foreach (var child in node.children)
                {
                    queue.Enqueue(child);
                }
            }

            return hashCode.ToHashCode();
        }
    }
}
