using JetBrains.Annotations;

namespace LeetCode.Problems._2671_Frequency_Tracker;

[PublicAPI]
public interface IFrequencyTracker
{
    public void Add(int number);
    public void DeleteOne(int number);
    public bool HasFrequency(int frequency);
}
