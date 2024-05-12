using JetBrains.Annotations;

namespace LeetCode._0518_Coin_Change_II;

[PublicAPI]
public interface ISolution
{
    public int Change(int amount, int[] coins);
}
