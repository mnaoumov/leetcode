using JetBrains.Annotations;

namespace LeetCode._0528_Random_Pick_with_Weight;

/// <summary>
/// https://leetcode.com/submissions/detail/950465958/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public ISolutionImpl Create(int[] w) => new Solution(w);

    private class Solution : ISolutionImpl
    {
        private readonly double[] _totalProbabilities;
        private readonly Random _random;

        public Solution(int[] w)
        {
            var totalProbability = 0d;
            _random = new Random();
            var totalWeight = w.Sum();
            _totalProbabilities = w.Select(weight => totalProbability += 1d * weight / totalWeight).ToArray();
        }
    
        public int PickIndex()
        {
            var randomTotalProbability = _random.NextDouble();
            var index = Array.BinarySearch(_totalProbabilities, randomTotalProbability);

            if (index < 0)
            {
                index = ~index;
            }

            return index;
        }
    }
}
