using JetBrains.Annotations;

namespace LeetCode.Problems._3091_Apply_Operations_to_Make_Sum_of_Array_Greater_Than_or_Equal_to_k;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-390/submissions/detail/1212144619/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int k)
    {
        var increaseCount1 = (int) Math.Floor(Math.Sqrt(k)) - 1;
        var increaseCount2 = (int) Math.Ceiling(Math.Sqrt(k)) - 1;
        var duplicateCount1 = (int) Math.Ceiling((double) k / (increaseCount1 + 1)) - 1;
        var duplicateCount2 = (int) Math.Ceiling((double) k / (increaseCount2 + 1)) - 1;
        return Math.Min(increaseCount1 + duplicateCount1, increaseCount2 + duplicateCount2);
    }
}
