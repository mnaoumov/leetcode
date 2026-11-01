namespace LeetCode.Problems._1356_Sort_Integers_by_The_Number_of_1_Bits;

/// <seealso href="https://leetcode.com/submissions/detail/929323215/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SortByBits(int[] arr) => arr.OrderBy(CountBits).ThenBy(num => num).ToArray();

    private static int CountBits(int num)
    {
        var result = 0;

        while (num > 0)
        {
            result += num & 1;
            num >>= 1;
        }

        return result;
    }
}
