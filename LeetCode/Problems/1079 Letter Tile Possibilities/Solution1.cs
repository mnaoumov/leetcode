using JetBrains.Annotations;

namespace LeetCode.Problems._1079_Letter_Tile_Possibilities;

/// <summary>
/// https://leetcode.com/submissions/detail/925758430/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumTilePossibilities(string tiles)
    {
        var counts = tiles.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
        var result = -1;
        Backtrack();
        return result;

        void Backtrack()
        {
            result++;

            foreach (var letter in counts.Keys.Where(letter => counts[letter] != 0))
            {
                counts[letter]--;
                Backtrack();
                counts[letter]++;
            }
        }
    }
}
