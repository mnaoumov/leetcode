using JetBrains.Annotations;

namespace LeetCode._1462_Course_Schedule_IV;

[PublicAPI]
public interface ISolution
{
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries);
}
