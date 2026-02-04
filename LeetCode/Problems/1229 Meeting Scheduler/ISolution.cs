namespace LeetCode.Problems._1229_Meeting_Scheduler;

[PublicAPI]
public interface ISolution
{
    IList<int> MinAvailableDuration(int[][] slots1, int[][] slots2, int duration);
}
