using JetBrains.Annotations;

namespace LeetCode.Problems._1202_Smallest_String_With_Swaps;

[PublicAPI]
public interface ISolution
{
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs);
}
