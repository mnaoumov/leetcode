using JetBrains.Annotations;

namespace LeetCode.Problems._3207_Maximum_Points_After_Enemy_Battles;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-134/submissions/detail/1311653734/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaximumPoints(int[] enemyEnergies, int currentEnergy)
    {
        Array.Sort(enemyEnergies);

        if (currentEnergy < enemyEnergies[0])
        {
            return 0;
        }

        var totalEnergy = 0L + currentEnergy - enemyEnergies[0];
        totalEnergy += enemyEnergies.Skip(1).Select(e => (long) e).Sum();
        return 1 + totalEnergy / enemyEnergies[0];
    }
}
