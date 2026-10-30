using System.Globalization;

#pragma warning disable CA1051
namespace LeetCode.DataStructure;

public class TreeNode
{
    // ReSharper disable once InconsistentNaming
    public int val;
    // ReSharper disable once InconsistentNaming
    public TreeNode? left;
    // ReSharper disable once InconsistentNaming
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public static TreeNode? CreateOrNull(int?[] values)
    {
        if (values.Length == 0)
        {
            return null;
        }

        var queue = new Queue<TreeNode>();
        var result = CreateFromIndex(0)!;
        queue.Enqueue(result);

        var index = 0;
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            node.left = CreateFromIndex(index + 1);
            node.right = CreateFromIndex(index + 2);

            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }

            if (node.right != null)
            {
                queue.Enqueue(node.right);
            }

            index += 2;
        }

        return result;

        TreeNode? CreateFromIndex(int index2)
        {
            if (index2 >= values.Length || values[index2] is not { } value)
            {
                return null;
            }

            return new TreeNode(value);
        }
    }

    public static TreeNode Create(int?[] values) => CreateOrNull(values) ?? throw new ArgumentException("Values represent an empty tree", nameof(values));

    /// <summary>
    /// Compares trees by shape and values. <see cref="TreeNode"/> itself keeps reference equality, as LeetCode's does,
    /// so a solution may key a collection by node; a test that compares trees by value passes this comparer.
    /// </summary>
    public static IEqualityComparer<TreeNode?> StructuralComparer { get; } = new TreeNodeStructuralComparer();

    public override string ToString()
    {
        if (HasCycle(this))
        {
            return $"{val.ToString(CultureInfo.InvariantCulture)},...cycle";
        }

        var valuesStr = GetValues(this).Select(value => value == null ? "null" : ((int)value).ToString(CultureInfo.InvariantCulture));
        return string.Join(",", valuesStr);
    }

    public static int?[] GetValues(TreeNode? treeNode)
    {
        if (HasCycle(treeNode))
        {
            throw new InvalidOperationException("The tree has a cycle, so it has no level-order values");
        }

        var values = new List<int?>();
        TraverseByLevel(treeNode, node => values.Add(node?.val));
        return values.ToArray();
    }

    /// <summary>
    /// A node reached twice is not a cycle by itself: a solution may hang one subtree in two places, and that tree is
    /// still finite. Only a node reached again from below itself makes a traversal endless.
    /// </summary>
    private static bool HasCycle(TreeNode? root)
    {
        if (root == null)
        {
            return false;
        }

        var onPath = new HashSet<TreeNode>(ReferenceEqualityComparer.Instance);
        var done = new HashSet<TreeNode>(ReferenceEqualityComparer.Instance);
        var stack = new Stack<(TreeNode Node, bool IsExit)>();
        stack.Push((root, false));

        while (stack.Count > 0)
        {
            var (node, isExit) = stack.Pop();

            if (isExit)
            {
                onPath.Remove(node);
                done.Add(node);
                continue;
            }

            if (done.Contains(node))
            {
                continue;
            }

            if (!onPath.Add(node))
            {
                return true;
            }

            stack.Push((node, true));

            foreach (var child in new[] { node.right, node.left })
            {
                if (child == null)
                {
                    continue;
                }

                if (onPath.Contains(child))
                {
                    return true;
                }

                stack.Push((child, false));
            }
        }

        return false;
    }

    private static void TraverseByLevel(TreeNode? node, Action<TreeNode?> treeAction)
    {
        var queue = new Queue<TreeNode?>();
        queue.Enqueue(node);

        var nullsCount = 0;

        while (queue.Count > 0)
        {
            node = queue.Dequeue();

            if (node == null)
            {
                nullsCount++;
                continue;
            }

            for (var i = 0; i < nullsCount; i++)
            {
                treeAction(null);
            }

            nullsCount = 0;

            treeAction(node);

            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }
    }

    public TreeNode? FindNode(int value)
    {
        var visited = new HashSet<TreeNode>(ReferenceEqualityComparer.Instance);
        var queue = new Queue<TreeNode?>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node == null || !visited.Add(node))
            {
                continue;
            }

            if (node.val == value)
            {
                return node;
            }

            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        return null;
    }

    [UsedImplicitly]
    public static TreeNode? FromObject(object obj)
    {
        var values = ((object?[]) obj)
            .Select(valueObj => valueObj == null ? (int?) null : Convert.ToInt32(valueObj, CultureInfo.InvariantCulture))
            .ToArray();
        return CreateOrNull(values);
    }

    private sealed class TreeNodeStructuralComparer : IEqualityComparer<TreeNode?>
    {
        // Equal trees share every level-order prefix, so hashing a bounded prefix keeps the Equals contract.
        private const int HashedPrefixLength = 64;

        /// <summary>
        /// Compares with an explicit stack, so a deep or skewed tree does not overflow the stack. A pair of nodes
        /// already compared is not compared again, so a cyclic structure terminates.
        /// </summary>
        public bool Equals(TreeNode? x, TreeNode? y)
        {
            var comparedPairs = new HashSet<(TreeNode, TreeNode)>(ReferencePairComparer<TreeNode>.Instance);
            var stack = new Stack<(TreeNode?, TreeNode?)>();
            stack.Push((x, y));

            while (stack.Count > 0)
            {
                var (a, b) = stack.Pop();

                if (a == null || b == null)
                {
                    if (a != b)
                    {
                        return false;
                    }

                    continue;
                }

                if (ReferenceEquals(a, b) || !comparedPairs.Add((a, b)))
                {
                    continue;
                }

                if (a.val != b.val)
                {
                    return false;
                }

                stack.Push((a.right, b.right));
                stack.Push((a.left, b.left));
            }

            return true;
        }

        public int GetHashCode(TreeNode? obj)
        {
            var hashCode = new HashCode();
            var queue = new Queue<TreeNode?>();
            queue.Enqueue(obj);

            for (var i = 0; i < HashedPrefixLength && queue.Count > 0; i++)
            {
                var node = queue.Dequeue();

                if (node == null)
                {
                    hashCode.Add(-1);
                    continue;
                }

                hashCode.Add(1);
                hashCode.Add(node.val);
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            return hashCode.ToHashCode();
        }
    }
}
