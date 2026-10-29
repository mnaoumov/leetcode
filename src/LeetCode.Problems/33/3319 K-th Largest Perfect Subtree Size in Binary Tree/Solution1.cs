namespace LeetCode.Problems._3319_K_th_Largest_Perfect_Subtree_Size_in_Binary_Tree;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-419/submissions/detail/1420588110/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int KthLargestPerfectSubtree(TreeNode root, int k)
    {
        const int imperfect = -1;
        var sizes = new List<int>();
        Dfs(root);

        if (sizes.Count < k)
        {
            return imperfect;
        }

        sizes.Sort();
        return sizes[^k];

        int Dfs(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }

            var left = Dfs(node.left);
            var right = Dfs(node.right);

            if (left != right || left == imperfect)
            {
                return imperfect;
            }

            var size = 2 * left + 1;
            sizes.Add(size);
            return size;
        }
    }
}
