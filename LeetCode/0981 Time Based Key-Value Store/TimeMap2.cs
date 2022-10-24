namespace LeetCode._0981_Time_Based_Key_Value_Store;

/// <summary>
/// https://leetcode.com/submissions/detail/829085381/
/// </summary>
public class TimeMap2 : ITimeMap
{
    private readonly Dictionary<string, List<(int timestamp, string value)>> _dict = new();

    public void Set(string key, string value, int timestamp)
    {
        if (!_dict.TryGetValue(key, out var list))
        {
            list = _dict[key] = new List<(int timestamp, string value)>();
        }

        var insertIndex = SearchInsertIndex(list, timestamp);

        var pair = (timestamp, value);

        if (insertIndex < list.Count && list[insertIndex].timestamp == timestamp)
        {
            list[insertIndex] = pair;
        }
        else
        {
            list.Insert(insertIndex, pair);
        }
    }

    public string Get(string key, int timestamp)
    {
        const string missingValue = "";

        if (!_dict.TryGetValue(key, out var list))
        {
            return missingValue;
        }

        var nearestIndex = SearchInsertIndex(list, timestamp);

        if (nearestIndex >= list.Count)
        {
            return list[^1].value;
        }

        if (list[nearestIndex].timestamp == timestamp)
        {
            return list[nearestIndex].value;
        }

        return nearestIndex == 0 ? missingValue : list[nearestIndex - 1].value;
    }

    private static int SearchInsertIndex(IReadOnlyList<(int timestamp, string value)> list, int timestamp)
    {
        var left = 0;
        var right = list.Count - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;

            var entryTimestamp = list[mid].timestamp;

            if (entryTimestamp < timestamp)
            {
                left = mid + 1;
            }
            else if (entryTimestamp > timestamp)
            {
                right = mid - 1;
            }
            else
            {
                return mid;
            }
        }

        return left;
    }
}