using JetBrains.Annotations;

namespace LeetCode._0315_Count_of_Smaller_Numbers_After_Self;

[PublicAPI]
public interface ISolution
{
    public IList<int> CountSmaller(int[] nums);
}
