namespace LeetCode.Problems._0231_Power_of_Two;

/// <seealso href="https://leetcode.com/submissions/detail/929935256/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsPowerOfTwo(int n) => n > 0 && (n & n - 1) == 0;
}
