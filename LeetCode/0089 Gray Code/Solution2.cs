using JetBrains.Annotations;

namespace LeetCode._0089_Gray_Code;

/// <summary>
/// https://leetcode.com/submissions/detail/829073789/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<int> GrayCode(int n)
    {
        if (n == 1)
        {
            return new[] { 0, 1 };
        }

        var previous = GrayCode(n - 1);

        var result = new List<int>();
        result.AddRange(previous);

        var higherBitOne = 1 << n - 1;

        result.AddRange(previous.Reverse().Select(value => higherBitOne + value));

        return result;
    }
}
