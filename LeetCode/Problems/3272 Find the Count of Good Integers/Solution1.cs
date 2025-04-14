namespace LeetCode.Problems._3272_Find_the_Count_of_Good_Integers;

/// <summary>
/// https://leetcode.com/problems/find-the-count-of-good-integers/submissions/1604130599/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountGoodIntegers(int n, int k)
    {
        if (n == 1)
        {
            return 9 / k;
        }

        var m = n / 2;
        var min = (int) Math.Pow(10, m - 1);
        var leftHalfMultiplier = (long) Math.Pow(10, n - m);
        var middleDigitMultiplier = leftHalfMultiplier / 10;

        var factorials = new int[n + 1];
        factorials[0] = 1;

        for (var i = 1; i <= n; i++)
        {
            factorials[i] = factorials[i - 1] * i;
        }


        var sortedKPalindromes = new HashSet<string>();

        for (var leftHalf = min; leftHalf < min * 10; leftHalf++)
        {
            var rightHalf = Reverse(leftHalf);
            var palindromePart = leftHalf * leftHalfMultiplier + rightHalf;

            if (n % 2 == 1)
            {
                for (var middleDigit = 0; middleDigit <= 9; middleDigit++)
                {
                    var num = palindromePart + middleDigit * middleDigitMultiplier;
                    AddKPalindrome(num);
                }
            }
            else
            {
                AddKPalindrome(palindromePart);
            }
        }

        var ans = 0L;

        foreach (var sortedKPalindrome in sortedKPalindromes)
        {
            var counts = new int[10];

            foreach (var digit in sortedKPalindrome.Select(digitChar => digitChar - '0'))
            {
                counts[digit]++;
            }

            var permutationsCount = 1L * (n - counts[0]) * factorials[n - 1];
            permutationsCount = counts.Aggregate(permutationsCount, (current, count) => current / factorials[count]);
            ans += permutationsCount;
        }

        return ans;

        void AddKPalindrome(long num)
        {
            if (num % k != 0)
            {
                return;
            }

            var key = string.Concat(num.ToString().OrderBy(digitChar => digitChar));
            sortedKPalindromes.Add(key);
        }
    }

    private static int Reverse(int num)
    {
        var reversed = 0;
        while (num > 0)
        {
            reversed = reversed * 10 + num % 10;
            num /= 10;
        }
        return reversed;
    }
}
