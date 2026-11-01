namespace LeetCode.Problems._0326_Power_of_Three;

/// <seealso href="https://leetcode.com/submissions/detail/923280427/">Submission</seealso>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool IsPowerOfThree(int n)
    {
        if (n <= 0)
        {
            return false;
        }

        var log = Math.Log(n, 3);
        return Math.Abs(log - Math.Round(log)) < 1e-10;
    }
}
