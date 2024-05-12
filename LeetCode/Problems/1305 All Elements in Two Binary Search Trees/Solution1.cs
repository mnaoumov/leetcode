using JetBrains.Annotations;

namespace LeetCode.Problems._1305_All_Elements_in_Two_Binary_Search_Trees;

/// <summary>
/// https://leetcode.com/submissions/detail/905946628/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> GetAllElements(TreeNode? root1, TreeNode? root2)
    {
        var arr1 = Inorder(root1).ToArray();
        var arr2 = Inorder(root2).ToArray();
        return Merge(arr1, arr2);
    }

    private static IList<int> Merge(IReadOnlyList<int> arr1, IReadOnlyList<int> arr2)
    {
        var result = new int[arr1.Count + arr2.Count];

        var index1 = 0;
        var index2 = 0;

        for (var i = 0; i < result.Length; i++)
        {
            var value1 = GetValueOrDefault(arr1, index1, int.MaxValue);
            var value2 = GetValueOrDefault(arr2, index2, int.MaxValue);

            if (value1 <= value2)
            {
                index1++;
            }
            else
            {
                index2++;
            }

            result[i] = Math.Min(value1, value2);
        }


        return result;
    }

    private static T GetValueOrDefault<T>(IReadOnlyList<T> array, int index, T defaultValue) => index < array.Count ? array[index] : defaultValue;

    private static IEnumerable<int> Inorder(TreeNode? node) => node == null ? Enumerable.Empty<int>() : Inorder(node.left).Append(node.val).Concat(Inorder(node.right));
}
