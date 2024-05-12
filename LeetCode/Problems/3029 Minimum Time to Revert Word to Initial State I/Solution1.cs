using JetBrains.Annotations;

namespace LeetCode.Problems._3029_Minimum_Time_to_Revert_Word_to_Initial_State_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-383/submissions/detail/1165399228/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumTimeToInitialState(string word, int k)
    {
        for (var i = 1; i <= (word.Length + k - 1) / k; i++)
        {
            var isSuffixMatch = true;

            for (var j = i * k; j < word.Length; j++)
            {
                if (word[j] == word[j - i * k])
                {
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
