using JetBrains.Annotations;

namespace LeetCode._0163_Missing_Ranges;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper);
}
