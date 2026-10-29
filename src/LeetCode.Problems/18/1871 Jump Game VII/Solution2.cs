namespace LeetCode.Problems._1871_Jump_Game_VII;

/// <summary>
/// https://leetcode.com/problems/jump-game-vii/submissions/2013004356/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        var n = s.Length;

        var zeroIndices = new SortedSet<int>(Enumerable.Range(0, n).Where(i => s[i] == '0'));

        var dp = new bool[n];
        dp[n - 1] = true;

        for (var i = n - 2; i >= 0; i--)
        {
            dp[i] = zeroIndices.GetViewBetween(i + minJump, i + maxJump).Any(j => dp[j]);
        }

        return dp[0];
    }
}
