using JetBrains.Annotations;

namespace LeetCode._0322_Coin_Change;

[PublicAPI]
public interface ISolution
{
    public int CoinChange(int[] coins, int amount);
}