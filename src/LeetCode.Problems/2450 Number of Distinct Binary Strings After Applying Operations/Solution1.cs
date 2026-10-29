namespace LeetCode.Problems._2450_Number_of_Distinct_Binary_Strings_After_Applying_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/881602734/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int CountDistinctStrings(string s, int k) => Pow2(s.Length - k + 1);

    private static int Pow2(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        const int modulo = 1_000_000_007;

        var result = n % 2 == 1 ? 2L : 1L;
        result *= Pow2(n / 2) * Pow2(n / 2);

        return (int) (result % modulo);
    }
}
