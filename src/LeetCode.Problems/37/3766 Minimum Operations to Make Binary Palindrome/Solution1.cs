namespace LeetCode.Problems._3766_Minimum_Operations_to_Make_Binary_Palindrome;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-171/problems/minimum-operations-to-make-binary-palindrome/submissions/1848427600/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MinOperations(int[] nums)
    {
        const int maxNum = 1 << 13;
        var binaryPalindromes = new List<int>();
        for (var i = 1; i < maxNum; i++)
        {
            var str = Convert.ToString(i, 2);
            var isBinaryPalindrome = true;
            for (var j = 0; j < str.Length / 2; j++)
            {
                if (str[j] == str[str.Length - 1 - j])
                {
                    continue;
                }

                isBinaryPalindrome = false;
                break;
            }

            if (isBinaryPalindrome)
            {
                binaryPalindromes.Add(i);
            }
        }

        return nums.Select(DistanceToClosestBinaryPalindrome).ToArray();

        int DistanceToClosestBinaryPalindrome(int num)
        {
            var index = binaryPalindromes.BinarySearch(num);

            if (index >= 0)
            {
                return 0;
            }

            index = ~index;

            var bigger = binaryPalindromes[index];
            var smaller = binaryPalindromes[index - 1];
            return Math.Min(bigger - num, num - smaller);
        }
    }
}
