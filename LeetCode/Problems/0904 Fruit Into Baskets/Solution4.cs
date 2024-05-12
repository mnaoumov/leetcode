using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0904_Fruit_Into_Baskets;

/// <summary>
/// https://leetcode.com/submissions/detail/205292490/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
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

        while (endTreeIndex < tree.Length)
        {
            while (fruitTypeCounts.Keys.Count == basketCount)
            {
                var fruitType = tree[startTreeIndex];

                fruitTypeCounts[fruitType]--;
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
                        maxFruitCount = Math.Max(maxFruitCount, fruitTypeCounts.Values.Sum());
                        break;
                    }

                    fruitTypeCounts[fruitType] = 0;
                }

                fruitTypeCounts[fruitType]++;
                endTreeIndex++;
            }
        }

        maxFruitCount = Math.Max(maxFruitCount, fruitTypeCounts.Values.Sum());

        return maxFruitCount;
    }
}
