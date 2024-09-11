using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0366_Find_Leaves_of_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/951660910/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> FindLeaves(TreeNode root)
    {
        var seen = new HashSet<TreeNode>();
        var ans = new List<IList<int>>();

        while (!seen.Contains(root))
        {
            ans.Add(new List<int>());
            Dfs(root);
        }

        return ans;

        void Dfs(TreeNode node)
        {
            if (seen.Contains(node))
            {
                return;
            }

            var isLeaf = true;
            isLeaf &= !ProcessChild(node.left);
            isLeaf &= !ProcessChild(node.right);

            if (!isLeaf)
            {
                return;
            }

            ans[^1].Add(node.val);
            seen.Add(node);
        }

        bool ProcessChild(TreeNode? child)
        {
            if (child == null || seen.Contains(child))
            {
                return false;
            }

            Dfs(child);
            return true;
        }
    }
}
