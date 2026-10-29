namespace LeetCode.Problems._0353_Design_Snake_Game;

[PublicAPI]
public interface ISolution
{
    ISnakeGame Create(int width, int height, int[][] food);
}
