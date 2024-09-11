using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0332_Reconstruct_Itinerary;

/// <summary>
/// https://leetcode.com/submissions/detail/932161395/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        var ticketObjs = tickets
            .Select(ticket => new Ticket
            {
                Departure = ticket[0],
                Arrival = ticket[1]
            })
            .ToArray();

        var departureTicketsMap = new Dictionary<string, SortedSet<Ticket>>();

        foreach (var ticket in ticketObjs)
        {
            departureTicketsMap.TryAdd(ticket.Departure, new SortedSet<Ticket>());
            departureTicketsMap[ticket.Departure].Add(ticket);
        }

        var result = new List<string>();
        var seen = new HashSet<Ticket>();

        const string startingCity = "JFK";

        Dfs(new Ticket
        {
            Departure = "",
            Arrival = startingCity
        });

        return result;

        bool Dfs(Ticket ticket)
        {
            if (!seen.Add(ticket))
            {
                return false;
            }

            result.Add(ticket.Arrival);

            if (departureTicketsMap.GetValueOrDefault(ticket.Arrival, new SortedSet<Ticket>()).Any(Dfs))
            {
                return true;
            }

            if (seen.Count == tickets.Count + 1)
            {
                return true;
            }

            result.RemoveAt(result.Count - 1);
            seen.Remove(ticket);
            return false;
        }
    }

    private class Ticket : IComparable<Ticket>
    {
        public string Departure { get; init; } = null!;
        public string Arrival { get; init; } = null!;

        public int CompareTo(Ticket? other) =>
            other == null ? 1 : string.Compare(Arrival, other.Arrival, StringComparison.Ordinal);
    }
}
