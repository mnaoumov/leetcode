using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode._1799_Maximize_Score_After_N_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/949883745/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxScore(int[] nums)
    {
        var gcdDp = new DynamicProgramming<(int index1, int index2), int>((key, _) =>
        {
            var (index1, index2) = key;
            return (int) BigInteger.GreatestCommonDivisor(nums[index1], nums[index2]);
        });

        var dp = new DynamicProgramming<(int operationId, int takenMask), int>((key, recursiveFunc) =>
        {
            var (operationId, takenMask) = key;

            var availableIndices = new List<int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if ((takenMask & 1 << i) == 0)
                {
                    availableIndices.Add(i);
                }
            }

            var ans = 0;

            for (var j = 0; j < availableIndices.Count; j++)
            {
                for (var k = j + 1; k < availableIndices.Count; k++)
                {
                    var index1 = availableIndices[j];
                    var index2 = availableIndices[k];
                    var score = operationId * gcdDp.GetOrCalculate((index1, index2));
                    var nextMask = takenMask | 1 << index1 | 1 << index2;
                    var nextScore = recursiveFunc((operationId + 1, nextMask));
                    ans = Math.Max(ans, score + nextScore);
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((1, 0));
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
