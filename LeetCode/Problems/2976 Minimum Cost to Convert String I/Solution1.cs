using JetBrains.Annotations;

namespace LeetCode.Problems._2976_Minimum_Cost_to_Convert_String_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-377/submissions/detail/1127084648/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
    {
        const int lettersCount = 26;
        const long impossibleCost = long.MaxValue;

        var costs = new long[lettersCount, lettersCount];

        for (var i = 0; i < lettersCount; i++)
        {
            for (var j = 0; j < lettersCount; j++)
            {
                costs[i, j] = impossibleCost;
            }

            costs[i, i] = 0;
        }

        var n = original.Length;

        for (var k = 0; k < n; k++)
        {
            var originalLetterIndex = ToLetterIndex(original[k]);
            var changedLetterIndex = ToLetterIndex(changed[k]);
            var changeCost = cost[k];

            if (costs[originalLetterIndex, changedLetterIndex] <= changeCost)
            {
                continue;
            }

            costs[originalLetterIndex, changedLetterIndex] = changeCost;

            for (var i = 0; i < lettersCount; i++)
            {
                if (costs[i, originalLetterIndex] == impossibleCost)
                {
                    continue;
                }

                for (var j = 0; j < lettersCount; j++)
                {
                    if (costs[changedLetterIndex, j] == impossibleCost)
                    {
                        continue;
                    }

                    var newCost = costs[i, originalLetterIndex] + costs[originalLetterIndex, changedLetterIndex] +
                                  costs[changedLetterIndex, j];

                    if (costs[i, j] > newCost)
                    {
                        costs[i, j] = newCost;
                    }
                }
            }
        }

        var m = source.Length;
        var ans = 0L;

        for (var i = 0; i < m; i++)
        {
            var letterChangeCost = costs[ToLetterIndex(source[i]), ToLetterIndex(target[i])];

            if (letterChangeCost == impossibleCost)
            {
                return -1;
            }

            ans += letterChangeCost;
        }

        return ans;
    }

    private static int ToLetterIndex(char letter) => letter - 'a';
}
