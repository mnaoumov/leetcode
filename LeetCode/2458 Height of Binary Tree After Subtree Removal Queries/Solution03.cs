using JetBrains.Annotations;

namespace LeetCode._2458_Height_of_Binary_Tree_After_Subtree_Removal_Queries;

/// <summary>
/// https://leetcode.com/submissions/detail/833519270/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution03 : ISolution
{
    private Dictionary<int, int> _heightDict = null!;
    private Dictionary<int, TreeNode> _valueToNodeDict = null!;
    private Dictionary<TreeNode, TreeNode?> _parentsDict = null!;

    public int[] TreeQueries(TreeNode root, int[] queries)
    {
        _heightDict = new Dictionary<int, int>();
        _valueToNodeDict = new Dictionary<int, TreeNode>();
        _parentsDict = new Dictionary<TreeNode, TreeNode?>();

        Fill(root, null);

        var valuesByLevels = new List<int>();

        var queue = new Queue<TreeNode?>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node == null)
            {
                continue;
            }

            valuesByLevels.Add(node.val);

            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        var queryDict = queries.Select((query, index) => (query, index)).GroupBy(x => x.query)
            .ToDictionary(g => g.Key, g => g.Select(x => x.index));

        var result = new int[queries.Length];

        foreach (var query in valuesByLevels.Reverse<int>())
        {
            if (!queryDict.ContainsKey(query))
            {
                continue;
            }

            var height = ResetAndGetHeight(root, query);

            foreach (var index in queryDict[query])
            {
                result[index] = height;
            }
        }

        return result;
    }

    private void Fill(TreeNode? node, TreeNode? parent)
    {
        while (true)
        {
            if (node == null)
            {
                return;
            }

            _valueToNodeDict[node.val] = node;
            _parentsDict[node] = parent;

            Fill(node.left, node);
            var node1 = node;
            node = node.right;
            parent = node1;
        }
    }

    private int ResetAndGetHeight(TreeNode root, int valueToSkip)
    {
        var node = _valueToNodeDict[valueToSkip];

        while (node != null)
        {
            _heightDict.Remove(node.val);
            node = _parentsDict[node];
        }

        var height = GetHeight(root, valueToSkip);

        node = _valueToNodeDict[valueToSkip];

        while (node != null)
        {
            _heightDict.Remove(node.val);
            node = _parentsDict[node];
        }

        return height;
    }

    private int GetHeight(TreeNode node, int valueToSkip)
    {
        if (_heightDict.ContainsKey(node.val))
        {
            return _heightDict[node.val];
        }

        var childNodes = new[] { node.left, node.right }.OfType<TreeNode>().Where(x => x.val != valueToSkip).ToArray();

        if (childNodes.Length == 0)
        {
            return _heightDict[node.val] = 0;
        }

        return _heightDict[node.val] = 1 + childNodes.Select(childNode => GetHeight(childNode, valueToSkip)).Max();
    }
}
