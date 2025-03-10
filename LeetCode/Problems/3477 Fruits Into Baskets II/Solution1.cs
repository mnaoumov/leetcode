namespace LeetCode.Problems._3477_Fruits_Into_Baskets_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-440/problems/fruits-into-baskets-ii/submissions/1567557122/
/// </summary>
[UsedImplicitly]
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
