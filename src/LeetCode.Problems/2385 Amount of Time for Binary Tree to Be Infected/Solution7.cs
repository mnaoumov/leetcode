namespace LeetCode.Problems._2385_Amount_of_Time_for_Binary_Tree_to_Be_Infected;

/// <summary>
/// https://leetcode.com/submissions/detail/1143880877/
/// </summary>
[UsedImplicitly]
public class Solution7 : ISolution
{
    public int AmountOfTime(TreeNode root, int start)
    {
        var queue = new Queue<(TreeNode node, TreeNode? parent)>();
        queue.Enqueue((root, null));
        var parentsMap = new Dictionary<int, TreeNode?>();

        var startNode = root;
        var startFound = false;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var (node, parent) = queue.Dequeue();

                parentsMap[node.val] = parent;

                if (node.val == start)
                {
                    startNode = node;
                    startFound = true;
                    break;
                }

                if (node.left != null)
                {
                    queue.Enqueue((node.left, node));
                }

                if (node.right != null)
                {
                    queue.Enqueue((node.right, node));
                }
            }

            if (startFound)
            {
                break;
            }
        }

        var ans = Depth(startNode);

        var childPathNode = startNode;
        var pathNode = parentsMap[childPathNode.val];
        var distanceFromStartNode = 1;

        while (pathNode != null)
        {
            var otherChildNode = ReferenceEquals(pathNode.left, childPathNode) ? pathNode.right : pathNode.left;
            ans = Math.Max(ans, distanceFromStartNode + 1 + Depth(otherChildNode));

            childPathNode = pathNode;
            pathNode = parentsMap[pathNode.val];
            distanceFromStartNode++;
        }

        return ans;
    }

    private static int Depth(TreeNode? node)
    {
        if (node == null)
        {
            return -1;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(node);

        var ans = -1;

        while (queue.Count > 0)
        {
            ans++;
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                node = queue.Dequeue();

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        return ans;
    }
}
