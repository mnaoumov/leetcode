using JetBrains.Annotations;

namespace LeetCode.Problems._3031_Minimum_Time_to_Revert_Word_to_Initial_State_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-383/submissions/detail/1165442041/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimumTimeToInitialState(string word, int k)
    {
        var j = 0;

        for (var i = 1; i <= (word.Length + k - 1) / k; i++)
        {
            var isSuffixMatch = true;

            j = Math.Max(j, i * k);

            while (j < word.Length)
            {
                if (word[j] != word[j - i * k])
                {
                    isSuffixMatch = false;
                    break;
                }

                j++;
            }

            if (isSuffixMatch)
            {
                return i;
            }
        }

        throw new InvalidOperationException();
    }
}
