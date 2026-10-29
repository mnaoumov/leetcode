namespace LeetCode.Problems._1261_Find_Elements_in_a_Contaminated_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1550264323/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IFindElements Create(TreeNode root) => new FindElements(root);

    private class FindElements : IFindElements
    {
        private readonly HashSet<int> _values = new();

        public FindElements(TreeNode root) => Recover(root, 0);

        private void Recover(TreeNode? node, int value)
        {
            if (node == null)
            {
                return;
            }
            _values.Add(value);
            Recover(node.left, value * 2 + 1);
            // ReSharper disable once TailRecursiveCall
            Recover(node.right, value * 2 + 2);
        }

        public bool Find(int target) => _values.Contains(target);
    }
}
