using JetBrains.Annotations;

namespace LeetCode._0210_Course_Schedule_II;

[PublicAPI]
public interface ISolution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites);
}
