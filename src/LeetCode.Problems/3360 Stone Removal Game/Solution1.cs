namespace LeetCode.Problems._3360_Stone_Removal_Game;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-144/submissions/detail/1460803863/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanAliceWin(int n)
    {
        var stonesToTake = 10;
        var isAliceTurn = true;

        while (true)
        {
            if (n < stonesToTake)
            {
                return !isAliceTurn;
            }

            n -= stonesToTake;
            stonesToTake--;
            isAliceTurn = !isAliceTurn;
        }
    }
}
