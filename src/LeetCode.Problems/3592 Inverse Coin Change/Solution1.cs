namespace LeetCode.Problems._3592_Inverse_Coin_Change;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-455/problems/inverse-coin-change/submissions/1672224873/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> FindCoins(int[] numWays)
    {
        var ans = new List<int>();

        for (var i = 1; i <= numWays.Length; i++)
        {
            var ways = Enumerable.Range(0, ans.Count).Select(maxCoinIndex => CalculateWays(maxCoinIndex, i - ans[maxCoinIndex])).ToArray();
            var restWays = numWays[i - 1] - ways.Sum();

            if (restWays == 1)
            {
                ans.Add(i);
            }
            else if (restWays != 0)
            {
                return new List<int>();
            }
        }

        return ans;

        int CalculateWays(int maxCoinIndex, int value)
        {
            if (value == 0)
            {
                return 1;
            }


            var ans2 = numWays[value - 1];

            for (var restIndex = maxCoinIndex + 1; restIndex < ans.Count; restIndex++)
            {
                var nextCoinValue = ans[restIndex];
                if (nextCoinValue > value)
                {
                    break;
                }
                ans2 -= CalculateWays(restIndex, value - nextCoinValue);
            }

            return ans2;
        }
    }
}
