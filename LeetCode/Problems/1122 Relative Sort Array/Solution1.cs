namespace LeetCode.Problems._1122_Relative_Sort_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1285334840/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        var indexMap = arr2.Select((num, index)=>(num, index)).ToDictionary(x=>x.num, x=>x.index);
        return arr1.OrderBy(num => indexMap.TryGetValue(num, out var index) ? (0, index) : (1, num)).ToArray();
    }
}
