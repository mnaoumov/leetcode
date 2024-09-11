
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0239_Sliding_Window_Maximum;

/// <summary>
/// https://leetcode.com/submissions/detail/200173687/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (nums.Length == 0 && k == 0)
        {
            return new int[] { };
        }
        var sortedWindowWithCounts = new SortedList<int, int>(k);
        for (int i = 0; i < k - 1; i++)
        {
            AddToListOfCounts(sortedWindowWithCounts, nums[i]);
        }

        var results = new int[nums.Length - k + 1];
        for (int i = 0; i < results.Length; i++)
        {
            AddToListOfCounts(sortedWindowWithCounts, nums[i + k - 1]);
            results[i] = sortedWindowWithCounts.Keys.Last();
            RemoveFromListOfCounts(sortedWindowWithCounts, nums[i]);
        }

        return results;
    }

    private void RemoveFromListOfCounts(SortedList<int, int> listOfCounts, int value)
    {
        listOfCounts[value]--;

        if (listOfCounts[value] == 0)
        {
            listOfCounts.Remove(value);
        }
    }

    private static void AddToListOfCounts(SortedList<int, int> listOfCounts, int value)
    {
        if (!listOfCounts.ContainsKey(value))
        {
            listOfCounts.Add(value, 0);
        }

        listOfCounts[value]++;
    }
}
