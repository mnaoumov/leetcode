namespace LeetCode.Problems._1340_Jump_Game_V;

/// <summary>
/// https://leetcode.com/problems/jump-game-v/submissions/2012972361/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaxJumps(int[] arr, int d)
    {
        var n = arr.Length;

        var numIndicesMap = new Dictionary<int, List<int>>();

        for (var i = 0; i < n; i++)
        {
            var num = arr[i];
            numIndicesMap.TryAdd(num, new List<int>());
            numIndicesMap[num].Add(i);
        }

        var dp = Enumerable.Repeat(1, n).ToArray();

        foreach (var num in numIndicesMap.Keys.OrderBy(x => x))
        {
            foreach (var i in numIndicesMap[num])
            {
                for (var j = i + 1; j <= Math.Min(i + d, n - 1); j++)
                {
                    if (arr[j] >= arr[i])
                    {
                        break;
                    }

                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }

                for (var j = i - 1; j >= Math.Max(i - d, 0); j--)
                {
                    if (arr[j] >= arr[i])
                    {
                        break;
                    }

                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp.Max();
    }
}
