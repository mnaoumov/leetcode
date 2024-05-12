using JetBrains.Annotations;

namespace LeetCode.Problems._2391_Minimum_Amount_of_Time_to_Collect_Garbage;

[PublicAPI]
public interface ISolution
{
    public int GarbageCollection(string[] garbage, int[] travel);
}
