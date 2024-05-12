using JetBrains.Annotations;

namespace LeetCode._1834_Single_Threaded_CPU;

[PublicAPI]
public interface ISolution
{
    public int[] GetOrder(int[][] tasks);
}
