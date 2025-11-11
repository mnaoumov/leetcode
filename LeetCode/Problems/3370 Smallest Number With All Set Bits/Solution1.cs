namespace LeetCode.Problems._3370_Smallest_Number_With_All_Set_Bits;

/// <summary>
/// https://leetcode.com/problems/smallest-number-with-all-set-bits/submissions/1816405744/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SmallestNumber(int n)
    {
        var bitCounts = 0;

        while (n > 0)
        {
            bitCounts++;
            n >>= 1;
        }

        return (1 << bitCounts) - 1;
    }
}
