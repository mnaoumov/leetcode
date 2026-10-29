namespace LeetCode.Problems._1550_Three_Consecutive_Odds;

/// <summary>
/// https://leetcode.com/submissions/detail/1305477123/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool ThreeConsecutiveOdds(int[] arr)
    {
        var count = 0;
        foreach (var i in arr)
        {
            if (i % 2 == 1)
            {
                count++;
                if (count == 3)
                {
                    return true;
                }
            }
            else
            {
                count = 0;
            }
        }

        return false;
    }
}
