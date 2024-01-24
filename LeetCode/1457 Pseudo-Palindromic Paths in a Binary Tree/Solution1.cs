using JetBrains.Annotations;

namespace LeetCode._1457_Pseudo_Palindromic_Paths_in_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1155990699/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PseudoPalindromicPaths (TreeNode root)
    {
        var ans = 0;

        var oddFrequencyValues = new HashSet<int>();

        Dfs(root);

        return ans;

        void Dfs(TreeNode? node)
        {
            if (node == null)
            {
                return;
            }

            var isLeafNode = node.left == null && node.right == null;
            UpdateFrequency(node.val);

            Dfs(node.left);
            Dfs(node.right);

            if (isLeafNode)
            {
                if (oddFrequencyValues.Count <= 1)
                {
                    ans++;
                }
            }

            UpdateFrequency(node.val);
        }

        void UpdateFrequency(int value)
        {
            if (!oddFrequencyValues.Add(value))
            {
                oddFrequencyValues.Remove(value);
            }
        }
    }
}
