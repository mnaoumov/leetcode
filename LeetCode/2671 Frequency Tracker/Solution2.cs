using JetBrains.Annotations;

namespace LeetCode._2671_Frequency_Tracker;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IFrequencyTracker Create() => new FrequencyTracker2();
}
