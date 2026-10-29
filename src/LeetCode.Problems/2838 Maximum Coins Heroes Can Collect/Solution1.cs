namespace LeetCode.Problems._2838_Maximum_Coins_Heroes_Can_Collect;

/// <summary>
/// https://leetcode.com/submissions/detail/1416501233/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long[] MaximumCoins(int[] heroes, int[] monsters, int[] coins)
    {
        var powerTotalRewardMap = new Dictionary<int, long>
        {
            [0] = 0
        };

        var previousPower = 0;

        foreach (var (power, reward) in monsters.Zip(coins, (power, reward) => (power, reward)).OrderBy(x => x.power))
        {
            powerTotalRewardMap[power] = powerTotalRewardMap[previousPower] + reward;
            previousPower = power;
        }

        var sortedPowers = powerTotalRewardMap.Keys.OrderBy(x => x).ToArray();

        return heroes.Select(GetHeroTotalReward).ToArray();

        long GetHeroTotalReward(int heroPower)
        {
            var powerIndex = Array.BinarySearch(sortedPowers, heroPower);
            if (powerIndex < 0)
            {
                powerIndex = ~powerIndex - 1;
            }

            var closestPower = sortedPowers[powerIndex];
            return powerTotalRewardMap[closestPower];
        }
    }
}
