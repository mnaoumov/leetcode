using JetBrains.Annotations;

namespace LeetCode.Problems._3160_Find_the_Number_of_Distinct_Colors_Among_the_Balls;

[PublicAPI]
public interface ISolution
{
    public int[] QueryResults(int limit, int[][] queries);
}
