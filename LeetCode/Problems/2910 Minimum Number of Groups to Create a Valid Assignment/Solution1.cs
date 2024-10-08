namespace LeetCode.Problems._2910_Minimum_Number_of_Groups_to_Create_a_Valid_Assignment;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-368/submissions/detail/1081035041/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinGroupsForValidAssignment(int[] nums)
    {
        var sizes = nums.GroupBy(num => num).Select(g => g.Count()).OrderBy(c => c).ToArray();
        var minSize = sizes[0];
        var minSizeFound = true;
        int ans;

        do
        {
            ans = 0;

            foreach (var size in sizes)
            {
                var q = size / minSize;
                var r = size % minSize;

                if (q >= r)
                {
                    var s = (q - r) / (minSize + 1);
                    ans += q - s;
                }
                else
                {
                    minSize = Math.Min(minSize, r);
                    minSizeFound = false;
                }
            }
        } while (!minSizeFound);

        return ans;
    }
}
