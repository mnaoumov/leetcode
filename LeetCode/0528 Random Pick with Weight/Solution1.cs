using JetBrains.Annotations;

namespace LeetCode._0528_Random_Pick_with_Weight;

/// <summary>
/// https://leetcode.com/submissions/detail/950458872/
/// https://leetcode.com/submissions/detail/950459507/
/// https://leetcode.com/submissions/detail/950461969/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public ISolutionImpl Create(int[] w) => new Solution(w);

    private class Solution : ISolutionImpl
    {
        private readonly int[] _totalWeights;
        private readonly Random _random;

        public Solution(IEnumerable<int> w)
        {
            var totalWeight = 0;
            _random = new Random();
            _totalWeights = w.Select(weight => totalWeight += weight).ToArray();
        }
    
        public int PickIndex()
        {
            var randomTotalWeight = _random.Next(_totalWeights[^1]);
            var index = Array.BinarySearch(_totalWeights, randomTotalWeight);

            if (index < 0)
            {
                index = ~index;
            }

            return index;
        }
    }
}
