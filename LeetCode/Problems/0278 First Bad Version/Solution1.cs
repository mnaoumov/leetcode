namespace LeetCode.Problems._0278_First_Bad_Version;

/// <summary>
/// https://leetcode.com/submissions/detail/923215339/
/// </summary>
[UsedImplicitly]
public class Solution1 : VersionControl
{
    public override int FirstBadVersion(int n)
    {
        var low = 1;
        var high = n;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (IsBadVersion(mid))
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
