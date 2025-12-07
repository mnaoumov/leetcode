namespace LeetCode.Problems._3771_Total_Score_of_Dungeon_Runs;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-479/problems/total-score-of-dungeon-runs/submissions/1848887947/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long TotalScore(int hp, int[] damage, int[] requirement)
    {
        var n = damage.Length;
        var prefixDamages = new long[n + 1];
        var set = new SortedSet<(long prefixDamage, int index)>();

        for (var i = 0; i < n; i++)
        {
            var prefixDamage = prefixDamages[i] + damage[i];
            prefixDamages[i + 1] = prefixDamage;
            set.Add((prefixDamage, i + 1));
        }

        var ans = 0;

        for (var i = n; i >= 1; i--)
        {
            set.Remove((prefixDamages[i], i));
            var diff = hp + prefixDamages[i] - requirement[i - 1];
            ans += set.GetViewBetween((0, 0), (diff, i)).Count;
        }

        return ans;
    }
}