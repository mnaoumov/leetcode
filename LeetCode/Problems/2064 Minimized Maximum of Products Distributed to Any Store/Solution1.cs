namespace LeetCode.Problems._2064_Minimized_Maximum_of_Products_Distributed_to_Any_Store;

/// <summary>
/// https://leetcode.com/submissions/detail/1452137409/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimizedMaximum(int n, int[] quantities) =>
        FindFirst(1, quantities.Max(),
            value => quantities.Select(quantity => (quantity + value - 1) / value).Sum() <= n);

    private static int FindFirst(int low, int high, Func<int, bool> predicate)
    {
        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            if (predicate(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }
}
