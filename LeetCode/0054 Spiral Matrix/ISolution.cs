using JetBrains.Annotations;

namespace LeetCode._0054_Spiral_Matrix;

[PublicAPI]
public interface ISolution
{
    public IList<int> SpiralOrder(int[][] matrix);
}