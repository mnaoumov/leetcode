namespace LeetCode.Problems._2048_Next_Greater_Numerically_Balanced_Number;

/// <summary>
/// https://leetcode.com/problems/next-greater-numerically-balanced-number/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NextBeautifulNumber(int n) => GetAllBeautifulNumbersSorted().First(x => x > n);

    private static IEnumerable<int> GetAllBeautifulNumbersSorted()
    {
        const int first7Digits = 1224444;
        return GenerateBeautifulNumbers().OrderBy(x => x).Append(first7Digits);
    }

    private static IEnumerable<int> GenerateBeautifulNumbers()
    {
        var ans = new List<int>();
        foreach (var uniqueDigits in GenerateUniqueDigits(1, 6))
        {
            var totalLength = uniqueDigits.Sum();
            var counts = new int[10];

            foreach (var digit in uniqueDigits)
            {
                counts[digit] = digit;
            }

            var num = 0;
            var numLength = 0;
            Backtrack();
            continue;

            void Backtrack()
            {
                if (numLength == totalLength)
                {
                    ans.Add(num);
                    return;
                }
                for (var digit = 0; digit < 10; digit++)
                {
                    if (counts[digit] == 0)
                    {
                        continue;
                    }

                    num = 10 * num + digit;
                    numLength++;
                    counts[digit]--;
                    Backtrack();
                    num /= 10;
                    numLength--;
                    counts[digit]++;
                }
            }
        }

        return ans;
    }

    private static IEnumerable<int[]> GenerateUniqueDigits(int minDigit, int maxLength)
    {
        if (minDigit > maxLength)
        {
            yield break;
        }

        yield return new[] { minDigit };

        foreach (var uniqueDigits in GenerateUniqueDigits(minDigit + 1, maxLength))
        {
            yield return uniqueDigits;
        }

        foreach (var uniqueDigits in GenerateUniqueDigits(minDigit + 1, maxLength - minDigit))
        {
            yield return uniqueDigits.Prepend(minDigit).ToArray();
        }
    }
}
