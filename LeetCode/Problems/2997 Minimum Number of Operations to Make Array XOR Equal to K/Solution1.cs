namespace LeetCode.Problems._2997_Minimum_Number_of_Operations_to_Make_Array_XOR_Equal_to_K;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-121/submissions/detail/1138539088/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums, int k)
    {
        var xor = nums.Aggregate((a, b) => a ^ b);
        var diff = xor ^ k;

        var ans = 0;

        while (diff > 0)
        {
            ans += diff & 1;
            diff >>= 1;
        }

        return ans;
    }
}
