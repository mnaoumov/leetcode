namespace LeetCode.Problems._2671_Frequency_Tracker;

[PublicAPI]
public interface IFrequencyTracker
{
    void Add(int number);
    void DeleteOne(int number);
    bool HasFrequency(int frequency);
}
