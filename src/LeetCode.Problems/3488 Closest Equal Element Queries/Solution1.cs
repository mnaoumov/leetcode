namespace LeetCode.Problems._3488_Closest_Equal_Element_Queries;

/// <summary>
/// https://leetcode.com/problems/closest-equal-element-queries/submissions/1980389204/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> SolveQueries(int[] nums, int[] queries)
    {
        var indicesMap = new Dictionary<int, List<int>>();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            indicesMap.TryAdd(num, new List<int>());
            indicesMap[num].Add(i);
        }

        return queries.Select(Answer).ToArray();


        int Answer(int query)
        {
            var num = nums[query];
            var indices = indicesMap[num];

            if (indices.Count == 1)
            {
                return -1;
            }

            var indexOfIndex = indices.BinarySearch(query);
            var previousIndexOfIndex = (indexOfIndex - 1 + indices.Count) % indices.Count;
            var nextIndexOfIndex = (indexOfIndex + 1) % indices.Count;
            var previousIndex = indices[previousIndexOfIndex];
            var nextIndex = indices[nextIndexOfIndex];
            return new[]
            {
                Math.Abs(query - previousIndex),
                Math.Abs(nextIndex - query),
                nums.Length - Math.Abs(query - previousIndex),
                nums.Length - Math.Abs(nextIndex - query)
            }.Min();
        }
    }
}
