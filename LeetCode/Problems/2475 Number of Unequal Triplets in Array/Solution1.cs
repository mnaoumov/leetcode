using JetBrains.Annotations;

namespace LeetCode.Problems._2475_Number_of_Unequal_Triplets_in_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-320/submissions/detail/846625632/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int UnequalTriplets(int[] nums)
    {
        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] == nums[i])
                {
                    continue;
                }

                for (var k = j + 1; k < nums.Length; k++)
                {
                    if (nums[k] == nums[j] || nums[k] == nums[i])
                    {
                        continue;
                    }

                    result++;
                }
            }
        }

        return result;
    }
}
