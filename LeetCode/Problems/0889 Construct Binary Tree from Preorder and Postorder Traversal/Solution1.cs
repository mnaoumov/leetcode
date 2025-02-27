namespace LeetCode.Problems._0889_Construct_Binary_Tree_from_Preorder_and_Postorder_Traversal;

/// <summary>
/// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-postorder-traversal/submissions/1552983620/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        var n = postorder.Length;

        var preorderNumIndexMap = new Dictionary<int, int>();
        var postorderNumIndexMap = new Dictionary<int, int>();

        for (var i = 0; i < n; i++)
        {
            preorderNumIndexMap[preorder[i]] = i;
            postorderNumIndexMap[postorder[i]] = i;
        }

        return Build(0, 0, n);

        TreeNode Build(int preorderIndex, int postorderIndex, int count)
        {
            var rootValue = preorder[preorderIndex];

            var node = new TreeNode
            {
                val = rootValue
            };

            if (count == 1)
            {
                return node;
            }

            var leftPreorderIndex = preorderIndex + 1;
            var rightPostorderIndex = postorderIndex + count - 2;
            var leftValue = preorder[leftPreorderIndex];
            var rightValue = postorder[rightPostorderIndex];

            if (leftValue != rightValue)
            {
                var leftPostorderIndex = postorderNumIndexMap[leftValue];
                var rightPreorderIndex = preorderNumIndexMap[rightValue];
                node.left = Build(leftPreorderIndex, postorderIndex, rightPreorderIndex - leftPreorderIndex);
                node.right = Build(rightPreorderIndex, leftPostorderIndex + 1,
                    count - 1 - rightPreorderIndex + leftPreorderIndex);
            }
            else
            {
                node.left = Build(leftPreorderIndex, postorderIndex, count - 1);
            }

            return node;
        }
    }
}
