namespace LeetCode.Problems._3834_Merge_Adjacent_Equal_Elements;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-488/problems/merge-adjacent-equal-elements/submissions/1911907802/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public IList<long> MergeAdjacent(int[] nums)
    {
        var list = nums.Select(num => (long) num).ToList();

        var i = 0;

        while (i < list.Count - 1)
        {
            if (list[i] == list[i + 1])
            {
                list[i] *= 2;
                list.RemoveAt(i + 1);

                if (i > 0)
                {
                    i--;
                }
            }
            else
            {
                i++;
            }
        }

        return list;
    }
}
