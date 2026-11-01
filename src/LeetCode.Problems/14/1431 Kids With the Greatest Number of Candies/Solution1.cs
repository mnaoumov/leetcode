namespace LeetCode.Problems._1431_Kids_With_the_Greatest_Number_of_Candies;

/// <seealso href="https://leetcode.com/submissions/detail/934983418/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var max = candies.Max();
        return candies.Select(candy => candy >= max - extraCandies).ToArray();
    }
}
