namespace LeetCode.Problems._2385_Amount_of_Time_for_Binary_Tree_to_Be_Infected;

/// <summary>
/// https://leetcode.com/submissions/detail/1143748655/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution5 : ISolution
{
    public int AmountOfTime(TreeNode root, int start)
    {
        return Dfs(root, true).amountOfTime;

        (int amountOfTime, int distanceFromStart) Dfs(TreeNode? node, bool isLookingForStart)
        {
            if (node == null)
            {
                return (0, -1);
            }

            if (!isLookingForStart || node.val == start)
            {
                var amountOfTime = Math.Max(Depth(node.left), Depth(node.right));
                return (amountOfTime, 0);
            }

            var leftResult = Dfs(node.left, true);

            if (leftResult.distanceFromStart >= 0)
            {
                return (
                    amountOfTime: new[]
                        { leftResult.amountOfTime, 1 + Depth(node.right), leftResult.distanceFromStart + 1 }.Max(),
                    distanceFromStart: leftResult.distanceFromStart + 1);
            }

            var rightResult = Dfs(node.right, true);

            if (rightResult.distanceFromStart >= 0)
            {
                return (
                    amountOfTime: new[]
                        { rightResult.amountOfTime, 1 + Depth(node.left), rightResult.distanceFromStart + 1 }.Max(),
                    distanceFromStart: rightResult.distanceFromStart + 1);
            }

            return (amountOfTime: 1 + Math.Max(leftResult.amountOfTime, rightResult.amountOfTime),
                distanceFromStart: -1);

        }
    }

    private static int Depth(TreeNode? node) => node == null ? 0 : 1 + Math.Max(Depth(node.left), Depth(node.right));
}
