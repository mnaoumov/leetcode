using JetBrains.Annotations;

namespace LeetCode.Problems._2191_Sort_the_Jumbled_Numbers;

/// <summary>
/// https://leetcode.com/submissions/detail/1331216101/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        return nums
            .Select((num, index) => (num, index))
            .OrderBy(x => MappedValue(x.num))
            .ThenBy(x => x.index)
            .Select(x => x.num).ToArray();

        int MappedValue(int num)
        {
            var digits = GetDigits(num);
            return digits.Select(digit => mapping[digit]).Aggregate(0, (current, mappedDigit) => current * 10 + mappedDigit);
        }
    }

    private static List<int> GetDigits(int num)
    {
        var digits = new List<int>();

        while (num > 0)
        {
            digits.Insert(0, num % 10);
            num /= 10;
        }

        if (digits.Count == 0)
        {
            digits.Add(0);
        }

        return digits;
    }
}
