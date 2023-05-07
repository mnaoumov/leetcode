using JetBrains.Annotations;

namespace LeetCode._2671_Frequency_Tracker;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-344/submissions/detail/945807727/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IFrequencyTracker Create() => new FrequencyTracker1();
}
