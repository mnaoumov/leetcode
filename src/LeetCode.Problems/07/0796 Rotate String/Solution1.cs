namespace LeetCode.Problems._0796_Rotate_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1441236834/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool RotateString(string s, string goal)
    {
        var n = s.Length;

        if (goal.Length != n)
        {
            return false;
        }

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (s[(i + j) % n] != goal[j])
                {
                    break;
                }

                if (j == n - 1)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
