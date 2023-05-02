using System.Text;

using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0012_Integer_to_Roman;

/// <summary>
/// https://leetcode.com/submissions/detail/808441069/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string IntToRoman(int num)
    {
        var dict = new Dictionary<int, string>
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

        var sb = new StringBuilder();

        while (num > 0)
        {
            var maxKey = dict.Keys.First(k => num >= k);
            sb.Append(dict[maxKey]);
            num -= maxKey;
        }

        return sb.ToString();
    }
}
