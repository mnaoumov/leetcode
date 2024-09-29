namespace LeetCode.Problems._0432_All_O_one_Data_Structure;

/// <summary>
/// https://leetcode.com/submissions/detail/1405495536/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IAllOne Create() => new AllOne();

    private class AllOne : IAllOne
    {
        private readonly Dictionary<string, int> _counts = new();
        private readonly SortedSet<(int count, string str)> _sorted = new();

        public void Inc(string key)
        {
            _counts.TryAdd(key, 0);
            _counts[key]++;
            var count = _counts[key];
            _sorted.Remove((count - 1,key));
            _sorted.Add((count, key));
        }

        public void Dec(string key)
        {
            _counts[key]--;
            var count = _counts[key];
            _sorted.Remove((count + 1, key));

            if (count == 0)
            {
                _counts.Remove(key);
            }
            else
            {
                _sorted.Add((count, key));
            }
        }

        public string GetMaxKey() => _sorted.Count == 0 ? "" : _sorted.Max.str;
        public string GetMinKey() => _sorted.Count == 0 ? "" : _sorted.Min.str;
    }
}
