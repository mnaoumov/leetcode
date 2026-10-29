namespace LeetCode.Problems._1338_Reduce_Array_Size_to_The_Half;

/// <summary>
/// https://leetcode.com/submissions/detail/914080262/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinSetSize(int[] arr)
    {
        var result = 0;
        var itemsToRemove = arr.Length / 2;

        foreach (var count in arr.GroupBy(num => num).Select(g => g.Count()).OrderByDescending(x => x))
        {
            itemsToRemove -= count;
            result++;

            if (itemsToRemove <= 0)
            {
                break;
            }
        }

        return result;
    }
}
