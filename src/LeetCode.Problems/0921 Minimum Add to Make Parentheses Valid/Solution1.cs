namespace LeetCode.Problems._0921_Minimum_Add_to_Make_Parentheses_Valid;

/// <summary>
/// https://leetcode.com/submissions/detail/1416492244/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinAddToMakeValid(string s)
    {
        var ans = 0;
        var balance = 0;
        const char open = '(';

        foreach (var bracket in s)
        {
            if (bracket == open)
            {
                balance++;
            }
            else
            {
                balance--;

                if (balance != -1)
                {
                    continue;
                }

                ans++;
                balance = 0;
            }
        }

        ans += balance;
        return ans;
    }
}
