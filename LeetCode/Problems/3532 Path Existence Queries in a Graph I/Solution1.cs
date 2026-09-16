namespace LeetCode.Problems._3532_Path_Existence_Queries_in_a_Graph_I;

/// <summary>
/// https://leetcode.com/problems/path-existence-queries-in-a-graph-i/submissions/2062237736/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries)
    {
        nums = nums.Distinct().ToArray();

        return queries.Select(arr => Answer(arr[0], arr[1])).ToArray();

        bool Answer(int u, int v)
        {
            if (u == v)
            {
                return true;
            }

            if (u > v)
            {
                return Answer(v, u);
            }

            var reachable = nums[u];

            while (reachable < nums[v])
            {
                var index = nums.BinarySearch(reachable + maxDiff);

                if (index < 0)
                {
                    index = ~index - 1;
                }

                var nextReachable = nums[index];

                if (nextReachable == reachable)
                {
                    return false;
                }

                reachable = nextReachable;
            }

            return true;
        }
    }
}
