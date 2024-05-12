using JetBrains.Annotations;

namespace LeetCode._2845_Count_of_Interesting_Subarrays;

[PublicAPI]
public interface ISolution
{
    public long CountInterestingSubarrays(IList<int> nums, int modulo, int k);
}
