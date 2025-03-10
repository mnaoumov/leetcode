namespace LeetCode.Problems._3479_Fruits_Into_Baskets_III;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        var ans = 0;

        var availableBaskets = baskets.ToList();

        foreach (var fruit in fruits)
        {
            var isPlaced = false;
            for (var i = 0; i < availableBaskets.Count; i++)
            {
                if (availableBaskets[i] < fruit)
                {
                    continue;
                }

                availableBaskets.RemoveAt(i);
                isPlaced = true;
                break;
            }

            if (!isPlaced)
            {
                ans++;
            }
        }

        return ans;
    }
}
