using JetBrains.Annotations;

namespace LeetCode.Problems._0894_All_Possible_Full_Binary_Trees;

/// <summary>
/// https://leetcode.com/submissions/detail/1002183208/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<TreeNode> AllPossibleFBT(int n)
    {
        switch (n)
        {
            case 1:
                return new List<TreeNode> { new() };
            case 2:
                return new List<TreeNode>();
            default:
                var ans = new List<TreeNode>();
                for (var i = 1; i < n - 1; i++)
                {
                    var leftTrees = AllPossibleFBT(i);
                    var rightTrees = AllPossibleFBT(n - 1 - i);
                    ans.AddRange(leftTrees.SelectMany(_ => rightTrees, (left, right) => new TreeNode(0, left, right)));
                }

                return ans;
        }
    }
}
