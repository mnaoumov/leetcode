namespace LeetCode.Problems._0259_3Sum_Smaller;

/// <summary>
/// https://leetcode.com/problems/3sum-smaller/submissions/1830011001/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int ThreeSumSmaller(int[] nums, int target)
    {
        var n = nums.Length;
        var ans = 0;

        var set = new SortedSet<(int num, int index)>();

        for (var j = n - 1; j >= 0; j--)
        {
            var num1ToNum3Counts = new Dictionary<int, int>();
            for (var i = j - 1; i >= 0; i--)
            {
                if (num1ToNum3Counts.TryGetValue(nums[i], out var num3Counts))
                {
                    ans += num3Counts;
                    continue;
                }
                var maxNum = target - nums[i] - nums[j];
                num3Counts = set.GetViewBetween((int.MinValue, 0), (maxNum, -1)).Count;
                num1ToNum3Counts[nums[i]] = num3Counts;
                ans += num3Counts;
            }

            set.Add((nums[j], j));
        }

        return ans;
    }
}
