namespace LeetCode.Problems._2719_Count_of_Integers;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-348/submissions/detail/963405223/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    // ReSharper disable InconsistentNaming
    public int Count(string num1, string num2, int min_sum, int max_sum)
    // ReSharper restore InconsistentNaming
    {
        const int modulo = 1_000_000_007;
        var cache = new Dictionary<(string maxNumStr, int maxDigitSum, bool isInclusive), int>();

        return ModDiff(FixMaxNumber(num2, true), FixMaxNumber(num1, false));

        int FixMaxNumber(string maxNumStr, bool isInclusive) =>
            ModDiff(FixMaxDigitSum(maxNumStr, max_sum, isInclusive),
                FixMaxDigitSum(maxNumStr, min_sum - 1, isInclusive));

        int FixMaxDigitSum(string maxNumStr, int maxDigitSum, bool isInclusive)
        {
            var key = (maxNumStr, maxDigitSum, isInclusive);
            return cache.TryGetValue(key, out var ans) ? ans : cache[key] = Calculate();

            int Calculate()
            {
                if (maxDigitSum <= 0)
                {
                    return 0;
                }

                var firstDigit = maxNumStr[0] - '0';

                if (maxNumStr.Length == 1)
                {
                    var maxNum = firstDigit;

                    if (!isInclusive && maxNum > 0)
                    {
                        maxNum--;
                    }

                    return Math.Min(maxNum, maxDigitSum) + 1;
                }

                var ans2 = FixMaxDigitSum(maxNumStr[1..], maxDigitSum - firstDigit, isInclusive);
                var onlyNines = new string('9', maxNumStr.Length - 1);

                for (var i = 0; i < firstDigit; i++)
                {
                    ans2 = (ans2 + FixMaxDigitSum(onlyNines, maxDigitSum - i, true)) % modulo;
                }

                return ans2;
            }

        }

        static int ModDiff(int a, int b) => ((a - b) % modulo + modulo) % modulo;
    }
}
