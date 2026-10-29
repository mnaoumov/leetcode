namespace LeetCode.Problems._0886_Possible_Bipartition;

/// <summary>
/// https://leetcode.com/submissions/detail/863050520/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool PossibleBipartition(int n, int[][] dislikes)
    {
        var neighbors = new Dictionary<int, List<int>>();

        foreach (var dislike in dislikes)
        {
            AddNeighbor(dislike[0], dislike[1]);
            AddNeighbor(dislike[1], dislike[0]);
            continue;

            void AddNeighbor(int a, int b)
            {
                if (!neighbors.ContainsKey(a))
                {
                    neighbors[a] = new List<int>();
                }

                neighbors[a].Add(b);
            }
        }

        var peopleGroupMap = new Dictionary<int, int>();

        for (var person = 1; person <= n; person++)
        {
            if (peopleGroupMap.ContainsKey(person))
            {
                continue;
            }

            var queue = new Queue<(int person, int group)>();
            queue.Enqueue((person, 1));

            while (queue.Count > 0)
            {
                var (queuedPerson, queuedPersonGroup) = queue.Dequeue();

                if (peopleGroupMap.TryGetValue(queuedPerson, out var actualGroup))
                {
                    if (actualGroup != queuedPersonGroup)
                    {
                        return false;
                    }

                    continue;
                }

                peopleGroupMap[queuedPerson] = queuedPersonGroup;

                var neighborGroup = queuedPersonGroup == 1 ? 2 : 1;

                foreach (var neighbor in neighbors.GetValueOrDefault(queuedPerson) ?? new List<int>())
                {
                    queue.Enqueue((neighbor, neighborGroup));
                }
            }
        }

        return true;
    }
}
