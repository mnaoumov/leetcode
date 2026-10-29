namespace LeetCode.Problems._3300_Minimum_Element_After_Replacement_With_Digit_Sum;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-140/submissions/detail/1404955845/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinElement(int[] nums) => nums.Select(SumOfDigits).Min();

    private static int SumOfDigits(int num) => Digits(num).Sum();

    private static IEnumerable<int> Digits(int num)
    {
        while (num > 0)
        {
            yield return num % 10;
            num /= 10;
        }
    }
}
