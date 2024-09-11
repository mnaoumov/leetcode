namespace LeetCode.Problems._0239_Sliding_Window_Maximum;

/// <summary>
/// https://leetcode.com/submissions/detail/874613344/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var result = new int[nums.Length - k + 1];
        var countsMap = new SortedList<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        foreach (var num in nums.Take(k))
        {
            countsMap[num] = countsMap.GetValueOrDefault(num) + 1;
        }

        result[0] = countsMap.Keys[0];

        for (var i = 1; i < result.Length; i++)
        {
            var oldWindowValue = nums[i - 1];
            var newWindowValue = nums[i + k - 1];
            countsMap[oldWindowValue]--;
            countsMap[newWindowValue] = countsMap.GetValueOrDefault(newWindowValue) + 1;

            if (countsMap[oldWindowValue] == 0)
            {
                countsMap.Remove(oldWindowValue);
            }

            result[i] = countsMap.Keys[0];
        }

        return result;
    }
}
