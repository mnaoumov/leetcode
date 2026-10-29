namespace LeetCode.Problems._0476_Number_Complement;

/// <summary>
/// https://leetcode.com/submissions/detail/1364170826/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindComplement(int num)
    {
        var ans = 0;
        var bitCount = 0;

        while (num > 0)
        {
            if ((num & 1) == 0)
            {
                ans |= 1 << bitCount;
            }
            num >>= 1;
            bitCount++;
        }

        return ans;
    }
}
