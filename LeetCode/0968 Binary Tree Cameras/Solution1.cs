using JetBrains.Annotations;

namespace LeetCode._0968_Binary_Tree_Cameras;

/// <summary>
/// https://leetcode.com/submissions/detail/954993959/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCameraCover(TreeNode root)
    {
        var impossible = 10000;

        var dp = new DynamicProgramming<TreeNode, (int coverChildrenNoSelf, int coverSelfWithChildrenNoCamera, int coverSelfWithChildrenWithCamera)>((node, recursiveFunc) =>
        {
#pragma warning disable IDE0042
            var left = ProcessChild(node.left);
            var right = ProcessChild(node.right);
#pragma warning restore IDE0042
            var leftCovered = Math.Min(left.coverSelfWithChildrenWithCamera, left.coverSelfWithChildrenNoCamera);
            var rightCovered = Math.Min(right.coverSelfWithChildrenWithCamera, right.coverSelfWithChildrenNoCamera);
            var leftAny = Math.Min(left.coverChildrenNoSelf, leftCovered);
            var rightAny = Math.Min(right.coverChildrenNoSelf, rightCovered);

            return (
                coverChildrenNoSelf: left.coverSelfWithChildrenNoCamera + right.coverSelfWithChildrenNoCamera,
                coverSelfWithChildrenNoCamera: Math.Min(
                    left.coverSelfWithChildrenWithCamera + rightCovered,
                    right.coverSelfWithChildrenWithCamera + leftCovered),
                coverSelfWithChildrenWithCamera: 1 + leftAny + rightAny
            );

            (int coverChildrenNoSelf, int coverSelfWithChildrenNoCamera, int coverSelfWithChildrenWithCamera)
                ProcessChild(TreeNode? child) => child == null ? (0, 0, impossible) : recursiveFunc(child);
        });

        var (_, coverSelfWithChildrenNoCamera, coverSelfWithChildrenWithCamera) = dp.GetOrCalculate(root);
        return Math.Min(coverSelfWithChildrenNoCamera, coverSelfWithChildrenWithCamera);
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
