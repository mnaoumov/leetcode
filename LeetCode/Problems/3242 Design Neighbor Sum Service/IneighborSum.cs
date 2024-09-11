namespace LeetCode.Problems._3242_Design_Neighbor_Sum_Service;

// ReSharper disable once InconsistentNaming
[PublicAPI]
public interface IneighborSum
{
    public int AdjacentSum(int value);
    public int DiagonalSum(int value);
}
