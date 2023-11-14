using JetBrains.Annotations;

namespace LeetCode._2932_Maximum_Strong_Pair_XOR_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-371/submissions/detail/1096947114/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumStrongPairXor(int[] nums) =>
        (from num1 in nums
            from num2 in nums
            where Math.Abs(num1 - num2) <= Math.Min(num1, num2)
            select num1 ^ num2)
        .Prepend(int.MinValue)
        .Max();
}
