namespace LeetCode.Problems._2967_Minimum_Cost_to_Make_Array_Equalindromic;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-376/submissions/detail/1121475946/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MinimumCost(int[] nums)
    {
        var palindromesByLength = Enumerable.Range(0, 10).Select(_ => new List<int>()).ToArray();
        palindromesByLength[1] = Enumerable.Range(1, 9).ToList();
        var palindromes = palindromesByLength[1].ToList();

        for (var length = 2; length <= 9; length++)
        {
            var multiplier = (int) Math.Pow(10, length - 1) + 1;

            foreach (var middlePalindrome in palindromesByLength[length - 2].Prepend(0))
            {
                for (var firstDigit = 1; firstDigit <= 9; firstDigit++)
                {
                    palindromesByLength[length].Add(firstDigit * multiplier + middlePalindrome * 10);
                }
            }

            palindromesByLength[length].Sort();
            palindromes.AddRange(palindromesByLength[length]);
        }

        var avg = (int) nums.Select(num => (long) num).Average();

        var index = palindromes.BinarySearch(avg);

        int lessPalindromeIndex;

        if (index < 0)
        {
            index = ~index;
            lessPalindromeIndex = index - 1;
        }
        else
        {
            lessPalindromeIndex = index;
        }

        var greaterPalindromeIndex = index;

        var lessPalindrome = palindromes[lessPalindromeIndex];
        var greaterPalindrome = palindromes[greaterPalindromeIndex];
        return Math.Min(Cost(lessPalindrome), Cost(greaterPalindrome));

        long Cost(int palindrome) => nums.Sum(num => 0L + Math.Abs(num - palindrome));
    }
}
