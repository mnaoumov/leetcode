using JetBrains.Annotations;

namespace LeetCode._2527_Find_Xor_Beauty_of_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-95/submissions/detail/873353815/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int XorBeauty(int[] nums) => nums.Aggregate(0, (acc, num) => acc ^ num);
}
