namespace LeetCode.Problems._0755_Pour_Water;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] PourWater(int[] heights, int volume, int k)
    {
        var water = new int[heights.Length];

        for (var drop = 0; drop < volume; drop++)
        {
            var bestLeft = k;

            for (var i = k - 1; i >= 0; i--)
            {
                if (heights[i] + water[i] < heights[bestLeft] + water[bestLeft])
                {
                    bestLeft = i;
                }
                else if (heights[i] + water[i] > heights[bestLeft] + water[bestLeft])
                {
                    break;
                }
            }

            if (bestLeft != k)
            {
                water[bestLeft]++;
                continue;
            }

            var bestRight = k;

            for (var i = k + 1; i < heights.Length; i++)
            {
                if (heights[i] + water[i] < heights[bestRight] + water[bestRight])
                {
                    bestRight = i;
                }
                else if (heights[i] + water[i] > heights[bestRight] + water[bestRight])
                {
                    break;
                }
            }

            if (bestRight != k)
            {
                water[bestRight]++;
                continue;
            }

            water[k]++;
        }

        var result = new int[heights.Length];

        for (var i = 0; i < heights.Length; i++)
        {
            result[i] = heights[i] + water[i];
        }

        return result;
    }
}
