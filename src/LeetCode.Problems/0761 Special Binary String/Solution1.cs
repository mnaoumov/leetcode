namespace LeetCode.Problems._0761_Special_Binary_String;

/// <summary>
/// https://leetcode.com/problems/special-binary-string/submissions/1925738256/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string MakeLargestSpecial(string s)
    {
        if (s.Length == 0)
        {
            return "";
        }

        var balance = 0;
        var mountains = new List<string>();
        var i = 0;

        for (var j = 0; j < s.Length; j++)
        {
            var value = s[j] switch
            {
                '1' => 1,
                '0' => -1,
                _ => throw new InvalidOperationException()
            };

            balance += value;

            if (balance != 0)
            {
                continue;
            }

            mountains.Add($"1{MakeLargestSpecial(s[(i + 1)..j])}0");
            i = j + 1;
        }

        return string.Concat(mountains.OrderByDescending(m => m));
    }
}
