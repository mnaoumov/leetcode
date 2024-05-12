using JetBrains.Annotations;

namespace LeetCode._3127_Make_a_Square_with_the_Same_Color;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-129/submissions/detail/1243292492/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanMakeSquare(char[][] grid)
    {
        for (var i = 0; i < 2; i++)
        {
            for (var j = 0; j < 2; j++)
            {
                var blackCount = 0;

                for (var row = i; row < i + 2; row++)
                {
                    for (var column = j; column < j + 2; column++)
                    {
                        if (grid[row][column] == 'B')
                        {
                            blackCount++;
                        }
                    }
                }

                if (blackCount != 2)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
