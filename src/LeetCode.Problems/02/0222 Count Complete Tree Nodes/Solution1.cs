namespace LeetCode.Problems._0222_Count_Complete_Tree_Nodes;

/// <summary>
/// https://leetcode.com/problems/count-complete-tree-nodes/submissions/843585833/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountNodes(TreeNode? root)
    {
        if (root == null)
        {
            return 0;
        }

        var bitCount = 0;
        var powerOfTwo = 1;
        var node = root;

        while (node != null)
        {
            node = node.left;
            powerOfTwo *= 2;
            bitCount++;
        }

        var max = powerOfTwo - 1;
        var min = powerOfTwo / 2;

        while (min <= max)
        {
            var mid = (min + max) / 2;
            node = root;

            for (var i = bitCount - 2; i >= 0; i--)
            {
                if (node == null)
                {
                    break;
                }

                var hasBit = (mid >> i & 1) == 1;

                node = hasBit ? node.right : node.left;
            }

            if (node == null)
            {
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }

        return min - 1;
    }
}
