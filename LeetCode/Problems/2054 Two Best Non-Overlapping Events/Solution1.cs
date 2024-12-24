namespace LeetCode.Problems._2054_Two_Best_Non_Overlapping_Events;

/// <summary>
/// https://leetcode.com/submissions/detail/1473080405/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxTwoEvents(int[][] events)
    {
        var eventObjs = events.Select(arr => new Event(arr[0], arr[1], arr[2])).OrderBy(e => e.Start).ToArray();
        var starts = eventObjs.Select(e => e.Start).ToArray();

        var n = eventObjs.Length;
        var maxValues = new int[n];

        for (var i = n - 1; i >= 0; i--)
        {
            maxValues[i] = Math.Max(i + 1 < n ? maxValues[i + 1] : 0, eventObjs[i].Value);
        }

        var ans = maxValues[0];

        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var eventObj in eventObjs)
        {
            var index = BinarySearchFirst(starts, eventObj.End + 1);
            if (index < n)
            {
                ans = Math.Max(ans, eventObj.Value + maxValues[index]);
            }
        }

        return ans;
    }

    private record Event(int Start, int End, int Value);

    private static int BinarySearchFirst<T>(IReadOnlyList<T> arr, T value, int? firstIndex = null, int? lastIndex = null) where T : IComparable<T>
    {
        var low = firstIndex ?? 0;
        var high = lastIndex ?? arr.Count - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (arr[mid].CompareTo(value) >= 0)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }
}
