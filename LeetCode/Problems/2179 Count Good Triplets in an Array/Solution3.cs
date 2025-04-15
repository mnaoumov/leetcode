namespace LeetCode.Problems._2179_Count_Good_Triplets_in_an_Array;

/// <summary>
/// https://leetcode.com/problems/count-good-triplets-in-an-array/submissions/1607191692/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long GoodTriplets(int[] nums1, int[] nums2)
    {
        var n = nums1.Length;
        var nums2Adjusted = new int[n];
        var nums2Reversed = new int[n];

        for (var i = 0; i < n; i++)
        {
            var num2 = nums2[i];
            nums2Reversed[num2] = i;
        }

        for (var i = 0; i < n; i++)
        {
            var num1 = nums1[i];
            nums2Adjusted[i] = nums2Reversed[num1];
        }

        var lessCounts = new int[n];

        var sorted = new List<int>();

        for (var i = 0; i < n; i++)
        {
            var num2 = nums2Adjusted[i];
            var index = sorted.BinarySearch(num2);
            index = ~index;
            sorted.Insert(index, num2);
            lessCounts[i] = index;
        }

        sorted.Clear();
        var greaterCounts = new int[n];

        for (var i = n - 1; i >= 0; i--)
        {
            var num2 = nums2Adjusted[i];
            var index = sorted.BinarySearch(num2);
            index = ~index;
            sorted.Insert(index, num2);
            greaterCounts[i] = sorted.Count - 1 - index;
        }

        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            ans += 1L * lessCounts[i] * greaterCounts[i];
        }

        return ans;

    }
}
