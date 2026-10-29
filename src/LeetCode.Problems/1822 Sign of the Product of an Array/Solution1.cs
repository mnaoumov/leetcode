namespace LeetCode.Problems._1822_Sign_of_the_Product_of_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/925203393/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ArraySign(int[] nums) => nums.Aggregate(1, (prod, num) => prod * Math.Sign(num));
}
