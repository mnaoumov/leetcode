using JetBrains.Annotations;

namespace LeetCode._0258_Add_Digits;

/// <summary>
/// https://leetcode.com/submissions/detail/924648915/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int AddDigits(int num)
    {
        var result = num % 9;
        return result == 0 && num > 0 ? 9 : result;
    }
}
