using System.Text;

namespace LeetCode._0012_Integer_to_Roman;

/// <summary>
/// https://leetcode.com/submissions/detail/808441900/
/// </summary>
public class Solution2 : ISolution
{
    private readonly Dictionary<int, string> _dict = new()
    {
        [1000] = "M",
        [900] = "CM",
        [500] = "D",
        [400] = "CD",
        [100] = "C",
        [90] = "XC",
        [50] = "L",
        [40] = "XL",
        [10] = "X",
        [9] = "IX",
        [5] = "V",
        [4] = "IV",
        [1] = "I"
    };

    public string IntToRoman(int num)
    {
        var sb = new StringBuilder();

        while (num > 0)
        {
            var maxKey = _dict.Keys.First(k => num >= k);
            sb.Append(_dict[maxKey]);
            num -= maxKey;
        }

        return sb.ToString();
    }
}