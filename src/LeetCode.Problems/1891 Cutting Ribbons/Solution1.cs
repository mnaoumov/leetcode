namespace LeetCode.Problems._1891_Cutting_Ribbons;

/// <summary>
/// https://leetcode.com/submissions/detail/1475352455/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxLength(int[] ribbons, int k)
    {
        var sum = ribbons.Select(r => (long) r).Sum();
        if (sum < k)
        {
            return 0;
        }

        var low = 1;
        var high = ribbons.Max();

        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            var count = ribbons.Sum(r => (long) r / mid);

            if (count < k)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return high;
    }
}
