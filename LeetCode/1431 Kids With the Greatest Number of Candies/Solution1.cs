using JetBrains.Annotations;

namespace LeetCode._1431_Kids_With_the_Greatest_Number_of_Candies;

/// <summary>
/// https://leetcode.com/submissions/detail/934983418/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var max = candies.Max();
        return candies.Select(candy => candy >= max - extraCandies).ToArray();
    }
}
