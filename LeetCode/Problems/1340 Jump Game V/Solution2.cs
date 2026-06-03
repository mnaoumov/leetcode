namespace LeetCode.Problems._1340_Jump_Game_V;

/// <summary>
/// https://leetcode.com/problems/jump-game-v/submissions/2012858145/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MaxJumps(int[] arr, int d)
    {
        var n = arr.Length;
        var nextIndices = Enumerable.Range(0, n).Select(_ => new SortedSet<int>()).ToArray();
        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j <= Math.Min(i + d, n - 1); j++)
            {
                if (arr[i] <= arr[j])
                {
                    break;
                }

                nextIndices[i].Add(j);
            }

            for (var j = i - 1; j >= Math.Max(i - d, 0); j--)
            {
                if (arr[i] <= arr[j])
                {
                    break;
                }

                nextIndices[i].Add(j);
            }
        }

        var dp = new int[n];
        for (var i = 0; i < n; i++)
        {
            dp[i] = nextIndices[i].Count > 0 ? 1 : 0;
        }

        var hasChanges = true;

        while (hasChanges)
        {
            hasChanges = false;

            for (var i = 0; i < n; i++)
            {
                var max = nextIndices[i].Select(j => dp[j]).Prepend(0).Max();
                if (max + 1 > dp[i])
                {
                    dp[i] = max + 1;
                    hasChanges = true;
                }
            }
        }

        return dp.Max();
    }
}
