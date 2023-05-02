using JetBrains.Annotations;

namespace LeetCode._0013_Roman_to_Integer;

/// <summary>
/// https://leetcode.com/submissions/detail/808451014/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private readonly Dictionary<string, int> _dict = new()
    {
        ["M"] = 1000,
        ["CM"] = 900,
        ["D"] = 500,
        ["CD"] = 400,
        ["C"] = 100,
        ["XC"] = 90,
        ["L"] = 50,
        ["XL"] = 40,
        ["X"] = 10,
        ["IX"] = 9,
        ["V"] = 5,
        ["IV"] = 4,
        ["I"] = 1
    };


    public int RomanToInt(string s)
    {
        var result = 0;

        while (s.Length > 0)
        {
            var key = _dict.Keys.First(s.StartsWith);
            result += _dict[key];
            s = s[key.Length..];
        }

        return result;
    }
}
