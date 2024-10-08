namespace LeetCode.Problems._0371_Sum_of_Two_Integers;

/// <summary>
/// https://leetcode.com/submissions/detail/926864595/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int GetSum(int a, int b)
    {
        var result = 0;
        var carry = false;
        var resultBit = 1;

        while (a != 0 || b != 0 || carry)
        {
            var digitA = a & 1;
            var digitB = b & 1;

            int resultDigit;

            switch (digitA, digitB, carry)
            {
                case (0, 0, false):
                    resultDigit = 0;
                    carry = false;
                    break;
                case (0, 1, false):
                case (1, 0, false):
                case (0, 0, true):
                    resultDigit = 1;
                    carry = false;
                    break;
                case (1, 1, false):
                case (0, 1, true):
                case (1, 0, true):
                    resultDigit = 0;
                    carry = true;
                    break;
                case (1, 1, true):
                    resultDigit = 1;
                    carry = true;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            if (resultDigit == 1)
            {
                result |= resultBit;
            }

            a >>= 1;
            b >>= 1;
            resultBit <<= 1;
        }

        return result;
    }
}
