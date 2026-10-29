namespace LeetCode.Problems._2848_Points_That_Intersect_With_Cars;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-362/submissions/detail/1045186528/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfPoints(IList<IList<int>> nums)
    {
        var set = new HashSet<int>();

        foreach (var num in nums)
        {
            for (var i = num[0]; i <= num[1]; i++)
            {
                set.Add(i);
            }
        }

        return set.Count;
    }
}
