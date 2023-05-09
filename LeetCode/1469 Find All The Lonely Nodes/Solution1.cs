using JetBrains.Annotations;

namespace LeetCode._1469_Find_All_The_Lonely_Nodes;

/// <summary>
/// https://leetcode.com/submissions/detail/946938304/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> GetLonelyNodes(TreeNode root)
    {
        var ans = new List<int>();

        Dfs(root);

        return ans;

        void Dfs(TreeNode? node)
        {
            while (true)
            {
                if (node == null)
                {
                    return;
                }

                if (node.left == null ^ node.right == null)
                {
                    ans.Add((node.left ?? node.right)!.val);
                }

                Dfs(node.left);
                node = node.right;
            }
        }
    }
}
