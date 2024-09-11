namespace LeetCode.Problems._2533_Number_of_Good_Binary_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/879630831/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int GoodBinaryStrings(int minLength, int maxLength, int oneGroup, int zeroGroup)
    {
        const int modulo = 1_000_000_007;

        if (maxLength < 0)
        {
            return 0;
        }

        var startWithOnes = GoodBinaryStrings(minLength - oneGroup, maxLength - oneGroup, oneGroup, zeroGroup);
        var startWithZeros = GoodBinaryStrings(minLength - zeroGroup, maxLength - zeroGroup, oneGroup, zeroGroup);

        return (startWithOnes + startWithZeros + (minLength <= 0 ? 1 : 0)) % modulo;
    }
}
