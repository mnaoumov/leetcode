using JetBrains.Annotations;

namespace LeetCode.Problems._0947_Most_Stones_Removed_with_Same_Row_or_Column;

/// <summary>
/// https://leetcode.com/problems/most-stones-removed-with-same-row-or-column/submissions/843560819/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int RemoveStones(int[][] stones)
    {
        var xComponentMap = new Dictionary<int, int>();
        var yComponentMap = new Dictionary<int, int>();

        var maxComponentIndex = 0;

        var changed = true;

        while (changed)
        {
            changed = false;
            foreach (var stone in stones)
            {
                var x = stone[0];
                var y = stone[1];

                var xComponent = xComponentMap.GetValueOrDefault(x, int.MaxValue);
                var yComponent = yComponentMap.GetValueOrDefault(y, int.MaxValue);

                var componentIndex = Math.Min(xComponent, yComponent);

                if (componentIndex == int.MaxValue)
                {
                    maxComponentIndex++;
                    componentIndex = maxComponentIndex;
                }

                if (xComponent != componentIndex || yComponent != componentIndex)
                {
                    changed = true;
                }

                xComponentMap[x] = componentIndex;
                yComponentMap[y] = componentIndex;
            }
        }

        return stones.Length - xComponentMap.Values.Max();
    }
}
