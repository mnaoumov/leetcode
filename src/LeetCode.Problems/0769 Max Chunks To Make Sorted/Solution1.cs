namespace LeetCode.Problems._0769_Max_Chunks_To_Make_Sorted;

/// <summary>
/// https://leetcode.com/submissions/detail/1482506975/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxChunksToSorted(int[] arr)
    {
        var ans = 0;
        var min = int.MaxValue;
        var max = int.MinValue;
        var next = 0;
        var count = 0;

        foreach (var num in arr)
        {
            min = Math.Min(min, num);
            max = Math.Max(max, num);
            count++;

            if (min != next || max - min + 1 != count)
            {
                continue;
            }

            ans++;
            next = max + 1;
            count = 0;
            min = int.MaxValue;
            max = int.MinValue;
        }

        return ans;
    }
}
