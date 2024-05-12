using JetBrains.Annotations;

namespace LeetCode._3031_Minimum_Time_to_Revert_Word_to_Initial_State_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-383/submissions/detail/1165471647/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MinimumTimeToInitialState(string word, int k)
    {
        var skip = new HashSet<int>();
        var j = 0;

        for (var i = 1; i <= (word.Length + k - 1) / k; i++)
        {
            if (skip.Contains(i))
            {
                continue;
            }

            var isSuffixMatch = true;

            j = Math.Max(j, i * k);

            while (j < word.Length)
            {
                if (word[j] == word[j - i * k])
                {
                    var s = j / k;

                    if (word[j] != word[j - s * k])
                    {
                        skip.Add(s);
                    }

                    j++;

                    continue;
                }

                isSuffixMatch = false;
                break;
            }

            if (isSuffixMatch)
            {
                return i;
            }
        }

        throw new InvalidOperationException();
    }
}
