namespace LeetCode.Problems._2038_Remove_Colored_Pieces_if_Both_Neighbors_are_the_Same_Color;

/// <summary>
/// https://leetcode.com/submissions/detail/1065161140/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool WinnerOfGame(string colors)
    {
        char lastColor = default;
        var lastColorCount = 0;
        var stepCounts = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['B'] = 0
        };

        foreach (var color in colors + default(char))
        {
            if (color == lastColor)
            {
                lastColorCount++;
            }
            else
            {
                if (lastColor != default)
                {
                    stepCounts[lastColor] += Math.Max(0, lastColorCount - 2);
                }

                lastColor = color;
                lastColorCount = 1;
            }
        }

        return stepCounts['A'] > stepCounts['B'];
    }
}
