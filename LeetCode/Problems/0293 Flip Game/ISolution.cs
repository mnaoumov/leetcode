using JetBrains.Annotations;

namespace LeetCode.Problems._0293_Flip_Game;

[PublicAPI]
public interface ISolution
{
    public IList<string> GeneratePossibleNextMoves(string currentState);
}
