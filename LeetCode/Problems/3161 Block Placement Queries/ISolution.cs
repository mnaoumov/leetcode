using JetBrains.Annotations;

namespace LeetCode.Problems._3161_Block_Placement_Queries;

[PublicAPI]
public interface ISolution
{
    public IList<bool> GetResults(int[][] queries);
}
