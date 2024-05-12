using JetBrains.Annotations;

namespace LeetCode.Problems._0210_Course_Schedule_II;

/// <summary>
/// https://leetcode.com/submissions/detail/936109363/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        var nextCourses = Enumerable.Range(0, numCourses).Select(_ => new List<int>()).ToArray();
        var indegrees = new int[numCourses];

        foreach (var prerequisite in prerequisites)
        {
            var a = prerequisite[0];
            var b = prerequisite[1];
            nextCourses[b].Add(a);
            indegrees[a]++;
        }

        var ans = new List<int>();

        var queue = new Queue<int>();

        for (var course = 0; course < numCourses; course++)
        {
            if (indegrees[course] == 0)
            {
                queue.Enqueue(course);
            }
        }

        var processedCount = 0;

        while (queue.Count > 0)
        {
            var course = queue.Dequeue();
            ans.Add(course);

            foreach (var nextCourse in nextCourses[course])
            {
                indegrees[nextCourse]--;

                if (indegrees[nextCourse] == 0)
                {
                    queue.Enqueue(nextCourse);
                }
            }

            processedCount++;
        }

        return processedCount != numCourses ? Array.Empty<int>() : ans.ToArray();
    }
}
