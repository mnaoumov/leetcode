using JetBrains.Annotations;

namespace LeetCode.Problems._0797_All_Paths_From_Source_to_Target;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph);
}
