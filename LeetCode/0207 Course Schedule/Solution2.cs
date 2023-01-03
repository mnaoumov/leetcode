using JetBrains.Annotations;

namespace LeetCode._0207_Course_Schedule;

/// <summary>
/// https://leetcode.com/submissions/detail/870067316/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var dependencies = Enumerable.Range(0, numCourses).Select(_ => new HashSet<int>()).ToArray();

        foreach (var prerequisite in prerequisites)
        {
            dependencies[prerequisite[0]].Add(prerequisite[1]);
        }

        var coursesCanFinish = new HashSet<int>();
        var courseProcessingChain = new HashSet<int>();

        return Enumerable.Range(0, numCourses).All(CanFinishCourse);

        bool CanFinishCourse(int course)
        { 
            if (coursesCanFinish.Contains(course))
            {
                return true;
            }

            if (!courseProcessingChain.Add(course))
            {
                return false;
            }

            var result = dependencies[course].All(CanFinishCourse);
            
            courseProcessingChain.Remove(course);

            if (!result)
            {
                return result;
            }

            coursesCanFinish.Add(course);
            return true;
        }
    }


}
