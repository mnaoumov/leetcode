using JetBrains.Annotations;

namespace LeetCode._1431_Kids_With_the_Greatest_Number_of_Candies;

[PublicAPI]
public interface ISolution
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies);
}
