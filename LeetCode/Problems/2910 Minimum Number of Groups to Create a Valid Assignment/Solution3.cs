using JetBrains.Annotations;

namespace LeetCode._2910_Minimum_Number_of_Groups_to_Create_a_Valid_Assignment;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-368/submissions/detail/1081047035/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int MinGroupsForValidAssignment(int[] nums)
    {
        var sizes = nums.GroupBy(num => num).Select(g => g.Count()).OrderBy(c => c).ToArray();
        return Math.Min(CountGroups(sizes[0]), CountGroups(sizes[0] - 1));

        int CountGroups(int minSize)
        {
            if (minSize == 0)
            {
                return int.MaxValue;
            }

            bool minSizeFound;
            int groupsCount;

            do
            {
                groupsCount = 0;
                minSizeFound = true;

                foreach (var size in sizes)
                {
                    var q = size / minSize;
                    var r = size % minSize;

                    if (q >= r)
                    {
                        var s = (q - r) / (minSize + 1);
                        groupsCount += q - s;
                    }
                    else
                    {
                        minSize = Math.Min(minSize, r);
                        minSizeFound = false;
                    }
                }
            } while (!minSizeFound);

            return groupsCount;
        }
    }
}
