namespace LeetCode.Problems._1462_Course_Schedule_IV;

[PublicAPI]
public interface ISolution
{
    IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries);
}
