using JetBrains.Annotations;

namespace LeetCode.Problems._0051_N_Queens;

[PublicAPI]
public interface ISolution
{
    public IList<IList<string>> SolveNQueens(int n);
}
