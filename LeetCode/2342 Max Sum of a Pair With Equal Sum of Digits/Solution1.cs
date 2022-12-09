using JetBrains.Annotations;

namespace LeetCode._2342_Max_Sum_of_a_Pair_With_Equal_Sum_of_Digits;

/// <summary>
/// https://leetcode.com/submissions/detail/856791449/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumSum(int[] nums)
    {
        var digitSums = new Dictionary<int, List<int>>();

        foreach (var num in nums)
        {
            var digitSum = DigitSum(num);

            if (!digitSums.ContainsKey(digitSum))
            {
                digitSums[digitSum] = new List<int>();
            }

            digitSums[digitSum].Add(num);
        }

        return digitSums.Values.Where(group => group.Count >= 2).Select(group => group.OrderByDescending(x => x).ToArray()).Select(orderedGroup => orderedGroup[0] + orderedGroup[1]).Prepend(-1).Max();
    }

    private static int DigitSum(int num)
    {
        var result = 0;

        while (num > 0)
        {
            var digit = num % 10;
            result += digit;
            num /= 10;
        }

        return result;
    }
}
