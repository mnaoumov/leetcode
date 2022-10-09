namespace LeetCode._0904_Fruit_Into_Baskets;

/// <summary>
/// https://leetcode.com/submissions/detail/205285967/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int TotalFruit(int[] tree)
    {
        const int basketCount = 2;
        if (tree.Length <= basketCount)
        {
            return tree.Length;
        }

        var maxFruitCount = basketCount;

        for (int i = 0; i < tree.Length; i++)
        {
            var fruitCount = 0;
            var fruitTypes = new HashSet<int>();
            for (int j = i; j < tree.Length; j++)
            {
                fruitTypes.Add(tree[j]);
                if (fruitTypes.Count > basketCount)
                {
                    break;
                }

                fruitCount++;
            }

            maxFruitCount = Math.Max(maxFruitCount, fruitCount);
        }

        return maxFruitCount;
    }
}
