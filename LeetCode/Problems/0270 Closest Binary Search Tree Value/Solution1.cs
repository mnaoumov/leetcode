namespace LeetCode.Problems._0270_Closest_Binary_Search_Tree_Value;

/// <summary>
/// https://leetcode.com/submissions/detail/897480344/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int ClosestValue(TreeNode root, double target)
    {
        var minDistance = double.MaxValue;
        var result = 0;

        var node = root;

        while (node != null)
        {
            var diff = node.val - target;

            if (Math.Abs(diff) < minDistance)
            {
                minDistance = Math.Abs(diff);
                result = root.val;
            }

            switch (diff)
            {
                case 0:
                    return node.val;
                case > 0:
                    node = node.left;
                    continue;
                case < 0:
                    node = node.right;
                    continue;
            }
        }

        return result;
    }
}
