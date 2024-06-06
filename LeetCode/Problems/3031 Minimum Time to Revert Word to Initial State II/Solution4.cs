using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._3031_Minimum_Time_to_Revert_Word_to_Initial_State_II;

/// <summary>
/// NotImplemented
/// </summary>
[UsedImplicitly]
[Category("TODO")]
public class Solution4 : ISolution
{
    public int MinimumTimeToInitialState(string word, int k)
    {
        var skip = new SortedSet<int>();
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

                    for (var s = i + 1; s <= j / k; s++)
                    {
                        if (word[j] != word[j - s * k])
                        {
                            skip.Add(s);
                        }
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
