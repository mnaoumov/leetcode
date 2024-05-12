using JetBrains.Annotations;

namespace LeetCode.Problems._0207_Course_Schedule;

[PublicAPI]
public interface ISolution
{
    public bool CanFinish(int numCourses, int[][] prerequisites);
}
