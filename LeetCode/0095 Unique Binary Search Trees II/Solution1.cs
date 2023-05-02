using JetBrains.Annotations;

namespace LeetCode._0095_Unique_Binary_Search_Trees_II;

/// <summary>
/// https://leetcode.com/submissions/detail/829298547/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<TreeNode> GenerateTrees(int n)
    {
        var dp = new IList<TreeNode?>[n + 2];

        return Get(n)!;

        IList<TreeNode?> Get(int k)
        {
            if (dp[k] is not { } result)
            {
                dp[k] = result = Enumerate(k).ToArray();
            }

            return result;
        }

        IEnumerable<TreeNode?> Enumerate(int k)
        {
            if (k <= 0)
            {
                yield return null;
                yield break;
            }

            for (var i = 1; i <= k; i++)
            {
                foreach (var left in Get(i - 1))
                {
                    foreach (var rightShifted in Get(k - i))
                    {
                        var right = Shift(rightShifted, i);
                        yield return new TreeNode(i, left, right);
                    }
                }
            }
        }
    }

    private static TreeNode? Shift(TreeNode? node, int shiftValue)
    {
        return node == null ? null : new TreeNode(node.val + shiftValue, Shift(node.left, shiftValue), Shift(node.right, shiftValue));
    }
}
