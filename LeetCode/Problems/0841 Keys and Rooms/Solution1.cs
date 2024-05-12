using JetBrains.Annotations;

namespace LeetCode.Problems._0841_Keys_and_Rooms;

/// <summary>
/// https://leetcode.com/submissions/detail/862390666/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        var n = rooms.Count;
        var visited = new bool[n];

        var queue = new Queue<int>();
        queue.Enqueue(0);
        var closedRoomCount = n;

        while (queue.Count > 0)
        {
            var room = queue.Dequeue();

            if (visited[room])
            {
                continue;
            }

            visited[room] = true;
            closedRoomCount--;

            if (closedRoomCount == 0)
            {
                return true;
            }

            foreach (var key in rooms[room])
            {
                queue.Enqueue(key);
            }
        }

        return false;
    }
}
