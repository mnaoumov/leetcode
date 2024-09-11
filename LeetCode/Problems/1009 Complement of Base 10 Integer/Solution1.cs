namespace LeetCode.Problems._1009_Complement_of_Base_10_Integer;

/// <summary>
/// https://leetcode.com/submissions/detail/1364176074/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int BitwiseComplement(int n)
    {
        var ans = 0;
        var bitCount = 0;

        while (n > 0)
        {
            if ((n & 1) == 0)
            {
                ans |= 1 << bitCount;
            }
            n >>= 1;
            bitCount++;
        }

        return ans;
    }
}
