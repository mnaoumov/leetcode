namespace LeetCode.Problems._3761_Minimum_Absolute_Distance_Between_Mirror_Pairs;

/// <summary>
/// https://leetcode.com/problems/minimum-absolute-distance-between-mirror-pairs/submissions/1980504325/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinMirrorPairDistance(int[] nums)
    {
        var n = nums.Length;
        var numIndexMap = new Dictionary<int, int>();
        var ans = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];

            var hasTrailingZeros = false;

            while (num % 10 == 0)
            {
                hasTrailingZeros = true;
                num /= 10;
            }

            if (!hasTrailingZeros)
            {
                var reversed = Reverse(num);

                if (numIndexMap.TryGetValue(reversed, out var j))
                {
                    ans = Math.Min(ans, i - j);
                }
            }

            numIndexMap[num] = i;
        }

        return ans == int.MaxValue ? -1 : ans;
    }

    private static int Reverse(int num) => Digits(num).Aggregate(0, (current, digit) => 10 * current + digit);

    private static List<int> Digits(int num)
    {
        var ans = new List<int>();

        while (num > 0)
        {
            var digit = num % 10;
            ans.Add(digit);
            num /= 10;
        }

        return ans;
    }
}
