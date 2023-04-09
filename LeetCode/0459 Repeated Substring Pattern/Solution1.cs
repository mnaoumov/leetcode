using JetBrains.Annotations;

namespace LeetCode._0459_Repeated_Substring_Pattern;

/// <summary>
/// https://leetcode.com/submissions/detail/930966269/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool RepeatedSubstringPattern(string s)
    {
        var length = 1;
        var n = s.Length;

        while (true)
        {
            if (length > n / 2)
            {
                return false;
            }

            if (s.Length % length == 0)
            {
                var result = true;

                for (var j = length; j < n; j++)
                {
                    if (s[j] == s[j % length])
                    {
                        continue;
                    }

                    result = false;
                    break;
                }

                if (result)
                {
                    return true;
                }
            }

            length++;
        }
    }
}
