using JetBrains.Annotations;

namespace LeetCode.Problems._0173_Binary_Search_Tree_Iterator;

/// <summary>
/// https://leetcode.com/submissions/detail/882135872/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IBSTIterator Create(TreeNode root) => new BSTIterator(root);

    private class BSTIterator : IBSTIterator
    {
        private readonly IEnumerator<int> _enumerator;
        private bool _isSubsequenceHashNextCall;

        public BSTIterator(TreeNode? root) => _enumerator = Enumerate(root).GetEnumerator();

        private static IEnumerable<int> Enumerate(TreeNode? root) =>
            root == null
                ? Array.Empty<int>()
                : Enumerate(root.left).Append(root.val).Concat(Enumerate(root.right));

        public int Next()
        {
            HasNext();
            _isSubsequenceHashNextCall = false;
            return _enumerator.Current;
        }

        public bool HasNext()
        {
            if (_isSubsequenceHashNextCall)
            {
                return true;
            }

            if (!_enumerator.MoveNext())
            {
                return false;
            }

            _isSubsequenceHashNextCall = true;
            return true;
        }
    }
}
