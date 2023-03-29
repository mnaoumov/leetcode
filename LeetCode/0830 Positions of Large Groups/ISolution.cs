using JetBrains.Annotations;

namespace LeetCode._0830_Positions_of_Large_Groups;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> LargeGroupPositions(string s);
}
