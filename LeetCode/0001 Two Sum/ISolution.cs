using JetBrains.Annotations;

namespace LeetCode._0001_Two_Sum;

[PublicAPI]
public interface ISolution
{
    int[] TwoSum(int[] nums, int target);
}