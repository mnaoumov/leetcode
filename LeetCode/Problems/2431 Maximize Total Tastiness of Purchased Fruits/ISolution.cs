using JetBrains.Annotations;

namespace LeetCode._2431_Maximize_Total_Tastiness_of_Purchased_Fruits;

[PublicAPI]
public interface ISolution
{
    public int MaxTastiness(int[] price, int[] tastiness, int maxAmount, int maxCoupons);
}
