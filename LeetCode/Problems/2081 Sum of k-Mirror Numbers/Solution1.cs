namespace LeetCode.Problems._2081_Sum_of_k_Mirror_Numbers;

/// <summary>
/// https://leetcode.com/problems/sum-of-k-mirror-numbers/submissions/1673154332/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long KMirror(int k, int n) =>
        Generate10Palindromes().Where(num => IsKPalindrome(num, k))
            .Take(n)
            .Sum();

    private static bool IsKPalindrome(long num, int k)
    {
        var digits = new List<int>();

        while (num > 0)
        {
            digits.Add((int) (num % k));
            num /= k;
        }

        for (var i = 0; i <= (digits.Count - 1) / 2; i++)
        {
            if (digits[i] != digits[digits.Count - 1 - i])
            {
                return false;
            }
        }

        return true;
    }

    private static IEnumerable<long> Generate10Palindromes()
    {
        const int maxLength = 18;
        for (var length = 1; length <= maxLength; length++)
        {
            foreach (var str in Generate10PalindromesStr(length, false))
            {
                yield return long.Parse(str);
            }
        }
    }

    private static IEnumerable<string> Generate10PalindromesStr(int length, bool allowLeadingZero)
    {
        var startDigit = allowLeadingZero ? 0 : 1;

        switch (length)
        {
            case 0:
                yield return "";
                break;
            case 1:
                {
                    for (var i = startDigit; i <= 9; i++)
                    {
                        yield return i.ToString();
                    }
                    yield break;
                }
            default:
                for (var digit = startDigit; digit <= 9; digit++)
                {
                    foreach (var middleStr in Generate10PalindromesStr(length - 2, true))
                    {
                        yield return $"{digit}{middleStr}{digit}";
                    }
                }

                break;
        }
    }
}
