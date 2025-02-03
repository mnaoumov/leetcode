namespace LeetCode.Problems._2127_Maximum_Employees_to_Be_Invited_to_a_Meeting;

/// <summary>
/// https://leetcode.com/problems/maximum-employees-to-be-invited-to-a-meeting/submissions/1521696454/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumInvitations(int[] favorite)
    {
        var n = favorite.Length;
        var reverseAdjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        for (var i = 0; i < n; i++)
        {
            reverseAdjNodes[favorite[i]].Add(i);
        }

        var longestCycle = 0;
        var twoCycleInvitations = 0;
        var visited = new bool[n];

        for (var i = 0; i < n; i++)
        {
            if (visited[i])
            {
                continue;
            }

            var personDistanceMap = new Dictionary<int, int>();
            var currentPerson = i;
            var distance = 0;

            while (true)
            {
                if (visited[currentPerson])
                {
                    break;
                }

                visited[currentPerson] = true;
                personDistanceMap[currentPerson] = distance;
                distance++;
                var nextPerson = favorite[currentPerson];

                if (!personDistanceMap.TryGetValue(nextPerson, out var previousDistance))
                {
                    currentPerson = nextPerson;
                }
                else
                {
                    var cycleLength = distance - previousDistance;
                    longestCycle = Math.Max(longestCycle, cycleLength);

                    if (cycleLength != 2)
                    {
                        break;
                    }

                    var visitedNodes = new HashSet<int>
                    {
                        currentPerson,
                        nextPerson
                    };
                    twoCycleInvitations +=
                        2 +
                        Bfs(nextPerson, visitedNodes) +
                        Bfs(currentPerson, visitedNodes);

                    break;
                }
            }
        }

        return Math.Max(longestCycle, twoCycleInvitations);

        int Bfs(int startingPerson, HashSet<int> visitedNodes)
        {
            var queue = new Queue<(int person, int distance)>();
            queue.Enqueue((startingPerson, 0));
            var maxDistance = 0;
            while (queue.Count > 0)
            {
                var (currentPerson, currentDistance) = queue.Dequeue();

                foreach (var neighbor in reverseAdjNodes[currentPerson].Where(visitedNodes.Add))
                {
                    queue.Enqueue((neighbor, currentDistance + 1));
                    maxDistance = Math.Max(maxDistance, currentDistance + 1);
                }
            }
            return maxDistance;
        }
    }
}