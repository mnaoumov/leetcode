using JetBrains.Annotations;

namespace LeetCode.Problems._2196_Create_Binary_Tree_From_Descriptions;

/// <summary>
/// https://leetcode.com/submissions/detail/1321257986/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        var nodesMap = new Dictionary<int, TreeNode>();
        var childValues = new HashSet<int>();

        foreach (var description in descriptions)
        {
            var parent = description[0];
            var child = description[1];
            childValues.Add(child);
            var isLeft = description[2] == 1;

            if (!nodesMap.ContainsKey(parent))
            {
                nodesMap[parent] = new TreeNode(parent);
            }

            if (!nodesMap.ContainsKey(child))
            {
                nodesMap[child] = new TreeNode(child);
            }

            if (isLeft)
            {
                nodesMap[parent].left = nodesMap[child];
            }
            else
            {
                nodesMap[parent].right = nodesMap[child];
            }
        }

        var rootValue = nodesMap.Keys.Except(childValues).Single();
        return nodesMap[rootValue];
    }
}
