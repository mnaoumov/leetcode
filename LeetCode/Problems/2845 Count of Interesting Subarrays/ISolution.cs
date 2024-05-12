using JetBrains.Annotations;

namespace LeetCode.Problems._2845_Count_of_Interesting_Subarrays;

[PublicAPI]
public interface ISolution
{
    public long CountInterestingSubarrays(IList<int> nums, int modulo, int k);
}
