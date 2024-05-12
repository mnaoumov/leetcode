using JetBrains.Annotations;

namespace LeetCode._1071_Greatest_Common_Divisor_of_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/889458801/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string GcdOfStrings(string str1, string str2)
    {
        if (str1[0] != str2[0])
        {
            return "";
        }

        var gcd = Gcd(str1.Length, str2.Length);

        for (var i = gcd; i >= 1; i--)
        {
            if (gcd % i != 0)
            {
                continue;
            }

            var success = true;

            for (var j = 0; j < Math.Max(str1.Length, str2.Length); j++)
            {
                if (j < str1.Length && j < str2.Length && str1[j] != str2[j])
                {
                    success = false;
                    break;
                }

                if (j < str1.Length && str1[j] != str1[j % i])
                {
                    success = false;
                    break;
                }

                // ReSharper disable once InvertIf
                if (j < str2.Length && str2[j] != str2[j % i])
                {
                    success = false;
                    break;
                }
            }

            if (success)
            {
                return str1[..i];
            }
        }

        return "";
    }

    private static int Gcd(int a, int b)
    {
        while (b > 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }
}
