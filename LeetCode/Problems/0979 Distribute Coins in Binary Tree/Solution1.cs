using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0979_Distribute_Coins_in_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1261388250/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DistributeCoins(TreeNode root) => DistributeCoins2(root).moves;

    private static (int balance, int moves) DistributeCoins2(TreeNode? root)
    {
        if (root == null)
        {
            return (0, 0);
        }

        var left = DistributeCoins2(root.left);
        var right = DistributeCoins2(root.right);
        var balance = root.val + left.balance + right.balance - 1;
        return (balance, moves: left.moves + right.moves + Math.Abs(balance));
    }
}
