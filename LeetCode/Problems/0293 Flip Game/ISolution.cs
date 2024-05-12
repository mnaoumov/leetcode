using JetBrains.Annotations;

namespace LeetCode._0293_Flip_Game;

[PublicAPI]
public interface ISolution
{
    public IList<string> GeneratePossibleNextMoves(string currentState);
}
