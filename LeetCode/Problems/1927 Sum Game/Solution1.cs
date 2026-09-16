namespace LeetCode.Problems._1927_Sum_Game;

/// <summary>
/// https://leetcode.com/problems/sum-game/submissions/2118610951/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool SumGame(string num)
    {
        var n = num.Length / 2;

        var diff = 0;
        var isAliceTurn = true;
        var minAliceDiff = 0;
        var maxAliceDiff = 0;
        var minBobDiff = 0;
        var maxBobDiff = 0;

        const char placeholder = '?';

        for (var i = 0; i < 2 * n; i++)
        {
            var symbol = num[i];

            if (symbol == placeholder)
            {
                if (i < n)
                {
                    if (isAliceTurn)
                    {
                        maxAliceDiff += 9;
                    }
                    else
                    {
                        maxBobDiff += 9;
                    }
                }
                else
                {
                    if (isAliceTurn)
                    {
                        minAliceDiff -= 9;
                    }
                    else
                    {
                        minBobDiff -= 9;
                    }
                }

                isAliceTurn = !isAliceTurn;
            }
            else
            {
                var digit = symbol - '0';
                if (i < n)
                {
                    diff += digit;
                }
                else
                {
                    diff -= digit;
                }
            }
        }

        return diff + maxAliceDiff + minBobDiff > 0 || diff + minAliceDiff + maxBobDiff < 0;
    }
}
