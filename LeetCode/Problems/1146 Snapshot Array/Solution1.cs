using JetBrains.Annotations;

namespace LeetCode.Problems._1146_Snapshot_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/964793338/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ISnapshotArray Create(int length) => new SnapshotArray();

    private class SnapshotArray : ISnapshotArray
    {
        private readonly Dictionary<int, List<(int snapId, int value)>> _changesMap = new();

        private int _snapId;

        public void Set(int index, int val)
        {
            _changesMap.TryAdd(index, new List<(int snapId, int value)>());

            var changes = _changesMap[index];

            if (changes.Count > 0 && changes[^1].snapId == _snapId)
            {
                changes[^1] = (_snapId, val);
            }
            else
            {
                changes.Add((_snapId, val));
            }
        }

        public int Snap()
        {
            var snapId = _snapId;
            _snapId++;
            return snapId;
        }

        // ReSharper disable once InconsistentNaming
        public int Get(int index, int snap_id)
        {
            var changes = _changesMap.GetValueOrDefault(index, new List<(int snapId, int value)>());

            var low = 0;
            var high = changes.Count - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (changes[mid].snapId <= snap_id)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return high < 0 ? 0 : changes[high].value;
        }
    }
}
