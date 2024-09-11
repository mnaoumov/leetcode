namespace LeetCode.Problems._2463_Minimum_Total_Distance_Traveled;

/// <summary>
/// https://leetcode.com/problems/minimum-total-distance-traveled/submissions/838919365/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long MinimumTotalDistance(IList<int> robot, int[][] factory) => MinimumTotalDistanceImpl(robot, factory);

    private static long MinimumTotalDistanceImpl(IList<int> robotPositions, int[][] factoryArrays)
    {
        robotPositions = robotPositions.OrderBy(x => x).ToList();
        factoryArrays = factoryArrays.OrderBy(arr => arr[0]).ToArray();

        var dp = new DynamicProgramming<(int robotIndex, int factoryIndex, int factoryCapacity), long>(
            (key, recursiveFunc) =>
            {
                var (robotIndex, factoryIndex, factoryCapacity) = key;

                if (robotIndex == robotPositions.Count)
                {
                    return 0;
                }

                if (factoryIndex == factoryArrays.Length)
                {
                    return long.MaxValue;
                }

                var skipFactoryResult = recursiveFunc((robotIndex, factoryIndex + 1, 0));

                if (factoryCapacity >= factoryArrays[factoryIndex][1])
                {
                    return skipFactoryResult;
                }

                var useFactoryResult = recursiveFunc((robotIndex + 1, factoryIndex, factoryCapacity + 1));

                return useFactoryResult == long.MaxValue
                    ? skipFactoryResult
                    : Math.Min(skipFactoryResult,
                        Math.Abs(robotPositions[robotIndex] - factoryArrays[factoryIndex][0]) + useFactoryResult);
            });

        return dp.GetOrCalculate((0, 0, 0));
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
