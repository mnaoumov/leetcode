using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable
#pragma warning disable CA1822

namespace LeetCode.Problems._0207_Course_Schedule;

/// <summary>
/// https://leetcode.com/submissions/detail/197124777/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanFinish(int numCourses, int[][] prerequisites) => CanFinish(numCourses, ArrayHelper.ArrayOfArraysTo2D(prerequisites));

    public bool CanFinish(int numCourses, int[,] prerequisites)
    {
        var dependencies = new HashSet<int>[numCourses];

        for (int course = 0; course < numCourses; course++)
        {
            dependencies[course] = new HashSet<int>();
        }

        for (int i = 0; i < prerequisites.GetLength(0); i++)
        {
            dependencies[prerequisites[i, 0]].Add(prerequisites[i, 1]);
        }

        for (int course = 0; course < numCourses; course++)
        {
            var dependencyChain = new HashSet<int> { course };
            int courseToCheck = course;

            while (dependencies[courseToCheck].Any())
            {
                int dependency = dependencies[courseToCheck].First();
                if (dependencyChain.Contains(dependency))
                {
                    return false;
                }

                dependencies[courseToCheck].Remove(dependency);
                dependencyChain.Add(dependency);
                courseToCheck = dependency;
            }
        }

        return true;
    }
}
