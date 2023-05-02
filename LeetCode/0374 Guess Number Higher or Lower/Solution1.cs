using JetBrains.Annotations;

namespace LeetCode._0374_Guess_Number_Higher_or_Lower;

/// <summary>
/// https://leetcode.com/problems/guess-number-higher-or-lower/submissions/844280524/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : GuessGame
{
    public override int GuessNumber(int n)
    {
        var min = 1;
        var max = n;

        while (min <= max)
        {
            var mid = (min + max) / 2;
            var guessResult = guess(mid);

            switch (guessResult)
            {
                case 0:
                    return mid;
                case 1:
                    min = mid + 1;
                    break;
                case -1:
                    max = mid - 1;
                    break;
            }
        }

        throw new InvalidOperationException();
    }
}
