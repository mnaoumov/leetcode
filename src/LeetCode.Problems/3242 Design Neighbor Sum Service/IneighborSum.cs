namespace LeetCode.Problems._3242_Design_Neighbor_Sum_Service;

// ReSharper disable once InconsistentNaming
[PublicAPI]
public interface IneighborSum
{
    int AdjacentSum(int value);
    int DiagonalSum(int value);
}
