namespace LeetCode.Problems._1871_Jump_Game_VII;

/// <summary>
/// https://leetcode.com/problems/jump-game-vii/submissions/2013009429/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        var n = s.Length;

        var zeroIndices = new SortedSet<int>(Enumerable.Range(0, n).Where(i => s[i] == '0'));

        if (!zeroIndices.Contains(n - 1))
        {
            return false;
        }

        var reachableIndices = new SortedSet<int> { n - 1 };


        foreach (var i in zeroIndices.Reverse())
        {
            var isReachable = reachableIndices.GetViewBetween(i + minJump, i + maxJump).Count > 0;

            if (isReachable)
            {
                reachableIndices.Add(i);
            }
        }

        return reachableIndices.Contains(0);
    }
}
