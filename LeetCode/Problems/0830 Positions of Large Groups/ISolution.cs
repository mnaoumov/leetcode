using JetBrains.Annotations;

namespace LeetCode.Problems._0830_Positions_of_Large_Groups;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> LargeGroupPositions(string s);
}
