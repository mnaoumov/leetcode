using JetBrains.Annotations;

namespace LeetCode.Problems._0576_Out_of_Boundary_Paths;

[PublicAPI]
public interface ISolution
{
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn);
}
