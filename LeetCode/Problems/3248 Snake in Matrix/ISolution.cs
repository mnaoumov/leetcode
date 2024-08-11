using JetBrains.Annotations;

namespace LeetCode.Problems._3248_Snake_in_Matrix;

[PublicAPI]
public interface ISolution
{
    public int FinalPositionOfSnake(int n, IList<string> commands);
}
