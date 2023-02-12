using JetBrains.Annotations;

namespace LeetCode._2563_Count_the_Number_of_Fair_Pairs;

[PublicAPI]
public interface ISolution
{
    public long CountFairPairs(int[] nums, int lower, int upper);
}
