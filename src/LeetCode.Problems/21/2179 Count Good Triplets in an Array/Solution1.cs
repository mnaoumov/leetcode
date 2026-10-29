namespace LeetCode.Problems._2179_Count_Good_Triplets_in_an_Array;

/// <summary>
/// https://leetcode.com/problems/count-good-triplets-in-an-array/submissions/1607138011/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long GoodTriplets(int[] nums1, int[] nums2)
    {
        var n = nums1.Length;
        var nums2Adjusted = new int[n];

        for (var i = 0; i < n; i++)
        {
            var num1 = nums1[i];
            nums2Adjusted[num1] = nums2[i];
        }

        var lessCounts = new int[n];

        var sorted = new SortedSet<int>();

        for (var i = 0; i < n; i++)
        {
            var num2 = nums2Adjusted[i];
            var view = sorted.GetViewBetween(-1, num2 - 1);
            lessCounts[i] = view.Count;
            sorted.Add(num2);
        }

        sorted.Clear();
        var greaterCounts = new int[n];

        for (var i = n - 1; i >= 0; i--)
        {
            var num2 = nums2Adjusted[i];
            var view = sorted.GetViewBetween(num2 + 1, n);
            greaterCounts[i] = view.Count;
            sorted.Add(num2);
        }

        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            ans += 1L * lessCounts[i] * greaterCounts[i];
        }

        return ans;
    }
}
