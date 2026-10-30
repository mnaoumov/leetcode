namespace LeetCode.Problems._3242_Design_Neighbor_Sum_Service;

[PublicAPI]
public interface INeighborSum
{
    int AdjacentSum(int value);
    int DiagonalSum(int value);
}
