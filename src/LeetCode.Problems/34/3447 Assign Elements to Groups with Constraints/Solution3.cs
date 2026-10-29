namespace LeetCode.Problems._3447_Assign_Elements_to_Groups_with_Constraints;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution3 : ISolution
{
    public int[] AssignElements(int[] groups, int[] elements)
    {
        var n = groups.Length;
        var ans = Enumerable.Repeat(-1, n).ToArray();
        var unassignedGroupIndices = Enumerable.Range(0, n).ToHashSet();
        var usedElements = new HashSet<int>();

        for (var elementIndex = 0; elementIndex < elements.Length; elementIndex++)
        {
            var element = elements[elementIndex];
            if (!usedElements.Add(element))
            {
                continue;
            }

            foreach (var groupIndex in from groupIndex in unassignedGroupIndices let groupSize = groups[groupIndex] where groupSize % element == 0 select groupIndex)
            {
                ans[groupIndex] = elementIndex;
                unassignedGroupIndices.Remove(groupIndex);
            }
        }

        return ans;
    }
}
