namespace LeetCode.Problems._2251_Number_of_Flowers_in_Full_Bloom;

/// <summary>
/// https://leetcode.com/submissions/detail/915398774/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FullBloomFlowers(int[][] flowers, int[] persons)
    {
        var n = persons.Length;
        var result = new int[n];
        var startTimes = flowers.Select(f => f[0]).OrderBy(x => x).ToArray();
        var endTimes = flowers.Select(f => f[1]).OrderBy(x => x).ToArray();

        for (var i = 0; i < n; i++)
        {
            var personTime = persons[i];
            var startedCounts = BinarySearchLast(startTimes, personTime);
            var endedCounts = BinarySearchLast(endTimes, personTime - 1);
            result[i] = startedCounts - endedCounts;
        }

        return result;
    }

    private static int BinarySearchLast<T>(IReadOnlyList<T> arr, T value) where T : IComparable<T>
    {
        var low = 0;
        var high = arr.Count - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (value.CompareTo(arr[mid]) >= 0)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return low;
    }
}
