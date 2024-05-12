using JetBrains.Annotations;

namespace LeetCode.Problems._2466_Count_Ways_To_Build_Good_Strings;

[PublicAPI]
public interface ISolution
{
    public int CountGoodStrings(int low, int high, int zero, int one);
}
