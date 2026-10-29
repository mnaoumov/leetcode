namespace LeetCode.Problems._0137_Single_Number_II;

/// <summary>
/// https://leetcode.com/problems/single-number-ii/submissions/839892169/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int SingleNumber(int[] nums)
    {
        var maxDigitsCount = (int) Math.Ceiling(Math.Log(int.MaxValue, 3));
        var resultBaseThreeDigits = new byte[maxDigitsCount];
        byte resultBinarySign = 0;

        foreach (var num in nums)
        {
            var index = 0;
            var num2 = num;
            var binarySign = 0;

            while (num2 != 0)
            {
                var digit = num2 % 3;
                num2 /= 3;

                if (digit < 0)
                {
                    num2 = -num;
                    digit = -digit;
                    binarySign = 1;
                }

                resultBinarySign = (byte) ((resultBinarySign + binarySign) % 3);
                resultBaseThreeDigits[index] = (byte) ((resultBaseThreeDigits[index] + digit) % 3);
                index++;
            }
        }

        var resultSign = resultBinarySign == 0 ? 1 : -1;

        var result = 0;
        var powerOfThree = 1;

        foreach (var digit in resultBaseThreeDigits)
        {
            result += powerOfThree * resultSign * digit;
            powerOfThree *= 3;
        }

        return result;
    }
}
