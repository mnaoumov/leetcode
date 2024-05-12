using JetBrains.Annotations;

namespace LeetCode.Problems._1335_Minimum_Difficulty_of_a_Job_Schedule;

[PublicAPI]
public interface ISolution
{
    public int MinDifficulty(int[] jobDifficulty, int d);
}
