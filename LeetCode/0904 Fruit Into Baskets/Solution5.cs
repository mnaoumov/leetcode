using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0904_Fruit_Into_Baskets;

/// <summary>
/// https://leetcode.com/submissions/detail/205292831/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int TotalFruit(int[] tree)
    {
        const int basketCount = 2;
        if (tree.Length <= basketCount)
        {
            return tree.Length;
        }

        var fruitTypeCounts = new Dictionary<int, int>();
        var startTreeIndex = 0;
        var endTreeIndex = 0;

        var maxFruitCount = 0;
        var fruitCount = 0;

        while (endTreeIndex < tree.Length)
        {
            while (fruitTypeCounts.Keys.Count == basketCount)
            {
                var fruitType = tree[startTreeIndex];

                fruitTypeCounts[fruitType]--;
                fruitCount--;
                if (fruitTypeCounts[fruitType] == 0)
                {
                    fruitTypeCounts.Remove(fruitType);
                }

                startTreeIndex++;
            }

            while (endTreeIndex < tree.Length)
            {
                var fruitType = tree[endTreeIndex];
                if (!fruitTypeCounts.ContainsKey(fruitType))
                {
                    if (fruitTypeCounts.Keys.Count == basketCount)
                    {
                        maxFruitCount = Math.Max(maxFruitCount, fruitCount);
                        break;
                    }

                    fruitTypeCounts[fruitType] = 0;
                }

                fruitTypeCounts[fruitType]++;
                endTreeIndex++;
                fruitCount++;
            }
        }

        maxFruitCount = Math.Max(maxFruitCount, fruitCount);

        return maxFruitCount;
    }
}
