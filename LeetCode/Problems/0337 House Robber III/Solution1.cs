using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0337_House_Robber_III;

/// <summary>
/// https://leetcode.com/submissions/detail/920405195/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int Rob(TreeNode root)
    {
        var dp = new DynamicProgramming<(TreeNode node, bool isParentRobbed), int>((key, recursiveFunc) =>
        {
            var (node, isParentRobbed) = key;

            var resultIfSkipped = 0;

            if (node.left != null)
            {
                resultIfSkipped += recursiveFunc((node.left, false));
            }

            if (node.right != null)
            {
                resultIfSkipped += recursiveFunc((node.right, false));
            }

            if (isParentRobbed)
            {
                return resultIfSkipped;
            }

            var resultIfTaken = node.val;

            if (node.left != null)
            {
                resultIfTaken += recursiveFunc((node.left, true));
            }

            if (node.right != null)
            {
                resultIfTaken += recursiveFunc((node.right, true));
            }

            return Math.Max(resultIfSkipped, resultIfTaken);
        });

        return dp.GetOrCalculate((root, false));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
