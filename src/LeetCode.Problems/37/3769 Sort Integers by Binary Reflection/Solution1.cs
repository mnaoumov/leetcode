namespace LeetCode.Problems._3769_Sort_Integers_by_Binary_Reflection;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-479/problems/sort-integers-by-binary-reflection/submissions/1848829921/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SortByReflection(int[] nums) => nums.OrderBy(num => (BinaryReflection(num), num)).ToArray();

    private static int BinaryReflection(int num)
    {
        var ans = 0;
        while (num > 0)
        {
            var digit = num % 2;
            ans <<= 1;
            ans += digit;
            num >>= 1;
        }

        return ans;
    }
}
