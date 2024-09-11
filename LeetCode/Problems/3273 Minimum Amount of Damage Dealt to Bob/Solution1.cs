using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3273_Minimum_Amount_of_Damage_Dealt_to_Bob;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-138/submissions/detail/1374305236/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MinDamage(int power, int[] damage, int[] health)
    {
        var enemies = damage.Zip(health, (d, h) => new Enemy(d, h)).ToArray();
        var ans = 0L;
        var move = 0;

        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var enemy in enemies.OrderByDescending(e => e.Damage).ThenBy(e => e.Health))
        {
            var hitsCount = (enemy.Health + power - 1) / power;
            ans += 1L * (move + hitsCount) * enemy.Damage;
            move += hitsCount;
        }

        return ans;
    }

    private record Enemy(int Damage, int Health);
}
