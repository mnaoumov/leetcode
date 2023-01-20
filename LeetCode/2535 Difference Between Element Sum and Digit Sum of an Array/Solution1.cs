using JetBrains.Annotations;

namespace LeetCode._2535_Difference_Between_Element_Sum_and_Digit_Sum_of_an_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-328/submissions/detail/878331650/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DifferenceOfSum(int[] nums)
    {
        var sum = nums.Sum();
        var digitsSum = nums.SelectMany(GetDigits).Sum();

        return Math.Abs(sum - digitsSum);
    }

    private static IEnumerable<int> GetDigits(int num)
    {
        while (num > 0)
        {
            yield return num % 10;
            num /= 10;
        }
    }
}
