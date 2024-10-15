namespace LeetCode.Problems._100451_Construct_the_Minimum_Bitwise_Array_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-141/submissions/detail/1420030528/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MinBitwiseArray(IList<int> nums) => nums.Select(GetX).ToArray();

    private static int GetX(int num)
    {
        var temp = num;
        var trailingOnesCount = 0;
        while (temp % 2 == 1)
        {
            temp >>= 1;
            trailingOnesCount++;
        }

        if (trailingOnesCount == 0)
        {
            return -1;
        }

        return (num ^ ((1 << trailingOnesCount) - 1)) + ((1 << trailingOnesCount - 1) - 1);
    }
}
