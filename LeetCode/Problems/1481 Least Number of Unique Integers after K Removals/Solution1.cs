namespace LeetCode.Problems._1481_Least_Number_of_Unique_Integers_after_K_Removals;

/// <summary>
/// https://leetcode.com/submissions/detail/914070938/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindLeastNumOfUniqueInts(int[] arr, int k)
    {
        var counts = arr.GroupBy(num => num).Select(g => g.Count()).OrderBy(x => x).ToArray();
        var result = counts.Length;

        foreach (var count in counts)
        {
            if (count > k)
            {
                break;
            }

            k -= count;
            result--;
        }

        return result;
    }
}
