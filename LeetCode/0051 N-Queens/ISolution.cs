using JetBrains.Annotations;

namespace LeetCode._0051_N_Queens;

[PublicAPI]
public interface ISolution
{
    public IList<IList<string>> SolveNQueens(int n);
}