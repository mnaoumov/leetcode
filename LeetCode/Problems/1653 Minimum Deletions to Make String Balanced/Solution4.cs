using JetBrains.Annotations;

namespace LeetCode.Problems._1653_Minimum_Deletions_to_Make_String_Balanced;

/// <summary>
/// https://leetcode.com/submissions/detail/1339008241/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
{
    public int MinimumDeletions(string s)
    {
        var groupSizes = new List<int> { 0 };

        foreach (var letter in s)
        {
            var groupLetter = groupSizes.Count % 2 == 1 ? 'a' : 'b';

            if (letter == groupLetter)
            {
                groupSizes[^1]++;
            }
            else
            {
                groupSizes.Add(1);
            }
        }

        if (groupSizes.Count % 2 == 1)
        {
            groupSizes.Add(0);
        }

        var n = groupSizes.Count;

        var bDeletions = new int[n];

        for (var i = 1; i < n; i++)
        {
            bDeletions[i] = bDeletions[i - 1] + (i % 2 == 1 ? groupSizes[i] : 0);
        }

        var aDeletions = new int[n];

        for (var i = n - 2; i >= 0; i--)
        {
            aDeletions[i] = aDeletions[i + 1] + (i % 2 == 0 ? groupSizes[i] : 0);
        }

        var ans = aDeletions[0];

        for (var i = 1; i < n - 2; i += 2)
        {
            ans = Math.Min(ans, bDeletions[i] + aDeletions[i + 2]);
        }

        return ans;
    }
}
