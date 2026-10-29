namespace LeetCode.Problems._0228_Summary_Ranges;

/// <summary>
/// https://leetcode.com/submissions/detail/944110400/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> SummaryRanges(int[] nums)
    {
        var ans = new List<string>();

        if (nums.Length == 0)
        {
            return ans;
        }

        var min = nums[0];
        var n = nums.Length;

        for (var i = 0; i < n; i++)
        {
            var current = nums[i];
            var next = i < n - 1 ? nums[i + 1] : 0;

            if (i < n - 1 && next == current + 1)
            {
                continue;
            }

            ans.Add(current == min ? min.ToString() : $"{min}->{current}");
            min = next;
        }

        return ans;
    }
}
