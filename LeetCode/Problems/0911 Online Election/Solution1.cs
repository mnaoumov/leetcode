using JetBrains.Annotations;

namespace LeetCode.Problems._0911_Online_Election;

/// <summary>
/// https://leetcode.com/submissions/detail/966465467/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ITopVotedCandidate Create(int[] persons, int[] times) => new TopVotedCandidate(persons, times);

    private class TopVotedCandidate : ITopVotedCandidate
    {
        private readonly int[] _times;
        private readonly int[] _winners;

        public TopVotedCandidate(IReadOnlyList<int> persons, int[] times)
        {
            _times = times;
            var n = persons.Count;
            _winners = new int[n];

            var counts = new Dictionary<int, int>();
            var maxCount = 0;

            for (var i = 0; i < n; i++)
            {
                var person = persons[i];
                counts[person] = counts.GetValueOrDefault(person) + 1;

                if (counts[person] >= maxCount)
                {
                    maxCount = counts[person];
                    _winners[i] = person;
                }
                else
                {
                    _winners[i] = _winners[i - 1];
                }
            }
        }
    
        public int Q(int t)
        {
            var index = Array.BinarySearch(_times, t);

            if (index < 0)
            {
                index = ~index - 1;
            }

            return _winners[index];
        }
    }
}
