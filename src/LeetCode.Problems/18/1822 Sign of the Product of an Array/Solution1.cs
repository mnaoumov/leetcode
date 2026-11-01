namespace LeetCode.Problems._1822_Sign_of_the_Product_of_an_Array;

/// <seealso href="https://leetcode.com/submissions/detail/925203393/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ArraySign(int[] nums) => nums.Aggregate(1, (prod, num) => prod * Math.Sign(num));
}
