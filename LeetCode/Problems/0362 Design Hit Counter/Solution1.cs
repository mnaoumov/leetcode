namespace LeetCode.Problems._0362_Design_Hit_Counter;

/// <summary>
/// https://leetcode.com/problems/design-hit-counter/submissions/1904788935/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IHitCounter Create() => new HitCounter();

    private class HitCounter : IHitCounter
    {
        private readonly Dictionary<int, int> _hitsByTimestamp = new();
        private readonly SortedSet<int> _timestamps = new();
        private int _totalHits = 0;

        public void Hit(int timestamp)
        {
            _hitsByTimestamp.TryAdd(timestamp, 0);
            _hitsByTimestamp[timestamp]++;
            _timestamps.Add(timestamp);
            _totalHits++;
            Cleanup(timestamp);
        }
    
        public int GetHits(int timestamp)
        {
            Cleanup(timestamp);
            return _totalHits;
        }

        private void Cleanup(int lastTimestamp)
        {
            const int threshold = 300;

            foreach (var timestamp in _timestamps.TakeWhile(timestamp => timestamp <= lastTimestamp - threshold).ToArray())
            {
                _totalHits -= _hitsByTimestamp[timestamp];
                _hitsByTimestamp.Remove(timestamp);
                _timestamps.Remove(timestamp);
            }
        }
    }
}
