namespace LeetCode.Problems._2914_Minimum_Number_of_Changes_to_Make_Binary_String_Beautiful;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-116/submissions/detail/1086087548/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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

            if (groupLength % 2 == 0)
            {
                groupLength = 1;
                groupCharacter = s[i];
            }
            else
            {
                groupLength++;
                ans++;
            }
        }

        return ans;
    }
}
