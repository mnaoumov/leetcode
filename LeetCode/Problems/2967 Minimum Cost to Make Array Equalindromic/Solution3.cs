using JetBrains.Annotations;

namespace LeetCode.Problems._2967_Minimum_Cost_to_Make_Array_Equalindromic;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-376/submissions/detail/1121504303/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public long MinimumCost(int[] nums)
    {
        var palindromesByLength = Enumerable.Range(0, 10).Select(_ => new List<double>()).ToArray();
        palindromesByLength[1] = Enumerable.Range(1, 9).Select(p => (double) p).ToList();
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

        Array.Sort(nums);
        var midIndex = nums.Length / 2;

        var median = nums.Length % 2 == 1
            ? nums[midIndex]
            : (nums[midIndex - 1] + nums[midIndex]) / 2d;

        var index = palindromes.BinarySearch(median);

        int lessPalindromeIndex;
        int greaterPalindromeIndex;

        if (index < 0)
        {
            lessPalindromeIndex = ~index - 1;
            greaterPalindromeIndex = ~index;
        }
        else
        {
            lessPalindromeIndex = index;
            greaterPalindromeIndex = index;
        }

        var lessPalindrome = (int) palindromes[lessPalindromeIndex];
        var greaterPalindrome = (int) palindromes[greaterPalindromeIndex];

        return Math.Min(Cost(lessPalindrome), Cost(greaterPalindrome));

        long Cost(int palindrome) => nums.Sum(num => 0L + Math.Abs(num - palindrome));
    }
}
