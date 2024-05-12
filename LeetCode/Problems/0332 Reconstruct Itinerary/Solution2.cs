using JetBrains.Annotations;

namespace LeetCode._0332_Reconstruct_Itinerary;

/// <summary>
/// https://leetcode.com/submissions/detail/932166430/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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

        var departureTicketsMap = new Dictionary<string, List<Ticket>>();

        foreach (var ticket in ticketObjs)
        {
            departureTicketsMap.TryAdd(ticket.Departure, new List<Ticket>());
            departureTicketsMap[ticket.Departure].Add(ticket);
        }

        foreach (var ticketsList in departureTicketsMap.Values)
        {
            ticketsList.Sort((ticket1, ticket2) => string.Compare(ticket1.Arrival, ticket2.Arrival, StringComparison.Ordinal));
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

            if (departureTicketsMap.GetValueOrDefault(ticket.Arrival, new List<Ticket>()).Any(Dfs))
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

    private class Ticket
    {
        public string Departure { get; init; } = null!;
        public string Arrival { get; init; } = null!;
    }
}
