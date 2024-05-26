using JetBrains.Annotations;

namespace LeetCode.Problems._3162_Find_the_Number_of_Good_Pairs_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-399/submissions/detail/1268006468/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfPairs(int[] nums1, int[] nums2, int k) =>
        (from num1 in nums1 from num2 in nums2 where num1 % (num2 * k) == 0 select num1).Count();
}
