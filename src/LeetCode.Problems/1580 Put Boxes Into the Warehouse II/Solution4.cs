namespace LeetCode.Problems._1580_Put_Boxes_Into_the_Warehouse_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1289488463/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    public int MaxBoxesInWarehouse(int[] boxes, int[] warehouse)
    {
        var n = warehouse.Length;
        Array.Sort(boxes);

        var dp = new DynamicProgramming<(int boxIndex, int leftBarrierIndex, int rightBarrierIndex), int>((key, recursiveFunc) =>
        {
            var (boxIndex, leftBarrierIndex, rightBarrierIndex) = key;

            if (boxIndex == 0)
            {
                var ans = 0;
                var maxIndex = 0;

                for (var i = 0; i < n; i++)
                {
                    if (warehouse[i] < boxes[0])
                    {
                        break;
                    }

                    ans = Math.Max(ans, 1 + recursiveFunc((1, i, i)));
                    maxIndex = 0;
                }

                for (var i = n - 1; i > maxIndex; i--)
                {
                    if (warehouse[i] < boxes[0])
                    {
                        break;
                    }

                    ans = Math.Max(ans, 1 + recursiveFunc((1, i, i)));
                }

                return ans;
            }

            if (boxIndex == boxes.Length)
            {
                return 0;
            }

            if (leftBarrierIndex < 0)
            {
                return 0;
            }

            if (rightBarrierIndex >= n)
            {
                return 0;
            }

            var box = boxes[boxIndex];
            var maxPushingFromTheLeftIndex = leftBarrierIndex - 1;

            for (var i = 0; i < leftBarrierIndex; i++)
            {
                if (warehouse[i] >= box)
                {
                    continue;
                }

                maxPushingFromTheLeftIndex = i - 1;
                break;
            }

            var minPushingFromTheRightIndex = rightBarrierIndex + 1;

            for (var i = n - 1; i > rightBarrierIndex; i--)
            {
                if (warehouse[i] >= box)
                {
                    continue;
                }

                minPushingFromTheRightIndex = i + 1;
                break;
            }

            if (maxPushingFromTheLeftIndex < 0 && minPushingFromTheRightIndex >= n)
            {
                return 0;
            }

            return 1 + Math.Max(
                recursiveFunc((boxIndex + 1, maxPushingFromTheLeftIndex, rightBarrierIndex)),
                recursiveFunc((boxIndex + 1, leftBarrierIndex, minPushingFromTheRightIndex))
            );
        });

        return dp.GetOrCalculate((0, 0, 0));
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
