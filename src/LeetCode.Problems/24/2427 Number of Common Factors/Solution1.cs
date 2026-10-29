namespace LeetCode.Problems._2427_Number_of_Common_Factors;

/// <summary>
/// https://leetcode.com/submissions/detail/899810305/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CommonFactors(int a, int b)
    {
        var result = 0;
        for (var i = 1; i <= Math.Min(a, b); i++)
        {
            if (a % i == 0 && b % i == 0)
            {
                result++;
            }
        }
        return result;
    }
}
