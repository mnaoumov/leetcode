using JetBrains.Annotations;

namespace LeetCode._1272_Remove_Interval;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved);
}
