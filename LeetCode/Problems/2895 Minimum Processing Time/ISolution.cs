using JetBrains.Annotations;

namespace LeetCode._2895_Minimum_Processing_Time;

[PublicAPI]
public interface ISolution
{
    public int MinProcessingTime(IList<int> processorTime, IList<int> tasks);
}
