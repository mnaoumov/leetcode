namespace LeetCode.Problems._0364_Nested_List_Weight_Sum_II;

/// <summary>
/// https://leetcode.com/problems/nested-list-weight-sum-ii/submissions/1836759259/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DepthSumInverse(IList<NestedInteger> nestedList)
    {
        var maxDepth = CalculateMaxDepth(nestedList, 0);
        return CalculateWeightedSum(nestedList, 0, maxDepth);
    }

    private static int CalculateWeightedSum(IList<NestedInteger> nestedList, int rootDepth, int maxDepth)
    {
        var ans = 0;

        foreach (var nestedInteger in nestedList)
        {
            var childDepth = rootDepth + 1;
            if (nestedInteger.IsInteger())
            {
                ans += (maxDepth - childDepth + 1) * nestedInteger.GetInteger();
            }
            else
            {
                ans += CalculateWeightedSum(nestedInteger.GetList() ?? Array.Empty<NestedInteger>(), childDepth,
                    maxDepth);
            }
        }

        return ans;
    }

    private static int CalculateMaxDepth(IList<NestedInteger> nestedList, int rootDepth)
    {
        while (true)
        {
            if (nestedList.Count == 0)
            {
                return rootDepth;
            }

            nestedList = nestedList.SelectMany(nestedInteger => nestedInteger.GetList() ?? Array.Empty<NestedInteger>())
                .ToArray();
            rootDepth++;
        }
    }
}
