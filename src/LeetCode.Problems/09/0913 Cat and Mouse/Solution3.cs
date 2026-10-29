namespace LeetCode.Problems._0913_Cat_and_Mouse;

/// <summary>
/// https://leetcode.com/submissions/detail/970759922/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int CatMouseGame(int[][] graph)
    {
        var neighborCount = new Dictionary<Entry, int>();
        var n = graph.Length;

        for (var mouse = 1; mouse < n; mouse++)
        {
            for (var cat = 1; cat < n; cat++)
            {
                neighborCount[new Entry(mouse, cat, true)] = graph[mouse].Length;
                neighborCount[new Entry(mouse, cat, false)] = graph[cat].Except(new[] { 0 }).Count();
            }
        }

        var winners = new Dictionary<Entry, Winner>();
        var queue = new Queue<Entry>();

        for (var cat = 1; cat < n; cat++)
        {
            foreach (var isMouseMove in new[] { false, true })
            {
                AddWinner(new Entry(0, cat, isMouseMove), Winner.Mouse);
                AddWinner(new Entry(cat, cat, isMouseMove), Winner.Cat);
            }
        }

        while (queue.Count > 0)
        {
            var entry = queue.Dequeue();
            var neighbors = Neighbors(entry);

            var winner = winners[entry];

            foreach (var neighbor in neighbors)
            {
                if (winners.ContainsKey(neighbor))
                {
                    continue;
                }

                var neighborWinner = neighbor.IsMouseMove ? Winner.Mouse : Winner.Cat;

                if (neighborWinner == winner)
                {
                    AddWinner(neighbor, winner);
                }
                else
                {
                    neighborCount[neighbor]--;

                    if (neighborCount[neighbor] == 0)
                    {
                        AddWinner(neighbor, winner);
                    }
                }
            }
        }

        return (int) winners.GetValueOrDefault(new Entry(1, 2, true));

        IEnumerable<Entry> Neighbors(Entry entry) =>
            !entry.IsMouseMove
                ? graph[entry.Mouse].Select(nextMouse => new Entry(nextMouse, entry.Cat, true))
                : graph[entry.Cat].Except(new[] { 0 }).Select(nextCat => new Entry(entry.Mouse, nextCat, false));

        void AddWinner(Entry entry, Winner winner)
        {
            queue.Enqueue(entry);
            winners[entry] = winner;
        }
    }

    private record Entry(int Mouse, int Cat, bool IsMouseMove);

    private enum Winner
    {
        // ReSharper disable once UnusedMember.Local
        Draw = 0,
        Mouse = 1,
        Cat = 2
    }
}
