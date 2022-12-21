using JetBrains.Annotations;

namespace LeetCode._0841_Keys_and_Rooms;

[PublicAPI]
public interface ISolution
{
    public bool CanVisitAllRooms(IList<IList<int>> rooms);
}
