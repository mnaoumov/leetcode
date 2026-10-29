namespace LeetCode.Problems._2161_Partition_Array_According_to_Given_Pivot;

/// <summary>
/// https://leetcode.com/problems/partition-array-according-to-given-pivot/submissions/1560919893/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        var smallerThanPivot = new List<int>();
        var equalToPivot = new List<int>();
        var greaterThanPivot = new List<int>();

        foreach (var num in nums)
        {
            var list = num.CompareTo(pivot) switch
            {
                < 0 => smallerThanPivot,
                > 0 => greaterThanPivot,
                _ => equalToPivot
            };

            list.Add(num);
        }

        return smallerThanPivot.Concat(equalToPivot).Concat(greaterThanPivot).ToArray();
    }
}
