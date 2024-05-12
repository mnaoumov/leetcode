using JetBrains.Annotations;

namespace LeetCode._0787_Cheapest_Flights_Within_K_Stops;

[PublicAPI]
public interface ISolution
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k);
}
