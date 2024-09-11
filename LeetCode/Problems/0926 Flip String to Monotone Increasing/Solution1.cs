namespace LeetCode.Problems._0926_Flip_String_to_Monotone_Increasing;

/// <summary>
/// https://leetcode.com/submissions/detail/879564518/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinFlipsMonoIncr(string s)
    {
        var zeroCounts = s.Count(c => c == '0');

        var zerosBeforeCurrent = 0;
        var zerosAfterCurrent = zeroCounts;

        var n = s.Length;

        var result = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            var onesToFlipLeft = i - zerosBeforeCurrent;
            var zerosToFlipRight = zerosAfterCurrent;
            result = Math.Min(result, onesToFlipLeft + zerosToFlipRight);

            if (s[i] != '0')
            {
                continue;
            }

            zerosBeforeCurrent++;
            zerosAfterCurrent--;
        }

        return result;
    }
}
