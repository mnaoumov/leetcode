using JetBrains.Annotations;

namespace LeetCode._0163_Missing_Ranges;

[PublicAPI]
public interface ISolution
{
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper);
}
