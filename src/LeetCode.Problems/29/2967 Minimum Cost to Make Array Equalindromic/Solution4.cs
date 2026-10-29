namespace LeetCode.Problems._2967_Minimum_Cost_to_Make_Array_Equalindromic;

/// <summary>
/// https://leetcode.com/submissions/detail/1121565249/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
{
    public long MinimumCost(int[] nums)
    {
        var palindromesByLength = Enumerable.Range(0, 10).Select(_ => new List<int>()).ToArray();
        palindromesByLength[0].Add(0);
        palindromesByLength[1].AddRange(Enumerable.Range(1, 9));
        var palindromes = palindromesByLength[1].ToList();

        for (var length = 2; length <= 9; length++)
        {
            var multiplier = (int) Math.Pow(10, length - 1) + 1;

            for (var subLength = length - 2; subLength >= 0; subLength -= 2)
            {
                var tenthPower = (int) Math.Pow(10, length - subLength >> 1);

                foreach (var middlePalindrome in palindromesByLength[subLength])
                {
                    for (var firstDigit = 1; firstDigit <= 9; firstDigit++)
                    {
                        palindromesByLength[length].Add(firstDigit * multiplier + middlePalindrome * tenthPower);
                    }
                }
            }

            palindromesByLength[length].Sort();
            palindromes.AddRange(palindromesByLength[length]);
        }

        Array.Sort(nums);
        var midIndex = nums.Length / 2;

        var median = nums[midIndex];

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

        var lessPalindrome = palindromes[lessPalindromeIndex];
        var greaterPalindrome = palindromes[greaterPalindromeIndex];

        return Math.Min(Cost(lessPalindrome), Cost(greaterPalindrome));

        long Cost(int palindrome) => nums.Sum(num => 0L + Math.Abs(num - palindrome));
    }
}
