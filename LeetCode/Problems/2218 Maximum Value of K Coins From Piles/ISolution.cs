using JetBrains.Annotations;

namespace LeetCode.Problems._2218_Maximum_Value_of_K_Coins_From_Piles;

[PublicAPI]
public interface ISolution
{
    public int MaxValueOfCoins(IList<IList<int>> piles, int k);
}
