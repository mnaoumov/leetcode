namespace LeetCode.Problems._0272_Closest_Binary_Search_Tree_Value_II;

/// <summary>
/// https://leetcode.com/problems/closest-binary-search-tree-value-ii/submissions/1715317834/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<int> ClosestKValues(TreeNode root, double target, int k)
    {
        var parents = new Dictionary<TreeNode, TreeNode?>();

        Dfs(root, null);

        var closest = FindClosestNode(root);
        var pq = new PriorityQueue<int, double>();
        pq.Enqueue(closest.val, -Math.Abs(closest.val - target));

        var next = closest;
        var previous = closest;
        for (var i = 0; i < k; i++)
        {
            if (next != null)
            {
                next = GetSuccessor(next);
            }

            if (previous != null)
            {
                previous = GetPredecessor(previous);
            }

            if (next != null)
            {
                pq.Enqueue(next.val, -Math.Abs(next.val - target));
                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }

            // ReSharper disable once InvertIf
            if (previous != null)
            {
                pq.Enqueue(previous.val, -Math.Abs(previous.val - target));
                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }
        }

        var list = new List<int>();
        while (pq.Count > 0)
        {
            list.Add(pq.Dequeue());
        }

        return list;

        TreeNode FindClosestNode(TreeNode node)
        {
            while (Math.Abs(node.val - target) >= double.Epsilon)
            {
                if (target < node.val)
                {
                    if (node.left == null)
                    {
                        return node;
                    }

                    node = node.left;
                }
                else
                {
                    if (node.right == null)
                    {
                        return node;
                    }

                    node = node.right;
                }
            }

            return node;
        }

        void Dfs(TreeNode? node, TreeNode? parent)
        {
            if (node == null)
            {
                return;
            }

            parents[node] = parent;

            Dfs(node.left, node);
            // ReSharper disable once TailRecursiveCall
            Dfs(node.right, node);
        }

        TreeNode? GetPredecessor(TreeNode? node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.left != null)
            {
                var ans = node.left;

                while (ans.left != null)
                {
                    ans = ans.left;
                }

                return ans;
            }

            var ancestor = parents[node];
            while (ancestor != null && ReferenceEquals(ancestor.left, node))
            {
                node = ancestor;
                ancestor = parents[node];
            }

            return ancestor;
        }

        TreeNode? GetSuccessor(TreeNode? node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.right != null)
            {
                var ans = node.right;

                while (ans.right != null)
                {
                    ans = ans.right;
                }

                return ans;
            }

            var ancestor = parents[node];
            while (ancestor != null && ReferenceEquals(ancestor.right, node))
            {
                node = ancestor;
                ancestor = parents[node];
            }

            return ancestor;
        }
    }
}
