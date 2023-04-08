using JetBrains.Annotations;

namespace LeetCode._0231_Power_of_Two;

/// <summary>
/// https://leetcode.com/submissions/detail/929935256/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsPowerOfTwo(int n) => n > 0 && (n & n - 1) == 0;
}
