namespace LeetCode.Problems._3447_Assign_Elements_to_Groups_with_Constraints;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-436/problems/assign-elements-to-groups-with-constraints/submissions/1536421460/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] AssignElements(int[] groups, int[] elements)
    {
        var n = groups.Length;
        var ans = new int[n];
        var groupSizeIndexMap = new Dictionary<int, int>();

        for (var groupIndex = 0; groupIndex < n; groupIndex++)
        {
            var groupSize = groups[groupIndex];

            if (groupSizeIndexMap.TryGetValue(groupSize, out var previousGroupIndex))
            {
                ans[groupIndex] = ans[previousGroupIndex];
                continue;
            }

            groupSizeIndexMap[groupSize] = groupIndex;
            ans[groupIndex] = -1;

            for (var elementIndex = 0; elementIndex < elements.Length; elementIndex++)
            {
                var element = elements[elementIndex];

                if (groupSize % element != 0)
                {
                    continue;
                }

                ans[groupIndex] = elementIndex;
                break;
            }
        }

        return ans;
    }
}
