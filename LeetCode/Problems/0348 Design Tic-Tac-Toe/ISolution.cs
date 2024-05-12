using JetBrains.Annotations;

namespace LeetCode.Problems._0348_Design_Tic_Tac_Toe;

[PublicAPI]
public interface ISolution
{
    public ITicTacToe Create(int n);
}
