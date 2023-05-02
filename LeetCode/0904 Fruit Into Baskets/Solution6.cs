using JetBrains.Annotations;

namespace LeetCode._0904_Fruit_Into_Baskets;

/// <summary>
/// https://leetcode.com/submissions/detail/893445288/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int TotalFruit(int[] tree)
    {
        const int maxFruitTypeCount = 2;
        var startIndex = 0;
        var endIndex = 0;
        var fruitTypeCountMap = new Dictionary<int, int>();
        var result = 0;

        while (endIndex < tree.Length)
        {
            var fruitType = tree[endIndex];
            fruitTypeCountMap[fruitType] = fruitTypeCountMap.GetValueOrDefault(fruitType) + 1;

            while (fruitTypeCountMap.Count > maxFruitTypeCount)
            {
                fruitType = tree[startIndex];
                fruitTypeCountMap[fruitType] = fruitTypeCountMap.GetValueOrDefault(fruitType) - 1;

                if (fruitTypeCountMap[fruitType] == 0)
                {
                    fruitTypeCountMap.Remove(fruitType);
                }

                startIndex++;
            }

            result = Math.Max(result, endIndex - startIndex + 1);
            endIndex++;
        }

        return result;
    }
}
