namespace LeetCode.Problems._3376_Minimum_Time_to_Break_Locks_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-145/submissions/detail/1472698036/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    // ReSharper disable once InconsistentNaming
    public int FindMinimumTime(IList<int> strength, int K)
    {
        var sortedStrengths = strength.ToList();
        sortedStrengths.Sort();

        var time = 0;
        var energy = 0;
        var energyIncreaseFactor = 1;

        while (sortedStrengths.Count > 0)
        {
            energy += energyIncreaseFactor;
            time++;
            var index = sortedStrengths.BinarySearch(energy);

            if (index < 0)
            {
                index = ~index - 1;
            }

            if (index < 0 || sortedStrengths[index] > energy)
            {
                continue;
            }

            sortedStrengths.RemoveAt(index);
            energy = 0;
            energyIncreaseFactor += K;
        }

        return time;
    }
}
