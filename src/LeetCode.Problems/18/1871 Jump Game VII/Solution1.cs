namespace LeetCode.Problems._1871_Jump_Game_VII;

/// <summary>
/// https://leetcode.com/problems/jump-game-vii/submissions/2013002085/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        var n = s.Length;
        var dp = new bool[n];
        dp[n - 1] = true;

        for (var i = n - 2; i >= 0; i--)
        {
            for (var j = i + minJump; j <= Math.Min(i + maxJump, n - 1); j++)
            {
                if (!dp[j] || s[j] == '1')
                {
                    continue;
                }

                dp[i] = true;
                break;
            }
        }

        return dp[0];
    }
}
