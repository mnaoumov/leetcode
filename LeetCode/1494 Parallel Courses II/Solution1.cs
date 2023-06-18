using JetBrains.Annotations;

namespace LeetCode._1494_Parallel_Courses_II;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinNumberOfSemesters(int n, int[][] relations, int k)
    {
        var indegrees = new int[n + 1];
        var nextCourses = new List<int>[n + 1];

        foreach (var relation in relations)
        {
            nextCourses[relation[0]].Add(relation[1]);
            indegrees[relation[1]]++;
        }



        throw new NotImplementedException();
    }
}
