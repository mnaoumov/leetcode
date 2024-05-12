using JetBrains.Annotations;

namespace LeetCode._2962_Count_Subarrays_Where_Max_Element_Appears_at_Least_K_Times;

[PublicAPI]
public interface ISolution
{
    public long CountSubarrays(int[] nums, int k);
}
