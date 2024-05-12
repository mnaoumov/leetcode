using JetBrains.Annotations;

namespace LeetCode.Problems._2899_Last_Visited_Integers;

[PublicAPI]
public interface ISolution
{
    public IList<int> LastVisitedIntegers(IList<string> words);
}
