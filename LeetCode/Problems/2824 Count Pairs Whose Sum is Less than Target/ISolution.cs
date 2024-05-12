using JetBrains.Annotations;

namespace LeetCode._2824_Count_Pairs_Whose_Sum_is_Less_than_Target;

[PublicAPI]
public interface ISolution
{
    public int CountPairs(IList<int> nums, int target);
}
