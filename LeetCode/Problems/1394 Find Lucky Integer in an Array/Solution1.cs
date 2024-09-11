namespace LeetCode.Problems._1394_Find_Lucky_Integer_in_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/898952290/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindLucky(int[] arr)
    {
        var counts = new Dictionary<int, int>();

        foreach (var num in arr)
        {
            counts[num] = counts.GetValueOrDefault(num) + 1;
        }

        return counts.Where(kvp => kvp.Key == kvp.Value).Select(kvp => kvp.Key).Prepend(-1).Max();
    }
}
