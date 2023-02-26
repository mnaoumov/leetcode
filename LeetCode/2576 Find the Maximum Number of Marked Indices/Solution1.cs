using JetBrains.Annotations;

namespace LeetCode._2576_Find_the_Maximum_Number_of_Marked_Indices;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-334/submissions/detail/905027708/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxNumOfMarkedIndices(int[] nums)
    {
        var n = nums.Length;

        var list = nums.OrderBy(x => x).ToList();

        while (list.Count > 0)
        {
            var max = list[^1];
            var index = list.BinarySearch(max / 2);

            if (index < 0)
            {
                index = ~index - 1;
            }

            if (index < 0)
            {
                return n - list.Count;
            }

            list.RemoveAt(list.Count - 1);
            list.RemoveAt(index);
        }

        return n;
    }
}
