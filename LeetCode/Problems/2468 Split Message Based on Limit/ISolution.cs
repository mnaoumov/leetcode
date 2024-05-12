using JetBrains.Annotations;

namespace LeetCode.Problems._2468_Split_Message_Based_on_Limit;

[PublicAPI]
public interface ISolution
{
    public string[] SplitMessage(string message, int limit);
}
