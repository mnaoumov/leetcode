using JetBrains.Annotations;

namespace LeetCode._1973_Count_Nodes_Equal_to_Sum_of_Descendants;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int EqualToDescendants(TreeNode root)
    {
        var ans = 0;

        Dfs(root);

        return ans;

        int Dfs(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }

            var descendantsSum = Dfs(node.left) + Dfs(node.right);

            if (node.val == descendantsSum)
            {
                ans++;
            }

            return descendantsSum + node.val;
        }
    }
}
