using JetBrains.Annotations;

namespace LeetCode.Problems._2914_Minimum_Number_of_Changes_to_Make_Binary_String_Beautiful;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-116/submissions/detail/1086082956/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinChanges(string s)
    {
        var n = s.Length;
        var ans = 0;

        var groupLength = 1;
        var groupCharacter = s[0];

        for (var i = 1; i < n; i++)
        {
            if (s[i] == groupCharacter)
            {
                groupLength++;
                continue;
            }

            groupLength = 1;

            if (groupLength % 2 == 0)
            {
                groupCharacter = s[i];
            }
            else
            {
                ans++;
                groupCharacter = s[i] == '0' ? '1' : '0';
            }
        }

        return ans;
    }
}
