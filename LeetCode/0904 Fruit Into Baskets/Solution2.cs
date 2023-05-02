using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0904_Fruit_Into_Baskets;

/// <summary>
/// https://leetcode.com/submissions/detail/205291683/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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
                endTreeIndex++;
                if (!fruitTypeCounts.ContainsKey(fruitType))
                {
                    if (fruitTypeCounts.Keys.Count == basketCount)
                    {
                        endTreeIndex--;
                        break;
                    }

                    fruitTypeCounts[fruitType] = 0;
                }

                fruitTypeCounts[fruitType]++;
            }

            maxFruitCount = Math.Max(maxFruitCount, fruitTypeCounts.Values.Sum());
        }

        return maxFruitCount;
    }
}
