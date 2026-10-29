namespace LeetCode.Problems._2862_Maximum_Element_Sum_of_a_Complete_Subset_of_Indices;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-363/submissions/detail/1051452263/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaximumSum(IList<int> nums)
    {
        var n = nums.Count;
        var seen = new bool[n];
        var squares = Enumerable.Range(1, (int) Math.Sqrt(n)).Select(k => k * k).ToArray();

        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            if (seen[i])
            {
                continue;
            }

            var sum = 0L;

            foreach (var square in squares)
            {
                var index = (i + 1) * square - 1;

                if (index >= n)
                {
                    break;
                }

                seen[index] = true;
                sum += nums[index];
            }

            ans = Math.Max(ans, sum);
        }

        return ans;
    }
}
