using JetBrains.Annotations;

namespace LeetCode._1011_Capacity_To_Ship_Packages_Within_D_Days;

[PublicAPI]
public interface ISolution
{
    public int ShipWithinDays(int[] weights, int days);
}
