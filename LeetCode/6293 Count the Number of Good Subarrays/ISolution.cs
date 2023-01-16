using JetBrains.Annotations;

namespace LeetCode._6293_Count_the_Number_of_Good_Subarrays;

[PublicAPI]
public interface ISolution
{
    public long CountGood(int[] nums, int k);
}
