namespace LeetCode.Problems._2481_Minimum_Cuts_to_Divide_a_Circle;

/// <summary>
/// https://leetcode.com/submissions/detail/850235792/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumberOfCuts(int n)
    {
        return n == 1 ? 0 : n % 2 == 0 ? n / 2 : n;
    }
}
