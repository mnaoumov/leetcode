namespace LeetCode.Problems._1399_Count_Largest_Group;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountLargestGroup(int n)
    {
        var groupSizes = Enumerable.Range(1, n).Select(DigitsSum).GroupBy(s => s).Select(g => g.Count()).ToArray();
        var maxGroupSize = groupSizes.Max();
        return groupSizes.Count(size => size == maxGroupSize);
    }

    private static int DigitsSum(int num) => Digits(num).Sum();

    private static IEnumerable<int> Digits(int num)
    {
        while (num > 0)
        {
            var digit = num % 10;
            yield return digit;
            num /= 10;
        }
    }
}
